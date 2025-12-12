using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using BMPTrains_2020;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020.Tools
{
    public static class ReportGenerator
    {
        // Existing general-purpose API may already exist; add focused overloads below.

        // Overload: object + title + property name list (string[])
        public static string GenerateHtmlReport(object obj, string title, string[] propertyNames)
        {
            return GenerateHtmlReport(obj, title, (IEnumerable<string>)propertyNames);
        }

        // New overload: object + title + property name list (IEnumerable<string>)
        // Uses Meta attributes for label/units/places and XmlPropertyObject.GetValue(...) when available.
        public static string GenerateHtmlReport(object obj, string title, IEnumerable<string> propertyNames)
        {
            if (obj == null) return "<i>null</i>";
            if (propertyNames == null) return GenerateHtmlReport(obj, title);

            var sb = new StringBuilder();
            var t = obj.GetType();

            sb.AppendLine($"<h3>{WebUtility.HtmlEncode(title ?? t.Name)}</h3>");
            sb.AppendLine("<table style='border-collapse:collapse;'>");

            // Try to cast to XmlPropertyObject for consistent formatting
            var xpo = obj as XmlPropertyObject;

            foreach (var propName in propertyNames)
            {
                if (string.IsNullOrWhiteSpace(propName)) continue;

                var pi = t.GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
                if (pi == null) continue;

                // Get Meta attribute if present
                var meta = pi.GetCustomAttribute<Meta>();
                string label = meta?.ReportLabel ?? meta?.Description ?? propName;
                string units = meta?.Units ?? string.Empty;
                int places = meta?.Places ?? (xpo != null ? xpo.PropertyDecimalPlaces(propName) : 2);

                string value = string.Empty;

                try
                {
                    if (xpo != null)
                    {
                        // Use XmlPropertyObject formatting where possible (preserves legacy behavior)
                        if (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(float) ||
                            pi.PropertyType == typeof(System.Single) || pi.PropertyType == typeof(System.Double))
                        {
                            value = xpo.GetValue(pi, places);
                        }
                        else
                        {
                            // fallback to property-name based GetValue that returns string
                            value = xpo.GetValue(propName);
                        }
                    }
                    else
                    {
                        var raw = pi.GetValue(obj);
                        if (raw == null) value = string.Empty;
                        else if (raw is IFormattable f)
                        {
                            // attempt to honor Meta.Format if present
                            try
                            {
                                value = f.ToString(meta?.Format, System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                value = f.ToString(null, System.Globalization.CultureInfo.InvariantCulture);
                            }
                        }
                        else
                        {
                            value = raw.ToString();
                        }
                    }
                }
                catch
                {
                    value = string.Empty;
                }

                // append units if present
                if (!string.IsNullOrWhiteSpace(units) && !string.IsNullOrWhiteSpace(value))
                {
                    value = value + " " + units;
                }
                else if (!string.IsNullOrWhiteSpace(units) && string.IsNullOrWhiteSpace(value))
                {
                    value = "(" + units + ")";
                }

                sb.AppendLine("<tr>");
                sb.AppendLine($"  <td style='padding:4px 8px;border:1px solid #ddd;vertical-align:top'><strong>{WebUtility.HtmlEncode(label)}</strong></td>");
                sb.AppendLine($"  <td style='padding:4px 8px;border:1px solid #ddd'>{WebUtility.HtmlEncode(value)}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");
            return sb.ToString();
        }

        // Fallback / existing generic generator: enumerate Meta-tagged properties
        public static string GenerateHtmlReport(object obj, string title = null)
        {
            if (obj == null) return "<i>null</i>";
            var sb = new StringBuilder();
            var t = obj.GetType();
            sb.AppendLine($"<h3>{WebUtility.HtmlEncode(title ?? t.Name)}</h3>");
            sb.AppendLine("<table style='border-collapse:collapse;'>");

            var xpo = obj as XmlPropertyObject;

            foreach (var pi in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var meta = pi.GetCustomAttribute<Meta>();
                if (meta == null) continue; // only print Meta-tagged props by default

                string label = meta.ReportLabel ?? meta.Description ?? pi.Name;
                string units = meta.Units ?? string.Empty;
                int places = meta.Places;

                string value;
                try
                {
                    if (xpo != null && (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(float)))
                        value = xpo.GetValue(pi, places);
                    else if (xpo != null)
                        value = xpo.GetValue(pi.Name);
                    else
                    {
                        var raw = pi.GetValue(obj);
                        value = raw == null ? string.Empty : raw.ToString();
                    }
                }
                catch
                {
                    value = string.Empty;
                }

                if (!string.IsNullOrWhiteSpace(units) && !string.IsNullOrWhiteSpace(value))
                    value = value + " " + units;
                else if (!string.IsNullOrWhiteSpace(units) && string.IsNullOrWhiteSpace(value))
                    value = "(" + units + ")";

                sb.AppendLine("<tr>");
                sb.AppendLine($"  <td style='padding:4px 8px;border:1px solid #ddd;vertical-align:top'><strong>{WebUtility.HtmlEncode(label)}</strong></td>");
                sb.AppendLine($"  <td style='padding:4px 8px;border:1px solid #ddd'>{WebUtility.HtmlEncode(value)}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");
            return sb.ToString();
        }
    }
}
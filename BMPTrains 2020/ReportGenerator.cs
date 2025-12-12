using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using BMPTrains_2020;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020.Tools
{
    public static class ReportGenerator
    {
        // Generate HTML for an object. If propertyNames is null we'll use all public properties with [Meta].
        public static string GenerateHtmlReport(object obj, string title = null, string[] propertyNames = null)
        {
            if (obj == null) return "<i>null</i>";
            var sb = new StringBuilder();
            sb.AppendLine($"<h2>{(title ?? obj.GetType().Name)} Report</h2>");
            sb.AppendLine("<table style='border-collapse:collapse;'>");

            var type = obj.GetType();
            PropertyInfo[] props;
            if (propertyNames != null && propertyNames.Length > 0)
            {
                props = propertyNames.Select(n => type.GetProperty(n)).Where(p => p != null).ToArray();
            }
            else
            {
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }

            foreach (var pi in props)
            {
                var meta = pi.GetCustomAttribute<Meta>();
                // Skip properties without Meta by default - this keeps legacy reporting tight.
                if (meta == null) continue;

                string label = string.IsNullOrWhiteSpace(meta.ReportLabel) ? pi.Name : meta.ReportLabel;
                string units = string.IsNullOrWhiteSpace(meta.Units) ? "" : $" {meta.Units}";

                string val = FormatPropertyValue(obj, pi, meta);
                sb.AppendLine($"<tr><td style='padding:4px 8px;border:1px solid #ddd;vertical-align:top'><b>{label}</b></td><td style='padding:4px 8px;border:1px solid #ddd'>{val}{units}</td></tr>");
            }

            sb.AppendLine("</table>");
            return sb.ToString();
        }

        private static string FormatPropertyValue(object owner, PropertyInfo pi, Meta meta)
        {
            try
            {
                object raw = pi.GetValue(owner);
                if (raw == null) return "";

                // If owner supports XmlPropertyObject use its GetValue formatting (keeps behavior consistent)
                if (owner is XmlPropertyObject xpo)
                {
                    try
                    {
                        return xpo.GetValue(pi, meta.Places) ?? "";
                    }
                    catch
                    {
                        // fallback to manual formatting
                    }
                }

                return FormatValue(raw, meta);
            }
            catch (Exception ex)
            {
                return $"<i>error: {ex.Message}</i>";
            }
        }

        private static string FormatValue(object value, Meta meta)
        {
            // Strings and primitives
            if (value is string s) return System.Net.WebUtility.HtmlEncode(s);
            if (value is IFormattable form && !(value is IEnumerable)) // numbers, DateTime
            {
                // try using Meta.Format if it's a numeric format
                try
                {
                    return form.ToString(meta.Format, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    return form.ToString(null, System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            // Collections (except string)
            if (value is IEnumerable en)
            {
                var sb = new StringBuilder();
                sb.AppendLine("<table style='border-collapse:collapse;'>");
                int index = 0;
                foreach (var item in en)
                {
                    if (item == null) continue;
                    // For simple scalars
                    if (item is string || item is ValueType)
                    {
                        sb.AppendLine($"<tr><td style='padding:2px;border:1px solid #eee'>{System.Net.WebUtility.HtmlEncode(item.ToString())}</td></tr>");
                    }
                    else
                    {
                        // Nested object -> recursive report (compact)
                        var nested = GenerateHtmlReport(item, item.GetType().Name);
                        sb.AppendLine($"<tr><td style='padding:4px;border:1px solid #eee'>{nested}</td></tr>");
                    }

                    index++;
                    if (index > 200) { sb.AppendLine("<tr><td>...truncated...</td></tr>"); break; }
                }
                sb.AppendLine("</table>");
                return sb.ToString();
            }

            // Complex object -> recursive report
            return GenerateHtmlReport(value, value.GetType().Name);
        }
    }
}
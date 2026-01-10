using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public static class BMPTrainsReports
    {

        public static string TableStyle1 =  "<style>"
            + ".my-table { border: 1px solid #cfcfcf; border-collapse: separate; border-spacing: 0; width:100%; }"
            + ".my-table td { padding: 6px 8px; vertical-align: top; }"
            + ".my-table tr { border-bottom: 1px solid #e6e6e6; }"
            + ".my-table tr:nth-child(even) { background-color: #fafafa; }"
            + ".my-table thead th { background: linear-gradient(#e6f2ff, #d9ecff); font-weight: 700; color: #0b5394; padding: 8px 10px; border-bottom: 2px solid #c0daf5; text-align: left; }"
            + "</style>";

        // CSS used for load/flow diagrams (moved here so other renderers can reuse it)
        // Updated: use larger, dark-blue Unicode arrows (no SVG) for better sizing/printing in WebBrowser.
        public static string LoadReportStyle1 =
    "<style>" +
    ".load-diagram { border-collapse: collapse; width:100%; font-family: Arial, sans-serif; }" +
    ".load-diagram td { padding: 10px; vertical-align: middle; }" +
    ".ld-border { border: 2px solid #333; padding: 10px; }" +
    ".ld-arrow { text-align: center; color: #0b5394; font-weight: 700; width: 72px; }" +
    ".ld-arrow .glyph { color: #0b5394; font-size: 28px; line-height: 1; display: inline-block; }" +
    ".ld-arrow .tail { color: #0b5394; font-size: 20px; margin-right:4px; display:inline-block; vertical-align:middle; }" +
    ".ld-arrow .box { display:inline-block; vertical-align: middle; }" +
    "</style>";

        /// <summary>
        /// Render a compact arrow using Unicode characters (no SVG) to improve sizing/printing.
        /// dir: "right" or "down"
        /// width/height parameters are accepted for compatibility but ignored (kept in signature).
        /// color - hex color for inline fallback (kept for compatibility).
        /// Returns a complete TD string containing a larger, dark-blue arrow with a tail and a head.
        /// </summary>
        public static string RenderArrow(string dir = "right", int width = 72, int height = 28, string color = "#0b5394")
        {
            dir = (dir ?? "right").ToLowerInvariant();

            if (dir == "down")
            {
                // Vertical tail (two short vertical bars) + head (down arrow)
                // Use simple characters to ensure consistent printing from WebBrowser.
                string headDown = $"<span class='glyph' style='color:{color};'>&darr;</span>"; // ↓
                return $"<td class='ld-arrow' title='Flow down' aria-label='Flow down'><div class='box' style='text-align:center;'>{headDown}</div></td>";
            }

            // Right arrow: short repeated dashes (tail) + large arrowhead
            string head = $"<span class='glyph' style='color:{color};'>&rarr;</span>"; // →
            return $"<td class='ld-arrow' title='Flow right' aria-label='Flow right'><div class='box'>{head}</div></td>";
        }

        public static string MasterReportHeader(string reportText, string reportTitle = "")
        {
            // Project/file/user metadata (safe-escaped)
            string projectName = System.Security.SecurityElement.Escape(BMPTrains_2020.Globals.Project?.ProjectName ?? "");
            string fileNameRaw = BMPTrains_2020.Globals.Project?.FileName ?? "";
            string fileName = string.IsNullOrWhiteSpace(fileNameRaw) ? "" : System.IO.Path.GetFileName(fileNameRaw);
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string generatedBy = BMPTrains_2020.Globals.IsValidatedUser ? System.Security.SecurityElement.Escape(BMPTrains_2020.Globals.UserEmail) : "Unregistered User";

            // Header CSS (keeps styling consistent with other reports)
            var headerCss = new StringBuilder();
            headerCss.AppendLine("<style>");
            headerCss.AppendLine(".report-header { border:1px solid #dbe9f7; background: linear-gradient(#f7fbff,#eaf6ff); padding:12px; border-radius:6px; display:flex; justify-content:space-between; align-items:center; margin-bottom:12px; font-family: Arial, sans-serif; }");
            headerCss.AppendLine(".report-left { max-width:70%; }");
            headerCss.AppendLine(".report-title { font-size:1.25em; font-weight:700; color:#0b5394; }");
            headerCss.AppendLine(".report-sub { font-size:0.95em; color:#23475a; margin-top:4px; }");
            headerCss.AppendLine(".report-meta { text-align:right; font-size:0.95em; color:#333; }");
            headerCss.AppendLine(".report-meta div { margin-bottom:4px; }");
            headerCss.AppendLine(".report-body { font-family: Arial, sans-serif; font-size: 13px; color:#222; }");
            headerCss.AppendLine("</style>");

            // Build header HTML (use provided reportTitle when present)
            string headerHtml;
            if (string.IsNullOrWhiteSpace(reportTitle))
            {
                var left = new StringBuilder();
                left.AppendLine($"<div class='report-left'>");
                left.AppendLine($"  <div class='report-title'>Project: {projectName}</div>");
                if (!string.IsNullOrWhiteSpace(fileName))
                    left.AppendLine($"  <div class='report-sub'>File: {System.Security.SecurityElement.Escape(fileName)}</div>");
                left.AppendLine("</div>");

                var right = new StringBuilder();
                right.AppendLine("<div class='report-meta'>");
                right.AppendLine($"  <div><strong>Date:</strong> {date}</div>");
                right.AppendLine($"  <div><strong>Generated by:</strong> {generatedBy}</div>");
                right.AppendLine("</div>");

                headerHtml = $"<div class='report-header'>{left}{right}</div>";
            }
            else
            {
                // If caller provides a custom title/header, include it but keep the same wrapper styling
                headerHtml = $"<div class='report-header'><div class='report-left'><div class='report-title'>{System.Security.SecurityElement.Escape(reportTitle)}</div></div><div class='report-meta'><div><strong>Date:</strong> {date}</div><div><strong>Generated by:</strong> {generatedBy}</div></div></div>";
            }

            // Compose final HTML
            var html = new StringBuilder();
            html.AppendLine("<html><head><meta http-equiv='X-UA-Compatible' content='IE=Edge'></head><body>");
            html.AppendLine(headerCss.ToString());
            html.AppendLine(headerHtml);
            html.AppendLine($"<div class='report-body'>{reportText}</div>");
            html.AppendLine("</body></html>");

            return html.ToString();
        }

        // Produce the Retention-in-Series report using values stored on CatchmentRouting.
        // Ensures the series calculation has been run and then reads routing properties.
        public static string RetentionInSeriesHtml(BMPTrainsProject project)
        {
            if (project == null) return string.Empty;

            // Ensure routing properties are populated
            CatchmentRouting.CalculateRetentionInSeries(project);

            var order = project.GetRoutingInOrder();
            var sb = new StringBuilder();

            // Basic CSS
            sb.AppendLine("<style>");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; font-size: 14px; }");
            sb.AppendLine("th { background-color: #4CAF50; color: white; padding: 8px; text-align: left; }");
            sb.AppendLine("td { border: 1px solid #ddd; padding: 6px; }");
            sb.AppendLine(".num { text-align: right; }");
            sb.AppendLine(".breakdown { font-size: 0.85em; color: #555; }");
            sb.AppendLine("</style>");

            // Volume table
            sb.AppendLine("<h3>Retention In Series - Volumes</h3>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead><tr>");
            sb.AppendLine("<th>ID</th><th class='num'>Area (ac)</th><th class='num'>Vol (ac-ft)</th><th class='num'>Cum. Vol</th><th class='num'>System TD (in)</th><th>TD Allocation</th><th class='num'>TN Load</th><th class='num'>TP Load</th>");
            sb.AppendLine("</tr></thead>");
            sb.AppendLine("<tbody>");

            if (order != null)
            {
                foreach (var id in order)
                {
                    var c = project.getCatchment(id);
                    if (c == null) continue;
                    var r = c.getRouting();
                    if (r == null) continue;

                    string breakdownHtml;
                    if (!string.IsNullOrWhiteSpace(r.TDAllocationBreakdown))
                    {
                        // stored breakdown assumed to be formatted HTML - render as-is
                        breakdownHtml = r.TDAllocationBreakdown;
                    }
                    else
                    {
                        // synthesize allocation string (contains only numeric IDs and formatting tags)
                        breakdownHtml = BuildTDAllocationString(project, order, id);
                    }

                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{id}</td>");
                    sb.AppendLine($"<td class='num'>{c.PostArea:F2}</td>");
                    sb.AppendLine($"<td class='num'>{r.RetentionVolume:F2}</td>");
                    sb.AppendLine($"<td class='num'>{r.CumulativeRetentionVolume:F2}</td>");
                    sb.AppendLine($"<td class='num'><strong>{r.SystemTreatmentDepth:F4}</strong></td>");
                    sb.AppendLine($"<td class='breakdown'>{breakdownHtml}</td>");
                    sb.AppendLine($"<td class='num'>{c.PostNLoading:F2}</td>");
                    sb.AppendLine($"<td class='num'>{c.PostPLoading:F2}</td>");
                    sb.AppendLine("</tr>");
                }
            }

            sb.AppendLine("</tbody></table>");

            // Effectiveness table
            sb.AppendLine("<h3>Retention In Series - Effectiveness</h3>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead><tr>");
            sb.AppendLine("<th>ID</th><th class='num'>System TD (in)</th><th class='num'>Efficiency (%)</th><th class='num'>TN Load (kg/yr)</th><th class='num'>TN Removed</th><th class='num'>TP Load (kg/yr)</th><th class='num'>TP Removed</th>");
            sb.AppendLine("</tr></thead>");
            sb.AppendLine("<tbody>");

            double totalTNLoad = 0, totalTPLoad = 0, totalTNRemoved = 0, totalTPRemoved = 0;

            if (order != null)
            {
                foreach (var id in order)
                {
                    var c = project.getCatchment(id);
                    if (c == null) continue;
                    var r = c.getRouting();
                    if (r == null) continue;

                    double eff = r.SeriesTNEfficiency;
                    double tnRem = r.TNRemovedSeries;
                    double tpRem = r.TPRemovedSeries;

                    totalTNLoad += c.PostNLoading;
                    totalTPLoad += c.PostPLoading;
                    totalTNRemoved += tnRem;
                    totalTPRemoved += tpRem;

                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{id}</td>");
                    sb.AppendLine($"<td class='num'>{r.SystemTreatmentDepth:F4}</td>");
                    sb.AppendLine($"<td class='num'>{eff:F1}%</td>");
                    sb.AppendLine($"<td class='num'>{c.PostNLoading:F2}</td>");
                    sb.AppendLine($"<td class='num'>{tnRem:F2}</td>");
                    sb.AppendLine($"<td class='num'>{c.PostPLoading:F2}</td>");
                    sb.AppendLine($"<td class='num'>{tpRem:F2}</td>");
                    sb.AppendLine("</tr>");
                }

                // totals
                sb.AppendLine("<tr style='font-weight:bold;background:#eaf2ff;'>");
                sb.AppendLine("<td>TOTALS</td><td></td><td></td>");
                sb.AppendLine($"<td class='num'>{totalTNLoad:F2}</td><td class='num'>{totalTNRemoved:F2}</td>");
                sb.AppendLine($"<td class='num'>{totalTPLoad:F2}</td><td class='num'>{totalTPRemoved:F2}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</tbody></table>");

            // Comparison block (cumulative vs multiplicative series)
            double cumulativeMethodEfficiency = (totalTNLoad > 0) ? (totalTNRemoved / totalTNLoad) : 0.0;
            double inverseSeriesE = 1.0;
            if (order != null)
            {
                foreach (var id in order)
                {
                    var r = project.getCatchment(id)?.getRouting();
                    if (r == null) continue;
                    inverseSeriesE *= (1.0 - r.SeriesTNEfficiency / 100.0);
                }
            }
            double seriesEfficiency = 1.0 - inverseSeriesE;

            sb.AppendLine("<div style='margin-top:12px;font-size:0.9em;color:#333'>");
            sb.AppendLine($"<strong>Comparison:</strong><br/>Cumulative method: <strong>{cumulativeMethodEfficiency:P2}</strong><br/>Multiplicative series (1 - Π(1-Ei)): <strong>{seriesEfficiency:P2}</strong>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }

        // Add DetentionInSeriesHtml to BMPTrainsReports
        public static string DetentionInSeriesHtml(BMPTrainsProject project)
        {
            if (project == null) return string.Empty;

            // Ensure detention-series values are populated
            CatchmentRouting.CalculateDetentionInSeries(project);

            var order = project.GetRoutingInOrder();
            var sb = new StringBuilder();

            sb.AppendLine("<style>");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; font-size: 14px; }");
            sb.AppendLine("th { background-color: #00796B; color: white; padding: 8px; text-align: left; }");
            sb.AppendLine("td { border: 1px solid #ddd; padding: 6px; }");
            sb.AppendLine(".num { text-align: right; }");
            sb.AppendLine(".breakdown { font-size: 0.85em; color: #555; }");
            sb.AppendLine("</style>");

            sb.AppendLine("<h3>Detention In Series - ART &amp; Effectiveness</h3>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead><tr>");
            sb.AppendLine("<th>ID</th><th class='num'>Perm. Pool (ac-ft)</th><th class='num'>Runoff (ac-ft/yr)</th><th class='num'>Series ART (days)</th><th class='num'>Total ART (days)</th><th>ART Allocation</th><th class='num'>TN Eff (%)</th><th class='num'>TN Removed</th><th class='num'>TP Eff (%)</th><th class='num'>TP Removed</th>");
            sb.AppendLine("</tr></thead>");
            sb.AppendLine("<tbody>");

            double totalTNLoad = 0.0, totalTPLoad = 0.0, totalTNRemoved = 0.0, totalTPRemoved = 0.0, totalRunoff = 0.0;

            if (order != null)
            {
                foreach (var id in order)
                {
                    var c = project.getCatchment(id);
                    if (c == null) continue;
                    var r = c.getRouting();
                    if (r == null) continue;

                    double permPool = 0.0, runoff = 0.0;
                    try { permPool = c.getWetDetention().PermanentPoolVolume; } catch { permPool = 0.0; }
                    try { runoff = c.getWetDetention().RunoffVolume; } catch { runoff = 0.0; }

                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{id}</td>");
                    sb.AppendLine($"<td class='num'>{permPool:F2}</td>");
                    sb.AppendLine($"<td class='num'>{runoff:F2}</td>");
                    sb.AppendLine($"<td class='num'>{r.SeriesART:F2}</td>");
                    sb.AppendLine($"<td class='num'>{r.TotalARTForCatchment:F2}</td>");
                    sb.AppendLine($"<td class='breakdown'>{r.ARTAllocationBreakdown}</td>");
                    sb.AppendLine($"<td class='num'>{r.DetentionTNEfficiency:F1}%</td>");
                    sb.AppendLine($"<td class='num'>{r.TNRemovedDetention:F2}</td>");
                    sb.AppendLine($"<td class='num'>{r.DetentionTPEfficiency:F1}%</td>");
                    sb.AppendLine($"<td class='num'>{r.TPRemovedDetention:F2}</td>");
                    sb.AppendLine("</tr>");

                    totalTNLoad += c.PostNLoading;
                    totalTPLoad += c.PostPLoading;
                    totalTNRemoved += r.TNRemovedDetention;
                    totalTPRemoved += r.TPRemovedDetention;
                    totalRunoff += runoff;
                }

                sb.AppendLine("<tr style='font-weight:bold;background:#eaf2ff;'>");
                sb.AppendLine("<td>TOTALS</td><td></td>");
                sb.AppendLine($"<td class='num'>{totalRunoff:F2}</td>");
                sb.AppendLine("<td></td><td></td><td></td><td></td>");
                sb.AppendLine($"<td class='num'>{totalTNRemoved:F2}</td>");
                sb.AppendLine($"<td></td><td class='num'>{totalTPRemoved:F2}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</tbody></table>");

            // System summary
            double sysTNEff = (totalTNLoad > 0) ? (totalTNRemoved / totalTNLoad) : 0.0;
            double sysTPEff = (totalTPLoad > 0) ? (totalTPRemoved / totalTPLoad) : 0.0;

            sb.AppendLine("<div style='margin-top:12px;font-size:0.9em;color:#333'>");
            sb.AppendLine($"<strong>System Summary:</strong><br/>Total TN Load: {totalTNLoad:F2} kg/yr | Removed: {totalTNRemoved:F2} kg/yr | <strong>System Eff: {sysTNEff:P1}</strong><br/>");
            sb.AppendLine($"Total TP Load: {totalTPLoad:F2} kg/yr | Removed: {totalTPRemoved:F2} kg/yr | <strong>System Eff: {sysTPEff:P1}</strong>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }

        // Helper to synthesize TD allocation string when none stored on routing
        private static string BuildTDAllocationString(BMPTrainsProject project, int[] order, int currentId)
        {
            try
            {
                int idx = Array.IndexOf(order, currentId);
                if (idx < 0) return "";
                var rCurrent = project.getCatchment(currentId)?.getRouting();
                if (rCurrent == null) return "";

                double cumVol = rCurrent.CumulativeRetentionVolume;
                if (cumVol <= 0) return "";

                var parts = new List<string>();
                for (int j = 0; j <= idx; j++)
                {
                    int contribId = order[j];
                    var contribRouting = project.getCatchment(contribId)?.getRouting();
                    if (contribRouting == null) continue;

                    double contributorVol = contribRouting.RetentionVolume;
                    double pct = (cumVol > 0.0) ? (contributorVol / cumVol) : 0.0;
                    double allocatedTD = rCurrent.SystemTreatmentDepth * pct;
                    // use Catchment ID rather than name, and produce HTML-ready string with <br/> separators
                    parts.Add($"Basin {contribId}: {allocatedTD:F3}\" ({pct:P1})");
                }

                return string.Join("<br/>", parts);
            }
            catch
            {
                return "";
            }
        }

        // Add Flow balance report to BMPTrainsReports
        public static string RoutingFlowBalanceHtml(BMPTrainsProject project)
        {
            if (project == null) return string.Empty;

            // Ensure routing/volumes are calculated
            project.CalculateRouting();

            var order = project.GetRoutingInOrder() ?? new int[0];
            var sb = new StringBuilder();

            // CSS
            sb.AppendLine("<style>");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; font-size: 13px; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 6px; }");
            sb.AppendLine("th { background:#2E8BC0; color:white; text-align:left; }");
            sb.AppendLine("tr:nth-child(even){background:#f9f9f9}");
            sb.AppendLine(".num { text-align: right; }");
            sb.AppendLine("</style>");

            sb.AppendLine("<h3>Flow Balance - Catchment Routing</h3>");
            sb.AppendLine("<p>Shows per-node volumetric inputs and outputs (ac-ft/yr) and associated BMP summary.</p>");

            sb.AppendLine("<table>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>ID</th>");
            sb.AppendLine("<th>Catchment</th>");
            sb.AppendLine("<th>BMP Type</th>");
            sb.AppendLine("<th class='num'>Vol from Upstream</th>");
            sb.AppendLine("<th class='num'>Vol from Catchment</th>");
            sb.AppendLine("<th class='num'>Total In</th>");
            sb.AppendLine("<th class='num'>Total Out</th>");
            sb.AppendLine("<th class='num'>Vol to GW / Media</th>");
            sb.AppendLine("<th class='num'>N Total (kg/yr)</th>");
            sb.AppendLine("<th class='num'>N Discharged (kg/yr)</th>");
            sb.AppendLine("<th class='num'>P Total (kg/yr)</th>");
            sb.AppendLine("<th class='num'>P Discharged (kg/yr)</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            // accumulate totals
            double sumUpVol = 0, sumCatchVol = 0, sumIn = 0, sumOut = 0, sumGW = 0;
            double sumNTotal = 0, sumNDis = 0, sumPTotal = 0, sumPDis = 0;

            foreach (var id in order)
            {
                var c = project.getCatchment(id);
                if (c == null) continue;
                var r = c.getRouting();
                if (r == null) continue;

                // populate values (safe defaults)
                double vUp = r.VolumeFromUpstream;
                double vCatch = r.VolumeFromCatchment;
                double vIn = r.VolumeIn;
                double vOut = r.VolumeOut;
                double vGW = r.VolumeGW;

                double nTotal = (r.Nitrogen != null ? r.Nitrogen.TotalMassLoad : 0.0);
                double nDis = (r.Nitrogen != null ? r.Nitrogen.DischargedLoad : 0.0);
                double pTotal = (r.Phosphorus != null ? r.Phosphorus.TotalMassLoad : 0.0);
                double pDis = (r.Phosphorus != null ? r.Phosphorus.DischargedLoad : 0.0);

                sumUpVol += vUp;
                sumCatchVol += vCatch;
                sumIn += vIn;
                sumOut += vOut;
                sumGW += vGW;
                sumNTotal += nTotal;
                sumNDis += nDis;
                sumPTotal += pTotal;
                sumPDis += pDis;

                string nameEsc = System.Security.SecurityElement.Escape(c.CatchmentName ?? ("Catchment " + id));
                string bmpEsc = System.Security.SecurityElement.Escape(c.SelectedBMPType ?? "");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{id}</td>");
                sb.AppendLine($"<td>{nameEsc}</td>");
                sb.AppendLine($"<td>{bmpEsc}</td>");
                sb.AppendLine($"<td class='num'>{vUp:F3}</td>");
                sb.AppendLine($"<td class='num'>{vCatch:F3}</td>");
                sb.AppendLine($"<td class='num'>{vIn:F3}</td>");
                sb.AppendLine($"<td class='num'>{vOut:F3}</td>");
                sb.AppendLine($"<td class='num'>{vGW:F3}</td>");
                sb.AppendLine($"<td class='num'>{nTotal:F2}</td>");
                sb.AppendLine($"<td class='num'>{nDis:F2}</td>");
                sb.AppendLine($"<td class='num'>{pTotal:F2}</td>");
                sb.AppendLine($"<td class='num'>{pDis:F2}</td>");
                sb.AppendLine("</tr>");
            }

            // include outlet row if present
            var outlet = project.getRoutingOutlet();
            if (outlet != null)
            {
                // ensure outlet totals are up-to-date
                // We've already run CalculateRouting above; outlet should reflect totals
                double vUp = outlet.VolumeFromUpstream;
                double vCatch = outlet.VolumeFromCatchment;
                double vIn = outlet.VolumeIn;
                double vOut = outlet.VolumeOut;
                double vGW = outlet.VolumeGW;
                double nTotal = outlet.Nitrogen?.TotalMassLoad ?? 0.0;
                double nDis = outlet.Nitrogen?.DischargedLoad ?? 0.0;
                double pTotal = outlet.Phosphorus?.TotalMassLoad ?? 0.0;
                double pDis = outlet.Phosphorus?.DischargedLoad ?? 0.0;

                sumUpVol += vUp;
                sumCatchVol += vCatch;
                sumIn += vIn;
                sumOut += vOut;
                sumGW += vGW;
                sumNTotal += nTotal;
                sumNDis += nDis;
                sumPTotal += pTotal;
                sumPDis += pDis;

                sb.AppendLine("<tr style='font-weight:bold;background:#eef;'>");
                sb.AppendLine("<td>OUT</td>");
                sb.AppendLine("<td>Outlet</td>");
                sb.AppendLine("<td></td>");
                sb.AppendLine($"<td class='num'>{vUp:F3}</td>");
                sb.AppendLine($"<td class='num'>{vCatch:F3}</td>");
                sb.AppendLine($"<td class='num'>{vIn:F3}</td>");
                sb.AppendLine($"<td class='num'>{vOut:F3}</td>");
                sb.AppendLine($"<td class='num'>{vGW:F3}</td>");
                sb.AppendLine($"<td class='num'>{nTotal:F2}</td>");
                sb.AppendLine($"<td class='num'>{nDis:F2}</td>");
                sb.AppendLine($"<td class='num'>{pTotal:F2}</td>");
                sb.AppendLine($"<td class='num'>{pDis:F2}</td>");
                sb.AppendLine("</tr>");
            }

            // Totals row
            //sb.AppendLine("<tr style='font-weight:bold;background:#dbeefc;'>");
            //sb.AppendLine("<td colspan='3'>SYSTEM TOTALS</td>");
            //sb.AppendLine($"<td class='num'>{sumUpVol:F3}</td>");
            //sb.AppendLine($"<td class='num'>{sumCatchVol:F3}</td>");
            //sb.AppendLine($"<td class='num'>{sumIn:F3}</td>");
            //sb.AppendLine($"<td class='num'>{sumOut:F3}</td>");
            //sb.AppendLine($"<td class='num'>{sumGW:F3}</td>");
            //sb.AppendLine($"<td class='num'>{sumNTotal:F2}</td>");
            //sb.AppendLine($"<td class='num'>{sumNDis:F2}</td>");
            //sb.AppendLine($"<td class='num'>{sumPTotal:F2}</td>");
            //sb.AppendLine($"<td class='num'>{sumPDis:F2}</td>");
            //sb.AppendLine("</tr>");

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            // Quick balance check
            sb.AppendLine("<div style='margin-top:10px;font-size:0.95em;color:#333;'>");
            sb.AppendLine("<strong>Notes:</strong> Volumes are in ac-ft/yr. Ideally Total In ≈ Vol Out + Vol to GW. Small differences may arise from rounding or special-case routing logic.");
            sb.AppendLine("</div>");

            return sb.ToString();
        }
        // Renders a compact block-diagram "balance" for all routings in the project.
        // Layout per-node:
        //  [Upstream] [Input] -> [Treatment] -> [Output]
        //                ↓
        //            [Mass Reduction]
        public static string RoutingBalanceDiagramForAllHtml(BMPTrainsProject project)
        {
            if (project == null) return string.Empty;

            // Ensure routings/volumes/loads are calculated
            project.CalculateRouting();

            var order = project.GetRoutingInOrder();
            if (order == null || order.Length == 0)
            {
                // fallback to dictionary ordering
                order = project.Catchments?.Keys.OrderBy(k => k).ToArray() ?? new int[0];
            }

            var sb = new StringBuilder();

            // CSS for a clean block diagram
            sb.AppendLine("<style>");
            sb.AppendLine(".bb-table { border-collapse: collapse; width:100%; font-family: Arial, sans-serif; margin-bottom:14px; }");
            sb.AppendLine(".bb-table td { vertical-align: top; padding:6px; }");
            sb.AppendLine(".block { border:1px solid #c7d6e8; background:#f7fbff; border-radius:4px; padding:8px; }");
            sb.AppendLine(".title { font-weight:700; margin-bottom:6px; color:#0b5394; }");
            sb.AppendLine(".sub { font-size:0.9em; color:#444; }");
            sb.AppendLine(".arrow { font-size:22px; text-align:center; width:40px; color:#666; }");
            sb.AppendLine(".arrow-down { text-align:center; font-size:22px; color:#666; }");
            sb.AppendLine(".removed { border:1px solid #f2dede; background:#fff5f5; color:#800; }");
            sb.AppendLine(".small { font-size:0.9em; color:#333; }");
            sb.AppendLine(".meta { font-size:0.85em; color:#666; }");
            sb.AppendLine("</style>");

            sb.AppendLine("<h3>Balance Diagrams — Routing Blocks</h3>");
            sb.AppendLine("<p style='margin-top:-8px;margin-bottom:8px;font-size:0.95em;color:#333;'>Each block shows upstream routing, inputs, treatment efficiencies, outputs and mass reduction for the selected BMP.</p>");

            foreach (var id in order)
            {
                var c = project.getCatchment(id, false);
                if (c == null) continue;
                var r = c.getRouting();
                if (r == null) continue;

                sb.AppendLine(RenderRoutingBlockHtml(r));
            }

            return sb.ToString();
        }

        // Render a single routing block (table) using the routing's small helpers for content.
        private static string RenderRoutingBlockHtml(CatchmentRouting r)
        {
            var sb = new StringBuilder();

            // Escape some simple text fields
            string idLabel = r.FromID != 0 ? ("Catchment " + r.FromID) : "Outlet";
            string bmpType = System.Security.SecurityElement.Escape(r.BMPType ?? "");
            string name = System.Security.SecurityElement.Escape(r.Name ?? idLabel);

            sb.AppendLine("<table class='bb-table'>");

            // Header row showing id and BMP
            sb.AppendLine("<tr>");
            sb.AppendLine($"<td colspan='6' style='padding-bottom:10px;'><span class='title'>{idLabel}</span> <span class='meta'>{bmpType}</span></td>");
            sb.AppendLine("</tr>");

            // Main row: Upstream | Input | -> | Treatment | -> | Output
            sb.AppendLine("<tr>");
            sb.AppendLine(RenderTdBlock("Upstream Nodes", r.UpstreamNodes ?? "None", "block", 1));
            sb.AppendLine(RenderTdBlock("Input", r.InputBalanceReport("Load In"), "block", 1));
            sb.AppendLine("<td class='arrow'>&rarr;</td>");
            sb.AppendLine(RenderTdBlock("Treatment", r.EfficiencyBalanceReport("Treatment"), "block", 1));
            sb.AppendLine("<td class='arrow'>&rarr;</td>");
            sb.AppendLine(RenderTdBlock("Output", r.OutputBalanceReport("Mass Discharged"), "block", 1));
            sb.AppendLine("</tr>");

            // Arrow-down row (points to removed mass block)
            sb.AppendLine("<tr>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("<td class='arrow-down' style='text-align:center;'>&darr;</td>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("</tr>");

            // Removed mass row: place removed block centered under treatment/output
            sb.AppendLine("<tr>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("<td></td>");
            sb.AppendLine("<td></td>");
            sb.AppendLine($"<td colspan='3'>{RenderRemovedBlockHtml(r)}</td>");
            sb.AppendLine("</tr>");

            sb.AppendLine("</table>");

            return sb.ToString();
        }

        // Small helper to render an individual TD as a titled block.
        // contentHtml may contain HTML (we render verbatim) — callers should ensure safe content.
        private static string RenderTdBlock(string title, string contentHtml, string cssClass = "block", int colspan = 1)
        {
            // Normalize content: if null or empty, show placeholder
            string content = string.IsNullOrWhiteSpace(contentHtml) ? "<span class='small'>(none)</span>" : contentHtml;
            var sb = new StringBuilder();
            sb.Append("<td");
            if (colspan > 1) sb.Append($" colspan='{colspan}'");
            sb.Append($">");
            sb.Append($"<div class='{cssClass}'>");
            sb.Append($"<div class='title'>{System.Security.SecurityElement.Escape(title)}</div>");
            // For upstreamNodes, the string already contains <br/>; do not escape
            if (title == "Upstream Nodes")
                sb.Append($"<div class='sub'>{content}</div>");
            else
                sb.Append($"<div class='sub'>{content}</div>");
            sb.Append("</div>");
            sb.Append("</td>");
            return sb.ToString();
        }

        // Render the removed/mass-reduction block
        private static string RenderRemovedBlockHtml(CatchmentRouting r)
        {
            // Use the routing's helper that returns HTML formatted values
            string removedHtml = r.RemovedBalanceReport("Mass Reduction");
            // Wrap in 'removed' block styling
            var sb = new StringBuilder();
            sb.AppendLine($"<div class='block removed'>");
            sb.AppendLine($"<div class='title'>Mass Reduction</div>");
            sb.AppendLine($"<div class='sub'>{removedHtml}</div>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }

    }
}

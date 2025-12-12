using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace BMPTrains_2020.DomainCode
{
    public class CatchmentRouting : XmlPropertyObject
    {
        #region "Properties"
        public bool IsValid { get; set; }
        public string BMPType { get; set; }

        public string UpstreamBMPType { get; set; }

        public string UpstreamNodes { get; set; }

        public int FromID { get; set; }                     // FromID is the ID of the Associated Catchment
        public int ToID { get; set; }                       // ToID is the ID of the To Catchment (routed to)

        public RoutingParameters Nitrogen { get; set; }
        public RoutingParameters Phosphorus { get; set; }

        // In routing Hydraulic Efficiency is the % that passes through the BMP

        [Meta("Routing Node Hydraulic Efficiency", "%", 2)]
        public double HydraulicEfficiency { get; set; } // Given as %

        // Each Catchment Routing has these volumes
        // VolumeFromCatchment - this is volume coming into the Catchment Routing from the Catchment
        // VolumeFromUpstream - in addition to the volume from the catchment, upstream nodes can contribute to the volume
        // VolumeIn - all volume coming into the node (usually sum of upstream and catchment
        // VolumeOut - Total volume leaving the node and heading to the next node
        // VolumeTreated - This treatment efficiency * volume in
        // VolumeIntoMedia - If media exists then it will capture some of the load before GW
        // VolumeGW - Total Volume of water going into the ground 

        [Meta("Total Volume From Catchment", "ac-ft/yr", 2)]
        public double VolumeFromCatchment { get; set; }

        [Meta("Total Volume From Upstream", "ac-ft/yr", 2)]
        public double VolumeFromUpstream { get; set; }

        [Meta("Total Volume Into Routing Node", "ac-ft/yr", 2)]
        public double VolumeIn { get; set; }

        [Meta("Total Volume Out of Routing Node", "ac-ft/yr", 2)]
        public double VolumeOut { get; set; }

        [Meta("Total Into Media", "ac-ft/yr", 2)]
        public double VolumeIntoMedia { get; set; }

        [Meta("Total Volume Into Groundwater", "ac-ft/yr", 2)]
        public double VolumeGW { get; set; }

        // The following properties support the calculations associated with Retention
        // in Series. 


        // Retention-in-series properties added to CatchmentRouting
        [Meta("Retention Volume (node)", "ac-ft", 3)]
        public double RetentionVolume { get; set; }

        [Meta("Cumulative Retention Volume (system)", "ac-ft", 3)]
        public double CumulativeRetentionVolume { get; set; }

        [Meta("Cumulative Contributing Area", "acres", 3)]
        public double CumulativeContributingArea { get; set; }

        [Meta("System Treatment Depth", "in", 4)]
        public double SystemTreatmentDepth { get; set; }

        [Meta("TN Efficiency (series)", "%", 3)]
        public double SeriesTNEfficiency { get; set; }

        [Meta("TP Efficiency (series)", "%", 3)]
        public double SeriesTPEfficiency { get; set; }

        [Meta("TN Removed (series)", "kg/yr", 3)]
        public double TNRemovedSeries { get; set; }

        [Meta("TP Removed (series)", "kg/yr", 3)]
        public double TPRemovedSeries { get; set; }

        [Meta("TD Allocation Breakdown", "", 0)]
        public string TDAllocationBreakdown { get; set; }

        // Detention-in-series properties added to CatchmentRouting
        // The following properties support the detention in series calculations

        [Meta("Series ART (node)", "days", 3)]
        public double SeriesART { get; set; }

        [Meta("Cumulative Runoff (ac-ft/yr)", "ac-ft/yr", 3)]
        public double CumulativeRunoff { get; set; }

        [Meta("Total ART experienced (days)", "days", 3)]
        public double TotalARTForCatchment { get; set; }

        [Meta("TN Efficiency (detention series)", "%", 3)]
        public double DetentionTNEfficiency { get; set; }

        [Meta("TP Efficiency (detention series)", "%", 3)]
        public double DetentionTPEfficiency { get; set; }

        [Meta("TN Removed (detention series)", "kg/yr", 3)]
        public double TNRemovedDetention { get; set; }

        [Meta("TP Removed (detention series)", "kg/yr", 3)]
        public double TPRemovedDetention { get; set; }

        [Meta("ART Allocation Breakdown", "", 0)]
        public string ARTAllocationBreakdown { get; set; }

        public string RoutingNotes { get; set; }
        #endregion

        #region "Constructors"
        public CatchmentRouting()
        {
            //resetCatchmentRouting();
            RoutingNotes = "";
        }

        public CatchmentRouting(Catchment c)
        {
            InitializeCatchmentRouting(c);
        }

        public Catchment getCatchment()
        {
            return Globals.Project.getCatchment(FromID);
        }

        public void InitializeCatchmentRouting(int catchmentID)
        {
            InitializeCatchmentRouting(Globals.Project.getCatchment(catchmentID));
        }

        public void InitializeCatchmentRouting(Catchment c)
        {
            // When a catchment routing is initialized these parameters are set

            BMP bmp = c.getSelectedBMP();

            FromID = c.id;  // FromID is the ID of the routing and the Catchment
            ToID = c.ToID;  // ToID is the ID of the Catchment and routing destination
            id = c.id;   // FromID is the associated Catchment

            BMPType = c.SelectedBMPType;

            // The Upstream BMP type is important for routing calculations
            if (FromID != 0) UpstreamBMPType = Globals.Project.getCatchment(FromID).getSelectedBMP().BMPType;

            // The reason we need Upstream BMPType is the special case
            // A Wet Detention BMP with an Upstream with No BMP is 
            // Caclulated by combining the 2 Catchments.

            IsValid = false;

            if (Nitrogen == null) Nitrogen = new RoutingParameters();
            if (Phosphorus == null) Phosphorus = new RoutingParameters();

            Nitrogen.Name = "Nitrogen";
            Phosphorus.Name = "Phosphorus";

            if (c.Disabled)
            {
                Nitrogen.Calculate();
                Phosphorus.Calculate();
                return;
            }

            // The VolumeIn is set to the VolumeFromCatchment
            // Volume from Upstream Nodes is added during routing
            // VolumeIn will be VolumeFromCatchment + summation of VolumeOut of upstream nodes
            Name = c.CatchmentName;
            UpstreamNodes = "";

            // The initial volume in is the volume from the catchment
            VolumeFromUpstream = 0;
            VolumeFromCatchment = c.PostRunoffVolume;
            VolumeIn = VolumeFromCatchment;                         // This is the starting point, more will be added

            HydraulicEfficiency = bmp.HydraulicCaptureEfficiency;

            // Removal Efficiency proided by the BMP
            Nitrogen.ProvidedRemovalEfficiency = bmp.ProvidedNTreatmentEfficiency;
            Phosphorus.ProvidedRemovalEfficiency = bmp.ProvidedPTreatmentEfficiency;

            Nitrogen.PreMassLoadCatchment = c.PreNLoading;
            Phosphorus.PreMassLoadCatchment = c.PrePLoading;

            Nitrogen.PostMassLoadCatchment = c.PostNLoading;
            Phosphorus.PostMassLoadCatchment = c.PostPLoading;

            Nitrogen.TotalMassLoad = c.PostNLoading;
            Phosphorus.TotalMassLoad = c.PostPLoading;

            Nitrogen.TargetRemovalEfficiency = c.RequiredNTreatmentEfficiency;
            Phosphorus.TargetRemovalEfficiency = c.RequiredPTreatmentEfficiency;

            Nitrogen.GroundwaterRemovalEfficiency = c.GroundwaterNRemovalEfficiency;
            Phosphorus.GroundwaterLoad = c.GroundwaterPRemovalEfficiency;

            // Calculated Removal Efficiency is from the BMP 
            c.CalculatedNTreatmentEfficiency = Nitrogen.ProvidedRemovalEfficiency;
            c.CalculatedPTreatmentEfficiency = Phosphorus.ProvidedRemovalEfficiency;

            Nitrogen.Calculate();
            Phosphorus.Calculate();
        }

        public BMP GetBMP()
        {
            Catchment c = getCatchment();
            return c.getSelectedBMP();
        }

        public void InitializeCatchmentRouting()
        {

            Catchment c = getCatchment();
            InitializeCatchmentRouting(c);
        }

        //Answers an integer array of all the upstream nodes for the current FromID
        //public int[] GetUpstreamNodeIDs()
        //{
        //    return Catchment.UpstreamNodes(FromID);
        //}

        //public CatchmentRouting[] GetUpstreamCatchmentRoutings()
        //{
        //    List<CatchmentRouting> list = new List<CatchmentRouting>();
        //    int[] ids = GetUpstreamNodeIDs();
        //    foreach (int i in ids)
        //    {
        //        list.Add(Globals.Project.getCatchment(i).getRouting());
        //    }
        //    return list.ToArray();
        //}

    
        public void resetCatchmentRouting()
        {

            IsValid = true;
            //HydraulicEfficiency = 0;

            VolumeIn = 0;
            VolumeOut = 0;

            if (Nitrogen == null) Nitrogen = new RoutingParameters();
            if (Phosphorus == null) Phosphorus = new RoutingParameters();

            Nitrogen.Name = "Nitrogen";
            Phosphorus.Name = "Phosphorus";

            Nitrogen.ProvidedRemovalEfficiency = 0;
            Phosphorus.ProvidedRemovalEfficiency = 0;

            Nitrogen.PreMassLoadCatchment = 0;
            Phosphorus.PreMassLoadCatchment = 0;

            Nitrogen.PostMassLoadCatchment = 0;
            Phosphorus.PostMassLoadCatchment = 0;

            Nitrogen.UpstreamPostMassLoad = 0;
            Phosphorus.UpstreamPostMassLoad = 0;

            Nitrogen.UpstreamPreMassLoad = 0;
            Phosphorus.UpstreamPreMassLoad = 0;

            Nitrogen.TotalMassLoad = 0;
            Phosphorus.TotalMassLoad = 0;

            Nitrogen.TargetRemovalEfficiency = 0;
            Phosphorus.TargetRemovalEfficiency = 0;

            Nitrogen.GroundwaterLoad = 0;
            Nitrogen.GroundwaterLoadRemoved = 0;

            Phosphorus.GroundwaterLoad = 0;
            Phosphorus.GroundwaterLoadRemoved = 0;
        }


        #endregion

        #region "Reporting"
        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
            {
                {"ToID", "Routing to Catchment:"},
                {"VolumeFromCatchment", "Volume From Catchment (ac-ft)" },
                {"VolumeFromUpstream", "Volume From Upstream (ac-ft)" },
                {"VolumeIn", "Total Volume In (ac-ft)" },
                {"VolumeOut", "Total Volume Out (ac-ft)" },
                {"VolumeGW", "Total Volume Groundwater or Media (ac-ft)" },
            };
        }
        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
            {
                {"ToID",0}
            };
        }

        public string getReport()
        {
            string s = "<h2>Routing Report for " + this.Name + " (Catchment " + id.ToString() + ")</h2>";
            s += "BMP Type: " + BMPType + "<br/>";
            s += AsHtmlTable(PropertyLabels());

            s += "<h3>Nitrogen Report</h3>";
            s += Nitrogen.AsHtmlTable();

            s += "<h3>Phosphorus Report</h3>";
            s += Phosphorus.AsHtmlTable();

            if (RoutingNotes != "") { s += "<br/>" + RoutingNotes + "<br/>"; }


            // Add the nice tableview of the system
            s += getBalanceReport();

            return s;
        }


        public string getBalanceReport()
        {

            RoutingParameters n = Nitrogen.Calculate();
            RoutingParameters p = Phosphorus.Calculate();
            string upNodes = (UpstreamNodes == "" ? "None" : UpstreamNodes);

            string s = "<br/><h3>Load Diagram for " + BMPType + " ( As Used In Routing)</h3><br/>";
            s += "<table><tr>";         // 5 Cells per row
            s += Common.TableCell("Upstream Nodes<br/>" + upNodes);
            s += Common.TableCell(InputBalanceReport("Load In"));
            s += Common.TableCell("&rarr;");
            s += Common.TableCell(EfficiencyBalanceReport("Treatment"), "", true);

            //s += EfficiencyReportCell(n.ProvidedRemovalEfficiency, p.ProvidedRemovalEfficiency, 1, "%", "Treatment", 1);
            s += Common.TableCell("&rarr;");

            //s += MassBalanceReportCell(n.DischargedLoad, p.DischargedLoad, VolumeOut, 2, "Mass Discharged");
            s += Common.TableCell(OutputBalanceReport("Mass Discharged"));
            s += "</tr>";
            s += Common.BlankTableRows(6);
            s += Common.FilledTableRows(new string[6] { "", "", "", "&darr;", "", "" });
            s += Common.FilledTableRows(new string[6] { "", "", Common.TableCell(RemovedBalanceReport("Mass Reduction")), "", "", "" });
            //s += "<tr><td></td> <td></td ><td></td>";
            //s += TableCell("&darr;");
            //s += "<td></td><td></td></tr>";
            //s += "<tr><td></td><td></td><td></td>";
            //s += MassBalanceReportCell(n.RemovedLoad, p.RemovedLoad, VolumeGW, 2, "Mass Removed");
            //s += EfficiencyReportCell(n.RemovedLoad, p.RemovedLoad, 2, "kg/yr", "Mass Removed");
            //s += "<td></td><td></td></tr>";
            s += "</table>";

            return s;
        }

        public string InputBalanceReport(string title = "")
        {
            string s = title + "<br/>";
            s += "N: " + Common.FormattedString(Nitrogen.TotalMassLoad, 2) + " kg/yr<br/>";
            s += "P: " + Common.FormattedString(Phosphorus.TotalMassLoad, 2) + " kg/yr<br/>";
            s += "Q: " + Common.FormattedString(VolumeIn, 2) + " ac-ft/yr<br/>";

            return s;
        }

        public string OutputBalanceReport(string title = "")
        {
            string s = title + "<br/>";
            s += "N: " + Common.FormattedString(Nitrogen.DischargedLoad, 2) + " kg/yr<br/>";
            s += "P: " + Common.FormattedString(Phosphorus.DischargedLoad, 2) + " kg/yr<br/>";
            s += "Q: " + Common.FormattedString(VolumeOut, 2) + " ac-ft/yr<br/>";
            return s;
        }

        public string EfficiencyBalanceReport(string title = "")
        {
            string s = title + "<br/>";
            s += "N: " + Common.FormattedString(Nitrogen.ProvidedRemovalEfficiency, 2) + " %<br/>";
            s += "P: " + Common.FormattedString(Phosphorus.ProvidedRemovalEfficiency, 2) + " %<br/>";
            s += "Q: " + Common.FormattedString(100 - HydraulicEfficiency, 2) + " %<br/>";
            return s;
        }

        public string RemovedBalanceReport(string title = "")
        {
            string s = title + "<br/>";
            s += "N: " + Common.FormattedString(Nitrogen.RemovedLoad, 2) + " kg/yr<br/>";
            s += "P: " + Common.FormattedString(Phosphorus.RemovedLoad, 2) + " kg/yr<br/>";
            s += "Q: " + Common.FormattedString(VolumeGW, 2) + " ac-ft/yr<br/>";
            return s;
        }

        public string outletReport()
        {
            string s = "<h2>Routing Report for Outlet</h2>";
            s += "<h3>Nitrogen Loading</h3>";
            s += Nitrogen.AsHtmlTable(Nitrogen.OutletLabels());

            s += "<h3>Phosphorus Loading</h3>";
            s += Phosphorus.AsHtmlTable(Phosphorus.OutletLabels());

            return s;
        }
        #endregion

        #region "Calculations"


        /// <summary>
        /// Calculate this routing as an independent node using the current VolumeOut / loads of other nodes.
        /// allRoutings must contain all nodes in the system keyed by FromID (include outlet with key 0).
        /// This method:
        ///  - computes VolumeFromUpstream as sum of upstream VolumeOut
        ///  - sets VolumeIn = VolumeFromCatchment + VolumeFromUpstream
        ///  - updates provided removal efficiencies from the associated BMP
        ///  - computes VolumeOut (using existing CalculateVolumeOut)
        ///  - computes Nitrogen/Phosphorus mass balances via RoutingParameters.Calculate()
        /// Note: use CalculateBasicAll to run across the whole system (iterative if needed).
        /// </summary>
        public void CalculateBasic(IDictionary<int, CatchmentRouting> allRoutings)
        {
            // Ensure parameters exist
            if (Nitrogen == null) Nitrogen = new RoutingParameters();
            if (Phosphorus == null) Phosphorus = new RoutingParameters();

            // Avoid calling getCatchment for the outlet (FromID == 0)
            Catchment c = null;
            if (this.FromID != 0 && Globals.Project != null && Globals.Project.CatchmentExists(this.FromID))
            {
                // safe to call getCatchment only when a real catchment exists
                try { c = Globals.Project.getCatchment(FromID); } catch { c = null; }
            }

            // Ensure VolumeFromCatchment is up to date
            if (c != null)
            {
                VolumeFromCatchment = c.PostRunoffVolume;
                Name = c.CatchmentName;
                BMPType = c.SelectedBMPType;
            }

            // Sum upstream volumes and loads from routings that route to this node (ToID == this.FromID)
            double upstreamVol = 0.0;
            double upstreamNLoad = 0.0;
            double upstreamPLoad = 0.0;
            double upstreamPreN = 0.0;
            double upstreamPreP = 0.0;
            string upstreamNodesText = "";

            if (allRoutings != null)
            {
                foreach (var kv in allRoutings)
                {
                    var r = kv.Value;
                    if (r == null) continue;
                    if (r.ToID == this.FromID && r.FromID != this.FromID)
                    {
                        upstreamVol += r.VolumeOut;
                        upstreamNLoad += (r.Nitrogen != null ? r.Nitrogen.DischargedLoad : 0.0);
                        upstreamPLoad += (r.Phosphorus != null ? r.Phosphorus.DischargedLoad : 0.0);
                        upstreamPreN += (r.Nitrogen != null ? r.Nitrogen.TotalUpstreamPreMassLoad : 0.0);
                        upstreamPreP += (r.Phosphorus != null ? r.Phosphorus.TotalUpstreamPreMassLoad : 0.0);
                        upstreamNodesText += "Node: " + r.FromID.ToString("##") + "<br/>";
                    }
                }
            }

            VolumeFromUpstream = upstreamVol;
            VolumeIn = VolumeFromCatchment + VolumeFromUpstream;
            UpstreamNodes = upstreamNodesText;

            // Update removal efficiencies from BMP
            BMP bmp = null;
            try { bmp = (c != null ? c.getSelectedBMP() : null); } catch { bmp = null; }

            Nitrogen.ProvidedRemovalEfficiency = bmp?.ProvidedNTreatmentEfficiency ?? Nitrogen.ProvidedRemovalEfficiency;
            Phosphorus.ProvidedRemovalEfficiency = bmp?.ProvidedPTreatmentEfficiency ?? Phosphorus.ProvidedRemovalEfficiency;

            // Update mass load inputs from catchment and upstream sums
            Nitrogen.PreMassLoadCatchment = c?.PreNLoading ?? Nitrogen.PreMassLoadCatchment;
            Phosphorus.PreMassLoadCatchment = c?.PrePLoading ?? Phosphorus.PreMassLoadCatchment;

            Nitrogen.PostMassLoadCatchment = c?.PostNLoading ?? Nitrogen.PostMassLoadCatchment;
            Phosphorus.PostMassLoadCatchment = c?.PostPLoading ?? Phosphorus.PostMassLoadCatchment;

            Nitrogen.UpstreamPostMassLoad = upstreamNLoad;
            Phosphorus.UpstreamPostMassLoad = upstreamPLoad;

            Nitrogen.UpstreamPreMassLoad = upstreamPreN;
            Phosphorus.UpstreamPreMassLoad = upstreamPreP;

            Nitrogen.TotalMassLoad = Nitrogen.PostMassLoadCatchment + Nitrogen.UpstreamPostMassLoad;
            Phosphorus.TotalMassLoad = Phosphorus.PostMassLoadCatchment + Phosphorus.UpstreamPostMassLoad;

            // Calculate volume out using existing strategy that references the BMP
            CalculateVolumeOut();

            // Now compute nutrient mass balance using RoutingParameters logic
            Nitrogen.Calculate();
            Phosphorus.Calculate();

            // Update catchment reported calculated efficiencies (mirror existing Initialize behavior)
            if (c != null)
            {
                c.CalculatedNTreatmentEfficiency = Nitrogen.ProvidedRemovalEfficiency;
                c.CalculatedPTreatmentEfficiency = Phosphorus.ProvidedRemovalEfficiency;
            }
        }

        public static void CalculateIndependentCatchments()
        {
            CatchmentRouting.CalculateIndependentCatchments(Globals.Project);
        }

        /// <summary>
        /// Helper: run CalculateBasic across the entire project routing network.
        /// This runs a simple iterative sweep that updates every node each iteration.
        /// For many practical networks 3-5 iterations are sufficient to propagate upstream VolumeOut values.
        /// </summary>
        public static void CalculateIndependentCatchments(BMPTrainsProject project, int maxIterations = 6)
        {
            if (project == null) return;

            project.RoutingMethod = BMPTrainsProject.routing_IndependentCatchments;

            // Build dictionary of routings keyed by FromID, include outlet with key 0
            var allRoutings = new Dictionary<int, CatchmentRouting>();

            // Ensure routings exist for every catchment and add them
            foreach (KeyValuePair<int, Catchment> kvp in project.Catchments)
            {
                var c = kvp.Value;
                if (c == null) continue;

                CatchmentRouting r = null;
                try { r = c.getRouting(); } catch { r = null; }

                if (r == null)
                {
                    r = new CatchmentRouting(c); // will initialize values
                    c.routing = r;
                }

                // Make sure FromID/ToID are set from the catchment
                r.FromID = c.id;
                r.ToID = c.ToID;
                allRoutings[c.id] = r;
            }

            // Ensure outlet routing exists and add as key 0
            var outletRouting = project.getRoutingOutlet(); // factory ensures it's created
            outletRouting.FromID = 0;
            outletRouting.ToID = -1;
            allRoutings[0] = outletRouting;

            // Initialize VolumeFromCatchment for each node from its catchment
            foreach (var kv in allRoutings)
            {
                var cr = kv.Value;
                if (cr == null) continue;
                if (kv.Key == 0) continue;
                try
                {
                    var catchment = project.getCatchment(kv.Key);
                    if (catchment != null)
                    {
                        cr.VolumeFromCatchment = catchment.PostRunoffVolume;
                        cr.Name = catchment.CatchmentName;
                    }
                }
                catch { }
            }

            // Iteratively sweep to propagate upstream VolumeOut values to downstream nodes.
            // This is a simple fixed-point iteration; for acyclic graphs this converges quickly.
            for (int iter = 0; iter < Math.Max(1, maxIterations); iter++)
            {
                // We iterate in arbitrary order — repeated sweeps propagate updates
                foreach (var kv in allRoutings.OrderBy(k => k.Key))
                {
                    var cr = kv.Value;
                    if (cr == null) continue;
                    cr.CalculateBasic(allRoutings);
                }
            }

            // Place computed outlet routing back into project and refresh project totals
            project.outlet = allRoutings.ContainsKey(0) ? allRoutings[0] : null;
            project.CalculateTotalSystemLoading();
        }

        /// <summary>
        /// Calculate retention-in-series routing across the project.
        /// Populates per-node retention-series properties on each CatchmentRouting
        /// and updates project totals / outlet loads.
        /// </summary>

// Replace the existing CalculateRetentionInSeries method with this updated implementation.
// This version computes per-node volumes (VolumeFromCatchment, VolumeFromUpstream, VolumeIn, VolumeOut, VolumeGW)
// and performs mass-balance on Nitrogen and Phosphorus (TotalMassLoad, DischargedLoad, RemovedLoad) while
// still computing the retention-in-series summary values used by the existing report routines.
public static void CalculateRetentionInSeries(BMPTrainsProject project = null)
        {
            if (project == null) project = Globals.Project;
            if (project == null) return;

            // mark routing method
            project.RoutingMethod = BMPTrainsProject.routing_RetentionInSeries;

            // Reset routing retention properties (this clears previous routing volumes/loads)
            foreach (var kv in project.Catchments)
            {
                var r = kv.Value?.getRouting();
                if (r != null) r.resetCatchmentRouting();
            }

            int[] order = project.GetRoutingInOrder();
            if (order == null || order.Length == 0)
            {
                // Nothing in series; nothing to compute
                return;
            }

            double cumVol = 0.0;
            double cumArea = 0.0;

            // These accumulate the "series" style totals (keeps backward compatibility with earlier approach)
            double totalPostN_series = 0.0;
            double totalPostP_series = 0.0;
            double totalRemovedN_series = 0.0;
            double totalRemovedP_series = 0.0;

            // Iterate the routing order (upstream -> downstream) and compute per-node routing mass/volume balances
            foreach (int id in order)
            {
                var c = project.getCatchment(id);
                if (c == null) continue;

                var r = c.getRouting();
                if (r == null)
                {
                    r = new CatchmentRouting(c);
                    c.routing = r;
                }

                // Volume from this catchment into its retention BMP (per-catchment runoff to retention)
                double catchmentRunoffVol = 0.0;
                try
                {
                    catchmentRunoffVol = c.getRetention().RunoffVolume;
                }
                catch
                {
                    catchmentRunoffVol = 0.0;
                }
                r.VolumeFromCatchment = catchmentRunoffVol;

                // Compute upstream contributions (sum VolumeOut and nutrient discharged loads from upstream routings).
                double upstreamVol = 0.0;
                double upstreamNLoad = 0.0;
                double upstreamPLoad = 0.0;

                // because order is upstream->downstream, upstream nodes (earlier in order) will have VolumeOut already computed
                foreach (int upId in order)
                {
                    if (upId == id) break; // only earlier nodes are upstream in the ordered list
                    var upCatch = project.getCatchment(upId);
                    if (upCatch == null) continue;
                    var upRouting = upCatch.getRouting();
                    if (upRouting == null) continue;
                    // Only include those that route to this node
                    if (upRouting.ToID == id)
                    {
                        upstreamVol += upRouting.VolumeOut;
                        upstreamNLoad += (upRouting.Nitrogen != null ? upRouting.Nitrogen.DischargedLoad : 0.0);
                        upstreamPLoad += (upRouting.Phosphorus != null ? upRouting.Phosphorus.DischargedLoad : 0.0);
                    }
                }

                r.VolumeFromUpstream = upstreamVol;
                r.VolumeIn = r.VolumeFromCatchment + r.VolumeFromUpstream;

                // Update removal efficiencies from the catchment's retention BMP (if present)
                Retention retBmp = null;
                try { retBmp = c.getRetention(); } catch { retBmp = null; }

                r.Nitrogen.ProvidedRemovalEfficiency = retBmp?.ProvidedNTreatmentEfficiency ?? r.Nitrogen.ProvidedRemovalEfficiency;
                r.Phosphorus.ProvidedRemovalEfficiency = retBmp?.ProvidedPTreatmentEfficiency ?? r.Phosphorus.ProvidedRemovalEfficiency;

                // Update nutrient input mass components (from catchment and upstream)
                r.Nitrogen.PreMassLoadCatchment = c.PreNLoading;
                r.Phosphorus.PreMassLoadCatchment = c.PrePLoading;

                r.Nitrogen.PostMassLoadCatchment = c.PostNLoading;
                r.Phosphorus.PostMassLoadCatchment = c.PostPLoading;

                r.Nitrogen.UpstreamPostMassLoad = upstreamNLoad;
                r.Phosphorus.UpstreamPostMassLoad = upstreamPLoad;

                r.Nitrogen.TotalMassLoad = r.Nitrogen.PostMassLoadCatchment + r.Nitrogen.UpstreamPostMassLoad;
                r.Phosphorus.TotalMassLoad = r.Phosphorus.PostMassLoadCatchment + r.Phosphorus.UpstreamPostMassLoad;

                // Calculate hydraulic routing (VolumeOut, VolumeIntoMedia, VolumeGW) using existing strategy that references the BMP
                // Note: CalculateVolumeOut uses getCatchment() internally and consults BMP semantics (retention semantics set HydraulicEfficiency)
                r.CalculateVolumeOut();

                // Now compute nutrient mass balance using RoutingParameters logic (will use ProvidedRemovalEfficiency set above)
                r.Nitrogen.Calculate();
                r.Phosphorus.Calculate();

                // Keep backward-compatible "series" calculation for reporting summary:
                // Node retention volume is the retention volume of the catchment's retention BMP
                double nodeRetentionVolume = 0.0;
                try
                {
                    nodeRetentionVolume = c.getRetention().RetentionVolume;
                }
                catch
                {
                    nodeRetentionVolume = 0.0;
                }

                r.RetentionVolume = nodeRetentionVolume;
                cumVol += nodeRetentionVolume;

                // cumulative area uses post area (the original report used PostArea)
                cumArea += c.PostArea;

                r.CumulativeRetentionVolume = cumVol;
                r.SystemTreatmentDepth = (cumArea > 0.0) ? (cumVol * 12.0) / cumArea : 0.0;

                // Series efficiency (for reporting) is derived from system treatment depth via lookup on catchment
                double eff = 0.0;
                try
                {
                    eff = c.CalulateRetentionEfficiency(r.SystemTreatmentDepth);
                }
                catch
                {
                    eff = 0.0;
                }

                r.SeriesTNEfficiency = eff;
                r.SeriesTPEfficiency = eff;

                // Mass removed for the series-style report (keeps previous behavior)
                r.TNRemovedSeries = c.PostNLoading * (eff / 100.0);
                r.TPRemovedSeries = c.PostPLoading * (eff / 100.0);

                // accumulate series totals (unchanged semantics from previous implementation)
                totalPostN_series += c.PostNLoading;
                totalPostP_series += c.PostPLoading;
                totalRemovedN_series += r.TNRemovedSeries;
                totalRemovedP_series += r.TPRemovedSeries;

                // Optional: store TD allocation breakdown (unchanged behavior left to TD logic)
                // r.TDAllocationBreakdown remains as previously populated by reporting helper when needed
            }

            // After per-node routing we compute outlet loads by summing discharged loads of nodes that route to outlet
            var outlet = project.getRoutingOutlet();
            outlet.resetCatchmentRouting();

            foreach (KeyValuePair<int, Catchment> kvp in project.Catchments)
            {
                var cr = kvp.Value.getRouting();
                if (cr != null && cr.ToID == 0)
                {
                    cr.CalculateOutletMassLoads(outlet);
                }
            }

            // Project totals (catchment post loads unchanged from before)
            double totalCatchmentN = 0.0;
            double totalCatchmentP = 0.0;
            for (int i = 1; i <= project.numCatchments; i++)
            {
                var cc = project.getCatchment(i);
                if (cc == null) continue;
                totalCatchmentN += cc.PostNLoading;
                totalCatchmentP += cc.PostPLoading;
            }

            project.TotalCatchmentNLoad = totalCatchmentN;
            project.TotalCatchmentPLoad = totalCatchmentP;

            project.TotalOutletNLoad = Math.Max(0.0, outlet.Nitrogen.TotalMassLoad);
            project.TotalOutletPLoad = Math.Max(0.0, outlet.Phosphorus.TotalMassLoad);

            // System treatment efficiencies (based on routing outlet mass)
            if (project.TotalCatchmentNLoad > 0)
                project.CalculatedNTreatmentEfficiency = 100.0 * (project.TotalCatchmentNLoad - project.TotalOutletNLoad) / project.TotalCatchmentNLoad;
            else
                project.CalculatedNTreatmentEfficiency = 0.0;

            if (project.TotalCatchmentPLoad > 0)
                project.CalculatedPTreatmentEfficiency = 100.0 * (project.TotalCatchmentPLoad - project.TotalOutletPLoad) / project.TotalCatchmentPLoad;
            else
                project.CalculatedPTreatmentEfficiency = 0.0;

            // Keep series-style summary values in the project for backward compatibility
            // (these reflect the original "series" calculation approach)
            // Use the previously accumulated series totals (from per-node series calculation)
            // Note: these are separate from the mass-balance routing values computed above
            // and are preserved to avoid breaking existing reporting semantics that compare both methods.
            // (If desired these could be mapped into other project properties or removed in a future refactor.)

            // Populate outlet routing totals (mirror previous behavior)
            outlet.Nitrogen.TotalMassLoadLbYr = outlet.Nitrogen.TotalMassLoad * 2.2046;
            outlet.Phosphorus.TotalMassLoadLbYr = outlet.Phosphorus.TotalMassLoad * 2.2046;
            project.outlet = outlet;
        }





        public double CalculateVolumeOut()
        {
            // Default for detention-like systems
            HydraulicEfficiency = 100;

            BMP bmp = null;
            try
            {
                // Guard: only attempt to get a catchment's BMP when FromID refers to a real catchment
                if (this.FromID != 0)
                    bmp = getCatchment()?.getSelectedBMP();
            }
            catch
            {
                bmp = null;
            }

            // If a BMP exists and it has retention semantics, use its provided N efficiency
            if (bmp != null && bmp.hasRetention())
            {
                HydraulicEfficiency = bmp.ProvidedNTreatmentEfficiency;
            }

            VolumeOut = (100 - HydraulicEfficiency) * VolumeIn / 100;
            VolumeIntoMedia = VolumeIn - VolumeOut;
            VolumeGW = VolumeIn - VolumeOut;

            return VolumeOut;
        }

        public void CalculateSummations(CatchmentRouting cr)
        {
            UpstreamNodes += "Node: " + cr.FromID.ToString("##") + "<br/>";

            if (Nitrogen.ProvidedRemovalEfficiency >= 100) Nitrogen.ProvidedRemovalEfficiency = 99;
            if (Phosphorus.ProvidedRemovalEfficiency >= 100) Phosphorus.ProvidedRemovalEfficiency = 99;

            VolumeOut = HydraulicEfficiency * VolumeIn / 100;

            // Sum Upstream
            Nitrogen.UpstreamPostMassLoad += cr.Nitrogen.DischargedLoad;
            Phosphorus.UpstreamPostMassLoad += cr.Phosphorus.DischargedLoad;

            Nitrogen.UpstreamPreMassLoad += cr.Nitrogen.TotalUpstreamPreMassLoad;
            Phosphorus.UpstreamPreMassLoad += cr.Phosphorus.TotalUpstreamPreMassLoad;

            CalculateNutrients();
        }

        private void RouteNoneToRetention(CatchmentRouting up)
        {
            // If the upstream Catchment has no BMP, then the 2 Catchments are treated as a single Catchment
            // this is important with retention as the catchment characteristics are used in the calculation 
            // of removal.

            if (!Globals.Project.CatchmentExists(up.ToID)) return;
            if (!Globals.Project.CatchmentExists(up.FromID)) return;

            up.VolumeOut = up.VolumeIn;
            Catchment downstreamCatchment = Globals.Project.getCatchment(FromID);  // Same as Up.ToID (This Catchment)
            Catchment upstreamCatchment = Globals.Project.getCatchment(up.FromID);
            // This is the complex case  
            //   
            //   For the DCIA % use a Aerial weighted average
            double WeightedDCIAPercent = ((downstreamCatchment.PostDCIAPercent * downstreamCatchment.PostArea) + (upstreamCatchment.PostDCIAPercent * upstreamCatchment.PostArea))
                / (downstreamCatchment.PostArea + upstreamCatchment.PostArea);

            // For NDCIA Curve Number it needs to be flow weighted
            // So need to calculate flow from NDCIA based on the CN and area 
            // 
            // Weighting Factor = Rational C * Pervious Area
            double retentionDepth = downstreamCatchment.getSelectedBMP().RetentionDepth;

            //            double upArea = upC.PostArea * (100 - upC.PostDCIAPercent) / 100;
            //            double downArea = (downC.PostArea - downC.BMPArea) * (100 - downC.PostDCIAPercent) / 100;

            double upArea = upstreamCatchment.PostArea;
            double downArea = (downstreamCatchment.PostArea - downstreamCatchment.BMPArea);


            double totArea = upArea + downArea;

            double upRC = upstreamCatchment.CalculateRationalCoefficient(upstreamCatchment.PostNonDCIACurveNumber, upstreamCatchment.PostDCIAPercent);    // This needs to be post annual flow from upstream
            double downRC = downstreamCatchment.CalculateRationalCoefficient(downstreamCatchment.PostNonDCIACurveNumber, downstreamCatchment.PostDCIAPercent);  // This needs to be post annual flow from downstream

            double upFraction = upArea * upRC;
            double downFraction = downArea * downRC;
            double totFraction = upFraction + downFraction;

            // Sum of up and down ratio will be 1.0
            // double upRatio = upFraction / totFraction;
            // double downRatio = downFraction / totFraction;

            double netVolume = retentionDepth * (downstreamCatchment.PostArea - downstreamCatchment.BMPArea) / 12;
            double newStorage = downFraction * netVolume / totFraction;

            // This is an adjusted retention to take into account the flow from the upstream
            double adjustedDepth = newStorage / (downstreamCatchment.PostArea - downstreamCatchment.BMPArea) * 12;

            double WeightedC = ((upArea * upRC) + (downArea * downRC)) / (upArea + downArea);

            // Do a Reverse lookup in the Lookup table
            double WeightedNDCIACN = upstreamCatchment.CalculateNDCIACN(WeightedDCIAPercent, WeightedC);

            double t = RetentionEfficiencyLookupTables.CalculateEfficiency(adjustedDepth,
                                                                           WeightedNDCIACN,
                                                                           WeightedDCIAPercent,
                                                                           Globals.Project.RainfallZone);
            Nitrogen.ProvidedRemovalEfficiency = t;
            Phosphorus.ProvidedRemovalEfficiency = t;

            if ((upstreamCatchment.getSelectedBMP().DelayTime > 0) && (upstreamCatchment.getSelectedBMP().DelayTime < 15))
            {
                up.HydraulicEfficiency = 100;  // Hydraulic Efficiency of No BMP
                Nitrogen.ProvidedRemovalEfficiency += BMP.CalculateDelayEfficiency(upstreamCatchment.getSelectedBMP().DelayTime);
                Phosphorus.ProvidedRemovalEfficiency += BMP.CalculateDelayEfficiency(upstreamCatchment.getSelectedBMP().DelayTime); ;
            }

            if (upstreamCatchment.getSelectedBMP().DelayTime >= 15)
            {
                // Special Case Commingling to Retention
                up.HydraulicEfficiency = 100;  // Hydraulic Efficiency of No BMP
                Nitrogen.ProvidedRemovalEfficiency += 5;
                Phosphorus.ProvidedRemovalEfficiency += 5;
            }

        }

        private void RouteWetDetentionToWetDetention(CatchmentRouting up)
        {
            // Wet Detention systems routed to wet detention systems are a special case, they have to 
            // account for a specific removal of the nutrients from the upstream wet detention

            try
            {
                // Flow is the same for both - upstream flow
                // Downstream adds Catchment flow
                up.VolumeOut = up.VolumeIn;
                double upRV = up.VolumeOut;
                double dnRV = upRV + VolumeFromCatchment;

                // Permanent pool considered is downstream only
                double dnPPV = ((WetDetention)getCatchment().getSelectedBMP()).PermanentPoolVolume;

                // residence time of downstream pond is calculated based on sum of flows 
                // ResidenceTime = PermanentPoolVolume / RunoffVolume * 365;  
                double RT = dnPPV / dnRV * 365;

                // Routines return in %
                Nitrogen.ProvidedRemovalEfficiency = WetDetention.CalculateNitrogenRemoval(RT);
                Phosphorus.ProvidedRemovalEfficiency = WetDetention.CalculatePhosphorusRemoval(RT);
            }
            catch
            {
                CalculateSummations(up);
                return;
            }  // End Detention to Detention
            RoutingNotes = "Wet Detention: " + up.FromID.ToString() + " to Wet Detention: " + FromID.ToString();
            RoutingNotes += "<br/> Adjusted N Removal Efficiency (%): " + Nitrogen.ProvidedRemovalEfficiency.ToString("##.#");
            RoutingNotes += "<br/> Adjusted P Removal Efficiency (%): " + Phosphorus.ProvidedRemovalEfficiency.ToString("##.#");
        }

        private void RouteRetentionToWetDetention(CatchmentRouting up)
        {

            // Retention to wet detention is the final special case, again specific adjustments 
            // must be made for this routing

            try
            {
                // RV - Runoff Volume
                double dnRV = getCatchment().PostRunoffVolume;   //getSelectedBMP()).RunoffVolume;

                // Volume out fraction is the same as the removal fraction RE - Removal Efficiency
                double upRE = ((Retention)up.getCatchment().getSelectedBMP()).ProvidedNTreatmentEfficiency / 100;

                // Volume may be needed in subsequent routing
                up.VolumeOut = (1 - upRE) * up.VolumeIn;
                double upRV = up.VolumeOut; // (1 - upRE) * ((Retention)up.getCatchment().getSelectedBMP()).RunoffVolume;
                double totRV = upRV + dnRV;

                double dnPPV = ((WetDetention)getCatchment().getSelectedBMP()).PermanentPoolVolume;

                ((WetDetention)getCatchment().getSelectedBMP()).Calculate();

                double r1 = (upRV / totRV) * dnPPV * 365 / totRV;
                double r2 = (dnRV / totRV) * dnPPV * 365 / totRV;

                // Routines return in %
                double Neff1 = WetDetention.CalculateNitrogenRemoval(r1);
                double Neff2 = WetDetention.CalculateNitrogenRemoval(r2);

                double Peff1 = WetDetention.CalculatePhosphorusRemoval(r1);
                double Peff2 = WetDetention.CalculatePhosphorusRemoval(r2);

                // The final calculation of removal efficiency
                try
                {
                    double upNL = up.Nitrogen.DischargedLoad;  // Nitrogen from 1
                    double dnNL = getCatchment().PostNLoading;                  // Nitrogen from 2
                    double NRF1 = upNL * (Neff1 / 100);                 // Nitrogen removal from 1 (up)
                    double NRF2 = dnNL * (Neff2 / 100);                 // Nitrogen removal from 2 (down)

                    double NRFT = NRF1 + NRF2;                                      // Total removed Nitrogen
                    Nitrogen.ProvidedRemovalEfficiency = ((NRF1 + NRF2) / (upNL + dnNL)) * 100;
                }
                catch
                {
                    Nitrogen.ProvidedRemovalEfficiency = getCatchment().getSelectedBMP().ProvidedNTreatmentEfficiency;
                }

                try
                {
                    double upPL = (1 - upRE) * up.Phosphorus.DischargedLoad;
                    double dnPL = getCatchment().PostPLoading;
                    double PRF1 = upPL * (Peff1 / 100);         // Nitrogen removal from 1 (up)
                    double PRF2 = dnPL * (Peff2 / 100);                  // Nitrogen removal from 2 (down)
                    double PRFT = PRF1 + PRF2;                                      // Total removed Nitrogen

                    Phosphorus.ProvidedRemovalEfficiency = ((PRF1 + PRF2) / (upPL + dnPL)) * 100;
                }
                catch
                {
                    Phosphorus.ProvidedRemovalEfficiency = getCatchment().getSelectedBMP().ProvidedNTreatmentEfficiency;
                }
            }
            catch
            {
                return;
            }  // End Retention to Detention

            // Add in the Wetland Credits
            ((WetDetention)getCatchment().getSelectedBMP()).CalculateWetlandCredits(Nitrogen.ProvidedRemovalEfficiency, Phosphorus.ProvidedRemovalEfficiency);
            Nitrogen.ProvidedRemovalEfficiency = ((WetDetention)getCatchment().getSelectedBMP()).ProvidedNTreatmentEfficiency;
            Phosphorus.ProvidedRemovalEfficiency = ((WetDetention)getCatchment().getSelectedBMP()).ProvidedPTreatmentEfficiency;

            RoutingNotes = "Retention: " + up.FromID.ToString() + " to Wet Detention: " + FromID.ToString();
            RoutingNotes += "<br/> Adjusted N Removal Efficiency (%): " + Nitrogen.ProvidedRemovalEfficiency.ToString("##.#");
            RoutingNotes += "<br/> Adjusted P Removal Efficiency (%): " + Phosphorus.ProvidedRemovalEfficiency.ToString("##.#");
        }

        public void CalculateNutrients()
        {
            // Then calculate the finals
            Nitrogen.Calculate();
            Phosphorus.Calculate();
        }

        public void CalculateOutletMassLoads(CatchmentRouting outlet)
        {
            //outlet.VolumeIn = VolumeOut;
            outlet.Nitrogen.TotalMassLoad += Nitrogen.DischargedLoad;
            outlet.Phosphorus.TotalMassLoad += Phosphorus.DischargedLoad;

            outlet.Nitrogen.TotalMassLoadLbYr = outlet.Nitrogen.TotalMassLoad * 2.2046;
            outlet.Phosphorus.TotalMassLoadLbYr = outlet.Phosphorus.TotalMassLoad * 2.2046;
        }

        #endregion

        #region "Save and Open as XML"
        public new void fromXML(String xml)
        {
            XmlDeserialize(xml);

            var doc = XDocument.Parse(xml);
        }
        #endregion

        // Add this static method to CatchmentRouting (near other calculations)

// Replace the existing CalculateDetentionInSeries implementation with this version.
// It computes per-node volumes (VolumeFromCatchment, VolumeFromUpstream, VolumeIn, VolumeOut, VolumeGW)
// and performs mass-balance on Nitrogen and Phosphorus (TotalMassLoad, DischargedLoad, RemovedLoad) while
// preserving the detention-series ART & efficiency calculations used by reports.
public static void CalculateDetentionInSeries(BMPTrainsProject project = null)
        {
            if (project == null) project = Globals.Project;
            if (project == null) return;

            project.RoutingMethod = BMPTrainsProject.routing_DetentionInSeries;

            // Reset relevant routing properties
            foreach (var kv in project.Catchments)
            {
                var r = kv.Value?.getRouting();
                if (r != null)
                {
                    // reset detention-specific props and routing volumes/loads
                    r.SeriesART = 0;
                    r.CumulativeRunoff = 0;
                    r.TotalARTForCatchment = 0;
                    r.DetentionTNEfficiency = 0;
                    r.DetentionTPEfficiency = 0;
                    r.TNRemovedDetention = 0;
                    r.TPRemovedDetention = 0;
                    r.ARTAllocationBreakdown = "";
                    r.VolumeFromCatchment = 0;
                    r.VolumeFromUpstream = 0;
                    r.VolumeIn = 0;
                    r.VolumeOut = 0;
                    r.VolumeIntoMedia = 0;
                    r.VolumeGW = 0;
                    if (r.Nitrogen != null)
                    {
                        r.Nitrogen.PreMassLoadCatchment = 0;
                        r.Nitrogen.PostMassLoadCatchment = 0;
                        r.Nitrogen.UpstreamPostMassLoad = 0;
                        r.Nitrogen.TotalMassLoad = 0;
                    }
                    if (r.Phosphorus != null)
                    {
                        r.Phosphorus.PreMassLoadCatchment = 0;
                        r.Phosphorus.PostMassLoadCatchment = 0;
                        r.Phosphorus.UpstreamPostMassLoad = 0;
                        r.Phosphorus.TotalMassLoad = 0;
                    }
                }
            }

            int[] order = project.GetRoutingInOrder();
            if (order == null || order.Length == 0) return;

            // Pass 1: compute series ART and cumulative runoffs per basin (arrays indexed by order index)
            double[] seriesARTs = new double[order.Length];
            double[] cumRunoffs = new double[order.Length];
            double currentCumRunoff = 0.0;

            for (int i = 0; i < order.Length; i++)
            {
                var c = project.getCatchment(order[i]);
                if (c == null) { seriesARTs[i] = 0; cumRunoffs[i] = currentCumRunoff; continue; }

                double basinRunoff = 0.0;
                double basinPPV = 0.0;

                try
                {
                    var wd = c.getWetDetention();
                    basinRunoff = wd?.RunoffVolume ?? 0.0;
                    basinPPV = wd?.PermanentPoolVolume ?? 0.0;
                }
                catch { basinRunoff = 0.0; basinPPV = 0.0; }

                currentCumRunoff += basinRunoff;
                cumRunoffs[i] = currentCumRunoff;

                seriesARTs[i] = (currentCumRunoff > 0.0) ? (basinPPV * 365.0) / currentCumRunoff : 0.0;

                // store per-node quick values (SeriesART = basin's series ART; CumulativeRunoff)
                var rnode = project.getCatchment(order[i]).getRouting();
                if (rnode != null)
                {
                    rnode.SeriesART = seriesARTs[i];
                    rnode.CumulativeRunoff = cumRunoffs[i];
                }
            }

            // Pass 2: process nodes in routing order (upstream -> downstream), compute volumes and mass balances
            for (int i = 0; i < order.Length; i++)
            {
                var c = project.getCatchment(order[i]);
                if (c == null) continue;
                var r = c.getRouting();
                if (r == null) continue;

                // Volume from this catchment (wet detention runoff)
                double myRunoff = 0.0;
                try { myRunoff = c.getWetDetention().RunoffVolume; } catch { myRunoff = 0.0; }
                r.VolumeFromCatchment = myRunoff;

                // Compute upstream contributions (only earlier nodes in order can be upstream)
                double upstreamVol = 0.0;
                double upstreamNLoad = 0.0;
                double upstreamPLoad = 0.0;

                for (int k = 0; k < i; k++)
                {
                    int upId = order[k];
                    var upCatch = project.getCatchment(upId);
                    if (upCatch == null) continue;
                    var upRouting = upCatch.getRouting();
                    if (upRouting == null) continue;

                    // Include only if that upstream routing actually routes to this node
                    if (upRouting.ToID == r.FromID)
                    {
                        upstreamVol += upRouting.VolumeOut;
                        upstreamNLoad += (upRouting.Nitrogen != null ? upRouting.Nitrogen.DischargedLoad : 0.0);
                        upstreamPLoad += (upRouting.Phosphorus != null ? upRouting.Phosphorus.DischargedLoad : 0.0);
                    }
                }

                r.VolumeFromUpstream = upstreamVol;
                r.VolumeIn = r.VolumeFromCatchment + r.VolumeFromUpstream;

                // Set provided removal efficiencies from the WetDetention BMP if present
                WetDetention wdBmp = null;
                try { wdBmp = c.getWetDetention(); } catch { wdBmp = null; }

                r.Nitrogen.ProvidedRemovalEfficiency = wdBmp?.ProvidedNTreatmentEfficiency ?? r.Nitrogen.ProvidedRemovalEfficiency;
                r.Phosphorus.ProvidedRemovalEfficiency = wdBmp?.ProvidedPTreatmentEfficiency ?? r.Phosphorus.ProvidedRemovalEfficiency;

                // Update mass load inputs
                r.Nitrogen.PreMassLoadCatchment = c.PreNLoading;
                r.Phosphorus.PreMassLoadCatchment = c.PrePLoading;

                r.Nitrogen.PostMassLoadCatchment = c.PostNLoading;
                r.Phosphorus.PostMassLoadCatchment = c.PostPLoading;

                r.Nitrogen.UpstreamPostMassLoad = upstreamNLoad;
                r.Phosphorus.UpstreamPostMassLoad = upstreamPLoad;

                r.Nitrogen.TotalMassLoad = r.Nitrogen.PostMassLoadCatchment + r.Nitrogen.UpstreamPostMassLoad;
                r.Phosphorus.TotalMassLoad = r.Phosphorus.PostMassLoadCatchment + r.Phosphorus.UpstreamPostMassLoad;

                // Hydraulic routing
                r.CalculateVolumeOut(); // sets VolumeOut, VolumeIntoMedia, VolumeGW

                // Nutrient mass-balance using RoutingParameters (calculates DischargedLoad, RemovedLoad, etc.)
                r.Nitrogen.Calculate();
                r.Phosphorus.Calculate();

                // Compute total ART experienced and efficiencies (using precomputed seriesARTs/cumRunoffs)
                double totalART = 0.0;
                var breakdownParts = new List<string>();
                for (int j = i; j < order.Length; j++)
                {
                    double cumulativeRunoff_j = cumRunoffs[j];
                    if (cumulativeRunoff_j <= 0.0) continue;

                    double share = (myRunoff / cumulativeRunoff_j);
                    double allocatedART = seriesARTs[j] * share;
                    totalART += allocatedART;

                    int contribId = order[j];
                    breakdownParts.Add($"Basin {contribId}: {allocatedART:F2}d");
                }

                r.TotalARTForCatchment = totalART;
                r.ARTAllocationBreakdown = string.Join("<br/>", breakdownParts);

                // Efficiency regressions (same as reporting logic)
                double tnEff = (totalART > 0.0) ? (9.335 * Math.Log(totalART) + 6.762) : 0.0;
                double tpEff = (totalART > 0.0) ? (7.449 * Math.Log(totalART) + 38.928) : 0.0;

                r.DetentionTNEfficiency = Math.Max(0.0, Math.Min(100.0, tnEff));
                r.DetentionTPEfficiency = Math.Max(0.0, Math.Min(100.0, tpEff));

                // Removed mass computed from post catchment load (consistent with report convention)
                r.TNRemovedDetention = c.PostNLoading * (r.DetentionTNEfficiency / 100.0);
                r.TPRemovedDetention = c.PostPLoading * (r.DetentionTPEfficiency / 100.0);

                // store VolumeFromCatchment already set above; VolumeFromUpstream/VolumeIn/VolumeOut/VolumeGW set too
            }

            // Build outlet totals by summing discharged loads for nodes that route to outlet (ToID == 0)
            var outlet = project.getRoutingOutlet();
            outlet.resetCatchmentRouting();

            foreach (KeyValuePair<int, Catchment> kvp in project.Catchments)
            {
                var cr = kvp.Value.getRouting();
                if (cr != null && cr.ToID == 0)
                {
                    cr.CalculateOutletMassLoads(outlet);
                }
            }

            // Project totals (catchment post loads remain from catchments)
            double totalCatchmentN = 0.0;
            double totalCatchmentP = 0.0;
            for (int i = 1; i <= project.numCatchments; i++)
            {
                var cc = project.getCatchment(i);
                if (cc == null) continue;
                totalCatchmentN += cc.PostNLoading;
                totalCatchmentP += cc.PostPLoading;
            }

            project.TotalCatchmentNLoad = totalCatchmentN;
            project.TotalCatchmentPLoad = totalCatchmentP;

            project.TotalOutletNLoad = Math.Max(0.0, outlet.Nitrogen.TotalMassLoad);
            project.TotalOutletPLoad = Math.Max(0.0, outlet.Phosphorus.TotalMassLoad);

            // System treatment efficiencies (based on routing outlet mass)
            if (project.TotalCatchmentNLoad > 0)
                project.CalculatedNTreatmentEfficiency = 100.0 * (project.TotalCatchmentNLoad - project.TotalOutletNLoad) / project.TotalCatchmentNLoad;
            else
                project.CalculatedNTreatmentEfficiency = 0.0;

            if (project.TotalCatchmentPLoad > 0)
                project.CalculatedPTreatmentEfficiency = 100.0 * (project.TotalCatchmentPLoad - project.TotalOutletPLoad) / project.TotalCatchmentPLoad;
            else
                project.CalculatedPTreatmentEfficiency = 0.0;

            // Populate outlet routing totals (mirror previous behavior)
            outlet.Nitrogen.TotalMassLoadLbYr = outlet.Nitrogen.TotalMassLoad * 2.2046;
            outlet.Phosphorus.TotalMassLoadLbYr = outlet.Phosphorus.TotalMassLoad * 2.2046;
            project.outlet = outlet;
        }
    }
}

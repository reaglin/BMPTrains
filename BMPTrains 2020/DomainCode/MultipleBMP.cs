using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class MultipleBMP :Storage
    {
        public static string case_RetentionToWetDetention = "Retention to Wet Detention";
        public static string case_RetentionInSeries = "Retention in Series";
        public static string case_WetDetentionInSeries = "Wet Detention in Series";
        public static string case_DetentionToHarvesting = "Wet Detention to Stormwater Harvesting";
        public static string case_Generic = "Generic Multiple BMP";

        public string ScenarioCase { get; set; }

        #region "Properties"
        public BMP bmp1;
        public BMP bmp2;
        public BMP bmp3;
        public BMP bmp4;
        public BMP cBMP; // Used for combining retention systems

        public int RetentionCount { get; set; }
        #endregion

        #region "Constructors"
        public MultipleBMP(Catchment c) : base(c)
        {
            RetentionCount = 0;
            RunoffVolume = c.PostRunoffVolume;
            BMPType = BMPTrainsProject.sMultipleBMP;
            bmp1 = new BMP(c); bmp1.BMPType = c.BMP1;
            bmp2 = new BMP(c); bmp2.BMPType = c.BMP2;
            bmp3 = new BMP(c); bmp3.BMPType = c.BMP3;
            bmp4 = new BMP(c); bmp4.BMPType = c.BMP4;

            cBMP = new Retention(c);
            cBMP.SetValuesFromCatchment(c);
        }

        public void AddBMP(int i, BMP bmp)
        {
            if (i == 1) bmp1 = bmp;
            if (i == 2) bmp2 = bmp;
            if (i == 3) bmp3 = bmp;
            if (i == 4) bmp4 = bmp;
        }
        #endregion

        #region "Determine Special Cases and Helper Methods"
        public void DetermineScenarioCase()
        {
            // Determine the scenario case for reporting purposes

            // If all BMPs are retention
            if (isRetention())
            {
                ScenarioCase = case_RetentionInSeries;
                return;
            }
            if (IsRetentionToWetDetention())
            {
                ScenarioCase = case_RetentionToWetDetention;
                return;
            }


            ScenarioCase =  case_Generic;

        }

        public BMP getBMP(int bmpID)
        {
            if (bmpID == 4) return bmp4;
            if (bmpID == 3) return bmp3;
            if (bmpID == 2) return bmp2;
            return bmp4;
        }

        public bool bmpExists(int i)
        {
            if (i == 1) return bmp1.isDefined();
            if (i == 2) return bmp2.isDefined();
            if (i == 3) return bmp3.isDefined();
            if (i == 4) return bmp4.isDefined();
            return false;
        }

        public override bool isDefined()
        {
            try
            {
                if (bmp1 != null && !string.IsNullOrWhiteSpace(bmp1.BMPType) && bmp1.BMPType != BMPTrainsProject.sNone) return true;
                if (bmp2 != null && !string.IsNullOrWhiteSpace(bmp2.BMPType) && bmp2.BMPType != BMPTrainsProject.sNone) return true;
                if (bmp3 != null && !string.IsNullOrWhiteSpace(bmp3.BMPType) && bmp3.BMPType != BMPTrainsProject.sNone) return true;
                if (bmp4 != null && !string.IsNullOrWhiteSpace(bmp4.BMPType) && bmp4.BMPType != BMPTrainsProject.sNone) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        // If any bmp in the sereis is retention, it has retention
        public override bool hasRetention()
        {
            if (bmp1 != null && bmp1.isRetention()) return true;
            if (bmp2 != null && bmp2.isRetention()) return true;
            if (bmp3 != null && bmp3.isRetention()) return true;
            if (bmp4 != null && bmp4.isRetention()) return true;

            return false;
        }



        // The last retention BMP in the series (contiguous retention from the start).
        // Returns 0 if the first BMP is not retention (or no retention present).
        private int LastRetention()
        {
            BMP[] bmps = new BMP[] { bmp1, bmp2, bmp3, bmp4 };
            int lastRetention = 0;

            for (int i = 0; i < bmps.Length; i++)
            {
                var b = bmps[i];
                // stop if no BMP defined at this position
                if (b == null || !b.isDefined()) break;

                // if defined but not retention, we stop and do not count further
                if (!b.isRetention()) break;

                // defined and retention -> update lastRetention
                lastRetention = i + 1;
            }

            return lastRetention;
        }

        // isRetention means all BMPs are retention types, this is because if the type is sNone, then there 
        // are no more BMPs used in the series.  As soon as a non-retention BMP is found, the system is not retention
        // isRetention means the series is a retention-only train:
        // - at least one BMP is defined, AND
        // - every defined BMP (from the first) is a retention, with no non-retention defined before a gap.
        public override bool isRetention()
        {
            BMP[] bmps = new BMP[] { bmp1, bmp2, bmp3, bmp4 };
            bool anyDefined = false;

            for (int i = 0; i < bmps.Length; i++)
            {
                var b = bmps[i];
                if (b == null || !b.isDefined())
                {
                    // empty slot -> end of series (valid); if we never saw a defined BMP, not retention
                    break;
                }

                anyDefined = true;

                if (!b.isRetention())
                {
                    // a defined but non-retention BMP -> series is not a retention-only train
                    return false;
                }
            }

            return anyDefined; // true only if at least one BMP defined and all defined ones were retention
        }

        // Returns true when the system "starts with" retention:
        // - it returns the isRetention() of the first defined BMP (i.e. first non-empty position must be retention).
        // - returns false if no BMPs are defined.
        public bool isRetentionUpstream()
        {
            BMP[] bmps = new BMP[] { bmp1, bmp2, bmp3, bmp4 };
            foreach (var b in bmps)
            {
                if (b == null) continue;
                if (b.isDefined())
                {
                    return b.isRetention();
                }
            }
            return false;
        }

        public bool IsRetentionToWetDetention(bool requireUpstreamRetention = true)
        {
            BMP[] bmps = new BMP[] { bmp1, bmp2, bmp3, bmp4 };

            // find last defined BMP index
            int lastIndex = -1;
            for (int i = 0; i < bmps.Length; i++)
            {
                if (bmps[i] != null && bmps[i].isDefined())
                    lastIndex = i;
            }
            if (lastIndex < 0) return false; // no BMPs defined

            // last must be wet detention
            var lastBmp = bmps[lastIndex];
            if (!(lastBmp is WetDetention) && lastBmp.BMPType != BMPTrainsProject.sWetDetention) return false;

            // ensure train is contiguous and all upstream defined BMPs are retention
            for (int i = 0; i < lastIndex; i++)
            {
                var b = bmps[i];
                if (b == null || !b.isDefined()) return false; // gap -> reject (or change behaviour if gaps allowed)
                if (!b.isRetention()) return false; // upstream must be retention
            }

            if (requireUpstreamRetention && lastIndex == 0) return false;

            return true;
        }

        private static readonly Dictionary<Type, string[]> _inputVariablesCache = new Dictionary<Type, string[]>();

        public static string[] GetInputVariablesForBmp(BMP bmp)
        {
            if (bmp == null) return new string[0];
            return GetInputVariablesForType(bmp.GetType());
        }

        private static string[] GetInputVariablesForType(Type t)
        {
            return GetVariablesForType(t, "InputVariables");

        }

        // Different BMP Types have different definition for InputVariables
        // Defined as a public static new string[] InputVariables property  
        private static string[] GetVariablesForType(Type t, string name)
        {
            if (t == null) return new string[0];

            lock (_inputVariablesCache)
            {
                if (_inputVariablesCache.TryGetValue(t, out var cached)) return cached;
            }

            Type cur = t;
            while (cur != null && cur != typeof(object))
            {
                // look for a public static field named "InputVariables"
                var fi = cur.GetField(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (fi != null && fi.FieldType == typeof(string[]))
                {
                    var value = fi.GetValue(null) as string[] ?? new string[0];
                    lock (_inputVariablesCache) { _inputVariablesCache[t] = value; }
                    return value;
                }

                // also support a public static property named "InputVariables"
                var pi = cur.GetProperty(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (pi != null && pi.PropertyType == typeof(string[]))
                {
                    var value = pi.GetValue(null, null) as string[] ?? new string[0];
                    lock (_inputVariablesCache) { _inputVariablesCache[t] = value; }
                    return value;
                }

                cur = cur.BaseType;
            }

            lock (_inputVariablesCache) { _inputVariablesCache[t] = new string[0]; }
            return new string[0];
        }
        #endregion

        #region "Calculate Methods"
        public new void Calculate()
        {

            // Special cases are handled separately. 
            DetermineScenarioCase();


            //
            // Special Case: All bmp in series are retention 
            //

            if (ScenarioCase == case_RetentionInSeries)
            {
                CalculateRetentionInSeries();
                return;
            }

            //
            // Special Case Wet Detention to Stormwater Harvesting (possibly following a retention system)
            //

            if (CalculateDetentionToHarvesting()) return;


            //
            //  Spcial Case Retention to Wet Detention  
            //

            if (ScenarioCase == case_RetentionToWetDetention)
            {
                CalculateRetentionToWetDetention();
                return;
            }

            int lastRetentionBMPId = CalculateRetention();
            int lastBMPId = lastRetentionBMPId;

            // Retention Can Route to WetDetention

            if ((lastRetentionBMPId == 1) && (bmp2.BMPType == BMPTrainsProject.sWetDetention)) { RouteRetentionToWetDetention(bmp1, bmp2); lastBMPId++; }
            if ((lastRetentionBMPId == 2) && (bmp3.BMPType == BMPTrainsProject.sWetDetention)) { RouteRetentionToWetDetention(bmp2, bmp3); lastBMPId++; }
            if ((lastRetentionBMPId == 3) && (bmp4.BMPType == BMPTrainsProject.sWetDetention)) { RouteRetentionToWetDetention(bmp3, bmp4); lastBMPId++; }


            // After Retention (or not) multiple Wet Detention can route to each other
            if ((bmp1.BMPType == BMPTrainsProject.sWetDetention) && (bmp2.BMPType == BMPTrainsProject.sWetDetention)) { lastBMPId = RouteWetDetentionToWetDetention(1);  }
            if ((bmp2.BMPType == BMPTrainsProject.sWetDetention) && (bmp3.BMPType == BMPTrainsProject.sWetDetention)) { lastBMPId = RouteWetDetentionToWetDetention(2);  }
            if ((bmp3.BMPType == BMPTrainsProject.sWetDetention) && (bmp4.BMPType == BMPTrainsProject.sWetDetention)) { lastBMPId = RouteWetDetentionToWetDetention(3);  }

            // Retention routing to something other than Wet Detention
            if ((lastBMPId >= 1) && (bmp2.BMPType != BMPTrainsProject.sNone))
            {
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(bmp1.ProvidedNTreatmentEfficiency, bmp2.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(bmp1.ProvidedPTreatmentEfficiency, bmp2.ProvidedPTreatmentEfficiency);
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                if (bmp3.BMPType == BMPTrainsProject.sNone) return;
            }

            if ((lastBMPId >= 2) && (bmp3.BMPType != BMPTrainsProject.sNone))
            {
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp3.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp3.ProvidedPTreatmentEfficiency);
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                if (bmp4.BMPType == BMPTrainsProject.sNone) return;
            }
            if ((lastBMPId >= 3) && (bmp4.BMPType != BMPTrainsProject.sNone))
            {
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp4.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp4.ProvidedPTreatmentEfficiency);
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                return;
            }

            // All other scenarios

            CalculateMassLoadReductionsTraditional();

            CalculateMassLoading();

            CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);
        }

        // This calculates the BMP overall if every BMP is Retention
        public void CalculateRetentionInSeries()
        {
            double d = CalculateSeriesRetentionTreatmentEfficiency();
            HydraulicCaptureEfficiency = d;
            ProvidedNTreatmentEfficiency = d;
            ProvidedPTreatmentEfficiency = d;
            RechargeRate = RunoffVolume * 0.3258724 * HydraulicCaptureEfficiency / 100;
            CalculateRetentionGroundwaterTreatmentEfficiency();

            // cBMP is the combined retention BMP and is used
            // to route to other BMP types as a single BMP

            cBMP.RetentionDepth = CalculateEquivalentRetentionDepth();
            cBMP.Calculate();
        }

        public bool CalculateDetentionToHarvesting()
        {
            // Wet Detention to Stormwater Harvesting (common case)
            if ((bmp1.BMPType == BMPTrainsProject.sWetDetention)
                   && (bmp2.BMPType == BMPTrainsProject.sStormwaterHarvesting))
            {
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(bmp1.ProvidedNTreatmentEfficiency, bmp2.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(bmp1.ProvidedPTreatmentEfficiency, bmp2.ProvidedPTreatmentEfficiency);
                HydraulicCaptureEfficiency = bmp2.ProvidedNTreatmentEfficiency;
                BMPVolumeOut = BMPVolumeIn * HydraulicCaptureEfficiency / 100;
                RunoffVolume = BMPVolumeIn * HydraulicCaptureEfficiency / 100;
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                // For situations where there are additional BMP's after the Detention to Stormwater Harvesting Scenario

                if (bmp3.BMPType == BMPTrainsProject.sNone) return true;

                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp3.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp3.ProvidedPTreatmentEfficiency);

                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);
                HydraulicCaptureEfficiency = bmp3.ProvidedNTreatmentEfficiency;
                BMPVolumeOut = BMPVolumeIn * HydraulicCaptureEfficiency / 100;
                RunoffVolume = BMPVolumeIn * HydraulicCaptureEfficiency / 100;
                if (bmp4.BMPType == BMPTrainsProject.sNone) return true;

                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp4.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp4.ProvidedPTreatmentEfficiency);

                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);
                HydraulicCaptureEfficiency = bmp4.ProvidedNTreatmentEfficiency;
                BMPVolumeOut = BMPVolumeIn * HydraulicCaptureEfficiency / 100;
                RunoffVolume = BMPVolumeIn * HydraulicCaptureEfficiency / 100;
                return true;
            }

            // The opther case is retention to detention to Stormwater Harvesting

            if (bmp1.isRetention()
                && (bmp2.BMPType == BMPTrainsProject.sWetDetention)
                    && (bmp3.BMPType == BMPTrainsProject.sStormwaterHarvesting))
            {
                RouteRetentionToWetDetention(bmp1, bmp2);
                RouteThisToStormwaterHarvesting(bmp3);

                return true;
            }

            if ((bmp1.BMPType == BMPTrainsProject.sWetDetention)
                && (bmp2.BMPType == BMPTrainsProject.sWetDetention)
                    && (bmp3.BMPType == BMPTrainsProject.sStormwaterHarvesting)) {

                RouteWetDetentionToWetDetention(2);
                RouteThisToStormwaterHarvesting(bmp3);
                return true;
            }

            if ((bmp1.BMPType == BMPTrainsProject.sWetDetention)
                && (bmp2.BMPType == BMPTrainsProject.sWetDetention)
                    && (bmp3.BMPType == BMPTrainsProject.sWetDetention)
                        && (bmp4.BMPType == BMPTrainsProject.sStormwaterHarvesting))
            {

                RouteWetDetentionToWetDetention(3);
                RouteThisToStormwaterHarvesting(bmp4);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates the Traditional Mass Loading reductions across a chain of up to four BMPs.
        /// </summary>
        /// <remarks>
        /// This method processes BMPs sequentially from <c>bmp1</c> to <c>bmp4</c>.
        /// The mass load output of one BMP becomes the mass load input of the next.
        /// The overall treatment efficiency for Nitrogen (N) and Phosphorus (P) 
        /// is updated after each defined BMP is processed, calculating the cumulative 
        /// efficiency from the initial <c>bmp1</c> input to the current BMP's output.
        /// The calculation chain stops immediately if an undefined BMP is encountered.
        /// </remarks>
        private void CalculateMassLoadReductionsTraditional()
        {
            // Create an array/list of the four Bmp objects to iterate over
            BMP[] bmps = new BMP[] { this.bmp1, this.bmp2, this.bmp3, this.bmp4 };

            // Store the initial mass load from the first defined BMP to use in the final efficiency calculation
            double initialNLoad = 0.0;
            double initialPLoad = 0.0;

            // Tracks the output from the previous BMP to be used as the input for the current BMP
            double previousNLoadOut = 0.0;
            double previousPLoadOut = 0.0;

            // Iterate over the BMPs
            for (int i = 0; i < bmps.Length; i++)
            {
                BMP currentBmp = bmps[i];

                if (currentBmp.isDefined())
                {
                    if (i == 0) // Special case for bmp1
                    {
                        // bmp1 always sets its own input, so we just calculate reductions directly.
                        CalculateMassLoadReductions(currentBmp);

                        // Store initial loads for the final efficiency calculation (used in the provided code logic)
                        initialNLoad = currentBmp.BMPNMassLoadIn;
                        initialPLoad = currentBmp.BMPPMassLoadIn;

                        // Set the efficiencies based only on bmp1
                        ProvidedNTreatmentEfficiency = currentBmp.ProvidedNTreatmentEfficiency;
                        ProvidedPTreatmentEfficiency = currentBmp.ProvidedPTreatmentEfficiency;
                    }
                    else // Logic for bmp2, bmp3, and bmp4 (chaining)
                    {
                        // The current BMP's input is the previous BMP's output
                        currentBmp.BMPNMassLoadIn = previousNLoadOut;
                        currentBmp.BMPPMassLoadIn = previousPLoadOut;

                        // Calculate reductions for the current BMP
                        CalculateMassLoadReductions(currentBmp);

                        // Calculate overall efficiency from the original input (bmp1.BMPNMassLoadIn)
                        // to the current BMP's output (currentBmp.BMPNMassLoadOut)
                        // Note: We use initialNLoad/initialPLoad for the denominator to avoid division by zero
                        if (initialNLoad != 0.0)
                        {
                            ProvidedNTreatmentEfficiency = 100 * (initialNLoad - currentBmp.BMPNMassLoadOut) / initialNLoad;
                        }
                        if (initialPLoad != 0.0)
                        {
                            ProvidedPTreatmentEfficiency = 100 * (initialPLoad - currentBmp.BMPPMassLoadOut) / initialPLoad;
                        }
                    }

                    // Update the 'previous' output loads for the next iteration
                    previousNLoadOut = currentBmp.BMPNMassLoadOut;
                    previousPLoadOut = currentBmp.BMPPMassLoadOut;

                    // Recalculate mass loading (this function call appears after every step in the original code)
                    CalculateMassLoading(false);
                }
                else // Stop calculation chain if an undefined BMP is encountered
                {
                    // Since the logic relies on chaining, we can break the loop when an undefined BMP is hit.
                    // Any subsequent BMPs (like bmp3 if bmp2 is undefined) will also be ignored,
                    // which maintains the cascading behavior of the original nested IFs.
                    break;
                }
            }
        }

        public void CalculateRetentionGroundwaterTreatmentEfficiency()
        {

        }

        /// <summary>
        /// Determines if the overall system (or "train") is a Retention System.
        /// </summary>
        /// <remarks>
        /// The system is considered retention if, and only if, the 
        /// <c>isRetention</c> method returns <c>true</c> for the 
        /// <strong class="key-concept">last defined BMP object</strong> in the sequence (<c>bmp1</c> through <c>bmp4</c>).
        /// <para>If no BMP objects are defined (i.e., all equal <c>BMPTrainsProject.sNone</c>), 
        /// the system is not considered a retention system, and the method returns <c>false</c>.</para>
        /// </remarks>
        /// <returns><c>true</c> if the last defined BMP is a retention type; otherwise, <c>false</c>.</returns>


        public override void CalculateCost()
        {
            ResetCost();

            if (bmpExists(1)) AddCost(bmp1);
            if (bmpExists(2)) AddCost(bmp2);
            if (bmpExists(3)) AddCost(bmp3);
            if (bmpExists(4)) AddCost(bmp4);

            if (NMassReductionLb != 0 && Globals.Project.ProjectDuration != 0) CostPerPoundNRemoved = PresentWorth / (NMassReductionLb * Globals.Project.ProjectDuration);
            if (PMassReductionLb != 0 && Globals.Project.ProjectDuration != 0) CostPerPoundPRemoved = PresentWorth / (PMassReductionLb * Globals.Project.ProjectDuration);
        }


        public double CalculateSeriesRetentionTreatmentEfficiency()
        {
            RetentionDepth = CalculateEquivalentRetentionDepth(); // Retention Depth

            // These values come from the Catchment
            double NDCIACN = WatershedNDCIACurveNumber;     // Non Directly connected CN
            double DCIAP = WatershedDCIAPercent;            // Directly Connected Impervious Area Perccent
            RetentionVolume = RetentionDepth * ContributingArea / 12;       // Acre-feet
            if ((RainfallZone == "") || (RainfallZone == null)) return 0.0;

                // These are all in %
            double t = RetentionEfficiencyLookupTables.CalculateEfficiency(RetentionDepth,
                                                                           NDCIACN,
                                                                           DCIAP,
                                                                           RainfallZone);

                return t;
        }

        public double CalculateGroundwaterNMassDischarge(double RetentionEfficiency)
        {
            GroundwaterNMassLoadIn = 
            GroundwaterNMassLoadOut = GroundwaterNMassLoadIn * (100 - RetentionEfficiency) / 100;
            return GroundwaterNMassLoadOut;
        }
        public double CalculateGroundwaterPMassDischarge(double RetentionEfficiency)
        {
            GroundwaterPMassLoadOut = BMPPMassLoadIn * (100 - RetentionEfficiency) / 100;
            return GroundwaterPMassLoadOut;
        }

        public double CalculateFlowWeightedGroundwaterTreatmentEfficiency(bool PhosphorousFlag = false)
        {
            double flowsum = 0;
            double weighted = 0;
            double GWTreatmentEfficiency = (PhosphorousFlag ? GroundwaterPTreatmentEfficiency : GroundwaterNTreatmentEfficiency);
            if (bmp1.isRetention())
            {
                flowsum += bmp1.BMPVolumeIn;
                weighted += (PhosphorousFlag ? bmp1.GroundwaterPTreatmentEfficiency : bmp1.GroundwaterNTreatmentEfficiency) * bmp1.BMPVolumeIn;
            }
            if (bmp2.isRetention())
            {
                flowsum += bmp2.BMPVolumeIn;
                weighted += (PhosphorousFlag ? bmp2.GroundwaterPTreatmentEfficiency : bmp2.GroundwaterNTreatmentEfficiency) * bmp2.BMPVolumeIn;
            }
            if (bmp3.isRetention())
            {
                flowsum += bmp3.BMPVolumeIn;
                weighted += (PhosphorousFlag ? bmp3.GroundwaterPTreatmentEfficiency : bmp3.GroundwaterNTreatmentEfficiency) * bmp3.BMPVolumeIn;
            }
            if (bmp4.isRetention())
            {
                flowsum += bmp4.BMPVolumeIn;
                weighted += (PhosphorousFlag ? bmp4.GroundwaterPTreatmentEfficiency : bmp4.GroundwaterNTreatmentEfficiency) * bmp4.BMPVolumeIn;
            }

            
            if (flowsum == 0) return 0;
            GWTreatmentEfficiency = weighted / flowsum;
            if (PhosphorousFlag)
            {
                MediaNPercentReduction = GWTreatmentEfficiency;
            }
            else
            {
                MediaPPercentReduction = GWTreatmentEfficiency;
            }
            return GWTreatmentEfficiency;
        }


        public override double GroundwaterNLoading()
        {
            // What is coming IN to Groundwater
             return GroundwaterNMassLoadIn;
        }

        public override double GroundwaterPLoading()
        {
            return GroundwaterPMassLoadIn;
        }

        public override double GroundwaterNRemoval()
        {
            // This would require media removal
            return GroundwaterNMassLoadIn - GroundwaterNMassLoadOut;
        }

        public override double GroundwaterPRemoval()
        {
            // This would require media removal
            return GroundwaterPMassLoadIn - GroundwaterPMassLoadOut;
        }

        public override double GroundwaterNRemovalEfficiency()
        {
            if (GroundwaterNMassLoadIn == 0) return 0;
            if (isRetention()) return bmp1.MediaNPercentReduction;

            return 100 * (GroundwaterNMassLoadIn - GroundwaterNMassLoadOut) / GroundwaterNMassLoadIn; 
        }
        public override double GroundwaterPRemovalEfficiency()
        {
            if (GroundwaterPMassLoadIn == 0) return 0;
            if (isRetention()) return bmp1.MediaPPercentReduction;

            return 100 * (GroundwaterPMassLoadIn - GroundwaterPMassLoadOut) / GroundwaterPMassLoadIn;
        }


        private int RouteWetDetentionToWetDetention(int bmpID)
        {
            // bmpID is the ID 1-3 of the upstream Wet Detention Pond
            double PP = 0;  // Permanent Pool
            double RV = 0; // Runoff Volume
            int lastBMP = 0;

            // The entire idea is to calculate a cumulative Permanent Pool and route the Runovv Volume through the entire pool
            if (bmpID == 1)
            {
                lastBMP = 2;
                RV = ((WetDetention)bmp1).RunoffVolume;
                PP += ((WetDetention)bmp1).PermanentPoolVolume;
                PP += ((WetDetention)bmp2).PermanentPoolVolume;
                ProvidedNTreatmentEfficiency = ((WetDetention)bmp1).ProvidedNTreatmentEfficiency;
                ProvidedPTreatmentEfficiency = ((WetDetention)bmp1).ProvidedPTreatmentEfficiency;

                if (bmp3.BMPType == BMPTrainsProject.sWetDetention) { PP += ((WetDetention)bmp3).PermanentPoolVolume; lastBMP = 3; }
                if (bmp3.BMPType == BMPTrainsProject.sWetDetention) { PP += ((WetDetention)bmp3).PermanentPoolVolume; lastBMP = 4; }
            }

            if (bmpID == 2)
            {
                lastBMP = 3;
                RV = ((WetDetention)bmp2).RunoffVolume;
                PP += ((WetDetention)bmp2).PermanentPoolVolume;
                PP += ((WetDetention)bmp3).PermanentPoolVolume;
                if (bmp4.BMPType == BMPTrainsProject.sWetDetention) { PP += ((WetDetention)bmp4).PermanentPoolVolume; lastBMP = 4; }
            }

            if (bmpID == 3)
            {
                lastBMP = 4;
                RV = ((WetDetention)bmp3).RunoffVolume;
                PP += ((WetDetention)bmp3).PermanentPoolVolume;
                PP += ((WetDetention)bmp4).PermanentPoolVolume;
            }

            // Add the permanent pools and use to calculate overall residency.


            double NEff = 0.0;
            double PEff = 0.0;

            double RT = 0;
            if (RV == 0) return lastBMP;

            RT = PP / RV * 365;
            NEff = WetDetention.CalculateNitrogenRemoval(RT);
            PEff = WetDetention.CalculatePhosphorusRemoval(RT);
            ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, NEff);

            // This does the same thing for both scenarios

            ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, PEff);
            CalculateMassLoadReductions(this);
            return lastBMP;
        }

        private void CalculateRetentionToWetDetention()
        {
            // Find the last retention BMP
            int lastRetentionBMPId = LastRetention();
            if (lastRetentionBMPId == 0) return; // No retention found - should not happen here

            // Create the Combined Retention BMP (cBMP)
            cBMP.RetentionDepth = CalculateEquivalentRetentionDepth();
            cBMP.Calculate();

            if (lastRetentionBMPId == 1) { RouteRetentionToWetDetention(cBMP, bmp2); return; }
            if (lastRetentionBMPId == 2) { RouteRetentionToWetDetention(cBMP, bmp3); return; }
            if (lastRetentionBMPId == 3) { RouteRetentionToWetDetention(cBMP, bmp4); return; }
        }

        private void RouteRetentionToWetDetention(BMP up, BMP down)
        {
            // e is provided retention treatment efficiency
            double e = CalculateSeriesRetentionTreatmentEfficiency();
            up.NTreatmentEfficiencySeriesContribution = e;
            up.PTreatmentEfficiencySeriesContribution = e;
            up.NTreatmentEfficiencyStandalone = e;
            up.PTreatmentEfficiencyStandalone = e;

            up.BMPVolumeOut = RunoffVolume * e / 100; // This is retention calculation for Volume Out
            if (up.BMPVolumeOut != 0)
                ((WetDetention)down).EffectiveResidenceTime = ((WetDetention)down).PermanentPoolVolume / up.BMPVolumeOut * 365;

            ((WetDetention)down).Calculate(((WetDetention)down).EffectiveResidenceTime);

            // The current Wet Detention efficiency for standalone for N and P are stored in
            // DetentionPercentNitrogenRemoval and DetentionPercentPhosphorusRemoval 
            double DetentionNEff = ((WetDetention)down).DetentionPercentNitrogenRemoval;
            double DetentionPEff = ((WetDetention)down).DetentionPercentPhosphorusRemoval;
            down.NTreatmentEfficiencyStandalone = DetentionNEff;
            down.PTreatmentEfficiencyStandalone = DetentionPEff;

            // The Wet Detention Calculation gives us a standalone efficiency for wet detentions
            // 

            double tna = 10.0; // Temporary N Adjustment Factor
            double tpa = 20.0; // Temporary P Adjustment Factor
            down.NTreatmentEfficiencySeriesContribution = (100 - e) * ((DetentionNEff/100) - (tna/100)*(e / 100));
            down.PTreatmentEfficiencySeriesContribution = (100 - e) * ((DetentionPEff/100) - (tpa/100)*(e / 100));

            if (down.NTreatmentEfficiencySeriesContribution <= 0) down.NTreatmentEfficiencySeriesContribution = 0.0;
            if (down.PTreatmentEfficiencySeriesContribution <= 0) down.PTreatmentEfficiencySeriesContribution = 0.0;

            // The provided efficiency for the system is the sum of retention and detention efficiencies
            ProvidedNTreatmentEfficiency = e + down.NTreatmentEfficiencySeriesContribution;
            ProvidedPTreatmentEfficiency = e + down.PTreatmentEfficiencySeriesContribution;

            up.BMPNMassLoadOut = up.BMPNMassLoadIn * (100 - up.NTreatmentEfficiencySeriesContribution) / 100;
            up.BMPPMassLoadOut = up.BMPPMassLoadIn * (100 - up.PTreatmentEfficiencySeriesContribution) / 100;

            // Now calculate Mass Load reductions (for BMP)
            down.BMPNMassLoadIn = up.BMPNMassLoadOut;
            down.BMPPMassLoadIn = up.BMPPMassLoadOut;

            down.BMPNMassLoadOut = down.BMPNMassLoadIn * (100 - down.NTreatmentEfficiencySeriesContribution) / 100;
            down.BMPPMassLoadOut = down.BMPPMassLoadIn * (100 - down.PTreatmentEfficiencySeriesContribution) / 100;

            // Also Overall reduction in Mass Load 

            BMPNMassLoadOut = BMPNMassLoadIn * (100 - ProvidedNTreatmentEfficiency) / 100;
            BMPPMassLoadOut = BMPPMassLoadIn * (100 - ProvidedPTreatmentEfficiency) / 100;
        }

        private void CalculateMassLoadReductions(BMP bmp)
        {
            bmp.BMPNMassLoadOut = bmp.BMPNMassLoadIn * (100 - bmp.ProvidedNTreatmentEfficiency) / 100;
            bmp.BMPPMassLoadOut = bmp.BMPPMassLoadIn * (100 - bmp.ProvidedPTreatmentEfficiency) / 100;

            // 
            //if (!bmp.isRetention()) { 
            //    bmp.GroundwaterNMassLoadIn = bmp.BMPNMassLoadIn * bmp.CalculatedNTreatmentEfficiency / 100;
            //    bmp.GroundwaterPMassLoadIn = bmp.BMPPMassLoadIn * bmp.CalculatedPTreatmentEfficiency / 100;
            //}


        }

        private void RouteThisToStormwaterHarvesting(BMP bmp)
        {
            // Used when there are upstream systems that end in Stormwater Harvesting
            ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp.ProvidedNTreatmentEfficiency);
            ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp.ProvidedPTreatmentEfficiency);
            double AdditionalHydraulicCaptureEfficiency = bmp.ProvidedNTreatmentEfficiency;
            HydraulicCaptureEfficiency = CalculateAdjustedEfficiency(AdditionalHydraulicCaptureEfficiency, HydraulicCaptureEfficiency);
            BMPVolumeOut = BMPVolumeIn * (100 - HydraulicCaptureEfficiency) / 100;      
        }


        private int CalculateRetention()
        {
            // For retention based systems - treatment is simply the sum of retention depth
            // of the subsystems.

            // The first BMP must be retention for this to work, and then every subsequent
            // BMP must be retention
            // This function answers the last BMP that is retention

            // Retention Systems are treated as a single system

            RetentionCount = 0;
            if (bmp1.isRetention())
            {
                HydraulicCaptureEfficiency = CalculateSeriesRetentionTreatmentEfficiency();


                // First Calculate Retention based removal efficiency
                // if (RetentionDepth != 0) base.Calculate();

                RunoffVolume = RunoffVolume * (100 - HydraulicCaptureEfficiency) / 100;       // Runoff Volume that gets through the system

                CalculateGroundwaterDischarge();

            }

            return RetentionCount;
        }



        public override void CalculateGroundwaterDischarge()
        {
            // Works as the Sum of all retention
            HydraulicCaptureEfficiency = CalculateSeriesRetentionTreatmentEfficiency();

            // Overall Hydraulic Efficiency (System is treated as a single Unit)
            GroundwaterNMassLoadIn = BMPNMassLoadIn * HydraulicCaptureEfficiency / 100;
            GroundwaterPMassLoadIn = BMPPMassLoadIn * HydraulicCaptureEfficiency / 100;

            MediaNPercentReduction = bmp1.MediaNPercentReduction;
            MediaPPercentReduction = bmp1.MediaPPercentReduction;

            GroundwaterNMassLoadOut = GroundwaterNMassLoadIn * (100 - MediaNPercentReduction) / 100;
            GroundwaterPMassLoadOut = GroundwaterPMassLoadIn * (100 - MediaPPercentReduction) / 100;
        }

        /// <summary>
        /// Calculates the equivalent retention depth by summing the RetentionDepth 
        /// of all defined BMPs that are retention types.
        /// </summary>
        /// <remarks>
        /// The process stops immediately and returns the accumulated depth 
        /// if a defined BMP is encountered that is not a retention type.
        /// </remarks>
        /// <returns>A double representing the total equivalent retention depth.</returns>
        private double CalculateEquivalentRetentionDepth()
        {
            // Create an array/list of the four Bmp objects to iterate over
            BMP[] bmps = new BMP[] { this.bmp1, this.bmp2, this.bmp3, this.bmp4 };

            double RD = 0.0;

            foreach (var bmp in bmps)
            {
                if (bmp.isDefined())
                {
                    if (bmp.isRetention())
                    {
                        RD += bmp.RetentionDepth;
                    }
                    else
                    {
                        // This captures the original logic: return accumulated RD if a defined BMP is non-retention.
                        return RD;
                    }
                }
            }

            return RD;
        }

        public double CalculateAdjustedEfficiency(double e1, double e2)
        {
            // Not flow weighted
            return ((e1 / 100.0) + (e2 / 100.0) * (1 - (e1 / 100.0))) * 100.0;
        }



        #endregion

        #region "Reporting"

        public override string PrintBMPSummary(bool inputVariables = false, bool outputVariables = false)
        {
            string s= BMPType;
            if (bmp1.isDefined()) s += " 1: " + bmp1.BMPType;
            if (bmp2.isDefined()) s += " 2: " + bmp2.BMPType;
            if (bmp3.isDefined()) s += " 3: " + bmp3.BMPType;
            if (bmp4.isDefined()) s += " 4: " + bmp4.BMPType;

            return s;
        }

        public override string PrintBMPReport()
        {
            string s = "<h2>Multiple BMP in Series</h2>";
            s += PrintWatershedCharacteristics();
            s += SpecificBMPReport(1, bmp1);
            s += SpecificBMPReport(2, bmp2);
            s += SpecificBMPReport(3, bmp3);
            s += SpecificBMPReport(4, bmp4);

            s += PrintSurfaceWaterDischarge();

            if ((DoGroundwaterAnalysis == "Yes") || (MediaMixType != MediaMix.None)) s += PrintGroundwaterAnalysis();

            s += PrintLoadDiagram();
            return s;
        }

        public string SpecificBMPReport(int i, BMP bmp)
        {
            if (bmp == null) return string.Empty;
            if (!bmp.isDefined()) return string.Empty;

            // Base WetDetention input variables (safe-guard against null)
            string[] inputVariables = GetInputVariablesForBmp(bmp);

            // Extra series/detention-specific variables to append for retention->detention case
            string[] detentionVariables = {
                "NTreatmentEfficiencySeriesContribution",
                "PTreatmentEfficiencySeriesContribution",
                "EffectiveResidenceTime"
            };

            string[] retentionVariables = {
                "ProvidedPTreatmentEfficiency",
                "ProvidedPTreatmentEfficiency"
            };
            
            // When the scenario is Retention -> Wet Detention and this BMP is the wet detention,
            // concatenate the arrays so we print both the normal input variables and the series variables.
            string[] varsToPrint = inputVariables;
            if ((ScenarioCase == case_RetentionToWetDetention) && (bmp.BMPType == BMPTrainsProject.sWetDetention))
            {
                varsToPrint = inputVariables.Concat(detentionVariables).ToArray();
            }


            if (bmp.BMPType == BMPTrainsProject.sRetention)
            {
                varsToPrint = inputVariables.Concat(retentionVariables).ToArray();
            }


            // Print selected properties for this BMP
            string vars = bmp.PrintProperties(varsToPrint);
            if (string.IsNullOrWhiteSpace(vars)) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine("<h3>BMP in Series Number: " + i.ToString() + " (BMP Type: " + System.Security.SecurityElement.Escape(bmp.BMPType ?? "") + ")</h3>");
            sb.Append(vars);

            return sb.ToString();
        }

        public override string PrintBasicReport()
        {
            return AsHtmlTable(MReportLabels());
        }

        public Dictionary<string, string> MReportLabels()
        {
            return new Dictionary<string, string>
            {               
                {"WatershedArea", "Catchment Area (acres)"},
                {"WatershedNDCIACurveNumber", "Watershed Non-DCIA Curve Number"},
                {"WatershedDCIAPercent", "Watershed DCIA Percent"},
                {"RainfallZone", "Rainfall Zone"},
                {"RationalCoefficient", "Calculated Annual Coefficient (0-1)"},
                {"RetentionDepth", "Total (accumulated) Retention Depth (in over watershed)"},
                {"ProvidedNTreatmentEfficiency", "Overall Provided Nitrogen Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Overall Provided Phosphorus Treatment Efficiency (%)"},
                {"BMPNMassLoadOut", "Overall Nitrogen Load (kg/yr)"},
                {"BMPPMassLoadOut", "Overall Phosphorus Load (kg/yr)"}
            };
        }

        public override string getReport()
        {
            string s = "<h2>Combined Report of all BMP's</h2>";
            s += AsHtmlTable(MReportLabels()); 

            if (isRetention())
            {
                s += "<h1>Equivalent Retention</h1>";
                s += PrintEfficiencyReport();
                return s;
            }

            s += PrintEfficiencyReport();
            return s;
        }

        

        public override string PrintEfficiencyReport()
        {
            string s = "<br/><h2>Load for  Multiple BMP in Series</h2><br/>";
            s += "<table><tr>";         // 5 Cells per row
            // ***************************** Row 1 *****************************
            s += Common.TableCellReport("Load", false, "",
                new ReportMetric("N", BMPNMassLoadIn, "kg/yr", 2),
                new ReportMetric("P", BMPPMassLoadIn, "kg/yr", 2),
                new ReportMetric("Q", RunoffVolume, "ac-ft/yr", 2));
            s += Common.TableCellRightArrow();
            s += Common.TableCellReport("Treatment", true, "",
                new ReportMetric("N", ProvidedNTreatmentEfficiency, "%", 0),
                new ReportMetric("P", ProvidedPTreatmentEfficiency, "%", 0));
            s += Common.TableCellRightArrow();
            if (BMPNMassLoadOut == 0.0) BMPNMassLoadOut = (1 - ProvidedNTreatmentEfficiency / 100) * BMPNMassLoadIn;
            if (BMPPMassLoadOut == 0.0) BMPPMassLoadOut = (1 - ProvidedPTreatmentEfficiency / 100) * BMPPMassLoadIn;
            double SurfaceDischarge = (1 - ProvidedNTreatmentEfficiency / 100) * RunoffVolume;
            s += Common.TableCellReport("Surface Discharge", false, "",
                new ReportMetric("N", BMPNMassLoadOut, "kg/yr", 2),
                new ReportMetric("P", BMPPMassLoadOut, "kg/yr", 2),
                new ReportMetric("Q", SurfaceDischarge, "ac-ft/yr", 2));
            s += "</tr>";

            // ***************************** Row 2 *****************************
            s += "<tr>" + Common.TableCellBlank(2);
            s += Common.TableCellDownArrow(); // Assuming this returns a <td>
            s += Common.TableCellBlank(2) + "</tr>";

            // ***************************** Row 3 *****************************
            s += "<tr>" + Common.TableCellBlank(2);
            s += Common.TableCellReport("Mass Reduction", false, "",
                new ReportMetric("N", BMPNMassLoadIn - BMPNMassLoadOut, "kg/yr", 2),
                new ReportMetric("P", BMPPMassLoadIn - BMPPMassLoadOut, "kg/yr", 2),
                new ReportMetric("Q", RunoffVolume - SurfaceDischarge, "ac-ft/yr", 2));
            s += Common.TableCellBlank(2);
            s += "</tr>";

            if (Globals.Project.DoGroundwaterAnalysis == "Yes")
            {
                // Custom header row
                s += "<tr><td>Retention Only</td>" + Common.TableCellBlank() + "<td><h2>Groundwater</h2></td>" + Common.TableCellBlank() + "<td>Treated as System</td></tr>";

                // ***************************** Row 1 *****************************
                s += "<tr>";

                // 5. Retention Into Media (3 decimal places)
                s += Common.TableCellReport("Retention into Media", false, "",
                    new ReportMetric("N", GroundwaterNMassLoadIn, "kg/yr", 3),
                    new ReportMetric("P", GroundwaterPMassLoadIn, "kg/yr", 3));

                s += Common.TableCellBlank();

                // 6. Media GW Treatment (Border = true, Places = 0)
                s += Common.TableCellReport("Media GW Treatment", true, "",
                    new ReportMetric("N", MediaNPercentReduction, "%", 0),
                    new ReportMetric("P", MediaPPercentReduction, "%", 0));

                s += Common.TableCellRightArrow();

                // 7. Total GW Discharge (3 decimal places)
                s += Common.TableCellReport("Total GW Discharge", false, "",
                    new ReportMetric("N", GroundwaterNMassLoadOut, "kg/yr", 3),
                    new ReportMetric("P", GroundwaterPMassLoadOut, "kg/yr", 3));

                s += "</tr>";
                // ***************************** Row 2 *****************************
                // --- GW Down Arrow ---
                s += "<tr>" + Common.TableCellBlank(2);
                s += Common.TableCellDownArrow();
                s += Common.TableCellBlank(2) + "</tr>";

                // --- Retained Section ---
                NRetained = BMPNMassLoadIn - BMPNMassLoadOut - GroundwaterNMassLoadOut;
                PRetained = BMPPMassLoadIn - BMPPMassLoadOut - GroundwaterPMassLoadOut;

                s += "<tr>";
                // ***************************** Row 3 *****************************
                s += Common.TableCellBlank(2);

                // 8. Retained (3 decimal places)
                s += Common.TableCellReport("Retained", false, "",
                    new ReportMetric("N", NRetained, "kg/yr", 3),
                    new ReportMetric("P", PRetained, "kg/yr", 3));

                s += Common.TableCellBlank(2) + "</tr>";
            }
            s += "</table>";
            return s;
        }

        public string reportAnoxicDepth(int bmpID, double PRemoval)
        {
            WetDetention wd = (WetDetention)getBMP(bmpID);
            wd.CalculateAnoxicDepth(PRemoval);
            return wd.AnoxicDepthReport();
        }


        #endregion
    }
}

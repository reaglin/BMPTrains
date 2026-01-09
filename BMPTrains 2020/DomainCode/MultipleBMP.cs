using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class MultipleBMP :Storage
    {
        #region "Properties"
        public BMP bmp1;
        public BMP bmp2;
        public BMP bmp3;
        public BMP bmp4;

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
        }

        public void AddBMP(int i, BMP bmp)
        {
            if (i == 1) bmp1 = bmp;
            if (i == 2) bmp2 = bmp;
            if (i == 3) bmp3 = bmp;
            if (i == 4) bmp4 = bmp;
        }
        #endregion

        #region "Calculate"
        public BMP getBMP(int bmpID)
        {
            if (bmpID == 4) return bmp4;
            if (bmpID == 3) return bmp3;
            if (bmpID == 2) return bmp2;
            return bmp4;
        }


        public new void Calculate()
        {

            // lastRetentionBMPId will be the last Retention BMP
            // lastBMPId is the last BMP used in calculation

            //
           // Special Case: All bmp in series are retention 
           //

            if (CalculateAllRetention()) return;

            //
            // Special Case Wet Detention to Stormwater Harvesting (possibly following a retention system)
            //

            if (CalculateDetentionToHarvesting()) return;


            //
            //  Spcial Caase Retention to Wet Detention  
            //

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

        public bool CalculateAllRetention()
        {
            if (isRetention())
            {
                double d = CalculateEffectiveRetentionTreatmentEfficiency();
                ProvidedNTreatmentEfficiency = d;
                ProvidedPTreatmentEfficiency = d;
                RechargeRate = RunoffVolume * 0.3258724 * HydraulicCaptureEfficiency / 100;
                CalculateRetentionGroundwaterTreatmentEfficiency();
                return true;
            }
            return false;
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
        public override bool isRetention()
        {
            // If the last BMP is retention - system is retention - These means all types are retention
            if (bmp1.isRetention()) { if (bmp2.BMPType == BMPTrainsProject.sNone) return true; } else return false;
            if (bmp2.isRetention()) { if (bmp3.BMPType == BMPTrainsProject.sNone) return true; } else return false;
            if (bmp3.isRetention()) { if (bmp4.BMPType == BMPTrainsProject.sNone) return true; } else return false;
            if (bmp4.isRetention()) return true;

            return false;
        }

        public override bool hasRetention()
        {
            // If any bmp is retention, it has retention
            if (bmp1.isRetention()) return true;
            if (bmp2.isRetention()) return true;
            if (bmp3.isRetention()) return true;
            if (bmp4.isRetention()) return true;

            return false;
        }

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


        public double CalculateEffectiveRetentionTreatmentEfficiency()
        {
            RetentionDepth = getEquivalentRetentionDepth();      // Retention Depth
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

        private void RouteRetentionToWetDetention(BMP up, BMP down)
        {
            double rt = 0.0;    // Adjusted Residence time based on incoming flow difference due to removal

            // e is provided retention treatment efficiency
            double e = CalculateEffectiveRetentionTreatmentEfficiency();
            up.BMPVolumeOut = up.BMPVolumeIn * e / 100; // This is retention calculation for VOlume Out
            if (((Storage)up).BMPVolumeOut != 0) rt = ((WetDetention)down).PermanentPoolVolume / ((Storage)up).BMPVolumeOut * 365;
            ((WetDetention)down).Calculate(rt);

            // The current Wet Detention efficiency for standalone for N and P are stored in
            // DetentionPercentNitrogenRemoval and DetentionPercentPhosphorusRemoval 
            double DetentionNEff = ((WetDetention)down).DetentionPercentNitrogenRemoval;
            double DetentionPEff = ((WetDetention)down).DetentionPercentPhosphorusRemoval;

            // The Wet Detention Calculation gives us a standalone efficiency for wet detentions
            // 

            // Now we have to adjust the overall efficiency to take into account the additional removal
            // using e as upstream retention treatment efficiency and detention efficiency non-adjusted. 
            // Adjusted efficiency =  ((e1 / 100.0) + (e2 / 100.0) * (1 - (e1 / 100.0))) * 100.0;
            // e1 and e2 as a fraction = e1 + e2*(1-e1)

            //double NonAdjustedN = CalculateAdjustedEfficiency(e, down.ProvidedNTreatmentEfficiency);
            //double NonAdjustedP = CalculateAdjustedEfficiency(e, down.ProvidedPTreatmentEfficiency);

            //down.ProvidedNTreatmentEfficiency = down.ProvidedNTreatmentEfficiency - e/7.0;
            //down.ProvidedPTreatmentEfficiency = down.ProvidedPTreatmentEfficiency - e/7.0;
            down.ProvidedNTreatmentEfficiency = (100 - e) * ((DetentionNEff/100) - (10/100)*(e / 100));
            down.ProvidedPTreatmentEfficiency = (100 - e) * ((DetentionPEff/100) - (20/100)*(e / 100));

            if (down.ProvidedNTreatmentEfficiency <= 0) down.ProvidedNTreatmentEfficiency = 0.0;
            if (down.ProvidedPTreatmentEfficiency <= 0) down.ProvidedPTreatmentEfficiency = 0.0;

            //ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(e, down.ProvidedNTreatmentEfficiency);
            //ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(e, down.ProvidedPTreatmentEfficiency);
            ProvidedNTreatmentEfficiency = e + down.ProvidedNTreatmentEfficiency;
            ProvidedPTreatmentEfficiency = e + down.ProvidedPTreatmentEfficiency;

            // Now calculate Mass Load reductions
            down.BMPNMassLoadIn = up.BMPNMassLoadOut;
            down.BMPPMassLoadIn = up.BMPPMassLoadOut;
            CalculateMassLoadReductions(down);
            CalculateMassLoadReductions(this);
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
                HydraulicCaptureEfficiency = CalculateEffectiveRetentionTreatmentEfficiency();

                // First Calculate Retention based removal efficiency
                // if (RetentionDepth != 0) base.Calculate();

                RunoffVolume = RunoffVolume * (100 - HydraulicCaptureEfficiency) / 100;       // Runoff Volume that gets through the system

                CalculateGroundwaterDischarge();

                if (bmp1.isRetention()) RetentionCount = 1;
                if (bmp2.isRetention()) RetentionCount = 2;
                if (bmp2.isRetention() && bmp3.isRetention()) RetentionCount = 3;
                if (bmp2.isRetention() && bmp3.isRetention() && bmp4.isRetention()) RetentionCount = 4;
            }

            return RetentionCount;
        }

        private int LastRetention()
        {
            int RetentionCount = 0;
            if (bmp1.isRetention()) RetentionCount = 1;
            if (bmp2.isRetention()) RetentionCount = 2;
            if (bmp3.isRetention()) RetentionCount = 3;
            if (bmp4.isRetention()) RetentionCount = 4;
            return RetentionCount;

        }

        public override void CalculateGroundwaterDischarge()
        {
            // Works as the Sum of all retention
            HydraulicCaptureEfficiency = CalculateEffectiveRetentionTreatmentEfficiency();

            // Overall Hydraulic Efficiency (System is treated as a single Unit)
            GroundwaterNMassLoadIn = BMPNMassLoadIn * HydraulicCaptureEfficiency / 100;
            GroundwaterPMassLoadIn = BMPPMassLoadIn * HydraulicCaptureEfficiency / 100;

            MediaNPercentReduction = bmp1.MediaNPercentReduction;
            MediaPPercentReduction = bmp1.MediaPPercentReduction;

            GroundwaterNMassLoadOut = GroundwaterNMassLoadIn * (100 - MediaNPercentReduction) / 100;
            GroundwaterPMassLoadOut = GroundwaterPMassLoadIn * (100 - MediaPPercentReduction) / 100;
        }


        //private double getEquivalentRetentionDepth()
        //{
        //    double RD = 0;
        //    if (bmp1.isDefined())
        //    {
        //        if (bmp1.isRetention())
        //        {
        //            RD += bmp1.RetentionDepth;
        //        }
        //        else
        //        {
        //            return 0.0;
        //        }
        //    }

        //    if (bmp2.isDefined())
        //    {
        //        if (bmp2.isRetention())
        //        {
        //            RD += bmp2.RetentionDepth;
        //        }
        //        else { return RD; }
        //    }

        //    if (bmp3.isDefined())
        //    {
        //        if (bmp3.isRetention())
        //        {
        //            RD += bmp3.RetentionDepth;
        //        }
        //        else
        //        {
        //            return RD;
        //        }
        //    }

        //    if (bmp4.isDefined())
        //    {
        //        if (bmp4.isRetention()) { RD += bmp4.RetentionDepth; } else { return RD; }
        //    }
        //    return RD;
        //}


        /// <summary>
        /// Calculates the equivalent retention depth by summing the RetentionDepth 
        /// of all defined BMPs that are retention types.
        /// </summary>
        /// <remarks>
        /// The process stops immediately and returns the accumulated depth 
        /// if a defined BMP is encountered that is not a retention type.
        /// </remarks>
        /// <returns>A double representing the total equivalent retention depth.</returns>
        private double getEquivalentRetentionDepth()
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
            try { 
            if ((bmp1.BMPType != BMPTrainsProject.sNone) && ((bmp1.BMPType.Trim()) != "")) return true;
            if ((bmp2.BMPType != BMPTrainsProject.sNone) && ((bmp2.BMPType.Trim()) != "")) return true;
            if ((bmp3.BMPType != BMPTrainsProject.sNone) && ((bmp3.BMPType.Trim()) != "")) return true;
            if ((bmp4.BMPType != BMPTrainsProject.sNone) && ((bmp4.BMPType.Trim()) != "")) return true;
            return false;
            }
            catch
            {
                return false;
            }
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

            s += LoadDiagram();
            return s;
        }

        public string SpecificBMPReport(int i, BMP bmp)
        {
            if (bmp == null) return string.Empty;

            string vars = bmp.PrintInputVariables();

            // If vars contains no printable content (null/empty/whitespace) return nothing
            if (string.IsNullOrWhiteSpace(vars)) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine("<h2>BMP in Series Number: " + i.ToString() + " (");
            // BMPType is plain text; escape to avoid injecting into surrounding HTML
            sb.AppendLine("BMP Type: " + System.Security.SecurityElement.Escape(bmp.BMPType ?? "") + ")</h2>");
            // vars is assumed to be HTML returned by PrintInputVariables() — include as-is
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
                s += EfficiencyReport();
                return s;
            }

            s += EfficiencyReport();
            return s;
        }

        

        public override string EfficiencyReport()
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

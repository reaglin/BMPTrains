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


            if (isRetention())
            {
                double d = CalculateEffectiveRetentionTreatmentEfficiency();
                ProvidedNTreatmentEfficiency = d;
                ProvidedPTreatmentEfficiency = d;
                RechargeRate = RunoffVolume * 0.3258724 * HydraulicCaptureEfficiency / 100;
                CalculateRetentionGroundwaterTreatmentEfficiency();
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

            // Common Case Wet Detention to Stormwater Harvesting 
            if ((bmp1.BMPType == BMPTrainsProject.sWetDetention) 
                && (bmp2.BMPType == BMPTrainsProject.sStormwaterHarvesting))
            {
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(bmp1.ProvidedNTreatmentEfficiency, bmp2.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(bmp1.ProvidedPTreatmentEfficiency, bmp2.ProvidedPTreatmentEfficiency);
                HydraulicCaptureEfficiency = bmp2.ProvidedNTreatmentEfficiency;
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                // For situations where there are additional BMP's after the Detention to Stormwater Harvesting Scenario

                if (bmp3.BMPType == BMPTrainsProject.sNone) return;
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp3.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp3.ProvidedPTreatmentEfficiency);
                
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                if (bmp4.BMPType == BMPTrainsProject.sNone) return;
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp4.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp4.ProvidedPTreatmentEfficiency);
                
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);
                return;
            }

            // Common Case Wet Detention to Stormwater Harvesting 
            if ((bmp2.BMPType == BMPTrainsProject.sWetDetention)
                && (bmp3.BMPType == BMPTrainsProject.sStormwaterHarvesting))
            {
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp3.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp3.ProvidedPTreatmentEfficiency);
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);

                // For situations where there are additional BMP's after the Detention to Stormwater Harvesting Scenario

                if (bmp4.BMPType == BMPTrainsProject.sNone) return;
                ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedNTreatmentEfficiency, bmp4.ProvidedNTreatmentEfficiency);
                ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(ProvidedPTreatmentEfficiency, bmp4.ProvidedPTreatmentEfficiency);
                CalculateMassLoading();
                CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);
                return;
            }

            CalculateTraditional();

            CalculateMassLoading();

            CalculateFlowWeightedGroundwaterTreatmentEfficiency(true);


        }

        private void CalculateTraditional()
        {

            if (bmp1.isDefined())
            {
                CalculateReductions(bmp1);
                ProvidedNTreatmentEfficiency = bmp1.ProvidedNTreatmentEfficiency;
                ProvidedPTreatmentEfficiency = bmp1.ProvidedPTreatmentEfficiency;
                CalculateMassLoading(false);
                if (bmp2.isDefined())
                {
                    bmp2.BMPNMassLoadIn = bmp1.BMPNMassLoadOut;
                    bmp2.BMPPMassLoadIn = bmp1.BMPPMassLoadOut;
                    CalculateReductions(bmp2);
                    ProvidedNTreatmentEfficiency = 100 *  (bmp1.BMPNMassLoadIn - bmp2.BMPNMassLoadOut) / bmp1.BMPNMassLoadIn;
                    ProvidedPTreatmentEfficiency = 100 *  (bmp1.BMPPMassLoadIn - bmp2.BMPPMassLoadOut) / bmp1.BMPPMassLoadIn;
                    CalculateMassLoading(false);
                    if (bmp3.isDefined())
                    {
                        bmp3.BMPNMassLoadIn = bmp2.BMPNMassLoadOut;
                        bmp3.BMPPMassLoadIn = bmp2.BMPPMassLoadOut;
                        CalculateReductions(bmp3);
                        ProvidedNTreatmentEfficiency = 100 * (bmp1.BMPNMassLoadIn - bmp3.BMPNMassLoadOut) / bmp1.BMPNMassLoadIn;
                        ProvidedPTreatmentEfficiency = 100 * (bmp1.BMPPMassLoadIn - bmp3.BMPPMassLoadOut) / bmp1.BMPPMassLoadIn;
                        CalculateMassLoading(false);
                        if (bmp4.isDefined())
                        {
                            bmp4.BMPNMassLoadIn = bmp3.BMPNMassLoadOut;
                            bmp4.BMPPMassLoadIn = bmp3.BMPPMassLoadOut;
                            CalculateReductions(bmp4);
                            ProvidedNTreatmentEfficiency = 100 * (bmp1.BMPNMassLoadIn - bmp4.BMPNMassLoadOut) / bmp1.BMPNMassLoadIn;
                            ProvidedPTreatmentEfficiency = 100 * (bmp1.BMPPMassLoadIn - bmp4.BMPPMassLoadOut) / bmp1.BMPPMassLoadIn;
                            CalculateMassLoading(false);
                        }

                    }

                }
            }
        }

        private void CalculateTraditional(BMP bmp)
        {
            if (bmp.isDefined())
            {
                bmp.BMPNMassLoadIn = bmp1.BMPNMassLoadOut;
                bmp.BMPPMassLoadIn = bmp1.BMPPMassLoadOut;
                CalculateReductions(bmp);
                ProvidedNTreatmentEfficiency = 100 * (bmp1.BMPNMassLoadIn - bmp.BMPNMassLoadOut) / bmp1.BMPNMassLoadIn;
                ProvidedPTreatmentEfficiency = 100 * (bmp1.BMPPMassLoadIn - bmp.BMPPMassLoadOut) / bmp1.BMPPMassLoadIn;
                CalculateMassLoading();
            }
        }

        public void CalculateRetentionGroundwaterTreatmentEfficiency()
        {

        }

        public override bool isRetention()
        {
            // If the last BMP is retention - system is retention
            if (bmp1.isRetention()) { if (bmp2.BMPType == BMPTrainsProject.sNone) return true; } else return false;
            if (bmp2.isRetention()) { if (bmp3.BMPType == BMPTrainsProject.sNone) return true; } else return false;
            if (bmp3.isRetention()) { if (bmp4.BMPType == BMPTrainsProject.sNone) return true; } else return false;
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
            CalculateReductions(this);
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

            down.BMPNMassLoadIn = up.BMPNMassLoadOut;
            down.BMPPMassLoadIn = up.BMPPMassLoadOut;

            // Now we have to adjust the overall efficiency to take into account the additional removal

            double NonAdjustedN = CalculateAdjustedEfficiency(e, down.ProvidedNTreatmentEfficiency);
            double NonAdjustedP = CalculateAdjustedEfficiency(e, down.ProvidedPTreatmentEfficiency);

            //if (e > down.CalculatedNTreatmentEfficiency)
            //    down.CalculatedNTreatmentEfficiency = down.CalculatedNTreatmentEfficiency - 22;
            //else
            down.ProvidedNTreatmentEfficiency = down.ProvidedNTreatmentEfficiency - e/7.0;
            //down.CalculatedNTreatmentEfficiency = NonAdjustedN - e / 7.0;
            //if (e > down.CalculatedPTreatmentEfficiency)
            //    down.CalculatedPTreatmentEfficiency = down.CalculatedPTreatmentEfficiency - 12;
            //else
            down.ProvidedPTreatmentEfficiency = down.ProvidedPTreatmentEfficiency - e/7.0;
            //down.CalculatedPTreatmentEfficiency = NonAdjustedP - e / 7.0;

            if (down.ProvidedNTreatmentEfficiency <= 0) down.ProvidedNTreatmentEfficiency = 0.0;
            if (down.ProvidedPTreatmentEfficiency <= 0) down.ProvidedPTreatmentEfficiency = 0.0;

            ProvidedNTreatmentEfficiency = CalculateAdjustedEfficiency(e, down.ProvidedNTreatmentEfficiency);
            ProvidedPTreatmentEfficiency = CalculateAdjustedEfficiency(e, down.ProvidedPTreatmentEfficiency);

            CalculateReductions(down);
            CalculateReductions(this);
        }

        private void CalculateReductions(BMP bmp)
        {
            bmp.BMPNMassLoadOut = bmp.BMPNMassLoadIn * (100 - bmp.ProvidedNTreatmentEfficiency) / 100;
            bmp.BMPPMassLoadOut = bmp.BMPPMassLoadIn * (100 - bmp.ProvidedPTreatmentEfficiency) / 100;

            // 
            //if (!bmp.isRetention()) { 
            //    bmp.GroundwaterNMassLoadIn = bmp.BMPNMassLoadIn * bmp.CalculatedNTreatmentEfficiency / 100;
            //    bmp.GroundwaterPMassLoadIn = bmp.BMPPMassLoadIn * bmp.CalculatedPTreatmentEfficiency / 100;
            //}


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


        private double getEquivalentRetentionDepth()
        {
            double RD = 0;
            if (bmp1.isDefined())
            {
                if (bmp1.isRetention())
                {
                    RD += bmp1.RetentionDepth;
                }
                else {
                    return 0.0;
                }
            }

            if (bmp2.isDefined())
            {
                if (bmp2.isRetention()) {
                    RD += bmp2.RetentionDepth;
                }
                else { return RD; }
            }

            if (bmp3.isDefined())
            {
                if (bmp3.isRetention()) {
                    RD += bmp3.RetentionDepth;
                }
                else {
                    return RD;
                }
            }

            if (bmp4.isDefined())
            {
                if (bmp4.isRetention()) { RD += bmp4.RetentionDepth; } else { return RD; }
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

        public override string BMPReport()
        {
            string s = "<b>Project:</b> " + Globals.Project.ProjectName + "<br/>";
            s += "<b>Date:</b> " + DateTime.Now.ToString("d") + "<br/><br/>";
            s += "<b>Multiple BMP in Series Design Parameters</b><br/>";
            if (bmp1.isDefined()) s += SpecificBMPReport(1, bmp1);
            if (bmp2.isDefined()) s += SpecificBMPReport(2, bmp2);
            if (bmp3.isDefined()) s += SpecificBMPReport(3, bmp3);
            if (bmp4.isDefined()) s += SpecificBMPReport(4, bmp4);

            s += WatershedCharacteristics();
            s += SurfaceWaterAnalysis();
            if ((DoGroundwaterAnalysis == "Yes") || (MediaMixType != MediaMix.None)) s += GroundwaterAnalysis();
            s += LoadDiagram();
            return s;
        }

        public string SpecificBMPReport(int i, BMP bmp)
        {
            string s = "<br/>BMP in Series Number: " + i.ToString() + "<br/>";
            s += "BMP Type: " + bmp.BMPType + "<br/>";
            s += bmp.BMPInputVariables();
            return s;
        }

        public override string BasicReport()
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
                {"CalculatedNTreatmentEfficiency", "Overall Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Overall Provided Phosphorus Treatment Efficiency (%)"},
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

            //s += "<h1>Contributing BMPs</h1>";
            //if (bmpExists(1) && bmp1.BMPType != BMPTrainsProject.sNone) s += bmp1.EfficiencyReport();
            //if (bmpExists(2) && bmp2.BMPType != BMPTrainsProject.sNone) s += bmp2.EfficiencyReport();
            //if (bmpExists(3) && bmp3.BMPType != BMPTrainsProject.sNone) s += bmp3.EfficiencyReport();
            //if (bmpExists(4) && bmp4.BMPType != BMPTrainsProject.sNone) s += bmp4.EfficiencyReport();
            s += EfficiencyReport();
            return s;
        }

        public override string EfficiencyReport()
        {
            string s = "<br/><h2>Load for  Multiple BMP in Series</h2><br/><table>";
            s += "<table><tr>";         // 5 Cells per row
            s += EfficiencyReportCell(BMPNMassLoadIn, BMPPMassLoadIn, 2, "kg/yr", "Load");
            s += EfficiencyReportCell("&rarr;");
            s += EfficiencyReportCell(ProvidedNTreatmentEfficiency, ProvidedPTreatmentEfficiency, 0, "%", "Treatment", 1);
            s += EfficiencyReportCell("&rarr;");
            s += EfficiencyReportCell(BMPNMassLoadOut, BMPPMassLoadOut, 2, "kg/yr", "Surface Discharge");
            s += "</tr>";

            s += "<tr><td></td><td></td>";
            s += EfficiencyReportCell("&darr;");
            s += "<td></td></tr><tr><td></td><td></td>";
            s += EfficiencyReportCell(BMPNMassLoadIn - BMPNMassLoadOut, BMPPMassLoadIn - BMPPMassLoadOut, 2, "kg/yr", "Mass Reduction");
            s += "<td></td></tr>";
            if (Globals.Project.DoGroundwaterAnalysis == "Yes")
            {
                s += "<tr><td>Retention Only</td><td></td><td><h2>Groundwater</h2></td><td></td><td>Treated as System</td></tr>";
                s += "<tr>";
                s += EfficiencyReportCell(GroundwaterNMassLoadIn, GroundwaterPMassLoadIn, 3, "kg/yr", "Retention into Media");
                s += "<td></td>";
                s += EfficiencyReportCell(MediaNPercentReduction, MediaPPercentReduction, 0, "%", "Media GW Treatment", 1);
                s += EfficiencyReportCell("&rarr;");
                s += EfficiencyReportCell(GroundwaterNMassLoadOut, GroundwaterPMassLoadOut, 3, "kg/yr", "Total GW Discharge");
                s += "</tr>";

                s += "<tr><td></td><td></td>";
                s += EfficiencyReportCell("&darr;");
                s += "<td></td><td></td>";
                s += "</tr>";

                NRetained = BMPNMassLoadIn - BMPNMassLoadOut - GroundwaterNMassLoadOut;
                PRetained = BMPPMassLoadIn - BMPPMassLoadOut - GroundwaterPMassLoadOut;

                s += "<tr><td></td><td></td>";
                s += EfficiencyReportCell(NRetained, PRetained, 3, "kg/yr", "Retained");
                s += "<td></td><td></td>";
                s += "</tr>";
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

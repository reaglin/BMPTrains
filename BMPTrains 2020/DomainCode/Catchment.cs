using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BMPTrains_2020.DomainCode
{
    [Serializable]
    public class Catchment : XmlPropertyObject
    {

        #region "Properties"

        public const string SessionId = "CatchmentID";
        // Catchment ID is id inherited from XmlPropertyObject
        public int ToID { get; set; }
        public bool Disabled { get; set; }

        [Meta("Catchment Name", "", 2)]
        public string CatchmentName { get; set; }
        
        // AnalysisType determines the analysis that is done for pre/post
        // It comes from BMPTrainsProject. The AnalysisTypes are prefixed with 
        // AT_(Type of Analysis)

        // AnalysisType can also have a Criteria (a generalization of AnalysisTypes)
        // Which categorize the AnalysisTypes. 
        public string AnalysisType { get; set; }

        [Meta("Annual Mean Rainfall", "in",  2)]
        public double Rainfall { get; set; }

        [Meta("Rainfall Zone", "",  2)]
        public string RainfallZone { get; set; }
        public string DoGroundwaterAnalysis { get; set; }

        public int PreLandUseId { get; set; }

        [Meta("Pre-Condition Landuse", "", 2)]
        public string PreLandUseName { get; set; }
        public int PostLandUseId { get; set; }

        [Meta("Post-Condition Landuse", "",  2)]
        public string PostLandUseName { get; set; }

        [Meta("Pre Condition Area", "acres",  2)]
        public double PreArea { get; set; }

        [Meta("Pre Rational Coefficient", "0-1",  2)]
        public double PreRationalCoefficient { get; set; }

        [Meta("Pre Non DCIA Curve Number", "",  2)]
        public double PreNonDCIACurveNumber { get; set; }

        [Meta("Pre DCIA Percent", "0-100",  2)]
        public double PreDCIAPercent { get; set; }

        [Meta("Post Condition Area", "acres",  2)]
        public double PostArea { get; set; }

        [Meta("Wet Pond Area", "acres",  2)]
        public double BMPArea { get; set; }

        [Meta("Post Rational Coefficient", "0-1",  2)]
        public double PostRationalCoefficient { get; set; }

        [Meta("Post Non DCIA Curve Number", "",  2)]
        public double PostNonDCIACurveNumber { get; set; }

        [Meta("Post DCIA Percent", "0-100",  2)]
        public double PostDCIAPercent { get; set; } // (0-100)

        public string PreLoading { get; set; }
        public string PostLoading { get; set; }


        // Three treatment efficiencies (all in percent) 
        // Required - given by user or as Analysis Type
        // Calculated - Treatment efficiency of BMP
        // PrePost - Treatment efficiency (Post after Trreatment compared to Pre)

        [Meta("Required Nitrogen Treatment Efficiency", "%", 2)]
        public double RequiredNTreatmentEfficiency { get; set; }

        [Meta("Required Nitrogen Treatment Efficiency", "%", 2)]
        public double RequiredPTreatmentEfficiency { get; set; }

        [Meta("Provided Nitrogen Treatment Efficiency", "%",  2)]
        public double CalculatedNTreatmentEfficiency { get; set; }

        [Meta("Provided Phosphorus Treatment Efficiency", "%",  2)]
        public double CalculatedPTreatmentEfficiency { get; set; }
        public double PrePostNTreatmentEfficiency { get; set; }
        public double PrePostPTreatmentEfficiency { get; set; }

        // Concentrations

        [Meta("Pre Nitrogen EMC", "mg/l",  2)]
        public double PreNConcentration { get; set; } // mg/l

        [Meta("Pre Phosphorus EMC", "mg/l",  2)]
        public double PrePConcentration { get; set; } // mg/l

        [Meta("Post Nitrogen EMC", "mg/l",  2)]
        public double PostNConcentration { get; set; } // mg/l

        [Meta("Post Phosphorus EMC", "mg/l",  2)]
        public double PostPConcentration { get; set; }  //mg/l

        // Volumes in ac-ft

        [Meta("Pre Runoff Volume", "ac-ft/yr",  2)]
        public double PreRunoffVolume { get; set; }     // ac-ft

        [Meta("Post Runoff Volume", "ac-ft/yr",  2)]
        public double PostRunoffVolume { get; set; }    // ac-ft

        [Meta("Post Treatment Discharge Volume", "ac-ft", 2)]
        public double PostVolumeOut { get; set; } // ac-ft after all treatments, volume out

        // Loadings in kg.year

        [Meta("Pre Nitrogen Loading", "kg/yr",  2)]
        public double PreNLoading { get; set; }  // kg/yr

        [Meta("Pre Phosphorus Loading", "kg/yr",  2)]
        public double PrePLoading { get; set; }  // kg/yr

        [Meta("Post Nitrogen Loading", "kg/yr",  2)]
        public double PostNLoading { get; set; }  //kg/yr

        [Meta("Post Phosphorus Loading", "kg/yr",  2)]
        public double PostPLoading { get; set; }  //kg/yr

        [Meta("Volume of Runoff Pre-Condition", "inches/yr",  2)]
        public double PreRunoffVolumeInches_Yr { get; set; }

        [Meta("Volume of Runoff Post-Condition", "inches/yr",  2)]
        public double PostRunoffVolumeInches_yr { get; set; }

        public double GroundwaterNLoading { get; set; }
        public double GroundwaterPLoading { get; set; }

        public double GroundwaterNRemoved { get; set; }

        public double GroundwaterPRemoved { get; set; }
        public double GroundwaterNRemovalEfficiency { get; set; }
        public double GroundwaterPRemovalEfficiency { get; set; }




        // Internal BMP Routing
        public string BMP1 { get; set; }
        public string BMP2 { get; set; }
        public string BMP3 { get; set; }
        public string BMP4 { get; set; }

        // Used in Routing - one BMP needs to be used for routing
        public string SelectedBMPType { get; set; }

        public string PreCompositeCN { get; set; }
        public string PreCompositeArea { get; set; }
        public string PostCompositeCN { get; set; }
        public string PostCompositeArea { get; set; }

        public string PreNCompositeEMC { get; set; }
        public string PrePCompositeEMC { get; set; }
        public string PostNCompositeEMC { get; set; }
        public string PostPCompositeEMC { get; set; }

        public double PreGWN { get; set; }
        public double PreGWP { get; set; }
        public double PostGWN { get; set; }
        public double PostGWP { get; set; }
        public double PreReductionPercent { get; set; }
        public CatchmentRouting routing { get; set; }

        // The variables are represented as strings here for the reports. The reports convert these to a table
        // using the description defined in the Meta tags for each variable. 

        // Reports can also be defined in a library that uses these string arrays and the title used for the report 
        // as the key. 

        public static readonly string[] InputVariables = {
            "CatchmentName", "RainfallZone", "Rainfall" };

        public static readonly string[] PreConditionVariables = {
            "PreLandUseName", "PreArea", "PreRationalCoefficient", "PreNonDCIACurveNumber", "PreDCIAPercent", "PreNConcentration",
        "PrePConcentration", "PreRunoffVolume", "PreNLoading", "PrePLoading" };

        public static readonly string[] PostConditionVariables = {
            "PostLandUseName", "PostArea", "PostRationalCoefficient", "PostNonDCIACurveNumber", "PostDCIAPercent",
            "PostNConcentration", "PostPConcentration", "PostRunoffVolume", "PostNLoading", "PostPLoading"};
        // Can use if meta properties are defined (Follow Meta Print for Details)

        public string PrintWatershedCharacteristics()
        {
            string s = InterfaceCommon.PrintPropertyTable(this, InputVariables, "Catchment Characteristics");
            s += InterfaceCommon.PrintPropertyTable(this, PreConditionVariables, "Pre-Condition Watershed Characteristics");
            s += InterfaceCommon.PrintPropertyTable(this, PostConditionVariables, "Post-Condition Watershed Characteristics");

            return s;
        }


        #region "BMP Properties"
        // Need to add a single instance of each BMP a Catchment Can have - this
        // will be about 20
        // 1. Add New Instantiation Here
        // 2. Instatiate in Catchment() Constructor
        // 3. Add to Dictionary ImplementedBMPs()
        // 4. Add a getNameOfBMP accessor

        NoBMP noBMP;
        Retention retention;
        Exfiltration exfiltration;
        WetDetention wetDetention;
        StormwaterHarvesting stormwaterHarvesting;
        RainwaterHarvesting rainwaterHarvesting;
        Greenroof greenroof;
        RainGarden rainGarden;
        PerviousPavement perviousPavement;
        Filtration filtration;
        Swale swale;
        TreeWell treeWell;
        VegetatedNaturalBuffer VNB;
        VegetatedFilterStrip VFS;
        MultipleBMP multipleBMP;
        UserDefinedBMP userDefinedBMP;

        #endregion

        #endregion

        #region "Contructors"
        public Catchment()
        {
            ResetAll();
        }
        
        public void ResetAll()
        {
            // Set Default values
            ToID = 0;
            Disabled = false;

            // Need to instantiate each of the possible BMPs that a Catchment can have
            // limitation is one BMP of each type on a Catchment
            noBMP = new NoBMP(this);
            retention = new Retention(this);
            exfiltration = new Exfiltration(this);
            wetDetention = new WetDetention(this);
            stormwaterHarvesting = new StormwaterHarvesting(this);
            rainwaterHarvesting = new RainwaterHarvesting(this);
            greenroof = new Greenroof(this);
            rainGarden = new RainGarden(this);
            perviousPavement = new PerviousPavement(this);
            filtration = new Filtration(this);
            swale = new Swale(this);
            treeWell = new TreeWell(this);
            VNB = new VegetatedNaturalBuffer(this);
            VFS = new VegetatedFilterStrip(this);
            userDefinedBMP = new UserDefinedBMP(this);
            multipleBMP = new MultipleBMP(this);

            BMP1 = BMPTrainsProject.sNone;
            BMP2 = BMPTrainsProject.sNone;
            BMP3 = BMPTrainsProject.sNone;
            BMP4 = BMPTrainsProject.sNone;

            DoGroundwaterAnalysis = "Yes";                      // default
            AnalysisType = BMPTrainsProject.AT_BMPAnalysis;     // default AnalysusType

            // Set Default BMP to None
            SelectedBMPType = BMPTrainsProject.sNone;
            routing = new CatchmentRouting(this);
        }

        public void CopyBMPs(Catchment c)
        {
            noBMP.setFrom(c.noBMP);
            retention.setFrom(c.retention);
            exfiltration.setFrom(c.exfiltration);
            wetDetention.setFrom(c.wetDetention);
            stormwaterHarvesting.setFrom(c.stormwaterHarvesting);
            rainwaterHarvesting.setFrom(c.rainwaterHarvesting);
            greenroof.setFrom(c.greenroof);
            rainGarden.setFrom(c.rainGarden);
            perviousPavement.setFrom(c.perviousPavement);
            filtration.setFrom(c.filtration);
            swale.setFrom(c.swale);
            treeWell.setFrom(c.treeWell);
            VNB.setFrom(c.VNB);
            VFS.setFrom(c.VFS);
            userDefinedBMP.setFrom(c.userDefinedBMP);
            //c.multipleBMP.bmp1.BMPType = c.BMP1;
            //c.multipleBMP.bmp2.BMPType = c.BMP2;
            //c.multipleBMP.bmp3.BMPType = c.BMP3;
            //c.multipleBMP.bmp4.BMPType = c.BMP4;
            multipleBMP.setFrom(c.multipleBMP);

            BMP1 = c.BMP1;
            BMP2 = c.BMP2;
            BMP3 = c.BMP3;
            BMP4 = c.BMP4;
            AnalysisType = c.AnalysisType;
        }

        public void Reset(BMP bmp)
        {
            DialogResult d = MessageBox.Show("This will reset all the value of the Current BMP " + bmp.BMPTypeTitle() + " do you wish to continue?"
                , "Reset BMP?"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Information);
            if (d == DialogResult.No)
            {
                return;
            }

            if (bmp.BMPType == BMPTrainsProject.sNone) noBMP = new NoBMP(this);
            if (bmp.BMPType == BMPTrainsProject.sRetention) retention = new Retention(this);
            if (bmp.BMPType == BMPTrainsProject.sExfiltration) exfiltration = new Exfiltration(this);
            if (bmp.BMPType == BMPTrainsProject.sWetDetention) wetDetention = new WetDetention(this);
            if (bmp.BMPType == BMPTrainsProject.sStormwaterHarvesting) stormwaterHarvesting = new StormwaterHarvesting(this);
            if (bmp.BMPType == BMPTrainsProject.sGreenroof) greenroof = new Greenroof(this);
            if (bmp.BMPType == BMPTrainsProject.sRainGarden) rainGarden = new RainGarden(this);
            if (bmp.BMPType == BMPTrainsProject.sPerviousPavement) perviousPavement = new PerviousPavement(this);
            if (bmp.BMPType == BMPTrainsProject.sFiltration) filtration = new Filtration(this);
            if (bmp.BMPType == BMPTrainsProject.sSwale) swale = new Swale(this);
            if (bmp.BMPType == BMPTrainsProject.sTreeWell) treeWell = new TreeWell(this);
            if (bmp.BMPType == BMPTrainsProject.sVegetatedNaturalBuffer) VNB = new VegetatedNaturalBuffer(this);
            if (bmp.BMPType == BMPTrainsProject.sVegetatedFilterStrip) VFS = new VegetatedFilterStrip(this);
            if (bmp.BMPType == BMPTrainsProject.sUserDefinedBMP) userDefinedBMP = new UserDefinedBMP(this);
            if (bmp.BMPType == BMPTrainsProject.sMultipleBMP) multipleBMP = new MultipleBMP(this);
        }

        public void SetValuesFromProject(BMPTrainsProject p)
        {
            // Each object holds a set of all values necessary for it to do the 
            // the calculations. These propogate from Project->Catchment->BMP
            Rainfall = p.MeanAnnualRainfall;
            RainfallZone = p.RainfallZone;
            AnalysisType = p.AnalysisType;
            PreReductionPercent = p.RequiredPreReductionPercent;

            CalculateRequiredNTreatmentEfficiency();
            CalculateRequiredPTreatmentEfficiency();
 
            DoGroundwaterAnalysis = p.getDoGroundwaterAnalysis();           
        }

        #endregion

        #region "Manage BMPs"
        public string SelectedBMPTitle()
        {
            return getSelectedBMP().BMPTypeTitle();
        }

        public void OpenSelectedBMPForm()
        {
            BMPTrainsProject.OpenSelectedBMPForm(SelectedBMPType, id);
        }

        public double getContributingArea()
        {
            double area = 0;
            return PostArea - BMPArea;
            if (getSelectedBMPType() == BMPTrainsProject.sStormwaterHarvesting) return this.PostArea;
            if (BMPArea > PostArea) return 0;
            return PostArea - BMPArea;

        }




        public Dictionary<string, BMP> ImplementedBMPs()
        {
            // This Dictionary makes it easy to Save as XML and Open from XML
            // The class type name is the key, the instantiated BMP is the value
            return new Dictionary<string, BMP>
            {
                { BMPTrainsProject.sNone, noBMP },
                { BMPTrainsProject.sRetention, retention },
                { BMPTrainsProject.sExfiltration, exfiltration},
                { BMPTrainsProject.sWetDetention, wetDetention },
                { BMPTrainsProject.sGreenroof, greenroof },
                { BMPTrainsProject.sRainGarden, rainGarden },
                { BMPTrainsProject.sStormwaterHarvesting, stormwaterHarvesting },
                { BMPTrainsProject.sRainwaterHarvesting, rainwaterHarvesting },
                { BMPTrainsProject.sPerviousPavement, perviousPavement },
                { BMPTrainsProject.sFiltration, filtration },
                { BMPTrainsProject.sSwale, swale },
                { BMPTrainsProject.sTreeWell, treeWell },
                { BMPTrainsProject.sVegetatedNaturalBuffer, VNB },
                { BMPTrainsProject.sVegetatedFilterStrip, VFS },
                { BMPTrainsProject.sUserDefinedBMP, userDefinedBMP },
                { BMPTrainsProject.sMultipleBMP, multipleBMP }
            };
        }

        public Dictionary<string, BMP> DefinedBMPs()
        {
            // This Dictionary makes it easy to Save as XML and Open from XML
            // The class type name is the key, the instantiated BMP is the value
            Dictionary<string, BMP> d = new Dictionary<string, BMP>();
            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs())
            {
                if (kvp.Value.isDefined()) d.Add(kvp.Key, kvp.Value);
            }

            return d;
        }

        public BMP getSelectedBMP()
        {
            // For routing this returns the BMP to be used in
            // Routing
            try
            {
                return ImplementedBMPs()[SelectedBMPType];
            }
            catch
            {
                return noBMP;
            }
        }


        public string getSelectedBMPType()
        {
            return getSelectedBMP().BMPType;
        }

        public double getCalculatedNTreatmentEfficiency()
        {
            getSelectedBMP().Calculate();
            return getSelectedBMP().ProvidedNTreatmentEfficiency;
        }
        public double getCalculatedPTreatmentEfficiency()
        {
            getSelectedBMP().Calculate();
            return getSelectedBMP().ProvidedPTreatmentEfficiency;
        }


        //public double GroundwaterNRemovalEfficiency()
        //{
        //    BMP bmp = getSelectedBMP();
        //    return bmp.GroundwaterNRemovalEfficiency();
        //}

        //public double GroundwaterPRemovalEfficiency()
        //{
        //    BMP bmp = getSelectedBMP();
        //    return bmp.GroundwaterPRemovalEfficiency();
        //}

        public virtual void CalculateGroundwaterLoading()
        {
            BMP bmp = getSelectedBMP();
            if (bmp.isRetention()) { 
                GroundwaterNLoading = bmp.GroundwaterNLoading();
                GroundwaterPLoading = bmp.GroundwaterPLoading();
            }
            else { 
                GroundwaterNLoading = 0.0;
                GroundwaterPLoading = 0.0;
            }

            GroundwaterNRemovalEfficiency = bmp.GroundwaterNRemovalEfficiency();
            GroundwaterPRemovalEfficiency = bmp.GroundwaterPRemovalEfficiency();

            GroundwaterNRemoved = GroundwaterNLoading * GroundwaterNRemovalEfficiency / 100;
            GroundwaterPRemoved = GroundwaterPLoading * GroundwaterPRemovalEfficiency / 100;
        }

        //public virtual double CalculateGroundwaterPLoading()
        //{
        //    BMP bmp = getSelectedBMP();
        //    if (bmp.isRetention()) GroundwaterPLoading = bmp.GroundwaterPLoading();
        //    else
        //        GroundwaterPLoading = 0.0;

        //    return GroundwaterPLoading;
        //}

        //public double GroundwaterNRemoved()
        //{
        //    double l = CalculateGroundwaterNLoading();
        //    double e = GroundwaterNRemovalEfficiency();
        //    double r =  l * e / 100;
        //    return r;
        //}

        //public double GroundwaterPRemoved()
        //{
        //    double l = GroundwaterPLoading;
        //    double e = GroundwaterPRemovalEfficiency();
        //    double r =  l * e / 100;
        //    return r;
        //}

        #endregion

        #region "Reporting"
        public string PrintCatchmentReport()
        {
            string s = getSelectedBMP().PrintBMPReport();
            return s;
        }

        //public string WatershedCharacteristics()
        //{
        //    string s = "<br/><b>Watershed Characteristics</b><br/>";
        //    s += AsHtmlTable(
        //        new Dictionary<string, string>
        //    {
        //        {"CatchmentName", "Catchment Name" },
        //        {"PostArea", "Contributing Area (acres)"},
        //        {"PostNonDCIACurveNumber", "Non DCIA Curve Number"},
        //        {"PostDCIAPercent", "DCIA Percent"},
        //        {"RainfallZone", "Rainfall Zone"},
        //        {"Rainfall", "Annual Rainfall (in)"}
        //    });
        //    return s;
        //}

        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
            {
                {"CatchmentName", "Catchment Name" },
                {"RainfallZone", "Rainfall Zone"},
                {"Rainfall", "Annual Mean Rainfall (in)"},
                {"Dummy1", "<b>Pre-Condition Landuse Information</b>" },
                {"PreLandUseName", "Pre-Condition Landuse"},
                {"PreArea", "Pre Condition Area (acres)"},
                {"PreRationalCoefficient", "Pre Rational Coefficient (0-1)"},
                {"PreNonDCIACurveNumber", "Pre Non DCIA Curve Number"},
                {"PreDCIAPercent", "Pre DCIA Percent (0-100)"},
                {"PreNConcentration", "Pre Nitrogen EMC (mg/l)"},
                {"PrePConcentration", "Pre Phosphorus EMC (mg/l)"},
                {"PreRunoffVolume", "Pre Runoff Volume (ac-ft/yr)" },
                {"PreNLoading", "Pre Nitrogen Loading (kg/yr)" },
                {"PrePLoading", "Pre Phosphorus Loading (kg/yr)" },
                {"Dummy2", "<b>Post-Condition Landuse Information</b>" },
                {"PostLandUseName", "Post-Condition Landuse"},
                {"PostArea", "Post Condition Area (acres)"},
                {"PostRationalCoefficient", "Post Rational Coefficient (0-1)"},
                {"PostNonDCIACurveNumber", "Post Non DCIA Curve Number"},
                {"PostDCIAPercent", "Post DCIA Percent (0-100)"},
                {"PostNConcentration", "Post Nitrogen EMC (mg/l)"},
                {"PostPConcentration", "Post Phosphorus EMC (mg/l)"},
                {"PostRunoffVolume", "Post Runoff Volume (ac-ft/yr)" },
                {"PostNLoading", "Post Nitrogen Loading (kg/yr)" },
                {"PostPLoading", "Post Phosphorus Loading (kg/yr)" },
            };
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
                {
                    {"Rainfall", 2},
                    {"PreArea", 2},
                    {"PreRationalCoefficient", 2},
                    {"PreNonDCIACurveNumber", 2},
                    {"PreDCIAPercent", 2},
                    {"PostArea", 2},
                    {"PostRationalCoefficient", 2},
                    {"PostNonDCIACurveNumber", 2},
                    {"PostDCIAPercent", 2}
                };
        }

        public string TitleHeader()
        {
            string s = " Analysis: " + AnalysisType;
            if ((AnalysisType == BMPTrainsProject.AT_SpecifiedRemovalEfficiency) ||
                (AnalysisType == BMPTrainsProject.AT_NetImprovement) ||
                (AnalysisType == BMPTrainsProject.AT_PreReductionPercent))
                return s + " Required Removal " + String.Format("N: {0:N0}% ", RequiredNTreatmentEfficiency) + String.Format("P: {0:N0}%", RequiredPTreatmentEfficiency);

            return s;
        }
        public new string AsHtmlTable()
        {
            string s = "<table>";
            foreach (KeyValuePair<string, string> pair in PropertyLabels())
            {
                s += "<tr>";
                s += "<td>" + pair.Value + "</td>";
                string v = GetValue(pair.Key);
                s += "<td>" + v + "</td>";
                s += "</tr>";
            }

            s += "<tr>";
            s += "<td>Pollutant<br/>Pre Condition Pollutant Loads </td>";
            s += "<td>" + AsHtmlTable(new string[] { "Pollutant", "Load (kg/year)" }, PreLoading) + "</td>";
            s += "</tr>";

            s += "<tr>";
            s += "<td>Pollutant<br/>Post Condition Pollutant Loads </td>";
            s += "<td>" + AsHtmlTable(new string[] { "Pollutant", "Load (kg/year)" }, PostLoading) + "</td>";
            s += "</tr>";

            //s += "<tr>";
            //s += "<td>Pollutant<br/> Required Removal Efficiency </td>";
            //s += "<td>" + AsHtmlTable(new string[] { "Pollutant", "Removal (%)" }, RequiredNTreatmentEfficiency) + "</td>";
            //s += "</tr>";

            s += "</table>";

            return s;
        }

        public string getRoutingReport()
        {
            return routing.getReport();
        }

        public string getRoutingBalanceReport()
        {
            return routing.getBalanceReport();
        }

        public string getFlowBalanceReport()
        {
            return routing.FlowBalanceReport();
        }
        

        #endregion

        #region "Calculations"
        public void Calculate()
        {
            // Calculate should be implemented by every object that 
            // does calculations - this is to help simplify the operation

            CalculateRationalCoefficients();
            CalculateMassLoadings();
            CalculateRequiredNTreatmentEfficiency();
            CalculateRequiredPTreatmentEfficiency();

            // Also Need to set values of BMP's relying on propogation of values

            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs())
            {
                kvp.Value.SetValuesFromCatchment(this);
                kvp.Value.Calculate();
            }
            setMultipleBMP(1, BMP1);
            setMultipleBMP(2, BMP2);
            setMultipleBMP(3, BMP3);
            setMultipleBMP(4, BMP4);

            if (retention.isDefined()) retention.Calculate();
            if (exfiltration.isDefined()) exfiltration.Calculate();
            if (wetDetention.isDefined()) wetDetention.Calculate();
            if (stormwaterHarvesting.isDefined()) stormwaterHarvesting.Calculate();
            if (rainwaterHarvesting.isDefined()) rainwaterHarvesting.Calculate();
            if (greenroof.isDefined()) greenroof.Calculate();
            if (rainGarden.isDefined()) rainGarden.Calculate();
            if (perviousPavement.isDefined()) perviousPavement.Calculate();
            if (filtration.isDefined()) filtration.Calculate();
            if (swale.isDefined()) swale.Calculate();
            if (treeWell.isDefined()) treeWell.Calculate();
            if (VNB.isDefined()) VNB.Calculate(); ;
            if (VFS.isDefined()) VFS.Calculate();
            if (userDefinedBMP.isDefined()) userDefinedBMP.Calculate();
            if (multipleBMP.isDefined()) multipleBMP.Calculate();

            CalculateGroundwaterLoading();

        }

        public string ErrorMessage(string analysisType = BMPTrainsProject.AT_BMPAnalysis)
        {
            // This checks catchement errors
            if (analysisType == BMPTrainsProject.AT_BMPAnalysis)
            {
                if ( PreNonDCIACurveNumber > 100)
                    return "The Pre Non DCIA CN Must be between 30 and 100";
                if (PreDCIAPercent < 0 || PreDCIAPercent > 100)
                    return "The Pre DCIA Percentage Must be between 0 and 100";
            }
            if ( PostNonDCIACurveNumber > 100)
                return "The Post Non DCIA CN Must be between 30 and 100";
            if (PostDCIAPercent < 0 || PostDCIAPercent > 100)
                return "The Post DCIA Percentage Must be between 0 and 100";
            if (BMPArea > PostArea)
                return "The BMP Area Cannot Exceed the Total Post Development Area";
            if (CatchmentName == "" )
                return "Please Enter a Name for Your Catchment Before Saving";

            // For specific types of analysis you must have a pre watershed condition
            if (((analysisType == BMPTrainsProject.AT_NetImprovement) || 
                (analysisType == BMPTrainsProject.AT_SpecifiedRemovalEfficiency) ||
                (analysisType == BMPTrainsProject.AT_PreReductionPercent)) && 
                PreLandUseName == "")
            {
                return "For this Analysis Method (" + analysisType + ") you must specify a Pre watershed condition";
            }
            return "";
        }

        public string CalculateRequiredRemoval(string preLoading, string postLoading)
        {

            var pre = AsDictionary(preLoading);
            var post = AsDictionary(postLoading);

            var efficiency = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in pre)
            {
                double preV = Convert.ToDouble(pair.Value);
                if (post.ContainsKey(pair.Key))
                {
                    double eff = 0;
                    double postV = Convert.ToDouble(post[pair.Key]);
                    if (postV != 0.0)
                    {
                        eff = 100 * (postV - preV) / postV;
                    }

                    efficiency.Add(pair.Key, AsString(eff, 1));
                }
            }
            return AsString(efficiency);
        }

        public void CalculateMassLoadings()
        {
            // PreNConcentration in mg/l
            // PreRationalCoefficient unitless
            // PreRunoff in ac-ft
            // Rainfall in Inches/yr
            // PreNLoading in kg/yr

            PreRunoffVolume = PreRationalCoefficient * PreArea * Rainfall /12;
            PostRunoffVolume = PostRationalCoefficient * (PostArea - BMPArea) * Rainfall /12;

            PreRunoffVolumeInches_Yr = 12 * PreRunoffVolume / PreArea;
            PostRunoffVolumeInches_yr = 12 * PostRunoffVolume / (PostArea - BMPArea);

            PreNLoading =  1.233 * PreNConcentration * PreRunoffVolume + PreGWN;
            PostNLoading = 1.233 * PostNConcentration * PostRunoffVolume + PostGWN;

            PrePLoading = 1.233 * PrePConcentration * PreRunoffVolume + PreGWP;
            PostPLoading = 1.233 * PostPConcentration * PostRunoffVolume + PostGWP;

            
        }

        public void CalculateRationalCoefficients()
        {
            PreRationalCoefficient =  CalculateRationalCoefficient( PreNonDCIACurveNumber, PreDCIAPercent);
            if (PreArea == 0) PreRationalCoefficient = 0;
            PostRationalCoefficient = CalculateRationalCoefficient( PostNonDCIACurveNumber, PostDCIAPercent);
        }

        public double CalculateRationalCoefficient(double NDCIACN, double DCIAP)
        {
            // RZ - Rainfall Zone
            // NDCIACN - Non Directly Connected Impervious Area CN
            // DCIAP - Directly Connected Impervious Area Percent

            if (String.IsNullOrEmpty(RainfallZone)) return 0.0;
            if (NDCIACN == 0) return 0;
            if (DCIAP < 0) return 0;

            LookupTable lut = StaticLookupTables.RationalCoeffientLookupTable(RainfallZone);
            return lut.Calculate(NDCIACN, DCIAP);
        }

        public double CalculateNDCIACN(double DCIAP, double RationalC)
        {
            LookupTable lut = StaticLookupTables.RationalCoeffientLookupTable(RainfallZone);
            double cn = lut.CalculateRowValue(DCIAP, RationalC);
            if (cn < 30) cn = 30;
            if (cn > 98) cn = 98;
            return cn;
        }

        public double CalculateLoading(double concentration, double rationalC, double area, double rainfall)
        {
            return 0.1029 * concentration * rationalC * area * rainfall;
        }

        public double getRechargeRate()
        {
            return getSelectedBMP().RechargeRate;
        }


        // Required Treatment Efficiency is either set by analysis type
        // or it can be calcualted from specific analysis types. 
        // #Eaglin  - N and P can be collapsed to a single routine
        public double CalculateRequiredNTreatmentEfficiency()
        {
            // Returns as a Percent Efficiency Requirement
            double ni = 0.0;
            switch (AnalysisType)
            {
                case BMPTrainsProject.AT_AllSites:
                case BMPTrainsProject.AT_OFW:
                case BMPTrainsProject.AT_ImpairedWater:
                case BMPTrainsProject.AT_ImpairedWater_OFW:
                case BMPTrainsProject.AT_Redevelopment:
                case BMPTrainsProject.AT_Redevelopment_OFW:
                    ni = BMPTrainsProject.AT_Removal_For_Scenario(AnalysisType, "N");
                    break;
                case BMPTrainsProject.AT_SpecifiedRemovalEfficiency:
                    ni = RequiredNTreatmentEfficiency;
                    break;
                case BMPTrainsProject.AT_NetImprovement:
                    ni = 100 * (PostNLoading - PreNLoading) / PostNLoading; 
                    break;
                case BMPTrainsProject.AT_BMPAnalysis: break;
                case BMPTrainsProject.AT_PreReductionPercent:
                    ni = 100 * (100.0 - (double)PreReductionPercent) / 100.0;
                    break;
                default:
                    break;
            }
            if (ni < 0) RequiredNTreatmentEfficiency = 0.0; else RequiredNTreatmentEfficiency = ni;
            return RequiredNTreatmentEfficiency;
        }

        public double CalculateRequiredPTreatmentEfficiency()
        {
            // Returns as a Required Efficiency Requirement
            double ni = 0.0;
            switch (AnalysisType)
            {
                case BMPTrainsProject.AT_AllSites:
                case BMPTrainsProject.AT_OFW:
                case BMPTrainsProject.AT_ImpairedWater:
                case BMPTrainsProject.AT_ImpairedWater_OFW:
                case BMPTrainsProject.AT_Redevelopment:
                case BMPTrainsProject.AT_Redevelopment_OFW:
                    ni = BMPTrainsProject.AT_Removal_For_Scenario(AnalysisType, "P");
                    break;
                case BMPTrainsProject.AT_SpecifiedRemovalEfficiency:
                    ni = RequiredPTreatmentEfficiency;
                    break;
                case BMPTrainsProject.AT_NetImprovement:
                    ni = 100 * (PostPLoading - PrePLoading) / PostPLoading;
                    break;
                case BMPTrainsProject.AT_BMPAnalysis: break;
                case BMPTrainsProject.AT_PreReductionPercent:
                    ni = 100 * (100.0 - (double)PreReductionPercent) / 100.0;
                    break;
                default:
                    break;
            }
            if (ni < 0) RequiredPTreatmentEfficiency = 0.0; else RequiredPTreatmentEfficiency = ni;
            return RequiredPTreatmentEfficiency;
        }

        // Comparisons of Whether specific conditions have been met
        public string IsPrePostTNMet()
        {
            if (RequiredNTreatmentEfficiency <= CalculatedNTreatmentEfficiency) return "Yes";
            return "No";
        }

        public string IsPrePostTPMet()
        {
            if (RequiredPTreatmentEfficiency <= CalculatedPTreatmentEfficiency) return "Yes";
            return "No";
        }
        public double[] CalculateWeightedC(bool pre)
        {
            int maxRows = 20;
            double[] CCNs = new double[maxRows];
            double[] areas = new double[maxRows];
            double[] Cs = new double[maxRows];
            double[] wC = new double[maxRows];

            LookupTable lut = StaticLookupTables.RationalCoeffientLookupTable(RainfallZone);

            double tDCIA;
            if (pre)
            {
                tDCIA = PreDCIAPercent;
                CCNs = XmlPropertyObject.AsDoubleArray(PreCompositeCN, maxRows);
                areas = XmlPropertyObject.AsDoubleArray(PreCompositeArea, maxRows);
            }
            else
            {
                tDCIA = PostDCIAPercent;
                CCNs = XmlPropertyObject.AsDoubleArray(PostCompositeCN, maxRows);
                areas = XmlPropertyObject.AsDoubleArray(PostCompositeArea, maxRows);
            }

            for (int i = 0; i < maxRows; i++)
            {
                if (CCNs[i] != 0)
                {
                    Cs[i] = lut.Calculate(CCNs[i], tDCIA);
                }
            }
            return Cs;
        }
        public double CalculateWeightedEMC(bool pre, bool nitro)
        {
            int maxRows = 20;
            double[] CCNs = new double[maxRows];
            double[] EMCs = new double[maxRows];
            double[] areas = new double[maxRows];
            double[] Cs = new double[maxRows];
            double[] wC = new double[maxRows];

            LookupTable lut = StaticLookupTables.RationalCoeffientLookupTable(RainfallZone);

            double tDCIA;
            if (pre)
            {
                tDCIA = PreDCIAPercent;

                if (nitro)
                    EMCs = XmlPropertyObject.AsDoubleArray(PreNCompositeEMC, maxRows);
                 else
                    EMCs = XmlPropertyObject.AsDoubleArray(PrePCompositeEMC, maxRows);

                CCNs = XmlPropertyObject.AsDoubleArray(PreCompositeCN, maxRows);
                areas = XmlPropertyObject.AsDoubleArray(PreCompositeArea, maxRows);
            }
            else
            {
                tDCIA = PostDCIAPercent;

                if (nitro)
                    EMCs = XmlPropertyObject.AsDoubleArray(PostNCompositeEMC, maxRows);
                else
                    EMCs = XmlPropertyObject.AsDoubleArray(PostPCompositeEMC, maxRows);


                CCNs = XmlPropertyObject.AsDoubleArray(PostCompositeCN, maxRows);
                areas = XmlPropertyObject.AsDoubleArray(PostCompositeArea, maxRows);
            }

            double totalArea = 0;
            for (int i = 0; i < maxRows; i++)
            {
                if (CCNs[i] != 0)
                {
                    Cs[i] = lut.Calculate(CCNs[i], tDCIA);
                    totalArea += Cs[i] * areas[i];
                }
            }

            if (totalArea == 0) return 0;

            double CompositeEMC = 0;
            for (int i = 0; i < maxRows; i++)
            {
                if (areas[i] != 0)
                {
                    CompositeEMC += EMCs[i] * Cs[i] * areas[i] / totalArea;
                }
            }

            return CompositeEMC;
        }

        public double[] CalculateAWeightedC(double[] areas, double[] Cs)
        {
            int maxRows = 20;
            double[] wC = new double[maxRows];

            double sumArea = 0;
            for (int i = 0; i < maxRows; i++) { sumArea += areas[i]; }

            for (int i = 0; i < maxRows; i++)
            {
                if (areas[i] != 0)
                {
                    wC[i] = Cs[i] * areas[i] / sumArea;
                }
            }
            return wC;
        }

        public double CalculateCCN(double averageWC, double DCIA)
        {
            LookupTable lut = StaticLookupTables.RationalCoeffientLookupTable(RainfallZone);
            return lut.CalculateRowValue(DCIA, averageWC);
        }

        public void setMultipleBMP(int i, string bType)
        {
            multipleBMP.AddBMP(i, getBMP(bType));
            if (i == 1) BMP1 = bType;
            if (i == 2) BMP2 = bType;
            if (i == 3) BMP3 = bType;
            if (i == 4) BMP4 = bType;
        }

        public void CalculateBMPs()
        {
            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs())
            {
                if (kvp.Value.isDefined()) kvp.Value.Calculate();
            }
        }

        public void CalculateCost()
        {
            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs() )
            {
                kvp.Value.CalculateCost();
            }
        }

        #endregion

        #region "Cost Table"
        public string CostTableReport()
        {
            string s = Globals.Project.CostReport();
            s += "<br/>";
            s += "<b>" + CatchmentName + " (Catchment #" + id.ToString() + ") </b><br/>";
            s += CatchmentCostTable();
            return s;
        }

        public Dictionary<string, string> HorizontalCostTableColumns()
        {
            return new Dictionary<string, string>
            {
                {"BMPType", "BMP Type" },
                {"RetentionVolume", "Treatment Volume (ac-ft)" },
                {"LandCost","Land Cost ($)"},
                {"ExpectedCost","Expected Life (yr)"},
                {"FixedCost","Fixed Cost ($)"},
                {"CostPerAcreFoot","BMP Cost ($/ac-ft)"},
                {"BMPCost","Initial BMP Cost ($)"},
                {"MaintenanceCost","BMP Maintenance ($/yr)"},
                {"AnnualCostRecovery","Annual Recovery ($/yr)"},
                {"TotalAnnualCost","Total Annual Cost ($/yr)"},
                {"FutureReplacementCost","Future Replace Cost ($)"},
                {"PresentValueOfReplacement","Present Value to Replace ($)"},
                {"PresentWorth","Present Value/Life Cycle Cost ($)"},
                {"NMassReductionLb","Nitrogen Mass Reduction (lb/yr)"},
                {"PMassReductionLb","Phosphorus Mass Reduction (lb/yr)"},
                {"CostPerPoundNRemoved","PV Cost per Pound N Removed ($/lb)"},
                {"CostPerPoundPRemoved","PV Cost per Pound P Removed ($/lb)"},
            };
        }

        public string CatchmentCostTable()
        {
            string s = "";
            s = "<table><tr>";
            foreach(KeyValuePair<string,string> kvp in HorizontalCostTableColumns())
            {
                s += "<td>" + kvp.Value + "</td>";
            }
            s += "</tr>";

            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs())
            {
                if (kvp.Value.isDefined()&&kvp.Value.BMPType != BMPTrainsProject.sNone) s += CostTableReportRow(kvp.Value);
            }

            s += "</table>";
            return s;
        }

        public string CatchmentCostCopy()
        {
            string s = "";
            foreach (KeyValuePair<string, string> kvp in HorizontalCostTableColumns())
            {
                s +=  kvp.Value + "\t";
            }
            s += "\n";

            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs())
            {
                if (kvp.Value.isDefined()) s += CostTableReportRow(kvp.Value, "", "\n");
            }

            return s;

        }

        public string CostTableReportRow(BMP bmp, string pre = "<tr>", string post="</tr>")
        {
            string s = "";
            string preCell = "";
            string postCell = "\t";

            if (pre == "<tr>") { preCell = "<td>"; postCell = "</td>"; }
            
            s += pre;
            s += preCell + bmp.BMPType + postCell;
            s += CostTableReportCell(bmp.RetentionVolume, 2, preCell, postCell);
            s += CostTableReportCell(bmp.LandCost, 0, preCell, postCell);
            s += CostTableReportCell(bmp.ExpectedLife, 0, preCell, postCell);
            s += CostTableReportCell(bmp.FixedCost, 0, preCell, postCell);
            s += CostTableReportCell(bmp.CostPerAcreFoot, 0, preCell, postCell);
            s += CostTableReportCell(bmp.BMPCost, 0, preCell, postCell);
            s += CostTableReportCell(bmp.MaintenanceCost, 0, preCell, postCell);
            s += CostTableReportCell(bmp.AnnualCostRecovery, 0, preCell, postCell);
            s += CostTableReportCell(bmp.TotalAnnualCost, 0, preCell, postCell);
            s += CostTableReportCell(bmp.FutureReplacementCost, 0, preCell, postCell);
            s += CostTableReportCell(bmp.PresentValueOfReplacement, 0, preCell, postCell);
            s += CostTableReportCell(bmp.PresentWorth, 0, preCell, postCell);
            s += CostTableReportCell(bmp.NMassReductionLb, 2, preCell, postCell);
            s += CostTableReportCell(bmp.PMassReductionLb, 2, preCell, postCell);
            s += CostTableReportCell(bmp.CostPerPoundNRemoved, 2, preCell, postCell);
            s += CostTableReportCell(bmp.CostPerPoundPRemoved, 2, preCell, postCell);

            s += post;
            return s;
        }

        public string CostTableReportCell(double d, int n = 2, string pre = "<td>", string post = "</td>")
        {
            string s = "";
            s += pre + String.Format("{0:N" + n.ToString() + "}", d) + post;
            return s;
        }

        #endregion

        public void setFrom(Catchment c)
        {
            // This is essentially a Copy operation
            // The copy opration will copy all the primitve
            // property types - this just adds a Calculate and 
            // Also ensures we are copying from a Catchment
            base.setFrom(c);
            this.Calculate();
            return;
        }

        public void setToRouting(int to)
        {
            this.ToID = to;
            this.routing.ToID = to;
        }

    public List<string> RainfallZones()
        {
            return StaticLookupTables.RainfallZones();
        }
       
        #region "Get Catchment BMP Options"
        // These public accessors make it easy to get
        // each of the BMPs of the Catchment
        public Retention getRetention()
        {            
            return retention;
        }

        public Exfiltration getExfiltration()
        {
            return exfiltration;
        }

        public WetDetention getWetDetention()
        {
            return wetDetention;
        }

        public StormwaterHarvesting getStormwaterHarvesting()
        {
            return stormwaterHarvesting;
        }

        public RainwaterHarvesting getRainwaterHarvesting()
        {
            return rainwaterHarvesting;
        }
        public Greenroof getGreenroof()
        {
            return greenroof;
        }

        public RainGarden getRainGarden()
        {
            return rainGarden;
        }

        public PerviousPavement getPerviousPavement()
        {
            return perviousPavement;
        }

        public Filtration getFiltration()
        {
            filtration.Calculate();
            return filtration;
        }

        public Swale getSwale()
        {
            return swale;
        }

        public TreeWell getTreeWell()
        {
            treeWell.Calculate();
            return treeWell;
        }

        public VegetatedNaturalBuffer getVegetatedNaturalBuffer()
        {
            return VNB;
        }

        public VegetatedFilterStrip getVegetatedFilterStrip()
        {
            return VFS;
        }

        public UserDefinedBMP getUserDefinedBMP()
        {
            return userDefinedBMP;
        }

        public MultipleBMP getMultipleBMP()
        {
            return multipleBMP;
        }

        public CatchmentRouting getRouting()
        {
            return routing;
        }

        public BMP getBMP(string bmp)
        {
            // Answers the BMP associated with the string
            if (bmp == "") bmp = BMPTrainsProject.sNone;
            if (bmp == "WetDetention") bmp = BMPTrainsProject.sWetDetention;
            BMP b =  ImplementedBMPs()[bmp];
            b.BMPType = bmp;
            return b;
        }
       
        public List<string> getAvailableBMPs()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, BMP> kvp in ImplementedBMPs())
            {
                if (kvp.Value.isDefined() && kvp.Key != "WetDetention")
                {
                    list.Add(kvp.Key);
                }
            }
            return list;
        }

     
        #endregion

        #region "Open and Save as XML"
        // This section is needed to be able to save and open 
        // objects from files.

        public new string AsXML(string id)
        {
            // We must get all the Implemented BMP's in the save
            // We store the XML from every BMP property (objects)
            // in an array, which is added as child nodes in the XML
            int n = ImplementedBMPs().Count;
            string[] array = new string[n + 1];
            int i = 1;
            foreach(KeyValuePair<string, BMP> kvp in this.ImplementedBMPs())
            {
                array[i - 1] = kvp.Value.AsXML(id);
                i++;
            }
            array[i - 1] = routing.AsXML(id);
            // This creates XML with child objects embedded in XML
            string s = base.AsXML(id, array);

            
            return s;
        }

        public override string PrintAll()
        {          
            string s = base.PrintAll();

            foreach (KeyValuePair<string, BMP> kvp in this.ImplementedBMPs())
            {
                s += "<h3>BMP: " + kvp.Key + "</h3>";
                s += kvp.Value.PrintAll();
            }
            return s;
        }

        public new void fromXML(string xml)
        {
            // This method is passed an XML string and will populate all the object properties
            var doc = XDocument.Parse(xml);

            ClearProperties();
            // This will get all root elements of the current object
            XmlDeserialize(doc);

            // Implemented BMPs is a Dictionary of all the classes by class name
            foreach (KeyValuePair<string, BMP> kvp in this.ImplementedBMPs())
            {
                try
                {
                    getFromXML(doc, kvp.Value.GetType().Name, kvp.Value);
                }
                catch
                {
                    // Do nothing
                }
            }

            // Get the routing
            try { getFromXML(doc, routing.GetType().Name, routing); } catch { }
        }
      
        private void getFromXML(XDocument doc, string ClassName, BMP bmp)
        {
            // There are objects saved as XML that are complex XML types - this is 
            // each of the BMP options.

            // This will get them all
            var XElements = doc.Descendants().Where(p => p.Name.LocalName == ClassName);
            foreach (XElement element in XElements)
            {
                bmp.fromXML(element.ToString()); break;
            }
            bmp.SetValuesFromCatchment(this);
        }

        private void getFromXML(XDocument doc, string ClassName, CatchmentRouting r)
        {
            var XElements = doc.Descendants().Where(p => p.Name.LocalName == ClassName);
            routing.fromXML(XElements.Descendants().First().ToString());
        }
        #endregion
    }


    public class RoutingParameters : XmlPropertyObject
    {
        #region "Properties"
        public double PreMassLoad { get; set; }
        public double PostMassLoad { get; set; }                // This is from the catchment
        public double UpstreamPreMassLoad { get; set; }
        public double UpstreamMassLoad { get; set; }
        public double TotalMassLoad { get; set; }  // Catchment + Incoming (from upstream)
        public double TotalUpstreamPreMassLoad { get; set; }
        public double TotalMassLoadLbYr { get; set; }
        public double TargetRemovalEfficiency { get; set; }
        public double TargetDischargeLoad { get; set; }
        public double ProvidedRemovalEfficiency { get; set; }
        public double DischargedLoad { get; set; }
        public double DischargedLoadLbYr { get; set; }
        public double RemovedLoad { get; set; }
        public double RemovedLoadLbYr { get; set; }

        // Surface Water Removal goes into GW
        // GW removal if Media only
        public double GroundwaterRemovalEfficiency { get; set; }
        public double GroundwaterLoad { get; set; }
        public double GroundwaterLoadLbYr { get; set; }
        public double GroundwaterLoadRemoved { get; set; }
        public double GroundwaterLoadRemovedLbYr { get; set; }
        #endregion

        #region "Reporting"
        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
            {
                {"PreMassLoad", "Catchment Pre Loading (kg/yr)"},
                {"PostMassLoad", "Catchment Post Loading (kg/yr)"},
                {"UpstreamMassLoad", "Upstream Mass Loading (kg/yr)"},
                {"TotalMassLoad", "Total Mass Loading [Catchment + Upstream] (kg/yr)"},
                {"TargetRemovalEfficiency","Target Load Reduction (%)" },
                {"TargetDischargeLoad","Target Discharge Load (kg/yr)" },
                {"ProvidedRemovalEfficiency","Provided Removal Efficiency (%)" },
                {"DischargedLoad","Total Discharged Load [Total * Efficiency] (kg/yr)" },
                {"DischargedLoadLbYr","Discharged Load (lb/yr)" },
                {"RemovedLoad","Removed Load [Total - Discharged] (kg/yr)" },
                {"RemovedLoadLbYr","Removed Load [Total - Discharged] (lb/yr)" }

            };
        }
        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
            {
                {"PreMassLoad", 2},
                {"PostMassLoad", 2},
                {"UpstreamMassLoad", 2},
                {"TotalMassLoad", 2 },
                {"TotalMassLoadLbYr", 2 },
                {"TargetRemovalEfficiency",0 },
                {"TargetDischargeLoad",2 },
                {"ProvidedRemovalEfficiency",0 },                
                {"DischargedLoad", 2 },
                {"DischargedLoadLbYr", 2 },
                {"RemovedLoad", 2 },
                {"RemovedLoadLbYr", 2 }
            };
        }
        public Dictionary<string, string> OutletLabels()
        {
            Dictionary<string,string> c =  new Dictionary<string, string>
            {
                {"Surface01", "" },
                {"Surface02", "<b>Surface Discharge</b>" },
                {"TotalMassLoad", "Total Outlet Mass Loading (kg/yr): "},
                {"TotalMassLoadLbYr", "Total Outlet Mass Loading (lb/yr): "}
            };

            if (GroundwaterLoad <= 0) return c;
            
            Dictionary<string, string> d = new Dictionary<string, string>
            {
                {"Ground01", "" },
                {"Ground02", "<b>Groundwater Discharge</b>" },
                {"GroundwaterLoad", "Total Groundwater Mass Loading (kg/yr): "},
                {"GroundwaterLoadLbYr", "Total Groundwater Mass Loading (lb/yr): "},
            };
            

            return this.Add(c,d);
        }
        #endregion

        #region "Calculations"
        public RoutingParameters Calculate()
        {
            TotalMassLoad = PostMassLoad + UpstreamMassLoad;
            TotalUpstreamPreMassLoad = PreMassLoad + UpstreamPreMassLoad;
            TotalMassLoadLbYr = TotalMassLoad * 2.2046;
            TargetDischargeLoad = (100 - TargetRemovalEfficiency) * TotalMassLoad / 100;
            DischargedLoad = (100 - ProvidedRemovalEfficiency) * TotalMassLoad / 100;
            DischargedLoadLbYr = DischargedLoad * 2.2046;

            RemovedLoad = TotalMassLoad - DischargedLoad;
            RemovedLoadLbYr = RemovedLoad * 2.2046;

            GroundwaterLoad = RemovedLoad * (100 - GroundwaterRemovalEfficiency) / 100;
            GroundwaterLoadRemoved = RemovedLoad * GroundwaterRemovalEfficiency / 100;
            return this;
        }

        #endregion
    }

    public class CatchmentRouting : XmlPropertyObject
    {
        #region "Properties"
        public bool IsValid { get; set; }
        public string BMPType { get; set; }
        public string UpstreamBMPType { get; set; }

        public string UpstreamNodes { get; set; }

        public int FromID { get; set; }                     // FromID is the ID of the Associated Catchment
        public int ToID { get; set; }                       // ToID is the ID of the To Catchment

        public RoutingParameters Nitrogen { get; set; }
        public RoutingParameters Phosphorus { get; set; }

        // In routing Hydraulic Efficiency is the % that passes through the BMP
        public double HydraulicEfficiency { get; set; } // Given as %

        // Each Catchment Routing has these volumes
        // VolumeFromCatchment - this is volume coming into the Catchment Routing from the Catchment
        // VolumeFromUpstream - in addition to the volume from the catchment, upstream nodes can contribute to the volume
        // VolumeIn - all volume coming into the node (usually sum of upstream and catchment
        // VolumeOut - Total volume leaving the node and heading to the next node
        // VolumeTreated - This treatment efficiency * volume in
        // VolumeIntoMedia - If media exists then it will capture some of the load before GW
        // VolumeGW - Total Volume of water going into the ground 

        public double VolumeFromCatchment { get; set; }
        public double VolumeFromUpstream { get; set; }
        public double VolumeIn { get; set; }

        
        public double VolumeOut { get; set; }
        public double VolumeTreated { get; set; }
        public double VolumeIntoMedia { get; set; }
        public double VolumeGW { get; set; }

        public string RoutingNotes { get; set; }
        #endregion

        #region "Constructors"
        public CatchmentRouting()
        {
            resetCatchmentRouting();
            RoutingNotes = "";
        }

        public CatchmentRouting(Catchment c)
        {
            setCatchmentRouting(c);
        }

        public CatchmentRouting(int id)
        {
            setCatchmentRouting(id);
        }

        public CatchmentRouting (int from, int to)
        {
            setCatchmentRouting(from);
            ToID = to;
        }

        public void setCatchmentRouting(int from)
        {
            setCatchmentRouting(Globals.Project.getCatchment(from));
        }

        public Catchment getCatchment()
        {
            return Globals.Project.getCatchment(FromID);
        }
        public void setCatchmentRouting(Catchment c)
        {
            // When a catchment routing is initialized these parameters are set

            resetCatchmentRouting();
            BMP bmp = c.getSelectedBMP();

            FromID = c.id; id = c.id;   // FromID is the associated Catchment
            ToID = c.ToID;
            BMPType = c.SelectedBMPType;

            
            if (FromID != 0) UpstreamBMPType = Globals.Project.getCatchment(FromID).getSelectedBMP().BMPType;

            // The reason we need Upstream BMPType is the special case
            // A Wet Detention BMP with an Upstream with No BMP is 
            // Caclulated by combining the 2 Catchments.

            IsValid = false;
            
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
            VolumeFromCatchment = c.PostRunoffVolume;
            VolumeIn = VolumeFromCatchment;                         // This is the starting point, more will be added
            VolumeFromUpstream = 0;
            HydraulicEfficiency = 100;

            // Removal Efficiency proided by the BMP
            Nitrogen.ProvidedRemovalEfficiency = bmp.ProvidedNTreatmentEfficiency;
            Phosphorus.ProvidedRemovalEfficiency = bmp.ProvidedPTreatmentEfficiency;

            Nitrogen.PreMassLoad = c.PreNLoading;
            Phosphorus.PreMassLoad = c.PrePLoading;

            Nitrogen.PostMassLoad = c.PostNLoading;
            Phosphorus.PostMassLoad = c.PostPLoading;

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

        public void resetCatchmentRouting()
        {
            // Used only for output
            FromID = 0;

            IsValid = true;
            HydraulicEfficiency = 0;

            Nitrogen = new RoutingParameters();
            Phosphorus = new RoutingParameters();

            Nitrogen.Name = "Nitrogen";
            Phosphorus.Name = "Phosphorus";

            Nitrogen.ProvidedRemovalEfficiency = 0;
            Phosphorus.ProvidedRemovalEfficiency = 0;

            Nitrogen.PreMassLoad = 0;
            Phosphorus.PreMassLoad = 0;

            Nitrogen.PostMassLoad = 0;
            Phosphorus.PostMassLoad = 0;

            Nitrogen.UpstreamMassLoad = 0;
            Phosphorus.UpstreamMassLoad = 0;

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
        public string FlowBalanceReport()
        {
            string s = "Catchment Routing ID: " + FromID.ToString() + "<br/>";
            s += "BMP Type: " + BMPType +"<br/>";
            s += "Routing to: " + ToID.ToString() + "<br/><br/>";
            s += "All volumes in ac-ft";
            s += "<table>";
            s += "<tr><td>Volume From Catchment</td><td>" + GetValue(VolumeFromCatchment, 2) + "</td></tr>";
            s += "<tr><td>Volume From Upstream</td><td>" + GetValue(VolumeFromUpstream, 2) + "</td></tr>";
            s += "<tr><td>Total Volume In</td><td>" + GetValue(VolumeIn, 2) + "</td></tr>";
            s += "<tr><td>Volume Into GW (or Media)</td><td>" + GetValue(VolumeGW, 2) + "</td></tr>";
            s += "<tr><td>Volume Out (to next node)</td><td>" + GetValue(VolumeOut, 2) + "</td></tr>";
            s += "</table>";
            return s;
        }
        public string getBalanceReport()
        {
            RoutingParameters n =  Nitrogen.Calculate();
            RoutingParameters p = Phosphorus.Calculate();
            string upNodes = (UpstreamNodes == "" ? "None" : UpstreamNodes);

            string s = "<br/><h3>Load Diagram for " + BMPType + " ( As Used In Routing)</h3><br/><table>";
            s += "<tr>";         // 5 Cells per row
            s += "<td>Upstream Nodes<br/>" + upNodes + "</td>";
            s += MassBalanceReportCell(n.TotalMassLoad, p.TotalMassLoad, VolumeIn, 2,  "Load");
            s += EfficiencyReportCell("&rarr;");
            s += EfficiencyReportCell(n.ProvidedRemovalEfficiency, p.ProvidedRemovalEfficiency, 1, "%", "Treatment", 1);
            s += EfficiencyReportCell("&rarr;");
            s += MassBalanceReportCell(n.DischargedLoad, p.DischargedLoad, VolumeOut, 2, "Mass Discharged");
            s += "</tr>";
            s += "<tr><td></td><td></td><td></td><td></td><td></td><td></td></tr>";
            s += "<tr><td></td><td></td><td></td>";
            s += EfficiencyReportCell("&darr;");
            s += "<td></td><td></td></tr>";
            s += "<tr><td></td><td></td><td></td>";
            s += MassBalanceReportCell(n.RemovedLoad, p.RemovedLoad, VolumeGW, 2, "Mass Removed");
            // s += EfficiencyReportCell(n.RemovedLoad, p.RemovedLoad, 2, "kg/yr", "Mass Removed");
            s += "<td></td><td></td></tr>";
            s += "</table>";

            return s;
        }

        public string EfficiencyReportCell(string s)
        {
            return "<td style='text-align:center; font-size: 150%'>" + s + "</td>";
        }

        public string EfficiencyReportCell(double val1, double val2, int places = 2, string units = "", string label = "", int border = 0)
        {
            //Common.FormattedString(val1, places)
            string td = "<td style='padding: 10px'>";
            if (border != 0) td = "<td style='border: 2px solid black; padding: 10px'>";
            return td + label + "<br/> N: " + GetValue(val1, places) + " " + units + "<br/> P: " + GetValue(val2, places) + " " + units + "</td>";
        }

        public string MassBalanceReportCell(double val1, double val2, double val3, int places = 2, string label = "", int border = 0)
        {
            string td = "<td style='padding: 10px'>";
            if (border != 0) td = "<td style='border: 2px solid black; padding: 10px'>";
            string retval = td + label + "<br/> N: ";
            retval += Common.FormattedString(val1, places) + " kg/yr<br/> P: "; 
            retval +=  Common.FormattedString(val2, places) + " kg/yr<br/> Q: ";
            retval += Common.FormattedString(val3, places) + " ac-ft</td>";
            return retval;
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
        //public void RouteTo(CatchmentRouting cr)
        //{
        //    cr.Nitrogen.UpstreamMassLoad += Nitrogen.DischargedLoad;
        //    cr.Phosphorus.UpstreamMassLoad += Phosphorus.DischargedLoad;
        //}

        //public void RouteTo(int to)
        //{
        //    RouteTo(Globals.Project.getRouting(to));
        //}

        public void CalculateUpstream(CatchmentRouting up)
        {
            // cr is upstream catchment
            // current CatchmentRouting is attached to the current catchment associated with the the routing
            // Most routing will simply accumulate the load

            BMP upstreamBMP = up.getCatchment().getSelectedBMP();

            if (BMPType == null)
            {
                if (up.BMPType == null) return;
                UpstreamBMPType = up.BMPType;
                CalculateVolumeFromRouting(up);
                CalculateSummations(up);
                upstreamBMP.CalculateMassLoading();

                return;
            }

            if (BMPType == BMPTrainsProject.sNone)
            {
                Nitrogen.ProvidedRemovalEfficiency = 0;
                Phosphorus.ProvidedRemovalEfficiency = 0;
                CalculateSummations(up);
                upstreamBMP.CalculateMassLoading();

                return;
            }

            UpstreamBMPType = up.BMPType;
            // Special Case Wet Detention to Wet Detention
            if ((BMPType == BMPTrainsProject.sWetDetention) && (UpstreamBMPType == BMPTrainsProject.sWetDetention))
            {
                // Special Case Wet Detention to Wet Detention
                // Hydraulic Efficiency of Wet Detention is 100%
                HydraulicEfficiency = 99; up.HydraulicEfficiency = 99;
                RouteWetDetentionToWetDetention(up);
                CalculateSummations(up);
                upstreamBMP.CalculateMassLoading();

                return;
            }

            // Special Case Retention to Wet Detention
            if ((BMPType == BMPTrainsProject.sWetDetention) && (UpstreamBMPType == BMPTrainsProject.sRetention))
            {
                // Special Case Retention to Wet Detention
                HydraulicEfficiency = 99;  // Hydraulic Efficiency of Wet Detention
                up.HydraulicEfficiency = up.getCatchment().getSelectedBMP().HydraulicCaptureEfficiency;
                RouteRetentionToWetDetention(up);
                CalculateSummations(up);
                upstreamBMP.CalculateMassLoading();

                return;
            }

            // Special Case No Upstream BMP Downstream Retention 
            if ((BMPType == BMPTrainsProject.sRetention) && (UpstreamBMPType == BMPTrainsProject.sNone))
            {
                RouteNoneToRetention(up);
                CalculateSummations(up);
                upstreamBMP.CalculateMassLoading();

                return;

            }

            // This is the default case
            CalculateVolumeFromRouting(up);
            CalculateSummations(up);
            upstreamBMP.CalculateMassLoading();

        }

        public double CalculateVolumeFromRouting(CatchmentRouting cr)
        {
            // This is the default routing situation - for retention systems Hydraulic Efficiency is tied
            // to N treatment, this Calculates Volume out of 
            cr.HydraulicEfficiency = 100;
            BMP bmp = cr.getCatchment().getSelectedBMP();

            // Retention and multiple BMP can have retention
            if (bmp.hasRetention())
            {
                cr.HydraulicEfficiency = 100 - bmp.ProvidedNTreatmentEfficiency;
            }

            cr.VolumeOut = cr.HydraulicEfficiency * cr.VolumeIn / 100;
            cr.VolumeIntoMedia = cr.VolumeIn - cr.VolumeOut;
            cr.VolumeGW = cr.VolumeIn - cr.VolumeOut;

            return cr.VolumeOut;
        }

        public void CalculateSummations(CatchmentRouting cr)
        {
            UpstreamNodes += "Node: " + cr.FromID.ToString("##") + "<br/>";

            if (Nitrogen.ProvidedRemovalEfficiency >= 100) Nitrogen.ProvidedRemovalEfficiency = 99;
            if (Phosphorus.ProvidedRemovalEfficiency >= 100) Phosphorus.ProvidedRemovalEfficiency = 99;

            // Volume
            VolumeIn += cr.VolumeOut;  // The Catchment Volume is put in during initialization
            VolumeFromUpstream += cr.VolumeOut;

            VolumeOut = HydraulicEfficiency * VolumeIn / 100;

            // Sum Upstream
            Nitrogen.UpstreamMassLoad += cr.Nitrogen.DischargedLoad;
            Phosphorus.UpstreamMassLoad += cr.Phosphorus.DischargedLoad;

            Nitrogen.UpstreamPreMassLoad += cr.Nitrogen.TotalUpstreamPreMassLoad;
            Phosphorus.UpstreamPreMassLoad += cr.Phosphorus.TotalUpstreamPreMassLoad;

            // And Calculate
            //getCatchment().getSelectedBMP().CalculatedNTreatmentEfficiency = Nitrogen.ProvidedRemovalEfficiency;
            //getCatchment().getSelectedBMP().CalculatedPTreatmentEfficiency = Phosphorus.ProvidedRemovalEfficiency;
            //getCatchment().getSelectedBMP().BMPNMassLoadOut = (100 - Nitrogen.ProvidedRemovalEfficiency) / 100 * getCatchment().getSelectedBMP().BMPNMassLoadIn;
            //getCatchment().getSelectedBMP().BMPPMassLoadOut = (100 - Phosphorus.ProvidedRemovalEfficiency) / 100 * getCatchment().getSelectedBMP().BMPPMassLoadIn;

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
            Catchment downC = Globals.Project.getCatchment(FromID);  // Same as Up.ToID (This Catchment)
            Catchment upC = Globals.Project.getCatchment(up.FromID);
            // This is the complex case  
            //   
            //   For the DCIA % use a Aerial weighted average
            double WeightedDCIAPercent = ((downC.PostDCIAPercent * downC.PostArea) + (upC.PostDCIAPercent * upC.PostArea)) / (downC.PostArea + upC.PostArea);

            // For NDCIA Curve Number it needs to be flow weighted
            // So need to calculate flow from NDCIA based on the CN and area 
            // 
            // Weighting Factor = Rational C * Pervious Area
            double retentionDepth = downC.getSelectedBMP().RetentionDepth;

            //            double upArea = upC.PostArea * (100 - upC.PostDCIAPercent) / 100;
            //            double downArea = (downC.PostArea - downC.BMPArea) * (100 - downC.PostDCIAPercent) / 100;

            double upArea = upC.PostArea;
            double downArea = (downC.PostArea - downC.BMPArea);


            double totArea = upArea + downArea;
           
            double upRC = upC.CalculateRationalCoefficient(upC.PostNonDCIACurveNumber, upC.PostDCIAPercent);    // This needs to be post annual flow from upstream
            double downRC = downC.CalculateRationalCoefficient(downC.PostNonDCIACurveNumber, downC.PostDCIAPercent);  // This needs to be post annual flow from downstream

            double upFraction = upArea * upRC;
            double downFraction = downArea * downRC;
            double totFraction = upFraction + downFraction;

            // Sum of up and down ratio will be 1.0
            double upRatio = upFraction / totFraction;
            double downRatio = downFraction / totFraction;

            double netVolume = retentionDepth * (downC.PostArea - downC.BMPArea) / 12;
            double newStorage = downFraction * netVolume / totFraction;

            // This is an adjusted retention to take into account the flow from the upstream
            double newRetention = newStorage / (downC.PostArea - downC.BMPArea) * 12;

            double WeightedC = ((upArea * upRC) + (downArea * downRC)) / (upArea + downArea);

            // Do a Reverse lookup in the Lookup table
            double WeightedNDCIACN = upC.CalculateNDCIACN(WeightedDCIAPercent, WeightedC);

            double t = RetentionEfficiencyLookupTables.CalculateEfficiency(newRetention,
                                                                           WeightedNDCIACN,
                                                                           WeightedDCIAPercent,
                                                                           Globals.Project.RainfallZone);
            Nitrogen.ProvidedRemovalEfficiency = t;
            Phosphorus.ProvidedRemovalEfficiency = t;

            if ((upC.getSelectedBMP().DelayTime > 0)&&(upC.getSelectedBMP().DelayTime < 15)) 
            {
                up.HydraulicEfficiency = 100;  // Hydraulic Efficiency of No BMP
                Nitrogen.ProvidedRemovalEfficiency += BMP.CalculateDelayEfficiency(upC.getSelectedBMP().DelayTime);
                Phosphorus.ProvidedRemovalEfficiency += BMP.CalculateDelayEfficiency(upC.getSelectedBMP().DelayTime); ;
            }

            if (upC.getSelectedBMP().DelayTime >= 15)
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

        public void CalculateOutlet(CatchmentRouting outlet)
        {
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
    }
}

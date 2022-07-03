using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BMPTrains_2020.DomainCode
{
    public class BMPTrainsProject : XmlPropertyObject
    {
        #region "BMP Types"
        public const string sNone = "None";
        public const string sRetention = "Retention";
        public const string sExfiltration = "Exfiltration";
        public const string sWetDetention = "Wet Detention";
        public const string sGreenroof = "Greenroof";
        public const string sRainGarden = "Rain Garden";
        public const string sStormwaterHarvesting = "Stormwater Harvesting";
        public const string sRainwaterHarvesting = "Rainwater Harvesting";
        public const string sPerviousPavement = "Pervious Pavement";
        public const string sFiltration = "Filtration";
        public const string sSwale = "Swale";
        public const string sTreeWell = "Tree Well";
        public const string sVegetatedNaturalBuffer = "Vegetated Natural Buffer";
        public const string sVegetatedFilterStrip = "Vegetated Filter Strip";
        public const string sUserDefinedBMP = "User Defined BMP";
        public const string sMultipleBMP = "Multiple BMP";
        #endregion

        #region "Static Methods"
        public const string sSpecifiedRemovalEfficiency = "Specified Removal Efficiency";
        public const string sNetImprovement = "Net Improvement";
        public const string sBMPAnalysis = "BMP Analysis";
        public const string sPreReduction = "10% Less than Pre-Development Conditions";
//        public const string sExistingBMPInput = "Existing Loading in Pre-Development";


        public static List<string> AnalysisTypes() => new List<string> { sSpecifiedRemovalEfficiency, sNetImprovement, sBMPAnalysis, sPreReduction };
        #endregion

        #region "Properties"
        public const string SessionId = "BMPTrainsProjectID";
        public const string DefaultCatchmentConfiguration = "A";

        public string ProjectName { get; set; }
        public string FileName { get; set; }
        public string RainfallZone { get; set; }
        public double MeanAnnualRainfall { get; set; }

        public string AnalysisType { get; set; }

        // Used for Target Efficicency
        public int RequiredNTreatmentEfficiency { get; set; }
        public int RequiredPTreatmentEfficiency { get; set; }

        // Used for Target Load
        public double TargetNMassLoad { get; set; }
        public double TargetPMassLoad { get; set; }

        // Used only if a pre-condition is loaded and then used 
        // in a second analysis

        public double TargetNFromPreLoad { get; set; }
        public double TargetPFromPreLoad { get; set; }

        public string CatchmentConfiguration { get; set; }

        public string DoGroundwaterAnalysis { get; set; }
        public double TotalGWVolume { get; set; }

        public int numCatchments { get; set; }
        public int currentCatchmentNum { get; set; }

        public Dictionary<int, Catchment> Catchments;
        public CatchmentRouting outlet;

        public int numCostScenarios;
        public Dictionary<int, CostScenario> CostScenarios;

        public bool Modified { get; set; }
        public bool LockedPreCondition { get; set; }

        // Cost Values
        public double InterestRate { get; set; }        // Percent
        public double ProjectDuration { get; set; }     // Years
        public double CostOfWater { get; set; }         // $ / 1000 gal-water

        #endregion

        // Constructor
        public BMPTrainsProject()
        {
            numCatchments = 0;
            CatchmentConfiguration = DefaultCatchmentConfiguration;

            Catchments = new Dictionary<int, Catchment>();
            CostScenarios = new Dictionary<int, CostScenario>();

            // Default Values

            RequiredNTreatmentEfficiency = 80;
            RequiredPTreatmentEfficiency = 80;
            AnalysisType = sBMPAnalysis;
            RainfallZone = StaticLookupTables.DefaultRainfallZone;

            Modified = false;
            LockedPreCondition = false;
        }

        public string Version()
        {
            return "BMP Trains Version: " + Application.ProductVersion;
        }

        public string VersionNumber()
        {
            return Application.ProductVersion;
        }


        #region "Catchment - Methods to Manage Catchments"
        public Catchment getCatchment()
        {
            return getCatchment(1);
        }

        public Catchment getCatchment(int id, bool CreateNew = true)
        {
            try
            {
                Catchment c = Catchments[id];
                c.id = id;
                return c;
            }
            catch
            {
                Catchment c = getNewCatchment();
                numCatchments = id;
                //Catchments.Add(id, c);     // Add this Catchment to the Dictionary
                return c;
            }
        }

        public Catchment getNewCatchment()
        {
            // Adds a new Catchment to the Catchment Dictionary and answers the new Catchment
            Catchment c = new Catchment();          // Create a new Catchment
            c.SetValuesFromProject(this);           // Set the base values (from the project)            
            c.id = Catchments.Count + 1;            // Increment the number of Catchments
            numCatchments = c.id;
            currentCatchmentNum = c.id;
            Catchments.Add(numCatchments, c);
            return c;
        }

        public Catchment AddCatchment(int i, int j)
        {
            return AddCatchment(getCatchment(i), getCatchment(j));
        }

        public Catchment AddCatchment(Catchment c1, Catchment c2)
        {
            Catchment c = getNewCatchment();
            c.CatchmentName = "Catchment " + c1.id.ToString() + " + " + c2.id.ToString();

            c.PreArea = c1.PreArea + c2.PreArea;
            c.PostArea = c1.PostArea + c2.PostArea;

            if (c.PreArea != 0)
            {
                c.PreDCIAPercent = (c1.PreDCIAPercent * c1.PreArea + c2.PreDCIAPercent * c2.PreArea) / c.PreArea;
                c.PreNConcentration = (c1.PreNConcentration * c.PreArea + c2.PreNConcentration * c2.PreArea) / (c.PreArea);
                c.PrePConcentration = (c1.PreNConcentration * c.PreArea + c2.PrePConcentration * c2.PreArea) / (c.PreArea);
                c.PreNonDCIACurveNumber = ((100 - c1.PreDCIAPercent) * c1.PreArea + (100 - c2.PreDCIAPercent) * c2.PreArea) / c.PreArea;

            }
            if (c.PostArea != 0)
            {
                c.PostDCIAPercent = (c1.PostDCIAPercent * c1.PostArea + c2.PostDCIAPercent * c2.PostArea) / c.PostArea;
                c.PostNConcentration = (c1.PostNConcentration * c.PostArea + c2.PostNConcentration * c2.PostArea) / (c.PostArea);
                c.PostPConcentration = (c1.PostPConcentration * c.PostArea + c2.PostPConcentration * c2.PostArea) / (c.PostArea);
                c.PostNonDCIACurveNumber = ((100 - c1.PostDCIAPercent) * c1.PostArea + (100 - c2.PostDCIAPercent) * c2.PostArea) / c.PostArea;
            }
            c.BMPArea = c2.BMPArea;
            c.Rainfall = c2.Rainfall;
            c.RainfallZone = c2.RainfallZone;
            c.DoGroundwaterAnalysis = c2.DoGroundwaterAnalysis;

            //            c.PreLandUseId = c1.PreLandUseId;
            //            c.PreLandUseName = c1.PreLandUseName;
            //            c.PostLandUseId = c1.PostLandUseId;
            //            c.PostLandUseName = c1.PostLandUseName;

            c.CopyBMPs(c2);

            return c;
        }
        public Catchment AddCatchment(int i)
        {

            return AddCatchment(getCatchment(i));
        }

        public Catchment AddCatchment(Catchment c1)
        {
            Catchment c = getNewCatchment();

            c.CatchmentName = "Catchment " + id.ToString();

            c.PreArea = c1.PreArea;
            c.PostArea = c1.PostArea;

            c.PreDCIAPercent = c1.PreDCIAPercent;

            c.PreNConcentration = c1.PreNConcentration;
            c.PrePConcentration = c1.PrePConcentration;
            c.PreNonDCIACurveNumber = c1.PreNonDCIACurveNumber;

            c.PostDCIAPercent = c1.PostDCIAPercent;
            c.PostNConcentration = c1.PostNConcentration;
            c.PostPConcentration = c1.PostPConcentration;
            c.PostNonDCIACurveNumber = c1.PostNonDCIACurveNumber;

            c.BMPArea = c1.BMPArea;
            c.Rainfall = c1.Rainfall;
            c.RainfallZone = c1.RainfallZone;
            c.DoGroundwaterAnalysis = c1.DoGroundwaterAnalysis;

            c.PreLandUseId = c1.PreLandUseId;
            c.PreLandUseName = c1.PreLandUseName;
            c.PostLandUseId = c1.PostLandUseId;
            c.PostLandUseName = c1.PostLandUseName;

            c.CopyBMPs(c1);
            c.Calculate();
            return c;
        }

        public CostScenario getCostScenario()
        {
            return getCostScenario(1);
        }

        public CostScenario getCostScenario(int i)
        {
            try
            {
                CostScenario c = CostScenarios[i];
                c.id = i;
                return c;
            }
            catch
            {
                CostScenario c = createNewCostScenario();
                numCostScenarios = i;
                return c;
            }
        }

        public CostScenario createNewCostScenario()
        {
            CostScenario c = new CostScenario();          // Create a new Catchment
                                                          //c.SetValuesFromProject(this);           // Set the base values (from the project)            
            c.id = CostScenarios.Count + 1;            // Increment the number of Catchments
            numCostScenarios = c.id;
            CostScenarios.Add(numCostScenarios, c);
            return c;
        }

        public bool hasCostScenario(BMP bmp)
        {
            foreach (KeyValuePair<int, CostScenario> kvp in CostScenarios)
            {
                if ((kvp.Value.CatchmentID == bmp.CatchmentID) && (kvp.Value.BMPType == bmp.BMPType))
                {
                    return true;
                }
            }
            return false;
        }

        public CostScenario getCostScenario(BMP bmp)
        {
            foreach (KeyValuePair<int, CostScenario> kvp in CostScenarios)
            {
                if ((kvp.Value.CatchmentID == bmp.CatchmentID) && (kvp.Value.BMPType == bmp.BMPType))
                {
                    return kvp.Value;
                }
            }
            return createNewCostScenario();
        }

        public bool CostScenariosExist()
        {
            if (CostScenarios.Count >= 1) return true;
            return false;
        }

        public string[] CostScenarioNames()
        {
            string[] a = new string[numCostScenarios];

            int i = 0;
            foreach (KeyValuePair<int, CostScenario> kvp in CostScenarios)
            {
                a[i] = "Scenario " + kvp.Key.ToString() + "(" + kvp.Value.BMPType + ") : " + kvp.Value.Name;
                i++;
            }
            return a;
        }

        public double[] CostScenarioValues(string ValueToPlot)
        {
            double[] a = new double[numCostScenarios];

            int i = 0;
            foreach (KeyValuePair<int, CostScenario> kvp in CostScenarios)
            {
                if (ValueToPlot == "ConstructionCost") a[i] = kvp.Value.ConstructionCost;
                else if (ValueToPlot == "PresentValue") a[i] = kvp.Value.PresentValue;
                else a[i] = kvp.Value.AnnualCost;
                i++;
            }
            return a;
        }

        public CatchmentRouting getRoutingOutlet()
        {
            if (outlet == null) outlet = new CatchmentRouting();
            return outlet;
        }

        public CatchmentRouting getRouting(int id)
        {
            // This returns the Catchment Routing associated with the Catchment with id = id


            // We are relying on the interface to not create routings
            // with corresponding Catchments.
            if (id == 0) return getRoutingOutlet();
            return getCatchment(id).getRouting();
        }

        public string getDoGroundwaterAnalysis()
        {
            if (DoGroundwaterAnalysis == "Yes") return "Yes"; else return "No";
        }

        public bool CatchmentExists(int i = 1)
        {
            return Catchments.ContainsKey(i);
        }

        public Catchment currentCatchment()
        {
            try { return Catchments[currentCatchmentNum]; }
            catch { return getNewCatchment(); }
        }



        public void setCatchment(int id, Catchment c)
        {
            Catchment current = getCatchment(id);
            current.setFrom(c);
            current.id = id;
        }

        public string getCatchmentDisplayName(int id)
        {
            return "Catchment " + id.ToString();
        }

        public string[] getCatchmentNames()
        {
            string[] s = new string[numCatchments + 1];
            for (int i = 1; i <= numCatchments; i++)
            {
                s[i] = getCatchmentDisplayName(id);
            }
            return s;
        }

        public BMP getBMP(int CatchmentID, string bmpType)
        {
            Catchment c = getCatchment(CatchmentID);
            return c.getBMP(bmpType);
        }

        public void getValuesFromPreDevelopment(BMPTrainsProject pre)
        {
            // This will set the loadings for the specified catchment to the output
            // loading for the pre development project specified

            TargetNMassLoad = pre.outlet.Nitrogen.TotalMassLoad;
            TargetPMassLoad = pre.outlet.Phosphorus.TotalMassLoad;

            TargetNFromPreLoad = TargetNMassLoad;
            TargetPFromPreLoad = TargetPMassLoad;

            RainfallZone = pre.RainfallZone;
            MeanAnnualRainfall = pre.MeanAnnualRainfall;
            LockedPreCondition = true;


            foreach (KeyValuePair<int, Catchment> kvp in pre.Catchments)
            {
                Catchment c = getCatchment(kvp.Value.id);
                c.PreLandUseId = kvp.Value.PreLandUseId;
                c.PreLandUseName = kvp.Value.PreLandUseName;
                c.PreArea = kvp.Value.PreArea;
                c.PreRationalCoefficient = kvp.Value.PreRationalCoefficient;
                c.PreNonDCIACurveNumber = kvp.Value.PreNonDCIACurveNumber;
                c.PreDCIAPercent = kvp.Value.PreDCIAPercent;
                c.CatchmentName = kvp.Value.CatchmentName;
            }

        }
        #endregion

        #region "Interface - Image for routing configuration"
        //Returns an I
        public Image getConfigurationImage() => getConfigurationImage(this.CatchmentConfiguration);

        public Image getConfigurationImage(string s)
        {
            switch (s)
            {
                case "A": return BMPTrains_2020.Properties.Resources.Config_A;
                case "B": return BMPTrains_2020.Properties.Resources.Config_B; 
                case "C": return BMPTrains_2020.Properties.Resources.Config_C; 
                case "D": return BMPTrains_2020.Properties.Resources.Config_D; 
                case "E": return BMPTrains_2020.Properties.Resources.Config_E; 
                case "F": return BMPTrains_2020.Properties.Resources.Config_F; 
                case "G": return BMPTrains_2020.Properties.Resources.Config_G; 
                case "H": return BMPTrains_2020.Properties.Resources.Config_H; 
                case "I": return BMPTrains_2020.Properties.Resources.Config_I; 
                case "J": return BMPTrains_2020.Properties.Resources.Config_J; 
                case "K": return BMPTrains_2020.Properties.Resources.Config_K; 
                case "L": return BMPTrains_2020.Properties.Resources.Config_L; 
                case "M": return BMPTrains_2020.Properties.Resources.Config_M; 
                case "N": return BMPTrains_2020.Properties.Resources.Config_N; 
                case "O": return BMPTrains_2020.Properties.Resources.Config_O;
                case "U": return BMPTrains_2020.Properties.Resources.Config_U;

                default: return BMPTrains_2020.Properties.Resources.Config_A; 
            }
        }

        public static void OpenSelectedBMPForm(string Selection, int id)
        {
            switch (Selection)
            {
                case BMPTrainsProject.sNone: return;

                case BMPTrainsProject.sRetention:
                    Form form = new frmRetention(id);
                    form.ShowDialog();
                    break;

                case BMPTrainsProject.sExfiltration:
                    Form form1 = new frmExfiltration(id);
                    form1.ShowDialog();
                    break;

                case BMPTrainsProject.sWetDetention:
                    Form form2 = new frmWetDetention(id);
                    form2.ShowDialog();
                    break;

                case BMPTrainsProject.sStormwaterHarvesting:
                    Form form3 = new frmStormwaterHarvesting(id);
                    form3.ShowDialog();
                    break;

                case BMPTrainsProject.sGreenroof:
                    Form form4 = new frmGreenroof(id);
                    form4.ShowDialog();
                    break;

                case BMPTrainsProject.sRainGarden:
                    Form form5 = new frmRainGarden(id);
                    form5.ShowDialog();
                    break;

                case BMPTrainsProject.sFiltration:
                    Form form6 = new frmFiltration(id);
                    form6.ShowDialog();
                    break;

                case BMPTrainsProject.sSwale:
                    Form form7 = new frmSwale(id);
                    form7.ShowDialog();
                    break;

                case BMPTrainsProject.sTreeWell:
                    Form form8 = new frmTreeWell(id);
                    form8.ShowDialog();
                    break;

                case BMPTrainsProject.sVegetatedNaturalBuffer:
                    Form form9 = new frmVegetatedNaturalBuffer(id);
                    form9.ShowDialog();
                    break;

                case BMPTrainsProject.sVegetatedFilterStrip:
                    Form form10 = new frmVegetatedFilterStrip(id);
                    form10.ShowDialog();
                    break;


                case BMPTrainsProject.sUserDefinedBMP:
                    Form form11 = new frmUserDefined(id);
                    form11.ShowDialog();
                    break;


                case BMPTrainsProject.sMultipleBMP:
                    Form form12 = new frmMultipleBMP(id);
                    form12.ShowDialog();
                    break;


                default: return;
            }
        }

        #endregion

        #region "Open and Save as XML"

        public void Save()
        {            
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name

            savefile.InitialDirectory = Common.WorkingDirectory();

            savefile.FileName = Globals.Project.getFileName();
            // set filters - this can be done in properties as well
            savefile.Filter = "BMP Trains files (*.bmpt)|*.bmpt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                savefile.FileName = savefile.FileName.Replace('&', '_');
                if ( saveToFile(savefile.FileName))
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("File " + savefile.FileName + " Saved Successfully");

                    FileList fl = new FileList(savefile.FileName);
                    fl.SaveFileList();
                }
                else
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("File " + savefile.FileName + " Error occurred in save");
                }
            }
        }

        public new string AsXML()
        {
            // Add any embedded objects here - they
            // should be added as a string into the String Array
            string s = base.AsXML("1", new string[] {
                CatchmentsAsXML(), 
                CostScenariosAsXML()
            });



            s = s.Replace("&", "&amp;");

            return s;
        }

        public string CatchmentsAsXML()
        {
            string s = "";
            foreach (KeyValuePair<int,Catchment> kvp in Catchments)
            {
                Catchment c = (Catchment)kvp.Value;
                s += c.AsXML(Convert.ToString(kvp.Key));
            }
            return s;
        }

        public string CostScenariosAsXML()
        {
            string s = "";
            if (CostScenarios == null) return s;
            foreach (KeyValuePair<int, CostScenario> kvp in CostScenarios)
            {
                CostScenario c = (CostScenario)kvp.Value;
                s += c.AsXML(Convert.ToString(kvp.Key));
            }
            return s;
        }


        public new void fromXML(string xml)
        {
            if (xml == "") return;
            if (xml == null) return;

            var doc = XDocument.Parse(xml);

            ClearProperties();
            // This will get all root elements of the current object
            XmlDeserialize(doc);

            getCatchmentsFromXML(doc);
            getCostScenariosFromXML(doc);
        }

        public new void ClearProperties()
        {
            Catchments = new Dictionary<int, Catchment>();
            base.ClearProperties();
        }

        private void getCatchmentsFromXML(XDocument doc)
        {
            // Now to get each subelement Catchments
            var XElements = doc.Descendants().Where(p => p.Name.LocalName == "Catchment");
            foreach (XElement element in XElements)
            {
                int id = Convert.ToInt32(element.FirstAttribute.Value);
                Catchment c = getCatchment(id);
                c.fromXML(element.ToString());
            }
        }

        private void getCostScenariosFromXML(XDocument doc)
        {
            // Now to get each subelement Catchments
            var XElements = doc.Descendants().Where(p => p.Name.LocalName == "CostScenario");
            foreach (XElement element in XElements)
            {
                int id = Convert.ToInt32(element.FirstAttribute.Value);
                CostScenario c = getCostScenario(id);
                c.fromXML(element.ToString());
            }
        }


        #endregion

        #region "File Open and Save - Embedded Object Independent"
        public bool saveToFile(string filename)
        {
            FileName = filename;
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                    sw.WriteLine(this.AsXML());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool saveToFile()
        {
            string filename = Path.GetFileNameWithoutExtension(this.FileName);
            if ((filename == "") || (filename == null))
                filename = Common.WorkingDirectory() + "\\" + BMPTrainsProject.getUniqueFileName();

            return saveToFile(filename);            
        }

        public string openFromFile(string filename)
        {    
                //try
                //{
                    if (File.Exists(filename))
                    {
                        string s = File.ReadAllText(filename);
                        this.fromXML(s);                        
                    }
            Calculate();
            return "";
        }

        public string getFileName()
        {
            if (FileName == "") return BMPTrainsProject.getUniqueFileName();
            else return Path.GetFileNameWithoutExtension(this.FileName);
        }

        public static string getUniqueFileName()
        {
            return Common.getUniqueFileName("BMP Trains Project ", "bmpt");
        }
        #endregion

        #region "Output Reporting"
        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
                {
                    {"MeanAnnualRainfall", 2}
                };
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
                {
                    {"ProjectName", "Project Name"},
                    {"FileName", "Project File Name"},
                    {"RainfallZone", "Rainfall Zone"},
                    {"MeanAnnualRainfall", "Mean Annual Rainfall (in)"},
                    {"AnalysisType", "Analysis Type"},
                    {"RequiredNTreatmentEfficiency", "Required Nitrogen Removal Efficiency (%)"},
                    {"RequiredPTreatmentEfficiency", "Required Phosphorus Removal Efficiency (%)"},
                    {"CatchmentConfiguration", "Catchment Configuration"}
            };
        }

        public new string AsHtmlTable()
        {
            string s = "<h1>Project Information</h1>";
            s += base.AsHtmlTable();
            return s;
        }

        #endregion

        #region "Caclulation Routines - Embedded Object Dependent"
        public void Calculate()
        {
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                kvp.Value.SetValuesFromProject(this);
                kvp.Value.Calculate();

                CalculateRouting(0);  // This is a recursive routing
            }

            CalculateOutlet();
        }

        public void CalculateOutlet()
        {
            if (outlet == null) return;
            outlet.resetCatchmentRouting(); // Clears Values
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (kvp.Value.getRouting().ToID == 0) kvp.Value.getRouting().CalculateOutlet(outlet);
            }
        }
        public double CalculateTotalCatchmentNLoading()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.PostNLoading;
            }
            return t;
        }

        public double CalculateTotalCatchmentPreNLoading()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.PreNLoading;
            }
            return t;
        }

        public double CalculateTotalCatchmentPLoading()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.PostPLoading;
            }
            return t;
        }
        public double CalculateTotalCatchmentPrePLoading()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.PrePLoading;
            }
            return t;
        }

        public double CalculateTotalCatchmentGWNLoading()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.GroundwaterNLoading();
            }
            return t;
        }

        public double CalculateTotalCatchmentGWRechargeRate()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                //if (!kvp.Value.Disabled) t += kvp.Value.getRechargeRate();
                if (!kvp.Value.Disabled) t += 0.3258724* kvp.Value.getRouting().VolumeGW;
            }
            return t;

        }

        public double CalculateTotalCatchmentGWPLoading()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.GroundwaterPLoading();
            }
            return t;
        }

        public double CalculateTotalCatchmentGWPRemoved()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.GroundwaterPRemoved();
            }
            return t;
        }

        public double CalculateTotalCatchmentGWNRemoved()
        {
            double t = 0.0;
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (!kvp.Value.Disabled) t += kvp.Value.GroundwaterNRemoved();
            }
            return t;
        }

        public void CalculateRouting(int cid, int iteration = 0)
        {
            // This is a recursive function
            // Find all routings that route to cid and calculate them
            int maxIterations = 2*Catchments.Count + 1;

            // Set the Values in CatchmentRouting[cid] to the values from the Catchment
            if (cid != 0) getRouting(cid).setCatchmentRouting(getCatchment(cid));
            
            // 
            
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                if (kvp.Value.getRouting().ToID == cid)
                {
                    int upstreamID = kvp.Key;
                    if (upstreamID != cid && upstreamID != 0) {
                        iteration++;
                        if (iteration > maxIterations)
                        {
                            MessageBox.Show("You have a circular reference in your routing. Please check your routing to fix this."
                                + " This can be cause by 1 routing to 2 and 2 routing to 1 (or similar situation)."
                                , "Circular Routing Warning"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);

                            return;
                        }

                        // Recursive Call - goes Upstream and Calculates Routing of Upstream Parameters
                        // For all noddes upstream
                        CalculateRouting(upstreamID, iteration);
                        // Actual Calculation - set N and P loads to sum of Upstream - this is not recursive
                        getRouting(cid).CalculateUpstream(getRouting(upstreamID));
                        
                    }
                }
            }
        }
        #endregion

        #region "Routing Report"
        public string getRoutingReport()
        {
            Calculate();

            string s = routingReportHeader();

            s += outlet.outletReport();
            s += "<br/>";
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                s += kvp.Value.getRoutingReport();
            }
            return s;
        }

        public string routingReportHeader()
        {
            string s = "Analysis Type: " +  AnalysisType + "<br/>";
            
                double tn = this.CalculateTotalCatchmentNLoading();
                double tp = this.CalculateTotalCatchmentPLoading();

                double an = outlet.Nitrogen.TotalMassLoad;
                double ap = outlet.Phosphorus.TotalMassLoad;

                double anr = 0.0; if (tn > 0) anr = 100 * (tn - an) / tn; 
                double apr = 0.0; if (tp > 0) apr = 100 * (tp - ap) / tp;

            s += "Total Catchment Nitrogen Loading: " + tn.ToString("##.##") + " kg/yr<br/>";
            s += "Total Outlet Nitrogen Loading: " + an.ToString("##.##") + " kg/yr<br/>";
            if ( AnalysisType == BMPTrainsProject.sSpecifiedRemovalEfficiency)
            {
                s += "Nitrogen Removal Required: " +  RequiredNTreatmentEfficiency.ToString("##") + "%<br/>";
                s += "Nitrogen Removal Provided: " + anr.ToString("##");
                if (anr >  RequiredNTreatmentEfficiency) s += "% Target met<br/>"; else s += "% Target Not met<br/>";
                s += "<br/>";
            }
            s += "Total Catchment Phosphorus Loading: " + tp.ToString("##.##") + " kg/yr<br/>";
            s += "Total Outlet Phosphorus Loading: " + ap.ToString("##.##") + " kg/yr<br/>";
            if ( AnalysisType == BMPTrainsProject.sSpecifiedRemovalEfficiency)
            {
                s += "Phosphorus Removal Required: " +  RequiredPTreatmentEfficiency.ToString("##") + " %<br/>";
                s += "Phosphorus Removal Provided: " + apr.ToString("##");
                if (apr >  RequiredPTreatmentEfficiency) s += "% Target met<br/>"; else s +=  "% Target Not met<br/>";
                s += "<br/>";
            }

            return s;
        }

        public string RoutingTable()
        {
            string p = "";
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                p += "Catchment " + kvp.Key.ToString() + " Routed to ";
                if (kvp.Value.routing.ToID != 0)
                {
                    p += "Catchment " + kvp.Value.routing.ToID.ToString();
                }
                else
                {
                    p += "Outlet";
                }
                p += "<br/>";
            }
            return p;
        }

        public string summaryReport()
        {
            Calculate();

            string s  = "<h1 style='text-align:left'>Summary Treatment Report Version: " + Application.ProductVersion + "</h1>";
            s += "<table style='width:80%'><tr><td style='width:50%'>";

            s += "<div <div style='font-size: 1.2em;'>Project: " + ProjectName + "</div><br/>";
            s += "<b>Analysis Type:</b> " +  AnalysisType + "<br/>";
            s += "<b>BMP Types: </b><br/>";
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                s += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                s += "Catchment " + kvp.Key.ToString() + " - (" + kvp.Value.CatchmentName +") " ;
                s += kvp.Value.SelectedBMPTitle();
                s += "</br>";
            }
            s += "Based on % removal values to the nearest percent<br/>";
            s += "</td>";
            s += "<td style='width:50%;'>";
            s += "<div style='font-size: 1.2em; text-align:right;'>Date:" + DateTime.Now.ToString("d") + "</div><br/>";
            s += "<b>Routing Summary</b><br/>";

            s += RoutingTable();
            s += "</td>";
            s += "</tr></table>";

            // Total Loading actual loading
            double tn = this.CalculateTotalCatchmentNLoading();
            double tp = this.CalculateTotalCatchmentPLoading();

            // Calculate Loading for pre-condition
            double ptn = this.CalculateTotalCatchmentPreNLoading();
            double ptp = this.CalculateTotalCatchmentPrePLoading();

            //if (Globals.Project.AnalysisType == BMPTrainsProject.sExistingBMPInput)
            //{
            //    ptn = TargetNMassLoad;
            //    ptp = TargetPMassLoad;
            //}

            double targetNPercent = 0;
            double targetPPercent = 0;
            //double targetNMass = 0;
            //double targetPMass = 0;

            // Target only used for sPreReduction and Specified Removal Efficiency
            if (Globals.Project.AnalysisType == BMPTrainsProject.sBMPAnalysis){
                Globals.Project.TargetNMassLoad = ptn;
                Globals.Project.TargetPMassLoad = ptp;
            }

            if (Globals.Project.AnalysisType == BMPTrainsProject.sSpecifiedRemovalEfficiency)
            {
               targetNPercent = Globals.Project.RequiredNTreatmentEfficiency;
               targetPPercent = Globals.Project.RequiredPTreatmentEfficiency;
               TargetNMassLoad = tn * (100 - targetNPercent) / 100.0;
               TargetPMassLoad = tp * (100 - targetPPercent) / 100.0;
            }
            // In the case of pre reduction we must calculate the required efficiency
            // from the pre and post mass loads.
            if (Globals.Project.AnalysisType == BMPTrainsProject.sNetImprovement)
            {
                TargetNMassLoad = ptn;
                TargetPMassLoad = ptp;
                if (tn != 0) targetNPercent = 100 * (tn - ptn) / tn;
                if (tp != 0) targetPPercent = 100 * (tp - ptp) / tp;
            }

            if (Globals.Project.AnalysisType == BMPTrainsProject.sPreReduction)
            {
                TargetNMassLoad = 0.9*ptn;
                TargetPMassLoad = 0.9*ptp;
                if (tn != 0) targetNPercent = 100 * (tn - ptn) / tn;
                if (tp != 0) targetPPercent = 100 * (tp - ptp) / tp;
            }
            if (targetNPercent < 0) targetNPercent = 0;
            if (targetPPercent < 0) targetPPercent = 0;

            // an and ap are actual mass loads to outlet
            double OutletNLoad = outlet.Nitrogen.TotalMassLoad;
            double OutletPLoad = outlet.Phosphorus.TotalMassLoad;

            // Actual Reduction Percent
            double ActualNR = 0.0; if (tn > 0) ActualNR = 100 * (tn - OutletNLoad) / tn;
            double ActualPR = 0.0; if (tp > 0) ActualPR = 100 * (tp - OutletPLoad) / tp;

//            s += "Total Catchment Nitrogen Loading: " + tn.ToString("##.##") + " kg/yr<br/>";
//            s += "Total Outlet Nitrogen Loading: " + an.ToString("##.##") + " kg/yr<br/>";
            if ((Globals.Project.AnalysisType == BMPTrainsProject.sSpecifiedRemovalEfficiency) ||
                (Globals.Project.AnalysisType == BMPTrainsProject.sNetImprovement))
            {
                //s += "Nitrogen Removal Required: " + Globals.Project.RequiredNTreatmentEfficiency.ToString("##") + "%<br/>";
                //s += "Nitrogen Removal Provided: " + anr.ToString("##");
                s += "Total nitrogen target removal met? ";
                s += InterfaceCommon.YesNo((TargetMet(ActualNR,targetNPercent, 0)));
                s += "<br/>";
                s += "Total phosphorus target removal met? ";
                s += InterfaceCommon.YesNo(TargetMet(ActualPR, targetPPercent, 0));
                s += "<br/>";
            }
           

            s += "<br/><div style='font-size:1.6em'>Summary Report</div>";

            s += "<div style='font-size:1.2em'>Nitrogen</div>";
            s += "<table style='margin:10px'>";
            string td = "<td style='padding-right:30px'>";
            s += "<tr><td><h4>Surface Water Discharge</h4></td><td></td><td></td></tr>";

            // Pre loads do not show in the case of BMP Analysis
            if (Globals.Project.AnalysisType != BMPTrainsProject.sBMPAnalysis)
            { 
                s += "<tr>" + td + "Total N pre load</td>" + td + "" + ptn.ToString("##.##") + " kg/yr</td><td></td></tr>";
            }

            s += "<tr>" + td + "Total N post load</td>" + td + "" + tn.ToString("##.##") + " kg/yr</td><td></td></tr>";

            // Targets only exist in the case of Specified removal efficiency
            if ((Globals.Project.AnalysisType == BMPTrainsProject.sSpecifiedRemovalEfficiency) 
                || (Globals.Project.AnalysisType == BMPTrainsProject.sNetImprovement)
                || (Globals.Project.AnalysisType == BMPTrainsProject.sPreReduction))
            { 
                s += "<tr>" + td + "Target N load reduction</td>" + td + "" + targetNPercent.ToString("##") + " %</td><td></td></tr>";
                s += "<tr>" + td + "Target N discharge load</td>" + td + "" + TargetNMassLoad.ToString("##.##") + " kg/yr</td><td></td></tr>";
            }
            string PNLR = (Double.IsNaN(ActualNR) ? "99+" : ActualNR.ToString("##"));
            if (Double.IsNaN(OutletNLoad)) OutletNLoad = 0;

            s += "<tr>" + td + "Percent N load reduction</td>" + td + "" + PNLR + " %</td><td></td></tr>";
            s += "<tr>" + td + "Provided N discharge load</td>" + td + "" + OutletNLoad.ToString("##.##") + " kg/yr</td><td>" + (OutletNLoad * 2.205).ToString("##.##") + " lb/yr</td></tr>";
            s += "<tr>" + td + "Provided N load removed</td>" + td + "" + (tn - OutletNLoad).ToString("##.##") + " kg/yr</td><td>" + ((tn - OutletNLoad) * 2.205).ToString("##.##") + " lb/yr</td></tr>";
            double recharge = CalculateTotalCatchmentGWRechargeRate();

            //            double NRetained = BMPNMassLoadIn - BMPNMassLoadOut - GroundwaterNMassDischarge;
            //            double PRetained = BMPPMassLoadIn - BMPPMassLoadOut - GroundwaterPMassDischarge;

            if (Globals.Project.DoGroundwaterAnalysis == "Yes")
            {
                s += "<tr><td><h4><br/>Groundwater Discharge</h4></td><td></td><td></td></tr>";
                double gwn = CalculateTotalCatchmentGWNLoading();   // Total mass of N going into GW/Media
                double gwnr = CalculateTotalCatchmentGWNRemoved();  // Total mass removed
                double gwnd;

                if (gwnr != 0)
                {
                    gwnd = gwn - gwnr; // TOtal mass discharged from media into GW
                }
                else
                {
                    gwnd = (tn - OutletNLoad);
                }
                double gwpr = 0.0;
                if (gwn  != 0) gwpr = 100* gwnd / gwn;
                double Nconcentration = (recharge != 0 ? (gwnd * 1e6)  / (recharge * 3785411.78) : 0.0);
                //double NConcentration = (tn-OutletNLoad)
                s += "<tr>" + td + "Average Annual Recharge</td>" + td + "" + recharge.ToString("##.###") + " MG/yr</td><td></td></tr>";
                s += "<tr>" + td + "Provided N recharge load</td>" + td + "" + gwnd.ToString("##.###") + " kg/yr</td><td>" + (gwnd * 2.205).ToString("##.##") + " lb/yr</td></tr>";
                s += "<tr>" + td + "Provided N Concentration</td>" + td + "" + Nconcentration.ToString("##.###") + " mg/l</td><td></td></tr>";
                //s += "<tr>" + td + "Provided N load removed</td>" + td + "" + gwnr.ToString("##.##") + " kg/yr</td><td>" + (gwnr * 2.205).ToString("##.##") + " lb/yr</td></tr>";
            }

            s += "</table><br/>";
            s += "<div style='font-size:1.2em'>Phosphorus</div>";
            s += "<table style='margin:10px'>";
            s += "<tr><td><h4><br/>Surface Water Discharge</h4></td><td></td><td></td></tr>";

            if (Globals.Project.AnalysisType != BMPTrainsProject.sBMPAnalysis)
            {
                s += "<tr>" + td + "Total P pre load</td>" + td + "" + ptp.ToString("##.###") + " kg/yr</td><td></td></tr>";
            }

            s += "<tr>" + td + "Total P post load</td>" + td + "" + tp.ToString("##.###") + " kg/yr</td><td></td></tr>";

            if ((Globals.Project.AnalysisType == BMPTrainsProject.sSpecifiedRemovalEfficiency)
                || (Globals.Project.AnalysisType == BMPTrainsProject.sNetImprovement)
                || (Globals.Project.AnalysisType == BMPTrainsProject.sPreReduction))
            {
                s += "<tr>" + td + "Target P load reduction</td>" + td + "" + targetPPercent.ToString("##") + " %</td><td></td></tr>";
                s += "<tr>" + td + "Target P discharge load</td>" + td + "" + TargetPMassLoad.ToString("##.###") + " kg/yr</td><td></td></tr>";
            }

            string PPLR = (Double.IsNaN(ActualPR) ? "99+" : ActualPR.ToString("##"));
            if (Double.IsNaN(OutletPLoad)) OutletPLoad = 0;
            s += "<tr>" + td + "Percent P load reduction</td>" + td + "" + PPLR + " %</td><td></td></tr>";
            s += "<tr>" + td + "Provided P discharge load</td>" + td + "" + OutletPLoad.ToString("##.###") + " kg/yr</td>";
            s += "<td>" + (OutletPLoad * 2.205).ToString("##.##") + " lb/yr</td></tr>";
            s += "<tr>" + td + "Provided P load removed</td>" + td + "" + (tp - OutletPLoad).ToString("##.###") + " kg/yr</td>";
            s += "<td>" + ((tp - OutletPLoad) * 2.205).ToString("##.###") + " lb/yr</td></tr>";

            if (Globals.Project.DoGroundwaterAnalysis == "Yes")
            {
                s += "<tr><td><br/><h4>Groundwater Discharge<h4></td><td></td><td></td></tr>";
                double gwn = CalculateTotalCatchmentGWPLoading();
                double gwnr = CalculateTotalCatchmentGWPRemoved();
                double gwnd;
                if (gwnr != 0)
                {
                    gwnd = gwn - gwnr;                           // TOtal mass discharged from media into GW
                }
                else
                {
                    gwnd = tp - OutletPLoad;
                }
                double gwpr = 0.0;
                if (gwn != 0) gwpr = 100 * gwnd / gwn;
                double Pconcentration = (recharge != 0 ? (gwnd * 1e6) / (recharge * 3785411.78) : 0.0);

                s += "<tr>" + td + "Average Annual Recharge</td>" + td + "" + recharge.ToString("##.###") + " MG/yr</td><td></td></tr>";
                s += "<tr>" + td + "Provided P recharge load</td>" + td + "" + gwnd.ToString("##.####") + " kg/yr</td><td>" + (gwnd * 2.205).ToString("##.####") + " lb/yr</td></tr>";
                s += "<tr>" + td + "Provided P Concentration</td>" + td + "" + Pconcentration.ToString("##.####") + " mg/l</td><td></td></tr>";
            }

            //if (Globals.Project.TargetNMassLoad != 0) {
            //    s += "<tr><td><br/><h4>From Pre-Condition Loads<h4></td><td></td><td></td></tr>";
            //    s += "<tr>" + td + "Existing N Discharge </td>" + td + "" + Globals.Project.TargetNMassLoad.ToString("##.##") + " (kg/yr)</td><td></td></tr>";
            //    s += "<tr>" + td + "Existing P Discharge </td>" + td + "" + Globals.Project.TargetPMassLoad.ToString("##.###") + " (kg/yr)</td><td></td></tr>";
            //}

            if (Globals.Project.TargetNFromPreLoad != 0)
            {
                s += "<tr><td><br/><h4>From Pre-Condition with Treatment<h4></td><td></td><td></td></tr>";
                s += "<tr>" + td + "Existing N Discharge </td>" + td + "" + Globals.Project.TargetNFromPreLoad.ToString("##.##") + " (kg/yr)</td><td></td></tr>";
                s += "<tr>" + td + "Existing P Discharge </td>" + td + "" + Globals.Project.TargetPFromPreLoad.ToString("##.###") + " (kg/yr)</td><td></td></tr>";
            }

            s += "</table>";
            return s;
        }
        

        public bool TargetMet(double actual, double target, int places)
        {
            if (Math.Round(actual, places) >= Math.Round(target, places)) return true;
            return false;
        }

        public string InputParameters()
        {
            string s = "<h2> General Site Information</h2>";
            s += Common.ParameterString( ProjectName, "Project Name");
            s += Common.ParameterString( RainfallZone, "Rainfall Zone");
            s += Common.ParameterString( MeanAnnualRainfall, "Mean Annual Rainfall (in)", 2);
            s += Common.ParameterString( AnalysisType, "Analysis Type");
            s += Common.ParameterString( DoGroundwaterAnalysis, "Do Groundwater Analysis"); 

            s += Common.ParameterString( RequiredNTreatmentEfficiency, "Required Nitrogen Efficiency");
            s += Common.ParameterString( RequiredPTreatmentEfficiency, "Required Phosphorus Efficiency");
            return s;
        }

        #endregion

        #region "Summary Report"

        public string CatchmentReport()
        {
            string br = "<br/>";
            string s = "<h1>Complete Report (not including cost) Ver " + Application.ProductVersion + "</h1>";
            s += "Project: " + ProjectName + br;
            s += "Date: " + DateTime.Now + br;
            s += "<h2>Site and Catchment Information</h2><br/>";
            s += "Analysis: " + AnalysisType + br + br;

            s += CatchmentTable();
            s += "<br/><br/>";
            for (int i = 1; i <= numCatchments; i++)
            {
                s += "<h2>Catchment Number: " + i.ToString() + "  Name: " + Catchments[i].CatchmentName + "</h2>";
                s += Catchments[i].CatchmentReport();
                s += "<br/>";
                s += Catchments[i].getRoutingBalanceReport();
                s += "<br/>";
            }
            s += "<br/>";
            s += summaryReport();
            return s;
        }

        public string CatchmentTable()
        {
            string s = "<table>";
            // Simply Put the title and the property and places (if decimal)
            s += CatchmentTableRow("Catchment Name", "CatchmentName");
            s += CatchmentTableRow("Rainfall Zone", "RainfallZone");
            s += CatchmentTableRow("Annual Mean Rainfall", "Rainfall", 2);
            s += CatchmentHeaderRow("<h2>Pre-Condition Landuse Information</h2>");
            s += CatchmentTableRow("Landuse", "PreLandUseName");
            s += CatchmentTableRow("Area (acres)", "PreArea", 2);
            s += CatchmentTableRow("Rational Coefficient (0-1)", "PreRationalCoefficient", 2);
            s += CatchmentTableRow("Non DCIA Curve Number", "PreNonDCIACurveNumber", 2);
            s += CatchmentTableRow("DCIA Percent (0-100)", "PreDCIAPercent", 2);
            s += CatchmentTableRow("Nitrogen EMC (mg/l)", "PreNConcentration", 3);
            s += CatchmentTableRow("Phosphorus EMC (mg/l)", "PrePConcentration", 3);
            s += CatchmentTableRow("Runoff Volume (ac-ft/yr)", "PreRunoffVolume", 3);
            s += CatchmentTableRow("Groundwater N (kg/yr)", "PreGWN", 3);
            s += CatchmentTableRow("Groundwater P (kg/yr)", "PreGWP", 3);
            s += CatchmentTableRow("Nitrogen Loading (kg/yr)", "PreNLoading", 3);
            s += CatchmentTableRow("Phosphorus Loading (kg/yr)", "PrePLoading", 3);
            s += CatchmentHeaderRow("<h2>Post-Condition Landuse Information</h2>");
            s += CatchmentTableRow("Landuse", "PostLandUseName");
            s += CatchmentTableRow("Area (acres)", "PostArea", 2);
            s += CatchmentTableRow("Rational Coefficient (0-1)", "PostRationalCoefficient", 2);
            s += CatchmentTableRow("Non DCIA Curve Number", "PostNonDCIACurveNumber", 2);
            s += CatchmentTableRow("DCIA Percent (0-100)", "PostDCIAPercent", 2);
            s += CatchmentTableRow("Wet Pond Area (ac)", "BMPArea", 2);
            s += CatchmentTableRow("Nitrogen EMC (mg/l)", "PostNConcentration", 3);
            s += CatchmentTableRow("Phosphorus EMC (mg/l)", "PostPConcentration", 3);
            s += CatchmentTableRow("Runoff Volume (ac-ft/yr)", "PostRunoffVolume", 3);
            s += CatchmentTableRow("Groundwater N (kg/yr)", "PostGWN", 3);
            s += CatchmentTableRow("Groundwater P (kg/yr)", "PostGWP", 3);
            s += CatchmentTableRow("Nitrogen Loading (kg/yr)", "PostNLoading", 3);
            s += CatchmentTableRow("Phosphorus Loading (kg/yr)", "PostPLoading", 3);
            s += "</table>";
            return s;
        }

        public string CatchmentTableRow(string title, string param, int places = -1)
        {
            string s = "<tr><td>" + title + "</td>";
            for (int i = 1; i <= numCatchments; i++)
            {
                if (places == -1)
                    s += "<td>" + Catchments[i].GetValue(param) + "<td>";
                else
                    s += "<td>" + Catchments[i].GetValue(param,places) + "<td>";
            }
            s += "</tr>";
            return s;
        }

        public string CatchmentHeaderRow(string header)
        {
            string s = "<tr><td colspan = '" + numCatchments.ToString() + "'>" + header + "</td></tr>";
            return s;
        }

        #endregion


        #region "Catchment Report"
        public string CatchmentReport(int cn)
        {
            string s = "<br/><h1>Catchment Information</h1>";
            s += "<b>" + Catchments[cn].TitleHeader() + "</b>";
            s += "<table>";           
            foreach (KeyValuePair<string, string> kvp in Catchments[cn].PropertyLabels())
            {
                s += CatchmentReportRow(cn, kvp.Key);
            }
            //if (AnalysisType == BMPTrainsProject.sNetImprovement)
            //{
            //    s += "<tr><td><b>" + AnalysisType  + "</b></td><td></td></tr>";
            //    s += "<tr><td>Nitrogen Net Improvement (%)</td><td>" + String.Format("{0:N1}", Catchments[cn].CalculateNImprovement()) + "</td></tr>";
            //    s += "<tr><td>Phosphorus Net Improvement (%)</td><td>" + String.Format("{0:N1}", Catchments[cn].CalculatePImprovement()) + "</td></tr>";
            //}
            s += "</table>";
            return s;
        }

        public string CatchmentReportRow(int cn, string property)
        {
            string s = "<tr>";
            s += "<td>" + Catchments[cn].PropertyLabels()[property] + "</td>";
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                s += "<td>" + kvp.Value.GetValue(property) + "</td>";
            }
           
            s += "</tr>";
            return s;
        }

        public string TitleHeader()
        {
            string s = " Analysis: " + AnalysisType;
            if ((AnalysisType == sSpecifiedRemovalEfficiency) || (AnalysisType == sNetImprovement) || (AnalysisType == sPreReduction))
                return s + " Required Removal " + String.Format("N: {0:N0}% ", RequiredNTreatmentEfficiency) + String.Format("P: {0:N0}%", RequiredPTreatmentEfficiency);

            //if (AnalysisType == sExistingBMPInput)
            //    return s + " Existing Removals (kg/yr) " + String.Format("N: {0:N0}% ", TargetNMassLoad) + String.Format("P: {0:N0}%", TargetPMassLoad);

            return s;
        }

        public Dictionary<string, string> CostLabels()
        {
            return  new Dictionary<string, string>
            {
                {"InterestRate", "Interest Rate (%)"  },
                {"ProjectDuration", "Project Duration (yr)"},
                {"CostOfWater", "Cost of Water ($ /1000 gal)"}
            };
        }
        #endregion

        #region "Cost Summary Report"
        public string CostReport()
        {
            string s = "<h2>Summary Cost Report</h2>";
            s += AsHtmlTable(CostLabels());
            s += "<br/>";
            return s;
        }

        public string FullCostReport()
        {

            string s = CostReport();
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                kvp.Value.CalculateCost();
                s += "<br/>";
                s += "<b>" + kvp.Value.CatchmentName + " (Catchment #" + kvp.Key.ToString() + ") </b><br/>";
                s += kvp.Value.CatchmentCostTable();
            }
            return s;

        }

        public string FullCostCopy()
        {
            string s = "";
            foreach (KeyValuePair<int, Catchment> kvp in Catchments)
            {
                s += kvp.Value.CatchmentName + "\tCatchment" + kvp.Key.ToString() + "\n";
                s += kvp.Value.CatchmentCostCopy();
                s += "\n";
            }
            return s;
        }

        #endregion

        #region "Retention Report"
        //public string RetentionReport()
        //{
        //    string s = "";
        //    s += "<table><tr><td></td><td>Catchment 1</td><td>Catchment 2</td><td>Catchment 3</td><td>Catchment 4</td></tr>";
        //    foreach(KeyValuePair<string, string> kvp in Retention1.PropertyLabels())
        //    {
        //        s += RetentionReportRow(kvp.Key);
        //    }
        //    s += "</table>";
        //    return s;
        //}

        //public string RetentionReportRow(string property)
        //{
        //    string s = "<tr>";
        //    s += "<td>" + Retention1.PropertyLabels()[property] + "</td>";
        //    s += "<td>" + Retention1.GetValue(property) + "</td>";
        //    s += "<td>" + Retention2.GetValue(property) + "</td>";
        //    s += "<td>" + Retention3.GetValue(property) + "</td>";
        //    s += "<td>" + Retention4.GetValue(property) + "</td>";
        //    s += "</tr>";
        //    return s;
        //}
        #endregion

        #region "Scenario Cost Report"

        public string CostScenarioReport()
        {
            string s = "";
            if (!CostScenariosExist()) return s;
            s = "<table><tr>";
            foreach (KeyValuePair<string, string> kvp in getCostScenario(1).HorizontalCostTableColumns())
            {
                s += "<td>" + kvp.Value + "</td>";
            }
            s += "</tr>";

            foreach (KeyValuePair<int, CostScenario> kvp in CostScenarios)
            {
                s += kvp.Value.CostTableReportRow();
            }

            s += "</table>";
            return s;
        }

        #endregion

        #region "Static Methods"

        public static Dictionary<string, string> CatchmentConfigurations()
        {
            Dictionary<string, string> d = new Dictionary<string, string>
            {
                {"A", "Single Catchment" },
                {"B", "2 Catchment-Series"},
                {"C", "2 Catchment-Parallel"},
                {"D", "3 Catchment-Series"},
                {"E" , "3 Catchment-Parallel" },
                {"F" , "Mixed-3 Catchment-2 Series-Parallel (A)"},
                {"G" , "Mixed-3 Catchment-2 Series-Parallel (B)"},
                {"H" , "4 Catchment-Series"},
                {"I" , "Mixed-4 Catchment-Series (A)"},
                {"J" , "Mixed-4 Catchment-3 Series-Parallel"},
                {"K" , "Mixed-4 Catchment-Series (B)"},
                {"L" , "4 Catchment-Parallel"},
                {"M" , "Mixed-4 Catchment-2 Series"},
                {"N" , "Mixed-4 Catchment-2 Series-2 Parallel"},
                {"O" , "Mixed-4 Catchment- Parallel- Series"},
                {"U" , "Multiple Catchments - User Defined"}
            };

            return d;
        }
        #endregion
    }
}

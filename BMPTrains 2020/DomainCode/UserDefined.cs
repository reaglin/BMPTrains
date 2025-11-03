using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class UserDefinedBMP : Storage
    {
        public static Dictionary<string,int> UserDefinedOptions()
        {
        return new Dictionary<string,int>
            {
                {"Baffle Boxes", 1},
                {"Baffle Boxes 2nd Gen",2},
                {"Hydrodynamic Separators",3},
                {"Catch Basin Inserts",4},
                {"Alum Treating",5},
                {"Street Sweeping",6},
                {"Other",7 }
            };
        }
        public static void PopulateUserDefinedOptions(ComboBox cb)
        {
            cb.DataSource = new System.Windows.Forms.BindingSource(UserDefinedOptions(), null);
            cb.DisplayMember = "Key";
            cb.ValueMember = "Key";
        }
       
        public new static readonly string[] InputVariables = {
            "ContributingArea", "CalculatedNTreatmentEfficiency", "CalculatedPTreatmentEfficiency"};
        public UserDefinedBMP(Catchment c) : base(c)
        {
            BMPType = BMPTrainsProject.sUserDefinedBMP;
        }

        public override Dictionary<string, string> BasicReportLabels()
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>
            {
                {"label0", "<h2>User Defined BMP</h2>" },
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
            };
            return d1;
        }
        public override string BMPInputVariables()
        {
            string s = "";
            s += AsHtmlTable(
                new Dictionary<string, string>
            {
                {"ContributingArea", "Contributing Catchment Area (acres)" },
                {"CalculatedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"CalculatedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
            });
            return s;
        }


        public override bool isDefined()
        {
            if (ProvidedNTreatmentEfficiency > 0) return true;
            return false;
        }

        public override bool isRetention()
        {
            return false;
        }

        public new void Calculate()
        {
            base.CalculateMassLoading();
        }
    }
}

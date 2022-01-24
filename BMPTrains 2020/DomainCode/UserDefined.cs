using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class UserDefinedBMP : Storage
    {
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
                {"ProvidedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
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
                {"ProvidedNTreatmentEfficiency", "Provided Nitrogen Treatment Efficiency (%)"},
                {"ProvidedPTreatmentEfficiency", "Provided Phosphorus Treatment Efficiency (%)"}
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

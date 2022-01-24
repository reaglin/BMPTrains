using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class LandUse : XmlPropertyObject
    {
        public const string SessionId = "LandUseID";

        public string TotalNitrogen { get; set; }
        public string TotalPhosphorus { get; set; }
        public string BOD { get; set; }
        public string COD { get; set; }
        public string Ammonia { get; set; }
        public string Turbidity { get; set; }
        public string TotalSuspendedSolids { get; set; }
        public string Coliforms { get; set; }
        public string OrthoPhosphates { get; set; }
        public string Nitrates { get; set; }
        public string Copper { get; set; }
        public string Iron { get; set; }
        public string Zinc { get; set; }
        public string Cadmium { get; set; }
        public string Lead { get; set; }
        public string Mercury { get; set; }

        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
                {
                    {"TotalNitrogen", "Total Nitrogen (mg/l)"},
                    {"TotalPhosphorus", "Total Phosphorus (mg/l)"},
                    {"BOD", "BOD  (mg/l)"},
                    {"COD", "COD  (mg/l)"},
                    {"Ammonia", "Ammonia (mg/l)"},
                    {"Turbidity", "Turbidity (mg/l)"},
                    {"TotalSuspendedSolids", "Total Suspended Solids (mg/l)"},
                    {"Coliforms", "Coliforms (mg/l)"},
                    {"OrthoPhosphates", "OrthoPhosphates (mg/l)"},
                    {"Nitrates", "Nitrates (mg/l)"},
                    {"Copper", "Copper (mg/l)"},
                    {"Iron", "Iron (mg/l)"},
                    {"Zinc", "Zinc (mg/l)"},
                    {"Cadmium", "Cadmium (mg/l)"},
                    {"Lead", "Lead (mg/l)"},
                    {"Mercury", "Mercury (mg/l)"}
                };
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
                {
                    {"TotalNitrogen", 3},
                    {"TotalPhosphorus", 3},
                    {"BOD", 2},
                    {"COD", 2},
                    {"Ammonia", 2},
                    {"Turbidity", 2},
                    {"TotalSuspendedSolids", 2},
                    {"Coliforms", 2},
                    {"OrthoPhosphates", 2},
                    {"Nitrates", 2},
                    {"Copper", 3},
                    {"Iron", 3},
                    {"Zinc", 3},
                    {"Cadmium", 3},
                    {"Lead", 3},
                    {"Mercury", 4}
                };
        }

    }

}

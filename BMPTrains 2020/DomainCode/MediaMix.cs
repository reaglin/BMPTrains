using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020.DomainCode
{
    static class MediaMix
    {
        public static string NotSpecified = "Not Specified";
        public static string None = "None";
        public static string BnG_ECT = "IFGEM";
        public static string BnG_OTE = "ICS";
        public static string BnG_ECT3 = "B&G ECT Mixes";
        public static string SAT = "SAT";
        public static string BnG_CTS12 = "B&G CTS12";
        public static string BnG_CTS24 = "B&G CTS24";
        public static string P_Pavement = "Pervious Pavement";
        public static string User_Defined = "User Defined";

        public static string defaultMix = NotSpecified;
        

        public static Dictionary<string, List<double>> MediaMixes()
        {       
            // TN Treatment Efficiency (%), TP Treatment Efficiency (%), Sustain (void fraction) , Sorption Rate (mg/g), Treatment Rate (gpm/sf)
            Dictionary<string, List<double>> d = new Dictionary<string, List<double>>
            {
                {NotSpecified, new List<double> {0.0, 0.0, 0.25, 0.0, 00, 0 }},
                //{BnG_ECT, new List<double> {45.0, 45.0, 0.25, 0.2, 63, 1.0}},
                {BnG_OTE, new List<double>  {80.0, 95.0, 0.30, 0.6, 105, 0.104 }}, //Now IFGEM // Now ICS
                {BnG_ECT3, new List<double> {45.0, 45.0, 0.30, 0.2, 63, 1.0 }},
                {SAT, new List<double>      {20.0, 45.0, 0.30, 0.2, 95, 0.02 }},
                {BnG_CTS12, new List<double> {60.0, 90.0, 0.30, 0.2, 95, 0.052 }},
                {BnG_CTS24, new List<double> {75.0, 95.0, 0.30, 0.2, 95, 0.052 }},
                {P_Pavement, new List<double> {60.0, 90.0, 0.30, 0.2, 95, 0.052 }},
                {User_Defined, new List<double> {0.0, 0.0, 0.25, 0.0, 00, 0.0 }},
            };
            return d;
        }

        public static void PopulateComboBox(ComboBox cb)
        {
            cb.DataSource = new System.Windows.Forms.BindingSource(MediaMix.MediaMixes(), null);
            cb.DisplayMember = "Key";
            cb.ValueMember = "Key";
        }

        public static bool isUserDefined(string mix, double defaultValue = 0.0)
        {
            if (mix == User_Defined) return true;
            return false;
        }

        public static bool isDefined(string mix)
        {
            if (mix == NotSpecified) return false;
            if (mix == None) return false;
            if (mix == "") return false;
            if (mix == null) return false;
            if (!MediaMix.MediaMixes().Keys.Contains<string>(mix)) return false;
            return true;
        }

        public static double TNRemoval(string mix, double defaultValue = 0.0, bool WetDetention = false)
        {
            if (!isDefined(mix)) return 0.0;

            if (mix == User_Defined) return defaultValue;

            if (WetDetention)
            {
                //if (mix == BnG_ECT) return 25.0;
                if (mix == BnG_ECT3) return 25.0;
                //if (mix == BnG_OTE) return 45.0;
                if (mix == SAT) return 25.0;
            }

            try
            {
                return Convert.ToDouble(MediaMixes()[mix][0]);
            }
            catch
            {
                return defaultValue;
            }
            
        }

        public static double TPRemoval(string mix, double defaultValue = 0.0, bool WetDetention = false)
        {
            if (!isDefined(mix)) return 0.0;
            if (mix == User_Defined) return defaultValue;

            if (WetDetention)
            {
                //if (mix == BnG_ECT) return 25.0;
                if (mix == BnG_ECT3) return 25.0;
                //if (mix == BnG_OTE) return 25.0;
                if (mix == SAT) return 25.0;
            }

            try
            {
                return Convert.ToDouble(MediaMixes()[mix][1]);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static double SorptionRate(string mix)
        {

            try
            {
                return Convert.ToDouble(MediaMixes()[mix][3]);
            }
            catch
            {
                return 0.0;
            }
        }

        public static double SaturatedWeight(string mix)
        {

            try
            {
                return Convert.ToDouble(MediaMixes()[mix][4]);
            }
            catch
            {
                return 0.0;
            }
        }
        public static double GPM_SF(string mix)
        {

            try
            {
                return Convert.ToDouble(MediaMixes()[mix][5]);
            }
            catch
            {
                return 0.0;
            }
        }

        public new static string ToString()
        {
            string s = "Mix Type      \tNitrogen\tPhosphorus\n";
            foreach(KeyValuePair<string, List<double>> kvp in MediaMixes())
            {
                s += kvp.Key.PadRight(15) + "\t";
                s += kvp.Value[0].ToString().PadRight(10) + "\t";
                s += kvp.Value[1].ToString().PadRight(10) + "\n";
            }

            return s;

        }
    }
}

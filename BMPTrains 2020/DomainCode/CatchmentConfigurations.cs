using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class CatchmentConfigurations
    {
        public static string A = "A";

// int array is catchment # that that index routes to
// i[2] = 3 - means Catchment 2 routes to Catchment 3
// Accessible via Routings Variable
// Routings["D"][1] is the Catchment that Catchment 1 routes to, value should be 2
// Routing to 0 is output

        public static Dictionary<string, int[]> Routings = new Dictionary<string, int[]>
        {
            {"A", new int[] {0, 0 }},
            {"B", new int[] {0, 2, 0}},
            {"C", new int[] {0, 0, 0}},
            {"D", new int[] {0, 2, 3, 0 }},
            {"E", new int[] {0, 0, 0, 0 }},
            {"F", new int[] {0, 3, 3, 0 }},
            {"G", new int[] {0, 2, 0, 0 }},            
            {"H", new int[] {0, 2, 3, 4, 0 }},
            {"I", new int[] {0, 2, 4, 4, 0 }},
            {"J", new int[] {0, 2, 3, 0, 0 }},
            {"K", new int[] {0, 3, 3, 4, 0 }},
            {"L", new int[] {0, 0, 0, 0, 0 }},
            {"M", new int[] {0, 2, 0, 4, 0 }},
            {"N", new int[] {0, 2, 0, 0, 0 }},
            {"O", new int[] {0, 4, 4, 4, 0 }},
            {"U",new int[] {0, 0 }} 
        };
    }
}

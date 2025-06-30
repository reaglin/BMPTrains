using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class Reuse : Storage
    {
        public Reuse(Catchment c) : base(c) { }

        public static Dictionary<string, double[]> RainfallStations = new Dictionary<string, double[]>
        {
            {"None",  new double[] {0,0,0 }},
            {"Belle Glade #616", new double[] {10.7,72.36,50.00 }},
            {"Boca Raton #845", new double[] {10.62,61.75,42.00 }},
            {"Brooksville #1048", new double[] {10.03,66.65,45.00}},
            {"Daytona #2158", new double[] {12.06,65.43,42.00}},
            {"Fort Meyers #3186", new double[] {9.94,65.13,44.00}},
            {"Gainesville #3321", new double[] {11.77,67.21,42.00}},
            {"Homestead #4091", new double[] {9.345,64.37,44.00}},
            {"Jacksonville #4358", new double[] {11.49,64.23,40.00}},
            {"Key West #4570", new double[] {11.31,72.27,51.00}},
            {"Lakeland #4797", new double[] {12.06,66.43,42.00}},
            {"Miami #5663", new double[] {10.06,62.13,42.00}},
            {"Niceville #6240", new double[] {10.99,56.16,33.00}},
            {"Orlando #6628", new double[] {12.32, 68.17,43.00}},
            {"Panama City #6842", new double[] {11.44,57.77,33.00}},
            {"Tallahassee #8758", new double[] {10.49,58.08,35.00}},
            {"Tampa #8788", new double[] {11.31,68.52,44.00}},
            {"Venice #9176", new double[] {11.66, 69.78,47.00}},
            {"West Palm Beach #9525", new double[] {10.2,61.95,42.00}}
        };
    }
}

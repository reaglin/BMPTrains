using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020
{
    static class Globals
    {
        private static DomainCode.BMPTrainsProject project = new BMPTrainsProject();

        public static BMPTrainsProject Project { get => project; set => project = value; }

        public static string HelpURL = "http://roneaglin.online/bmptrains/";
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Meta : Attribute
    {
        public string Description { get; }
        public string ReportLabel { get; }
        public string InterfaceLabel { get; }
        public string Units { get; }
        public string Format { get; }

        public int Places { get; }

        public Meta (string description, string units = "", string format = "##.##")
        {
            Description = description;
            ReportLabel = description;
            InterfaceLabel = description;
            Units = units;
            Format = format;
            Places = Meta.CountSharpSymbolsAfterDot(format);
        }

        public Meta(string description, string units = "", int places = 2)
        {
            Description = description;
            ReportLabel = description;
            InterfaceLabel = description;
            Units = units;
            Format = CreateStringWithHashes(places);
            Places = places;
        }

        public Meta(string description, string reportLabel, string interfaceLabel, string units, string format = "##.##") : this(description, units, format)
        {
            ReportLabel = reportLabel;
            InterfaceLabel = interfaceLabel;
        }

        public static int CountSharpSymbolsAfterDot(string inputString)
        {
            int firstDotIndex = inputString.IndexOf('.');

            if (firstDotIndex == -1)
            {
                return 0; // No dot found
            }

            string substringAfterDot = inputString.Substring(firstDotIndex + 1);
            return substringAfterDot.Count(c => c == '#');
        }

        public static string CreateStringWithHashes(int n)
        {
            return "##." + new string('#', n);
        }
    }
}

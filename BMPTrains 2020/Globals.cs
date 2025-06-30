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

        public Meta (string description, string units = "", string format = "##.##")
        {
            Description = description;
            ReportLabel = description;
            InterfaceLabel = description;
            Units = units;
            Format = format;
        }

        public Meta(string description, string reportLabel, string interfaceLabel, string units, string format = "##.##") : this(description, units, format)
        {
            ReportLabel = reportLabel;
            InterfaceLabel = interfaceLabel;
        }


    }
}

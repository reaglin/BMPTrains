using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    

    public class ReportLine
    {
        public string Property { get; set; }
        public string Label { get; set; }
        public int Decimal { get; set; }

        public ReportLine(string p, string l, int d)
        {
            Property = p;
            Label = l;
            Decimal = d;
        }

        public ReportLine(string p, int d)
        {
            Property = p;            
            Decimal = d;
        }

        public ReportLine(string p)
        {
            Property = p;
        }

    }
}

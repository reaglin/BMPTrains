using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class CostScenario : XmlPropertyObject
    {
        public int CatchmentID { get; set; }
        public string BMPType { get; set; }
        public double AnnualCost { get; set; }
        public double ConstructionCost { get; set; }
        public double PresentValue { get; set; }

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string> {
                {"AnnualCost", "Annual Cost ($)"},
                {"ConstructionCost", "Construction Cost ($)"},
                {"PresentValue", "Present Value ($)"}
            };
            return current;
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
            {
                {"AnnualCost", -2},
                {"ConstructionCost", -2},
                {"PresentValue", -2},
                {"AnnualCost", -2},
                {"ConstructionCost", -2},
                {"PresentValue", -2}
            };

            return current;
        }

        public void CreateFromBMP(BMP bmp)
        {
            this.CatchmentID = bmp.CatchmentID;
            this.BMPType = bmp.BMPType;
            this.AnnualCost = bmp.TotalAnnualCost;
            this.ConstructionCost = bmp.BMPCost;
            this.PresentValue = bmp.PresentWorth;
        }


        public Dictionary<string, string> HorizontalCostTableColumns()
        {
            return new Dictionary<string, string>
            {
                {"id", "Scenario Number" },
                {"Name", "Scenario Name"},
                {"CatchmentID", "Catchment Number" },
                {"BMPType", "BMP Type"},
                {"ConstructionCost","Construction Cost ($)"},
                {"AnnualCost","Annual Cost ($/yr)"},
                {"PresentValue","Present Value/Life Cycle Cost ($)"}
            };
        }

        public string CostTableReportRow(string pre = "<tr>", string post = "</tr>")
        {
            string s = "";
            string preCell = "";
            string postCell = "\t";

            if (pre == "<tr>") { preCell = "<td>"; postCell = "</td>"; }

            s += pre;
            s += CostTableReportCell(id, 0, preCell, postCell);
            s += preCell + Name + postCell;
            s += CostTableReportCell(CatchmentID, 0, preCell, postCell);
            s += preCell + BMPType + postCell;
            s += CostTableReportCell(ConstructionCost, 2, preCell, postCell);
            s += CostTableReportCell(AnnualCost, 2, preCell, postCell);
            s += CostTableReportCell(PresentValue, 2, preCell, postCell);
            s += post;
            return s;
        }

        public string CostTableReportCell(double d, int n = 2, string pre = "<td>", string post = "</td>")
        {
            string s = "";
            s += pre + String.Format("{0:N" + n.ToString() + "}", d) + post;
            return s;
        }

    }
}

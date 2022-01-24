using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class ValueDictionary
    {
        // Used as a Abstract class to create a Dictionary<string, double> of 
        // This is a common pattern used in the program
        // Example
        // Concrete Pervious Pavement\t25.00\nFilterPave\t20.00\n 
        // Tab \t separates the description and the value
        // New Line \n separates the different dictionary values
        //
        public string Name { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }

        public string[] Descriptions()
        {
            string[] rows = Description.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] ret = new string[rows.Count()];
            for (int i = 0; i < rows.Count(); i++)
            {
                string[] cells = rows[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                ret[i] = cells[0];
            }
            return ret;
        }

        public double[] Values()
        {
            string[] rows = Description.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            double[] ret = new double[rows.Count()];
            for (int i = 0; i < rows.Count(); i++)
            {
                string[] cells = rows[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                if (cells[1].Trim() != String.Empty)
                {
                    ret[i] = Convert.ToDouble(cells[1]);
                }
                else
                {
                    ret[i] = 0;
                }

            }
            return ret;
        }

        public Dictionary<string, double> AsDictionary()
        {
            Dictionary<string, double> d = new Dictionary<string, double>();

            string[] rows = Description.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < rows.Count(); i++)
            {
                string[] cells = rows[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                d.Add(cells[0], Convert.ToDouble(cells[1]));
            }
            return d;
        }

        public string getDescription(int i)
        {
            return Descriptions()[i];
        }
    }
}

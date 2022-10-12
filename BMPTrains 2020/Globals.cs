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
}

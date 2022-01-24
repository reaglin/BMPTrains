using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPTrains_2020.DomainCode
{
    public class NoBMP : BMP
    {
        public NoBMP(Catchment c) : base(c)
        {
            BMPType = BMPTrainsProject.sNone;
            ProvidedNTreatmentEfficiency = 0;
            ProvidedPTreatmentEfficiency = 0;
        }

        public override bool isDefined()
        {
            return true;
        }
    }
}

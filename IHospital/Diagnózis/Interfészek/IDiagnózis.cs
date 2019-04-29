using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Diagnózis
{
    interface IDiagnózis
    {
        Súlyosság Súlyosság { get; set; }
        int Műtétidőtartam { get; set; }
        void Kiír();
    }
}

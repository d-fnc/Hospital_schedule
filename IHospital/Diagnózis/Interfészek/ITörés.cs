using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Diagnózis
{
    interface ITörés : IDiagnózis
    {
        bool Nyílt { get; set; }
        string Elhelyezkedés { get; set; }
    }
}

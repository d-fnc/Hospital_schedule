using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Diagnózis
{
    interface IGyulladás : IDiagnózis
    {
        bool Váladékos { get; set; }
        GyulladásMérték Mértéke { get; set; }
        string Elhelyezkedése { get; set; }
    }
}

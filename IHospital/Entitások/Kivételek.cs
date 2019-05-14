using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Entitások
{
    class NincsenekBetegekKivétel : Exception
    {
        public string msg;
        public NincsenekBetegekKivétel(String msg)
        { this.msg = msg; }
    }

    class TúlSokSzabadIdőKivétel : Exception
    {
        public string msg;
        public TúlSokSzabadIdőKivétel(String msg)
        { this.msg = msg; }
    }

    class NincsIlyenBetegKivétel : Exception
    {
        public string msg;
        public NincsIlyenBetegKivétel(String msg)
        { this.msg = msg; }
    }

    class HibásFájlKivétel : Exception { }
}

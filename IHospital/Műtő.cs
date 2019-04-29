using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital
{
    class Műtő
    {
        public List<Beteg> betegek = new List<Beteg>();
        public int hasznaltPercek;

        public void Beoszt(Beteg beteg)
        {
            betegek.Add(beteg);
            hasznaltPercek += beteg.Diagnózis.Műtétidőtartam;
        }

        public Műtő Másolat()
        {
            return new Műtő(betegek, hasznaltPercek);
        }

        public Műtő(List<Beteg> betegek, int hasznaltPercek)
        {
            this.betegek = betegek;
            this.hasznaltPercek = hasznaltPercek;
        }
    }
}

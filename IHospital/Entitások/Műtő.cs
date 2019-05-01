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
        public int SumSúlyosság;
        private string név;

        public void Beoszt(Beteg beteg)
        {
            betegek.Add(beteg);
            hasznaltPercek += beteg.Diagnózis.Műtétidőtartam;
            SumSúlyosság += (int) beteg.Diagnózis.Súlyosság;
        }

        public Műtő(String név)
        {
            betegek = new List<Beteg>();
            hasznaltPercek = 0;
            SumSúlyosság = 0;
            this.név = név;
        }

        public Műtő(List<Beteg> betegek, String név)
        {
            this.betegek = betegek;
            foreach (var beteg in betegek)
            {
                this.hasznaltPercek += beteg.Diagnózis.Műtétidőtartam;
                this.SumSúlyosság += (int)beteg.Diagnózis.Súlyosság;
            }

        }

        public string getNév()
        {
            return név;
        }
    }
}

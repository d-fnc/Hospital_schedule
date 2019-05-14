using IHospital.Entitások;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital
{
    class Műtő
    {
        public LancoltLista betegek = new LancoltLista();
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
            betegek = new LancoltLista();
            hasznaltPercek = 0;
            SumSúlyosság = 0;
            this.név = név;
        }

        public Műtő(LancoltLista betegek, String név)
        {
            this.betegek = betegek;
            for(int i = 0; i < betegek.Size(); i++)
            {
                Beteg beteg = betegek.Get(i);
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

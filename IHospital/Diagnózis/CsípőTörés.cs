﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Diagnózis
{
    class CsípőTörés : ITörés
    {
        private string Típus = "Csípőtörés";
        public Súlyosság Súlyosság { get; set; }
        public int Műtétidőtartam { get; set; }
        public bool Nyílt { get; set; }
        public string Elhelyezkedés { get; set; }

        public CsípőTörés(Súlyosság súlyosság, int időtartam, bool nyílt, string hely)
        {
            this.Súlyosság = súlyosság;
            this.Műtétidőtartam = időtartam;
            this.Nyílt = nyílt;
            this.Elhelyezkedés = hely;
        }
        public void Kiír()
        {
            string súlyosság = Enum.GetName(typeof(Súlyosság), this.Súlyosság);
            string nyílt = this.Nyílt ? "Igen" : "Nem";
            Console.Write("Műtét ideje: " + Műtétidőtartam + "perc; " + this.Típus + "; Súlyosság: " + súlyosság + ";" + Environment.NewLine + "Nyílt: " + nyílt + "; Elhelyezkedése: " + Elhelyezkedés);
        }
    }
}

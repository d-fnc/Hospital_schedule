using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Diagnózis
{
    class VakbélGyulladás : IGyulladás
    {
        private string Típus = "Vakbél gyulladás";
        public Súlyosság Súlyosság { get; set; }
        public int Műtétidőtartam { get; set; }
        public bool Váladékos { get; set; }
        public GyulladásMérték Mértéke { get; set; }
        public string Elhelyezkedése { get; set; }

        public VakbélGyulladás(Súlyosság súlyosság, int időtartam, bool váladék, GyulladásMérték mérték, string hely)
        {
            this.Súlyosság = súlyosság;
            this.Műtétidőtartam = időtartam;
            this.Váladékos = váladék;
            this.Mértéke = mérték;
            this.Elhelyezkedése = hely;
        }
        public void Kiír()
        {
            string súlyosság = Enum.GetName(typeof(Súlyosság), this.Súlyosság);
            string váladékos = this.Váladékos ? "Igen" : "Nem";
            string gyulladásmérték = Enum.GetName(typeof(GyulladásMérték), this.Mértéke);
            Console.Write("Műtét ideje: " + Műtétidőtartam + "perc; " + this.Típus + "; Súlyosság: " + súlyosság + "; " + Environment.NewLine + "Váladékos: " + váladékos + "; Gyulladás mértéke: " + gyulladásmérték + "; Elhelyezkedése: " + Elhelyezkedése);
        }
    }
}

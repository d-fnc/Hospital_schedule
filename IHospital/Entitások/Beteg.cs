using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital
{
    using Diagnózis;
    class Beteg
    {
        public string Név { get; set; }
        public int Életkor { get; set; }
        public IDiagnózis Diagnózis { get; set; }

        public Beteg(string név, int kor, IDiagnózis diagnózis)
        {
            this.Név = név;
            this.Életkor = kor;
            this.Diagnózis = diagnózis;
        }

        public void Kiír()
        {
            Console.WriteLine(Név + ", " + Életkor);
            Diagnózis.Kiír();
            Console.Write(Environment.NewLine);
            Console.Write("----------------------------------------------------------");
            Console.Write(Environment.NewLine);
        }
    }
}

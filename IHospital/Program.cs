using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHospital.Diagnózis;

namespace IHospital
{
    class Program
    {
        private static Rendező rendező;
        static void Main(string[] args)
        {
            rendező = new Rendező(BetegekInicializálás());  
            
            BetegekKiír();
            BetegFelvétel();
            BetegTörlés();
            BetegekKiír();

            rendező.Beosztás();

            Console.ReadLine();
        }

        private static void BetegFelvétel()
        {
            bool ujBeteg = false;
            do
            {
                Console.WriteLine("Szeretne új beteget felvenni?" + Environment.NewLine + "I - igen, N - nem");
                ujBeteg = Console.ReadLine() == "i" ? true : false;
                if (ujBeteg) rendező.BetegFelvétel();
            } while (ujBeteg);
        }

        private static void BetegTörlés()
        {
            bool betegTörlés = false;
            do
            {
                Console.WriteLine("Szeretne beteget törölni?" + Environment.NewLine + "I - igen, N - nem");
                betegTörlés = Console.ReadLine() == "i" ? true : false;
                if (betegTörlés) rendező.BetegTörlés();
            } while (betegTörlés);
        }

        private static List<Beteg> BetegekInicializálás()
        {
            Beteg[] betegek_arr = new Beteg[3];
            betegek_arr[0] = new Beteg("Kovács Béla", 55, new EpehólyagGyulladás(Súlyosság.Fájdalmas, 75, false, GyulladásMérték.Enyhe, "Bevezető"));
            betegek_arr[1] = new Beteg("Tamási Áron", 34, new CsípőTörés(Súlyosság.Bénító, 55, false, "Közép"));
            betegek_arr[2] = new Beteg("Szomáli András", 12, new BordaköziIdegzsábaGyulladás(Súlyosság.Bénító, 90, true, GyulladásMérték.Súlyos, "3.ik borda"));

            return new List<Beteg>(betegek_arr);
        }

        private static void BetegekKiír()
        {
            Console.WriteLine("Betegek" + Environment.NewLine);
            foreach (Beteg beteg in rendező.Betegek)
            {
                beteg.Kiír();
            }
            Console.WriteLine();
        }
    }
}

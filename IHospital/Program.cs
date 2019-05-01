using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHospital.Diagnózis;
using IHospital.Entitások;

namespace IHospital
{
    class Program
    {
        private static Rendező rendező;
        static void Main(string[] args)
        {
            List<Beteg> BetegLista = BetegListaOlvas();
            if(BetegLista.Count == 0)
            {
                Console.WriteLine("A megadott fájl formátuma hibás, nem használható");
            }
            rendező = new Rendező(BetegLista, műtés: Program.Műtés, felvétel: Program.Felvétel);
            BetegFelvétel();
            BetegTörlés();
            BetegekKiír();

            rendező.Beosztás();

            Console.ReadLine();
        }

        public static void Felvétel(Beteg beteg)
        {
            Console.WriteLine("Új beteg érkzett: " + beteg.Név);
            rendező.Betegek.Add(beteg);
            rendező.BetegRendezés();
        }
        public static bool Műtés(Beteg beteg)
        {
            if (rendező.Betegek.Contains(beteg))
            {
                Console.WriteLine(beteg.Név + " műtésre került! Mihamarabbi jobbulást!");
                rendező.Betegek.Remove(beteg);
                return true;
            }
            return false;
        }
        private static void BetegFelvétel()
        {
            bool ujBeteg = false;
            do
            {
                Console.WriteLine("Szeretne új beteget felvenni?" + Environment.NewLine + "I - igen, N - nem");
                ujBeteg = Console.ReadLine().ToLower().Equals("i") ? true : false;
                if (ujBeteg) rendező.BetegFelvétel();
            } while (ujBeteg);
        }

        private static void BetegTörlés()
        {
            bool betegTörlés = false;
            do
            {
                Console.WriteLine("Szeretne beteget műteni?(soron kívül)" + Environment.NewLine + "I - igen, N - nem");
                betegTörlés = Console.ReadLine().ToLower().Equals("i") ? true : false;
                if (betegTörlés) rendező.BetegTörlés();
            } while (betegTörlés);
        }

        private static void BetegekKiír()
        {
            Console.WriteLine("Betegek" + Environment.NewLine);
            foreach (Beteg beteg in rendező.Betegek)
            {
                // Console.WriteLine(beteg.Név + " " + beteg.Diagnózis.Súlyosság + " " + beteg.Diagnózis.Műtétidőtartam); // Egyszerűsített kiírás - debughoz
                beteg.Kiír();
            }
            Console.WriteLine();
        }

        private static List<Beteg> BetegListaOlvas()
        {
            List<Beteg> BetegLista = new List<Beteg>();
            StreamReader streamReader = null;
            while (streamReader == null)
            {
                Console.WriteLine("Adja meg a filenevet amiből olvassuk a betegeket!");
                try
                {
                    streamReader = new StreamReader(Console.ReadLine() + ".txt");
                } catch (Exception e)
                {
                    Console.WriteLine("Hibás fájlnév!");
                }
            }
            while (!streamReader.EndOfStream)
            {
                try
                {
                    string[] adatok = streamReader.ReadLine().Split(';');
                    string név = adatok[0];
                    int kor = int.Parse(adatok[1]);
                    string típus = adatok[2];
                    if (típus.Equals("törés"))
                    {
                        string törés = adatok[3];
                        if (törés.Equals("végtag"))
                        {
                            BetegLista.Add(new Beteg(név, kor, new VégtagTörés((Súlyosság)int.Parse(adatok[5]), int.Parse(adatok[4]), adatok[6].Equals("i") ? true : false, adatok[7])));
                        }
                        else if (törés.Equals("csípő"))
                        {
                            BetegLista.Add(new Beteg(név, kor, new CsípőTörés((Súlyosság)int.Parse(adatok[5]), int.Parse(adatok[4]), adatok[6].Equals("i") ? true : false, adatok[7])));
                        }
                        else if (törés.Equals("gerinc"))
                        {
                            BetegLista.Add(new Beteg(név, kor, new GerincTörés((Súlyosság)int.Parse(adatok[5]), int.Parse(adatok[4]), adatok[6].Equals("i") ? true : false, adatok[7])));
                        }
                        else
                        {
                            throw new HibásFájlKivétel();
                        }
                    }
                    else if (típus.Equals("gyulladás"))
                    {
                        string gyulladás = adatok[3];
                        if (gyulladás.Equals("vakbél"))
                        {
                            BetegLista.Add(new Beteg(név, kor, new VakbélGyulladás((Súlyosság)int.Parse(adatok[5]), int.Parse(adatok[4]), adatok[6].Equals("i") ? true : false, (GyulladásMérték)int.Parse(adatok[7]), adatok[8])));
                        }
                        else if (gyulladás.Equals("epehólyag"))
                        {
                            BetegLista.Add(new Beteg(név, kor, new EpehólyagGyulladás((Súlyosság)int.Parse(adatok[5]), int.Parse(adatok[4]), adatok[6].Equals("i") ? true : false, (GyulladásMérték)int.Parse(adatok[7]), adatok[8])));
                        }
                        else if (gyulladás.Equals("bordaközi"))
                        {
                            BetegLista.Add(new Beteg(név, kor, new BordaköziIdegzsábaGyulladás((Súlyosság)int.Parse(adatok[5]), int.Parse(adatok[4]), adatok[6].Equals("i") ? true : false, (GyulladásMérték)int.Parse(adatok[7]), adatok[8])));
                        }
                        else
                        {
                            throw new HibásFájlKivétel();
                        }
                    }
                    else
                    {
                        throw new HibásFájlKivétel();
                    }
                } catch (HibásFájlKivétel e)
                {
                    return new List<Beteg>();
                }
            }
            streamReader.Close();
            return BetegLista;
        }
    }
}

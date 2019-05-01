using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHospital.Diagnózis;
using IHospital.Entitások;

namespace IHospital
{
    class Rendező
    {
        public delegate bool BetegMűtés(Beteg beteg);
        public event BetegMűtés Műtés;

        private readonly int MaxPercek = 480;
        public List<Beteg> Betegek { get; set; }
        public Rendező (List<Beteg> betegek, BetegMűtés műtés)
        {
            this.Műtés = műtés;
            this.Betegek = betegek;
            BetegRendezés();
        }

        public void Beosztás()
        {
            Műtő műtőA = VisszaLépésselBeoszt("Quelana");
            Műtő műtőB = VisszaLépésselBeoszt("Quelaan");
            Műtő műtőC = VisszaLépésselBeoszt("Quelaag");
            Console.WriteLine(műtőA.getNév() + " kihasználtsága: " + műtőA.hasznaltPercek + " perc; Értéke: " + műtőA.SumSúlyosság);
            Console.WriteLine(műtőB.getNév() + " kihasználtsága: " + műtőB.hasznaltPercek + " perc; Értéke: " + műtőB.SumSúlyosság);
            Console.WriteLine(műtőC.getNév() + " kihasználtsága: " + műtőC.hasznaltPercek + " perc; Értéke: " + műtőC.SumSúlyosság);
        }

        private Műtő VisszaLépésselBeoszt(String MűtőNév)
        {
            Műtő műtő = new Műtő(MűtőNév);
            try
            {
                if (Betegek.Count() == 0) throw new NincsenekBetegekKivétel(műtő.getNév());
                List<Beteg> BetegekMásolat = Betegek.ToList();
                int[] megoldás = new int[Betegek.Count()];
                int[] legjobbMegoldás = new int[Betegek.Count()];
                Beoszt(0, 0, megoldás, legjobbMegoldás);
                for (int i = 0; i < legjobbMegoldás.Length; i++)
                {
                    if (legjobbMegoldás[i] == 1)
                    {
                        műtő.Beoszt(BetegekMásolat[i]);
                        Műtés(BetegekMásolat[i]);
                    }
                }
                if (műtő.hasznaltPercek <= 360) throw new TúlSokSzabadIdőKivétel(műtő.getNév());
            }
            catch (NincsenekBetegekKivétel e)
            {
                Console.WriteLine("Nem lehet beosztást készíteni a " + e.msg + " műtőhöz, mert nincs elég beteg!");
            }
            catch(TúlSokSzabadIdőKivétel e)
            {
                Console.WriteLine("A " + e.msg + " műtőben több mint 2 óra szabad idő maradt a napra!");
            }
            return műtő;
        }

        private void Beoszt(int szint, int hasznaltPercek, int[] megoldás, int[] legjobbMegoldás)
        {
            if (szint == Betegek.Count())
            {
                if (BeosztásÉrték(megoldás) > BeosztásÉrték(legjobbMegoldás))
                {
                    for(int i=0; i<megoldás.Length; i++)
                    {
                        legjobbMegoldás[i] = megoldás[i];
                    }
                }
            }
            else
            {
                if (hasznaltPercek + Betegek[szint].Diagnózis.Műtétidőtartam <= MaxPercek)
                {
                    megoldás[szint] = 1;
                    Beoszt(szint + 1, hasznaltPercek + Betegek[szint].Diagnózis.Műtétidőtartam, megoldás, legjobbMegoldás);
                }
                else
                {
                    megoldás[szint] = 0;
                    Beoszt(szint + 1, hasznaltPercek, megoldás, legjobbMegoldás);
                }
            }


        }

        private int BeosztásÉrték(int[] beosztás)
        {
            int összÉrték = 0;
            for (int i=0; i<beosztás.Length; i++)
            {
                if (beosztás[i] == 1) összÉrték += (int)Betegek[i].Diagnózis.Súlyosság;
            }
            return összÉrték;
        }

        private void BetegRendezés()
        {
            Betegek.Sort((x,y) => y.Diagnózis.Súlyosság.CompareTo(x.Diagnózis.Súlyosság));
        }

        public void BetegFelvétel()
        {
            Console.WriteLine("Mi a beteg neve?");
            string név = Console.ReadLine();
            Console.WriteLine("Mi a beteg életkora?");
            int életkor = int.Parse(Console.ReadLine());
            Console.WriteLine("Mi a beteg baja?" + Environment.NewLine + "1.) Törés" + Environment.NewLine + "2.) Gyulladás");
            int betegségtípus = int.Parse(Console.ReadLine());

            switch (betegségtípus)
            {
                case 1:
                    TörésBetegFelvétel(név, életkor);
                    break;
                case 2:
                    GyulladásBetegFelvétel(név, életkor);
                    break;
                default:
                    Console.WriteLine("/watch?v=SrxedErOyrs");
                    break;
            }

        }

        public void GyulladásBetegFelvétel(string név, int életkor)
        {
            Console.WriteLine("Milyen gyulladás?" + Environment.NewLine + "1.) Vakbélgyulladás" + Environment.NewLine + "2.) Epehólyag gyulladás" + Environment.NewLine + "3.) Bordaközi idegzsába gyulladás");
            int típus = int.Parse(Console.ReadLine());

            Console.WriteLine("Milyen súlyos a gyulladás oka?");
            int i = 1;
            foreach (var value in Enum.GetValues(typeof(Súlyosság)).Cast<Súlyosság>())
            {
                Console.WriteLine(i + ".)" + value);
                i++;
            }
            Súlyosság súlyosság = (Súlyosság)int.Parse(Console.ReadLine());

            Console.WriteLine("Milyen súlyos a gyulladás?");
            i = 1;
            foreach (var value in Enum.GetValues(typeof(GyulladásMérték)).Cast<GyulladásMérték>())
            {
                Console.WriteLine(i + ".)" + value);
                i++;
            }
            GyulladásMérték gyulladásmértéke = (GyulladásMérték)int.Parse(Console.ReadLine());

            Console.WriteLine("Váladékos-e a gyulladás? " + Environment.NewLine + "I - igen, N - nem");
            bool váladék = Console.ReadLine() == "i" ? true : false;

            Console.WriteLine("Mi az elhelyezkedése a gyulladásnak? ");
            string elhelyezkedés = Console.ReadLine();

            Console.WriteLine("Hány perc lenne megműteni?");
            int idő = int.Parse(Console.ReadLine());

            switch(típus)
            {
                case 1:
                    Betegek.Add(new Beteg(név, életkor, new VakbélGyulladás(súlyosság, idő, váladék, gyulladásmértéke, elhelyezkedés)));
                    break;
                case 2:
                    Betegek.Add(new Beteg(név, életkor, new EpehólyagGyulladás(súlyosság, idő, váladék, gyulladásmértéke, elhelyezkedés)));
                    break;
                case 3:
                    Betegek.Add(new Beteg(név, életkor, new BordaköziIdegzsábaGyulladás(súlyosság, idő, váladék, gyulladásmértéke, elhelyezkedés)));
                    break;
                default:
                    Console.WriteLine("/watch?v=SrxedErOyrs");
                    return;
            }
        }

        public void TörésBetegFelvétel(string név, int életkor)
        {
            Console.WriteLine("Milyen törés?" + Environment.NewLine + "1.) Végtagtörés" + Environment.NewLine + "2.) Csipőtörés" + Environment.NewLine + "3.) Gerinctörés");
            int típus = int.Parse(Console.ReadLine());

            Console.WriteLine("Milyen súlyos a törés?");
            int i = 1;
            foreach (var value in Enum.GetValues(typeof(Súlyosság)).Cast<Súlyosság>())
            {
                Console.WriteLine(i + ".)" + value);
                i++;
            }
            Súlyosság súlyosság = (Súlyosság) int.Parse(Console.ReadLine());

            Console.WriteLine("Nyílt-e a törés? " + Environment.NewLine + "I - igen, N - nem");
            bool nyílt = Console.ReadLine() == "i" ? true : false;

            Console.WriteLine("Mi az elhelyezkedése a törésnek? ");
            string elhelyezkedés = Console.ReadLine();

            Console.WriteLine("Hány perc lenne megműteni?");
            int idő = int.Parse(Console.ReadLine());

            switch (típus)
            {
                case 1:
                    Betegek.Add(new Beteg(név, életkor, new VégtagTörés(súlyosság, idő, nyílt, elhelyezkedés)));
                    break;
                case 2:
                    Betegek.Add(new Beteg(név, életkor, new CsípőTörés(súlyosság, idő, nyílt, elhelyezkedés)));
                    break;
                case 3:
                    Betegek.Add(new Beteg(név, életkor, new GerincTörés(súlyosság, idő, nyílt, elhelyezkedés)));
                    break;
                default:
                    Console.WriteLine("/watch?v=SrxedErOyrs");
                    return;
            }

            BetegRendezés();
        }

        public void BetegTörlés()
        {
            Console.WriteLine("Adja meg a törlendő beteg nevét!");
            string név = Console.ReadLine();
            Beteg beteg = Betegek.Find(x => x.Név.Equals(név));
            if (beteg != null) Betegek.Remove(beteg);
        }
    }

}

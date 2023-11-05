using System;
using System.Text;

namespace SZGYA_Szoftverek_20231005
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Szoftver> szoftverek = new List<Szoftver>();

            StreamReader sr = new StreamReader("../../../src/szoftverek.txt", Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                szoftverek.Add(new Szoftver(sr.ReadLine()));
            }
            sr.Close();

            foreach (var sz in szoftverek)
            {
                Console.WriteLine(sz);
            }
            Console.WriteLine();

            //7
            List<Szoftver> antivirusok = JoAntivirusok(szoftverek);
            Console.WriteLine($"7.feladat: {antivirusok.Count}\n");

            //8
            List<Szoftver> joSzoftverek = JoSzoftverek(szoftverek);
            Console.WriteLine("8.feladat");
            foreach (var sz in joSzoftverek)
            {
                Console.WriteLine($"\t{sz}");
            }
            Console.WriteLine();

            //10
            Console.WriteLine($"10.feladat: {AdobeAtlag(szoftverek)}\n");

            //11
            var f11 = Kategoriak(szoftverek);
            Console.WriteLine("11.feladat:");
            if (f11.Length == 0) Console.WriteLine("[HIBA] nincs ilyen");
            else Console.WriteLine(string.Join(", ", f11));
            Console.WriteLine();

            //12
            Console.WriteLine("12.feladat");
            var f12 = Draga(szoftverek);
            if (f12.Count == 0) Console.WriteLine("[HIBA] nincs ilyen");
            else Console.WriteLine(string.Join(", ", f12.Select(sz => sz.Id)));

            //13
            StreamWriter sw = new StreamWriter("../../../src/fizetos.txt");
            var f13 = szoftverek.Where(sz => sz.LicenszTipus == "fizetős").ToList();
            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine(f13[i]);
            }
            sw.Close();
        }

        //7
        static List<Szoftver> JoAntivirusok(List<Szoftver> szoftverek)
        {
            return szoftverek.Where(sz => sz.Kategoria == "antivírus" && sz.Ertekeles > 8.5f).ToList();
        }
        //8
        static List<Szoftver> JoSzoftverek(List<Szoftver> szoftverek)
        {
            float max = (float)Math.Round(szoftverek.Max(szz => szz.Ertekeles - 0.1f), 1);
            return szoftverek.Where(sz => sz.Ertekeles ==  max).ToList();
        }
        //10
        static float AdobeAtlag(List<Szoftver> szoftverek)
        {
            return szoftverek.Where(sz => sz.NevEsVerzio.StartsWith("Adobe")).Average(sz => sz.BruttoAr);
        }

        //11
        static string[] Kategoriak(List<Szoftver> szoftverek)
        {
            List<string> kat = szoftverek
                .Where(sz => sz.TamogatottOSek.Length == 2)
                .GroupBy(sz => sz.Kategoria)
                .Select(sz => sz.Key)
                .ToList();
            kat.Sort();
            return kat.ToArray();
        }

        //12
        static List<Szoftver> Draga(List<Szoftver> szoftverek)
        {
            return szoftverek.Where(sz => sz.NettoAr > 500 && sz.Ertekeles < 9).ToList();
        }
    }
}
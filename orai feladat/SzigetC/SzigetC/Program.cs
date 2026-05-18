

using System.Security.Cryptography;
using System.Text.Json;

namespace SzigetC
{
    public class Program
    {
        public static List<Eloado> eloadok=new List<Eloado>();
        static List<Eloado> jsonEloadok=new List<Eloado>();
        static void Main(string[] args)
        {
            Beolvas();
            JsonBeolvas();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();
        }

        private static void Feladat9()
        {
            Dictionary<string, int> statisztika=new Dictionary<string, int>();

            foreach (var item in eloadok)
            {
                if (statisztika.ContainsKey(item.FellepesNapja))
                {
                    statisztika[item.FellepesNapja]++;
                }
                else
                {
                    statisztika.Add(item.FellepesNapja, 1);
                }
            }

            statisztika = statisztika.OrderByDescending(s=> s.Value).ToDictionary();
            Console.WriteLine("9. feladat");
            foreach (var item in statisztika)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value} fellépő");
            }
        }

        private static void Feladat8()
        {
            Console.WriteLine("8. feladat");
            Console.Write("Adja meg a keresett szót vagy számcímet: ");
            string keresett=Console.ReadLine();

            bool talalat=false;
            foreach (var item in eloadok)
            {
                if (item.KeresSlager(keresett).Count>0)
                {
                    talalat=true;
                    Console.WriteLine($"\t{item.Nev}:");
                    foreach (var szamCimek in item.KeresSlager(keresett))
                    {
                        Console.WriteLine($"\t\t- {szamCimek}");
                    }
                    
                }
            }
            if (!talalat)
            {
                Console.WriteLine("Nincs találat!");
            }
        }

        private static void Feladat7()
        {
            double atlag = eloadok.Average(e => e.SpotifyHallgato);

            Console.WriteLine("7. Feladat");
            foreach (var item in eloadok)
            {
                if (item.SpotifyHallgato>atlag)
                {
                    Console.WriteLine($"\t{item.Nev} : {item.SpotifyHallgato/1000000} millió");
                }
            }
            //V2
            //List<Eloado> atlafFelettiek=eloadok.Where(e=>e.SpotifyHallgato>atlag).ToList();
            List<Eloado> atlafFelettiek=eloadok.Where(e=>e.SpotifyHallgato> eloadok.Average(e => e.SpotifyHallgato)).ToList();
        }

        private static void Feladat6()
        {
            Console.WriteLine($"6.Feladat\n\tElőadók száma: {eloadok.Count}");
        }

        private static void JsonBeolvas()
        {
            string json = File.ReadAllText("sziget2025.json");
            jsonEloadok = JsonSerializer.Deserialize<List<Eloado>>(json);
        }

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("sziget2025.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                eloadok.Add(new Eloado(sr.ReadLine()));
            }
            sr.Close();


        }
    }
}

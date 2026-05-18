using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SzigetC
{
    public class Eloado
    {
        //Név	Ország	Műfaj	FellépésNapja	SpotifyHallgatók	Slágerek
        [JsonInclude]
        public string Nev { get; private set; }

        [JsonInclude]
        public string Orszag { get; private set; }

        [JsonInclude]
        public string Mufaj { get; private set; }

        [JsonInclude]
        public string FellepesNapja { get; private set; }

        [JsonInclude]
        public int SpotifyHallgato { get; private set; }
        
        [JsonInclude]
        public string[] Slagerek { get; private set; }

        public Eloado(string sor) 
        {
            string[] temp=sor.Split('\t');
            Nev=temp[0];
            Orszag=temp[1];
            Mufaj=temp[2];
            FellepesNapja=temp[3];
            SpotifyHallgato=int.Parse(temp[4]);
            string[] slagerString = temp[5].Split(",");
            Slagerek = slagerString;
        }

        public Eloado()
        {
        }

        public List<string> KeresSlager(string keresettSzo)
        {
            List<string> keresett = new List<string>();
            
            foreach (var item in Slagerek)
            {
                if (item.ToLower().Contains(keresettSzo.ToLower()))
                {
                    keresett.Add(item);
                }
            }

            return keresett;
        }
    }
}

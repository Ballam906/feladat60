using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SzigetWPF
{
    public class Eloado
    {
        //Név	Ország	Műfaj	FellépésNapja	SpotifyHallgatók	Slágerek
        public string Nev { get; private set; }

        public string Orszag { get; private set; }

        public string Mufaj { get; private set; }

        public string FellepesNapja { get; private set; }

        public int SpotifyHallgato { get; private set; }
        
        public string Slagerek { get; private set; }

        public Eloado(string sor) 
        {
            string[] temp=sor.Split('\t');
            Nev=temp[0];
            Orszag=temp[1];
            Mufaj=temp[2];
            FellepesNapja=temp[3];
            SpotifyHallgato=int.Parse(temp[4]);
            
            Slagerek = temp[5];
        }

        

        
    }
}

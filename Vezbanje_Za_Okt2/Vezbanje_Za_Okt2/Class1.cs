using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezbanje_Za_Okt2
{
    class Class1
    {
        string predmet;
        int brpr;
        int brpo;
        public Class1(string predmet, int brpr, int brpo)
        {
            this.predmet = predmet;
            this.brpr = brpr;
            this.brpo = brpo;
        }

        public string Predmet { get => predmet; set => predmet = value; }
        public int Brpr { get => brpr; set => brpr = value; }
        public int Brpo { get => brpo; set => brpo = value; }

        public override string ToString()
        {
            return "Predmet: " + predmet + ", Br. prijavljenih: " + brpr +", Br. polozenih: " + brpo; 
        }
    }
}

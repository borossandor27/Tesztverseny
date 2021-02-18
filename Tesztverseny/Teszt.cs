using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesztverseny
{
    class Teszt
    {
        string versenyzoKod = null;
        string valaszok = null;
        public int kapottPont = 0;
        char[] jok = new char[14];

        public string VersenyzoKod { get => versenyzoKod; set => versenyzoKod = value; }
        public string Valaszok { get => valaszok; set => valaszok = value; }

        public Teszt(string[] sor, string joValaszok)
        {
            this.VersenyzoKod = sor[0];
            this.Valaszok = sor[1];
            for (int i = 0; i < this.Valaszok.Length; i++)
            {
                if (this.Valaszok[i].Equals(joValaszok[i]))
                {
                    jok[i] = '+';
                    kapottPont += pontoz(i + 1);
                }
                else
                {
                    jok[i] = ' ';
                }
            }
        }

        public string joValaszokString()
        {
            return new string(jok);
        }

        int pontoz(int ssz)
        {
            int p = 0;
            switch (ssz)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    p = 3;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    p = 4;
                    break;
                case 11:
                case 12:
                case 13:
                    p = 5;
                    break;
                case 14:
                    p = 6;
                    break;
                default:
                    p = 0;
                    break;
            }
            return p;
        }
        public bool kerdesJo(int ssz)
        {
            return jok[ssz].Equals('+');
        }
    }
}

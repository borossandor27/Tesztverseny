using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tesztverseny
{
    class Program
    {
        static string joValasz = null;
        static List<Teszt> tesztek = new List<Teszt>();
        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat: 'valaszok.txt' beolvasása ...");
            Beolvas("valaszok.txt");
            Console.WriteLine($"\n2. feladat: A vetélkedőn {tesztek.Count} versenyző indult.");

            Console.Write("\n3. feladat: A versenyző azonosítója = ");
            string azon = Console.ReadLine().ToUpper();
            Console.WriteLine("\t" + tesztek.Find(a => a.VersenyzoKod.Equals(azon)).Valaszok + "\t(a versenyző válasza)");

            Console.WriteLine("\n4. feladat");
            Console.WriteLine($"\t{joValasz}\t(a helyes megoldás)");
            Console.WriteLine($"\t{tesztek.Find(a => a.VersenyzoKod.Equals(azon)).joValaszokString()}\t(a versenyző helyes válaszai)");

            Console.Write("\n5. feladat: A feladat sorszáma = ");
            int ssz;
            do
            {
            } while (!int.TryParse(Console.ReadLine(), out ssz)||ssz<1||ssz>14);
            int jok = tesztek.FindAll(a => a.kerdesJo(ssz-1)).Count();
            Console.WriteLine($"\tA feladatra {jok} fő, a versenyzők {(100.0*jok/tesztek.Count).ToString("N2")}%-a adott helyes választ.");

            Console.WriteLine("\n6. feladat: A versenyzők pontszámának meghatározása");

            Console.WriteLine("\n7. feladat: A verseny legjobbjai:");
            var topHaromPont = tesztek.Select(a => new  { pont = a.kapottPont }).OrderByDescending(b => b.pont).Distinct().Take(3).ToArray();
            int helyezes = 0;
            foreach (var item in topHaromPont)
            {
                helyezes++;
                foreach (Teszt dijazott in tesztek.FindAll(a => a.kapottPont==item.pont))
                {
                    Console.WriteLine($"\t{helyezes}. díj ({dijazott.kapottPont} pont): {dijazott.VersenyzoKod}");
                }
            }
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        static void Beolvas(string fajl)
        {
            using (StreamReader sr = new StreamReader(fajl))
            {
                joValasz = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    tesztek.Add(new Teszt(sr.ReadLine().Split(' '), joValasz));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace atof_improved_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] fajl = System.IO.File.ReadAllLines(@"C:\Users\Tijana\source\repos\atof_improved_assignment\atof_improved_assignment\tijana_csv_proba.csv");

            /*List<String> datum = new List<String>();
            List<String> rezultat = new List<String>();
            List<String> komentar = new List<String>();*/

            //umesto ovog gore cilj je da imam List<Uzorak> sa parametrima klase Uzorak
            //kako bih mogla da im pristupam u grupi i da ne zagubim usput

            List<Uzorak> listaUzorka = new List<Uzorak>();


            for (int i = 1; i < fajl.Length; i++)
            {
                //Console.WriteLine(fajl[i]); //svaka linija

                String[] fajlSplit = fajl[i].Split(",");

                listaUzorka.Add(new Uzorak(fajlSplit[0], fajlSplit[1], fajlSplit[2]));

                /*datum.Add(fajlSplit[0]);
                rezultat.Add(fajlSplit[1]);
                komentar.Add(fajlSplit[2]);*/

            }

            /*foreach (var clan in listaUzorka)
            {
                Console.WriteLine(clan.Komentar);
            }*/


            /*foreach (var a in datum)
            {
                Console.WriteLine(a);
            }*/
            //proba stampanja da vidim sta imam u listama tacno

        }
    }
}

using System;
using System.Collections.Generic;

namespace atof_improved_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] fajl = System.IO.File.ReadAllLines(@"C:\Users\Tijana\source\repos\atof_improved_assignment\atof_improved_assignment\tijana_csv_proba.csv");

            List<Uzorak> listaUzorka = new List<Uzorak>();


            for (int i = 1; i < fajl.Length; i++)
            {
                //Console.WriteLine(fajl[i]); //svaka linija
                Console.WriteLine("Parsira se red broj: " + i);

                String[] fajlSplit = fajl[i].Split(",");

                listaUzorka.Add(new Uzorak(fajlSplit[0], fajlSplit[1], fajlSplit[2]));       

            }

            

        }
    }
}

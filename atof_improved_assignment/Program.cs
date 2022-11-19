using System;
using System.Collections.Generic;
using System.IO;

namespace atof_improved_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("output.err.txt"))
            {
                File.Delete("output.err.txt");
            }

            String[] fajl = System.IO.File.ReadAllLines(@"C:\Users\Tijana\source\repos\atof_improved_assignment\atof_improved_assignment\tijana_csv_proba.csv");

            List<Uzorak> listaUzorka = new List<Uzorak>();
            //List<String> errors = new List<string>();

            for (int i = 1; i < fajl.Length; i++)
            {
                //Console.WriteLine(fajl[i]); //svaka linija
                Console.WriteLine("Parsira se red broj: " + i);

                String[] fajlSplit = fajl[i].Split(",");

                listaUzorka.Add(new Uzorak(fajlSplit[0], fajlSplit[1], fajlSplit[2]));

            }
            /*foreach (var uzorak in listaUzorka)
            {
                if (uzorak.Validan)
                {
                    Console.WriteLine("Ovaj uzorak je validan. Rezultat uzorka: " + uzorak.Rezultat);
                }
            }*/

        }
    }
}

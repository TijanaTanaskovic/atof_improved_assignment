using System;
using System.Collections.Generic;
using System.IO;

namespace atof_improved_assignment
{
    class Program
    {
        static string meseciPoRednomBr(string mesec)
        {
            switch (mesec)
            {
                case "1":
                    return "Januar";
                    break;
                case "2":
                    return "Februar";
                    break;
                case "3":
                    return "Mart";
                    break;
                case "4":
                    return "April";
                    break;
                case "5":
                    return "Maj";
                    break;
                case "6":
                    return "Jun";
                    break;
                case "7":
                    return "Jul";
                    break;
                case "8":
                    return "Avgust";
                    break;
                case "9":
                    return "Septembar";
                    break;
                case "10":
                    return "Oktobar";
                    break;
                case "11":
                    return "Novembar";
                    break;
                case "12":
                    return "Decembar";
                    break;
                default:
                    return "Ne postoji mesec";
                    break;
            }
        }
        static void Main(string[] args)
        {
            if (File.Exists("output.csv"))
            {
                File.Delete("output.csv");
            }

            if (File.Exists("output.err.txt"))
            {
                File.Delete("output.err.txt");
            }

            String[] fajl = System.IO.File.ReadAllLines(@"C:\Users\Tijana\source\repos\atof_improved_assignment\atof_improved_assignment\tijana_csv_proba.csv");

            List<Uzorak> listaUzorka = new List<Uzorak>();

            for (int i = 1; i < fajl.Length; i++)
            {
                
                Console.WriteLine("Parsira se red broj: " + i);

                String[] fajlSplit = fajl[i].Split(",");

                listaUzorka.Add(new Uzorak(fajlSplit[0], fajlSplit[1], fajlSplit[2]));

            }
            Dictionary<string, Grupisanje> recnikGrupisanja = new Dictionary<string, Grupisanje>();
            foreach (var uzorak in listaUzorka)
            {
                if (uzorak.Validan)
                {
                    if (!recnikGrupisanja.ContainsKey(uzorak.Datum.Month + "-" + uzorak.Datum.Year))
                    {
                        string key = uzorak.Datum.Month + "-" + uzorak.Datum.Year;
                        recnikGrupisanja.Add(key, new Grupisanje(uzorak.Rezultat)); //pravim objekat klase grupisanja, tom objektu moze da se pristupa kao gr.suma/ukupnaMerenja 
                    }
                    else
                    {
                        Grupisanje gr = recnikGrupisanja[uzorak.Datum.Month + "-" + uzorak.Datum.Year];
                        gr.suma += uzorak.Rezultat;
                        gr.ukupnoMerenja++;
                        recnikGrupisanja[uzorak.Datum.Month + "-" + uzorak.Datum.Year] = gr;
                    }
                }
            }
            
            List<String> listaIzlaznihLinija = new List<string>();
            listaIzlaznihLinija.Add("Mesec,Godina,UkupnaMerenja,Suma");
            foreach (KeyValuePair<string, Grupisanje> entry in recnikGrupisanja)
            {
                string datum = entry.Key;
                Grupisanje gr = entry.Value;
                String[] datumSplit = datum.Split("-");
                string mesecStr = meseciPoRednomBr(datumSplit[0]);
                string godina = datumSplit[1];
                double sumaZ = gr.suma;
                int uMerenja = gr.ukupnoMerenja;
                listaIzlaznihLinija.Add(mesecStr + "," + godina + "," + uMerenja + "," + sumaZ);
            }
            System.IO.File.WriteAllLines("output.csv", listaIzlaznihLinija);
        }
    }
}

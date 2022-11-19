using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace atof_improved_assignment
{
    class Uzorak
    {
        List<String> errors = new List<string>();

        private String komentar;
        private DateTime datum;
        private double rezultat;
        private bool validan = true; //za validaciju podataka (datum, rezultat)
        private string komentarValidacije= "";  
       
        public String Komentar
        {
            get { return komentar; }
            set { komentar = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public double Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }

        public bool Validan
        {
            get { return validan; }
            set { validan = value; }
        }
        public String KomentarValidacije
        {
            get { return komentarValidacije; }
            set { komentarValidacije = value; }
        }

        public Uzorak(string datum, string rezultat, string komentar)
        {
            string[] dozvoljeniFormati = { "dd/MM/yyyy", "dd.MM.yyyy", "dd.MM.yyyy." };
            this.komentar = komentar;
            this.rezultat = 1;

            bool validanDatum = validirajDatum(datum);
            if (validanDatum)
            {
                DateTime dateValue;

                DateTime.TryParseExact(datum, dozvoljeniFormati,
                         new CultureInfo("en-US"),
                         DateTimeStyles.None,
                         out dateValue);

                this.datum = dateValue;

            }
            else
            {
                this.validan = false;
                
            }

            double? validanRezultat = validirajRezultat(rezultat);
            if (validanRezultat != null)
            {
                this.rezultat = (double)validanRezultat;
            }
            else
            {
                this.validan = false;
              
            }
            Console.WriteLine("Objekat je: " + this.validan);
            Console.WriteLine("Rezutat uzorka je: " + this.rezultat);
            Console.WriteLine("Komentar je: " + this.komentarValidacije);

            if (this.validan == false)
            {
                this.komentarValidacije += "Ova linija ne moze biti konvertovana. Originalni datum: " + datum + " Originalan rezultat: " + rezultat;
                errors.Add(komentarValidacije);
            }

            

            System.IO.File.AppendAllLines(@"output.err.txt", errors);
        }

        private float strToIntegerPart(string str)
        {
            float response = 0;

            foreach (char c in str)
            {
                response *= 10;
                response += c - '0';
            }

            return response;
        }

        private float? parseExponent(string str)
        {
            if (str.Contains('+'))
            {
                String[] splitZnak = str.Split("+");
                float integerPart = strToIntegerPart(splitZnak[1]);
                double broj = Math.Pow(10, integerPart);
                return (float)(broj);
            }
            else if (str.Contains('-'))
            {
                String[] splitZnak = str.Split('-');
                float integerPart = strToIntegerPart(splitZnak[1]);
                double broj = Math.Pow(10, integerPart);
                return (float)(1/broj);
            }
            else
            {
                return null;
            }
        }

        private double? validirajRezultat(string str)
        {
            String[] splitStr = str.Split("."); //4.54e-7
            if (splitStr.Length == 2 && !str.ToLower().Contains('e')) //sme da ima tacku ali ne sme da ima e (ovo se odnosi na str a ne na splitStr)
            {
                float integerPart = strToIntegerPart(splitStr[0]);
                double floatPart = strToDecimalPart(splitStr[1]);

                return integerPart + floatPart;
            }
            else if (splitStr.Length == 1 && !str.ToLower().Contains('e')) //nema tacku i ne sadrzi e 
            {
                double result = 0;
                float integerPart = strToIntegerPart(splitStr[0]);
                return result + integerPart;
            }
            else if(str.ToLower().Contains('e')) //splitStr.Length == 1 && 
            {
                String[] exponentSplit = str.ToLower().Split("e");
                if (exponentSplit.Length > 2)
                {
                    return null;
                }
                else
                {
                    double scientificResult = 0;
                    double decimalPart;
                    float? exponentPart;
                    if (exponentSplit[0].Contains('.'))
                    {
                        String[] exponentDecimalStr = exponentSplit[0].Split(".");

                        float integerPart = strToIntegerPart(exponentDecimalStr[0]);
                        double floatPart = strToDecimalPart(exponentDecimalStr[1]);

                        decimalPart = integerPart + floatPart;
                    }
                    else
                    {
                        String[] exponentDecimalStr = exponentSplit[0].Split(".");
                        float integerPart = strToIntegerPart(exponentDecimalStr[0]);
                        double tmp = 0;
                        decimalPart = tmp + integerPart;
                    }

                    exponentPart = parseExponent(exponentSplit[1]);
                    if (exponentPart != null)
                    {
                        scientificResult = (double)(decimalPart * exponentPart);
                        return scientificResult;
                    }
                    else
                    {
                        return null;
                    }
                    
                }

               
            }
            else
            {
                return null;
            }


        }

        private double strToDecimalPart(string str)
        {
            double accumulator = 0.1;
            double response = 0;
            foreach (char c in str)
            {
                float number = c - '0';
                response += number * accumulator;
                accumulator = accumulator / 10;
            }
            //Console.WriteLine(response);
            return response;
        }

        //Console.WriteLine(strTointegerPart("123456"));
        //Console.WriteLine(parseDecimal("47.54")); 

        private bool validirajDatum(string date)
        {
            string[] formats = { "dd/MM/yyyy", "dd.MM.yyyy", "dd.MM.yyyy." };
            DateTime dateValue;
            if (DateTime.TryParseExact(date, formats, 
                      new CultureInfo("en-US"),
                      DateTimeStyles.None,
                      out dateValue))
            {
                //Console.WriteLine("Converted '{0}' to {1}.", date, dateValue);
                return true;
            }

            else
            {
                //Console.WriteLine("Unable to convert '{0}' to a date.", date);
                return false;
            }


        }
    }
}

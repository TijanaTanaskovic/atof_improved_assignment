using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace atof_improved_assignment
{
    class Uzorak
    {
        private String komentar;
        private DateTime datum;
        private double rezultat;
        private bool validan = true; //za validaciju podataka (datum, rezultat)
       
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

        private double? validirajRezultat(string str)
        {
            String[] splitStr = str.Split(".");
            if (splitStr.Length == 2)
            {
                float integerPart = strToIntegerPart(splitStr[0]);
                double floatPart = strToDecimalPart(splitStr[1]);

                return integerPart + floatPart;
            }
            else if (splitStr.Length == 1 && !str.ToLower().Contains('e'))
            {
                double result = 0;
                float integerPart = strToIntegerPart(splitStr[0]);
                return result + integerPart;
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

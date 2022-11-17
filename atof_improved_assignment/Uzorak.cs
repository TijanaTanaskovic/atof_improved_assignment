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
        private float rezultat;
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

        public float Rezultat
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
        }

        public bool validirajRezultat(string rezultat)
        {
            return false;
            //uradi
        }

        private bool validirajDatum(string date)
        {
            string[] formats = { "dd/MM/yyyy", "dd.MM.yyyy", "dd.MM.yyyy." };
            DateTime dateValue;
            if (DateTime.TryParseExact(date, formats,
                      new CultureInfo("en-US"),
                      DateTimeStyles.None,
                      out dateValue))
            {
                Console.WriteLine("Converted '{0}' to {1}.", date, dateValue);
                return true;
            }

            else
            {
                Console.WriteLine("Unable to convert '{0}' to a date.", date);
                return false;
            }


        }
    }
}

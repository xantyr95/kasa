using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Koszyk
    {
        private List<Produkt> Zakupy;
        public Koszyk()
        {
            Zakupy = new List<Produkt>();
        }

        public void Kopiuj()
        {
            Zakupy.Add(Zakupy.Last());
            Console.WriteLine("Ostatni dodany produkt został skopiowany.");
        }

        public void Dodaj()
        {
            bool Poprawna = false;
            string nazwa;
            int ilosc = 0;
            double cena = 0;

            Console.WriteLine("Podaj nazwę wybranego produktu: ");
            nazwa = Console.ReadLine();

            Console.WriteLine("Podaj cenę tego produktu: ");
            while (!Poprawna)
            {
                Poprawna = true;

                try
                {
                    Console.Write("··");
                    cena = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystapił błąd.");
                    Poprawna = false;
                }
            }

            Poprawna = false;

            Console.WriteLine("Podaj ilość produktu: ");
            while (!Poprawna)
            {
                Poprawna = true;

                try
                {
                    Console.Write("··");
                    ilosc = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystapił błąd.");
                    Poprawna = false;
                }
            }

            Zakupy.Add(new Produkt(nazwa, cena, ilosc));
            Console.WriteLine("Produkt został dodany.");
        }

        public void wypiszKoszyk()
        {
            foreach (var prod in Zakupy)
            {
                prod.wypiszProdukt();
            }
            Console.WriteLine("Należność do zapłaty: " + dozaplaty());
        }

        public double dozaplaty()
        {
            double suma = 0;
            foreach (var prod in Zakupy)
            {
                suma += prod.podajCene();
            }
            return suma;
        }

        public void Skasuj()
        {
            bool Poprawny = false;
            int doUsuniecia = -1;

            while (!Poprawny)
            {
                Poprawny = true;
                try
                {
                    doUsuniecia = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystąpił błąd.");
                    Poprawny = false;
                }
            }
            try
            {
                Zakupy.RemoveAt(doUsuniecia);
            }
            catch (Exception)
            {
                Console.WriteLine("Pojawił się błąd przy próbie usunięcia danego elemntu.\nSprawdz indeks!");
            }
        }

        public void wyczysc()
        {
            Zakupy.Clear();
        }

        public void zapiszParagon()
        {
            string Day = DateTime.Now.Day.ToString();
            string Month = DateTime.Now.Month.ToString();
            string Year = DateTime.Now.Year.ToString();
            string Hour = DateTime.Now.Hour.ToString();
            string Minute = DateTime.Now.Minute.ToString();
            string Second = DateTime.Now.Second.ToString();
            string name = Day + Month + Year + Hour + Minute + Second;
            string line;

            FileStream fs = new FileStream(name, FileMode.CreateNew);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var prod in Zakupy)
                {
                    line = prod.podajProdukt();
                    sw.WriteLine(line);
                }
                sw.WriteLine("Należność do zapłaty: " + dozaplaty());
                wyczysc();
            }
        }
    }
}

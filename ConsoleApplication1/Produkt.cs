using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Produkt
    {
        private string nazwa;
        private double cenaJednostkowa;
        private int ilosc;
        public Produkt(string nazwa, double cenaJednostkowa, int ilosc)
        {
            this.nazwa = nazwa;
            this.cenaJednostkowa = cenaJednostkowa;
            this.ilosc = ilosc;
        }

        public string podajProdukt()
        {
            return nazwa + "  " + ilosc + " * " + cenaJednostkowa + " = " + ilosc * cenaJednostkowa;
        }

        public void wypiszProdukt()
        {
            Console.WriteLine(nazwa + "  " + ilosc + " * " + cenaJednostkowa + " = " + ilosc * cenaJednostkowa);
        }

       

        public double podajCene()
        {
            return ilosc * cenaJednostkowa;
        }
    }
}
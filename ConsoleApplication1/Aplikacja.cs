using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Aplikacja
    {
        private static char klawisz;
        private static Koszyk Zakupy = new Koszyk();
        private static void WczytajKlawisz()
        {
            Console.WriteLine("Witam!");
            Console.WriteLine("Co chcesz zrobić? Nacisnij odpowiedni klawisz.");
            Console.WriteLine("Legenda:");
            Console.WriteLine("Wciśnij P aby dodać produkt do koszyka");
            Console.WriteLine("Wciśnij K aby skopiować ostatnio wprowadzony produkt");
            Console.WriteLine("Wciśnij Z aby zobaczyć zawartość koszyka");
            Console.WriteLine("Wciśnij S aby sprawdzić sumę do zapłaty");
            Console.WriteLine("Wciśnij X aby skasować produkt z listy (musisz znać wcześniej numer na liście)");
            Console.WriteLine("Wciśnij W aby wydrukować paragon");
            Console.WriteLine("Wciśnij N aby dodać nowy koszyk");
            Console.WriteLine("Wciśnij E aby wyjść z programu");
     

            char[] wybor = {'P','K','Z','S','X','W','N','E','p','k','z','s','x','w','n','e'};
            bool czyPoprawny = false;

            while(!czyPoprawny)
            {
                czyPoprawny = true;

                try
                {
                    Console.Write("··");
                    klawisz = Convert.ToChar(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Błędny klawisz.");
                    czyPoprawny = false;
                }

                if (!wybor.Contains(klawisz))
                    czyPoprawny = false;
            }
            Console.Clear();
        }

        public static void WykonajDzialanie()
        {
            while (true)
            {
                WczytajKlawisz();

                if (klawisz == 'P' || klawisz == 'p')
                {
                    Zakupy.Dodaj();
                    Continue();
                }

                if (klawisz == 'K' || klawisz == 'k')
                {
                    Zakupy.Kopiuj();
                    Continue();
                }

                if (klawisz == 'Z' || klawisz == 'z')
                {
                    Zakupy.wypiszKoszyk();
                    Continue();
                }

                if (klawisz == 'S' || klawisz == 's')
                {
                    Console.WriteLine("W sumie do zapłaty: ", +Zakupy.dozaplaty());
                    Continue();
                }

                if (klawisz == 'X' || klawisz == 'x')
                {
                    Zakupy.Skasuj();
                    Continue();
                }

                if (klawisz == 'W' || klawisz == 'w')
                {
                    Zakupy.zapiszParagon();
                    Console.WriteLine("Paragon został zapisany.");
                    Continue();
                }

                if (klawisz == 'N' || klawisz == 'n')
                {
                    Zakupy.wyczysc();
                    Console.WriteLine("Koszyk został opróżniony.");
                }

                if (klawisz == 'E' || klawisz == 'e')
                    return;
            }

        }

        private static void Continue()
        {
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

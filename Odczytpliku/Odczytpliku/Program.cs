
namespace Odczytpliku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nazwapliku = "../../../drukowanie.txt";

            StreamWriter drukowanie = new StreamWriter(nazwapliku);
            //Korzystam z dostępnych bibliotek dzięki framework .NET, która automatycznie implementuje biblioteke IOS i przypisuje
            //zmienną do klasy (umieszczam ../ trzy razy aby odrazu mieć plik na wierzchu, a nie w katalogu bin)
            drukowanie.WriteLine("1234");
            drukowanie.WriteLine("Lorem ipsum ");
            drukowanie.WriteLine("Franciszek ma %d kg i %.2f %s wzrostu", 87, 80.3, "cm");
            drukowanie.WriteLine(546);

            //Dodaje jakiś tam tekst do pliku dzięki metodzie WriteLine

            drukowanie.Close();
            //Zamykam zapis pliku aby nie generować błędu
            Console.WriteLine("Utworzono plik, którą linię do odczytu chcesz wybrać?");

            string wybórUżytkownika;
            //Zapisuje w string ponieważ nie chcę mi się parsować zmiennych gdyż do Console.ReadLine (pobieranie danych od użytkownika) przyjmuje tylko string
            bool program = true;

            //Robię sobie pomocnicze zmienne oraz tworze pętle programu
            while (program)
            {
                Console.WriteLine("Wybierz liczbę:");
                Console.WriteLine("| 1 (odczytuje 1linie)| 2 (odczytuje 2linie)| 3 (odczytuje 3linie)");
                Console.WriteLine("| 4 (odczytuje 4linie)| 5 (odczytuje cały plik)| 6 (zakańcza program)|");
                wybórUżytkownika = Console.ReadLine();

                //Robię sobie ifa żeby zabezpieczyć się przed innymi zmiennymi niż te, które chcę otrzymać od użytkownika
                if(wybórUżytkownika== "1" || wybórUżytkownika == "2" || wybórUżytkownika == "3" || wybórUżytkownika == "4" || wybórUżytkownika == "5" || wybórUżytkownika == "6")
                {
                    
              

                    if (File.Exists(nazwapliku))
                    {
                        string[] linia = File.ReadAllLines(nazwapliku);
                        //Używam sobie takiej fajnej metody z klasy File, która odczytuje cały plik, a potem zbiera każdą linie do tablicy
                        //Robię sobie switcha i odczytuje linie za pomocą tablicy na podstawie wyboru użytkownika

                        switch (wybórUżytkownika)
                        {
                            case "1":
                                Console.WriteLine("Linia 1 pliku: " + linia[0]);
                                Console.WriteLine();
                                break;
                            case "2":
                                Console.WriteLine("Linia 2 pliku: " + linia[1]);
                                Console.WriteLine();
                                break;
                            case "3":
                                Console.WriteLine("Linia 3 pliku: " + linia[2]);
                                Console.WriteLine();
                                break;
                            case "4":
                                Console.WriteLine("Linia 4 pliku: " + linia[3]);
                                Console.WriteLine();
                                break;
                            case "5":
                                StreamReader odczytywanie = new StreamReader(nazwapliku);
                                string line;
                                while ((line = odczytywanie.ReadLine()) != null)
                                {

                                    Console.WriteLine(line);
                                }
                                odczytywanie.Close();
                                Console.WriteLine();
                                //A tu daje sobie taka instrukcje do odczytu całego pliku, za pomocą klasy StreamReader bo czemu nie
                                break;
                            case "6":
                                program = false;

                                //A tu wychodzimy z pętli jeśli użytkownik tak zadecyduje
                                break;


                        }
                    }
   
                }
   
            }
        }
    }
}
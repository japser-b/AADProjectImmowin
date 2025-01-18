using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using System;
namespace AAD.ImmoWin.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Klant> klanten = new List<Klant>();

            // klant zonder eigendommen
            try
            {
                Klant klant1 = new Klant("", "1");
                klanten.Add(klant1);
            }
            catch (FamilienaamIsLeegOfNullException ex) { Console.WriteLine(ex.Message); }


            //Klant met een huis

            Adres adresHuis = new Adres("Straat 1", "10", 1000, "Brussel");
            Klant klant2 = new Klant("klant", "2");
            Huis huis1 = new Huis(adresHuis, 250000, new DateOnly(2000, 5, 15), Soort.alleenstaand);
            klant2.VoegWoningToe(huis1);
            klanten.Add(klant2);


            // klant met appartement

            Klant klant3 = new Klant("klant", "3");
            Adres adresAppartement = new Adres("Straat 2", "10", 1000, "Brussel");
            Appartement appartement1 = new Appartement(adresAppartement, 1500, new DateOnly(2010, 3, 12), 1);
            klant3.VoegWoningToe(appartement1);
            klanten.Add(klant3);


            // Klant met een huis en een
            Klant klant4 = new Klant("Klant", "4");
            Adres adresHuis4 = new Adres("Straat 4", "10", 1000, "Brussel");
            Huis huis4 = new Huis(adresHuis, 250000, new DateOnly(2000, 5, 15), Soort.driegevel);
            Adres adresAppartement4 = new Adres("Straat 2", "15", 2000, "Antwerpen");
            Appartement appartement4 = new Appartement(adresAppartement, 150000, new DateOnly(2011, 3, 12), 3);
            klant4.VoegWoningToe(huis1);
            klant4.VoegWoningToe(appartement1);
            klanten.Add(klant4);



            // Klant met twee huizen en vier appartementen


            Klant klant5 = new Klant("Klant", "5");
            klant5.VoegWoningToe(new Huis(new Adres("Straat 3", "20", 3000, "Gent"), 300000, new DateOnly(1995, 6, 25), Soort.rijhuis));
            klant5.VoegWoningToe(new Huis(new Adres("Straat 4", "25", 4000, "Leuven"), 275000, new DateOnly(1980, 8, 13), Soort.alleenstaand));
            klant5.VoegWoningToe(new Appartement(new Adres("Straat 5", "30", 5000, "Brugge"), 175000, new DateOnly(2015, 9, 12), 5));
            klant5.VoegWoningToe(new Appartement(new Adres("Straat 6", "35", 6000, "Mechelen"), 200000, new DateOnly(2017, 10, 23), 2));
            klant5.VoegWoningToe(new Appartement(new Adres("Straat 7", "40", 7000, "Hasselt"), 225000, new DateOnly(2018, 4, 17), 1));
            klant5.VoegWoningToe(new Appartement(new Adres("Straat 8", "45", 8000, "Kortrijk"), 195000, new DateOnly(2019, 8, 30), 4));
            klanten.Add(klant5);

            // Toon overzicht van alle klanten en hun eigendommen
            foreach (var klant in klanten)
            {
                Console.WriteLine(klant);
                Console.WriteLine(new string('-', 40)); // Separator
            }

            // Wacht op een toets om het programma af te sluiten
            Console.WriteLine("Druk op een toets om af te sluiten...");
            Console.ReadKey();

        }
    }
}

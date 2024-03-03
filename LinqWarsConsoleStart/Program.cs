using LinqWarsConsoleStart.Models;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace LinqWarsConsoleStart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var characters = Data.CharacterManager.GetAllCharacters();

            var result = characters.OrderBy(cn => cn.Name);

            foreach(var character in result)
            {
                Console.WriteLine("Karaktär namn: " +character.Name);
            }
            Console.WriteLine("-------------------------------------------");

            var WViews = Data.CharacterManager.GetAllCharacters();

            var viewing = WViews.Where(v => v.WikipediaPageViews > 4500000);

            foreach(var view in viewing)
            {
                Console.WriteLine(view.Name + " är karaktär som har: " + view.WikipediaPageViews + " Wikipediavisningar");
            }
            Console.WriteLine("----------------------------------------------");

            var appearences = Data.CharacterManager.GetAllCharacters();

            var countMovies = appearences.Select(ap => new{ Counts= ap.Appearances.Count, CharactersName = ap.Name }).OrderByDescending(ap => ap.Counts);


            foreach (var mv in countMovies)
            {
                Console.WriteLine("Karaktären: " + mv.CharactersName + " är med i: " + mv.Counts +" filmer");
            }
            Console.WriteLine("---------------------------------------------------");

            var Appearance= Data.CharacterManager.GetAllCharacters();
            
            var result2 = appearences.Where(a => a.Appearances.Contains("Star Wars: The Clone Wars")).GroupBy(a => a.Name); 

            foreach (var ap in result2)
            {
                Console.WriteLine("Karaktär som varit med i Star Wars: The Clone Wars: " + ap.Key);
            }
            Console.WriteLine("--------------------------------------------------------");

            var FiveMovies = Data.CharacterManager.GetAllCharacters();

            var result3 = FiveMovies.Where(ch => ch.Appearances.Count >= 5).Select(ch => new { Counts = ch.Appearances.Count, CharactersName = ch.Name });

                foreach (var star in result3)
            {
                Console.WriteLine(star.CharactersName + " har varit med i:" + star.Counts + " Star wars filmer!");
            }
            Console.WriteLine("_________________________________________________________");

            var weapons = Data.CharacterManager.GetAllCharacters();

            var result4 = weapons.Where(w => w.Weapons.Count < 2).Select(w => new {Counts = w.Weapons.Count, CharacterName = w.Name});

            foreach(var weapon in result4)
            {
                Console.WriteLine(weapon.CharacterName + " har: " + weapon.Counts + " vapen");
            }
            Console.WriteLine("-----------------------------------------------------------");

            var weapons2 = Data.CharacterManager.GetAllCharacters();

            var weaponresult = from w in weapons2
                               where w.Weapons.Count <2
                               select w;
            foreach (var we in weaponresult)
            {
                Console.WriteLine(we.Name + " har "+ we.Weapons.Count);
            }
            Console.WriteLine("--------------------------------------------------------------");

            var vehicles = Data.CharacterManager.GetAllCharacters();

            var result5 = vehicles.Where(vh => vh.Vehicles.Count >= 3).GroupBy(vh => vh.Name);

            foreach (var vehicle in result5)
            {
                Console.WriteLine(vehicle.Key + " har 3 eller fler farkoster." );
            }
            Console.WriteLine("-------------------------------------------------------------");

            var vehicles2 = Data.CharacterManager.GetAllCharacters();

            var resul = from v in vehicles2
                        where v.Vehicles.Count >= 3
                        select v;
            foreach (var vx in resul)
            {
                Console.WriteLine(vx.Name + " har " + vx.Vehicles.Count + " farkoster.");
            }
            Console.WriteLine("----------------------------------------------------------------");

            var locations = Data.CharacterManager.GetAllCharacters();

            var result6 = locations.Where(loc => loc.Locations.Contains("Tatooine")).GroupBy(loc => loc.Name);

            foreach(var locCh in result6)
            {
                Console.WriteLine("Karaktär med Tatooine som location: " + locCh.Key);
            }
            Console.WriteLine("-----------------------------------------------------------------");
            var species = Data.CharacterManager.GetAllCharacters();

            var result7 = from s in species
                          orderby s.Species
                          select s;
                         
                          

            foreach (var sp in result7)
            {
                Console.WriteLine(sp.Species + " = " + sp.Name);
            }




        }
    }
}
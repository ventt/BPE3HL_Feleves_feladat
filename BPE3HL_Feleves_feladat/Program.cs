using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
   
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            CategoryReader cr = new CategoryReader();
            var categories = cr.readCategories();

            if (cr.isCategoriesOverlapping(categories))
            {
                Console.WriteLine("A kategóriák összeérnek");
                Console.ReadKey();
                return;
            }

            // Beolvassuk a jatekosokat
            PlayerReader pr = new PlayerReader();
            var players = pr.readPlayers();

            // Letrehozzuk a csoportokat a ketegoriakban
            foreach (Category category in categories)
            {
                category.groups.Add(new Group(category));
            }

            // Jatekosok hozzaadasa csoportokhoz
            foreach (var player in players)
            {
                foreach (var category in categories)
                {
                    foreach (var group in category.groups)
                    {
                        if (group.isPlayerEligible(player))
                            group.players.Add(player);
                    }
                }
            }


            // Játékosok particionálása minden kategoriaban
            foreach (var category in categories)
            {
                category.partitionGroups();
            }


            // Jatekok futtatasa
            var game = new Game(categories);
            game.start();

            Console.ReadKey();
        }
    }
}

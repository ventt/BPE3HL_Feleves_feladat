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

            // Letrehozzuk a csoportokat
            List<Group> groups = new List<Group>();
            foreach(Category category in categories)
            {
                groups.Add(new Group(category, category.name + " 1"));
            }

            // Jatekosok hozzaadasa csoportokhoz
            foreach (var player in players)
            {
                foreach (var group in groups)
                {
                    if(group.isPlayerEligible(player)) 
                        group.players.Add(player);
                }
            }

            // Jatekok futtatasa
            var game = new Game(groups);
            game.start();

            Console.ReadKey();
        }
    }
}

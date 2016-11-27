using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryReader cr = new CategoryReader();
            var categories = cr.readCategories();

            if(cr.isCategoriesOverlapping(categories))
            {
                Console.WriteLine("A kategóriák összeérnek");
                Console.ReadKey();
            }
            Console.WriteLine("Játékosok és taktikák sikeresen beolvasva!");
            Console.WriteLine("Nincs átfedő kategória!");
            Console.ReadKey();

            PlayerReader pr = new PlayerReader();
            pr.readPlayers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Game
    {
        List<Group> groups;

        public Game(List<Group> groups) {
            this.groups = groups;
        }

        public Player fight(Player p1, Player p2)
        {
            int p1Choosed = p1.tactic.choose();
            int p2Choosed = p2.tactic.choose();
            int db = 1;
            while (p1Choosed == p2Choosed)
            {
                p1Choosed = p1.tactic.choose();
                p2Choosed = p2.tactic.choose();
                db++;
                if (db == 3)                          //Ha 3.jára is döntetlen, akkor pénzfeldobással döntik el
                {
                    int n = Program.random.Next(0, 1);
                    if (n == 0)
                        return p1;
                    return p2;
                }
            }
            if (p1Choosed == 0 && p2Choosed == 1)
            {
                return p1;
            }
            if (p1Choosed == 0 && p2Choosed == 2)
            {
                return p2;
            }
            if (p1Choosed == 1 && p2Choosed == 0)
            {
                return p2;
            }
            if (p1Choosed == 2 && p2Choosed == 0)
            {
                return p1;
            }
            if (p1Choosed == 1 && p2Choosed == 2)
            {
                return p1;
            }
            // p1Choosed == 2 && p2Choosed == 1
            return p2;
        }

        /// <summary>
        /// Visszaadja a nyertes játékost, és a vesztest kiszedi a listából
        /// </summary>
        /// <returns>Nyertes játékos</returns>
        public void start()
        {
            foreach(Group group in groups) {
                // Ha a csoport nem indithato
                if(!group.canBeStarted())
                    continue;
                
                printGroup(group);

                List<Player> players = new List<Player>(group.players);
                for (int turnCount=1; players.Count > 1; turnCount++)
                {
                    Console.Write("Forduló"+turnCount+": [");
                    for (int i = 0; i <= players.Count - 2; i += 2)
                    {
                        var p1 = players[i];
                        var p2 = players[i + 1];

                        Player loser = fight(p1, p2);
                        players.Remove(loser);

                        if (i != 0)
                            Console.Write(", ");

                        Console.Write(p1.name + " - " + p2.name);

                    }
                    Console.WriteLine("]");
                }
                var winner = players.First();
                printWinner(winner);
            }
        }

        private void printGroup(Group group)
        {
            Console.WriteLine("##########################");
            Console.WriteLine("Kategória: " + group.category.name);
            Console.WriteLine("Csoport: " + group.name);
            Console.WriteLine("##########################");
        }
        private void printWinner(Player player)
        {
            Console.WriteLine("Nyertes: " + player.name);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Game
    {
        List<Category> categories;
        StreamWriter file;

        public Game(List<Category> categories) {
            this.categories = categories;
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
            file = new StreamWriter("eredmeny.txt", false);

            // Vegigmegyunk minden kategorian es csoporton
            foreach (Category category in categories)
            {
                int groupCount = 0;
                foreach (Group group in category.groups)
                {
                    groupCount++;

                    // Ha a csoport nem indithato
                    if (!group.canBeStarted())
                        continue;

                    printGroup(group,category.name+" "+groupCount);

                    List<Player> players = new List<Player>(group.players);
                    for (int turnCount = 1; players.Count > 1; turnCount++)
                    {
                        write("Forduló" + turnCount + ": [");
                        for (int i = 0; i <= players.Count - 2; i += 2)
                        {
                            var p1 = players[i];
                            var p2 = players[i + 1];

                            Player loser = fight(p1, p2);
                            players.Remove(loser);

                            if (i != 0)
                                write(", ");

                            write(p1.name + " - " + p2.name);

                        }
                        writeLine("]");
                    }
                    var winner = players.First();
                    printWinner(winner);
                }
            }

            file.Flush();
            file.Close();
        }

        private void printGroup(Group group, string name)
        {
            writeLine("##########################");
            writeLine("Kategória: " + group.category.name);
            writeLine("Csoport: " + name);
            writeLine("##########################");
        }
        private void printWinner(Player player)
        {
            Console.WriteLine("Nyertes: " + player.name);
        }

        //kiírja a szöveget fileba és consoleba is
        public void write(string text)
        {
            Console.Write(text);
            file.Write(text);


        }
        //kiírja a szöveget fileba és consoleba is, majd következő sorra ugrik
        public void writeLine(string text)
        {
            Console.WriteLine(text);
            file.WriteLine(text);
        }

    }
}

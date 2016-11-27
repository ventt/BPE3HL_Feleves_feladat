using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class PlayerReader
    {
        private const string PLAYERS_FILE = "players.txt";               //Beolvasó
        private const string TACTICS_FILE = "tactics.txt";


        public List<Tactic> readTactics()
        {
            List<Tactic> tactics = new List<Tactic>();
            foreach (string line in File.ReadLines(TACTICS_FILE))
            {
                Tactic tactic = new Tactic();
                if (line == null) continue;

                //szétdaraboljuk a sort két részre
                string[] str = splitString(line, '|', 2);
                tactic.playerId = str[0]; //playerId

                if (str[1] == null) continue;
                string[] szazalekok = splitString(str[1], '-', 3);
                tactic.rock = double.Parse(szazalekok[0]);
                tactic.paper = double.Parse(szazalekok[1]);
                tactic.scissors = double.Parse(szazalekok[2]);

                tactics.Add(tactic);
            }


            return tactics;
        }

        /// <summary>
        /// Feldarabol egy stringet elválasztók mentén
        /// </summary>
        /// <param name="str">szöveg</param>
        /// <param name="separator">elválasztó karakter</param>
        /// <param name="size">a visszaadott tömb mérete</param>
        /// <returns>egy tömb a szövegdarabokkal</returns>
        private string[] splitString(string str, char separator, int size)
        {
            string[] result = new string[size];
            string buf = "";
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == separator)
                {
                    result[count] = buf;
                    count++;
                    buf = "";
                }
                else
                {
                    buf = buf + str[i];
                }

            }
            result[count] = buf;
            return result;
        }
    }

}

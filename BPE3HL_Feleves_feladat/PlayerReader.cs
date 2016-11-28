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
        private const string PLAYERS_FILE = "players.txt";               //alap
        private const string TACTICS_FILE = "tactics.txt";               //fájlok

        /// <summary>
        /// Beolvassa a player fáljból a játékosok nevét, életkorát és ID-ját, majd ID szerint csatolja a taktikákat.
        /// </summary>
        /// <returns>Egy player listát</returns>
        public List<Player> readPlayers()
        {
            var tactics = readTactics();
            int count = 0;
            List<Player> players = new List<Player>();
            foreach (string line in File.ReadLines(PLAYERS_FILE))
            {
                if (count++ == 0) continue;   //segéd változó, hogy az első elemet ne mentse az a program
                if (line == null) continue;
                Player player = new Player();
                string[] str = Utils.splitString(line, '|', 3);
                if (str[0] == null || str[1] == null || str[2] == null) continue;   //ellenörzi hogy az str tömb egyik eleme se null
                player.name = str[0];
                player.age = int.Parse(str[1]);
                player.id = str[2];


                foreach (var tactic in tactics)            //hozzá adja ID szerint a player listába a taktikákat
                {
                    if (player.id == tactic.playerId)
                    {
                        player.tactic = tactic;
                    }
                }

                players.Add(player);
            }
            return players;
        }

        private List<Tactic> readTactics()
        {
            List<Tactic> tactics = new List<Tactic>();
            foreach (string line in File.ReadLines(TACTICS_FILE))
            {
                Tactic tactic = new Tactic();
                if (line == null) continue;

                //szétdaraboljuk a sort két részre
                string[] str = Utils.splitString(line, '|', 2);
                tactic.playerId = str[0]; //playerId

                if (str[1] == null) continue;
                string[] szazalekok = Utils.splitString(str[1], '-', 3);
                tactic.rock = double.Parse(szazalekok[0]);
                tactic.paper = double.Parse(szazalekok[1]);
                tactic.scissors = double.Parse(szazalekok[2]);

                tactics.Add(tactic);
            }


            return tactics;
        }
        
    }

}

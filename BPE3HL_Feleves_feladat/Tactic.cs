using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Tactic
    {
       public string playerId;
       public double rock;
       public double paper;
       public double scissors;

        public Tactic() { }

        public Tactic(string playerId, double rock, double paper, double scrissors)
        {
            this.playerId = playerId;
            this.rock = rock;
            this.paper = paper;
            this.scissors = scrissors;
        }

        public int choose()
        {
            double n = Program.random.NextDouble()*100;
            if (n < rock)
                return 0;
            if (n > rock && n < scissors)
                return 1;
            return 2;
        }
    }
}

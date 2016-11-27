using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Player
    {
        public string id;
        public string name;
        public int age;
        public Tactic tactic;

        public Player() { }

        public Player(string id, string name, int age, Tactic tactic)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.tactic = tactic;
        }
    
    }
}

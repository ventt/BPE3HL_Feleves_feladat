using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Group
    {
        public List<Player> players = new List<Player>();
        public Category category;
     
        public bool canBeStarted()
        {
            
            for (int i = 0; i < 100; i++)
            {
                if (players.Count == (int) Math.Pow(2, i))
                {
                    return true;
                }
            }
            return false;
        }   
    }
}

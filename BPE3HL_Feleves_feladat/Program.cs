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
            PlayerReader pr = new PlayerReader();

            pr.readPlayers();
        }
    }
}

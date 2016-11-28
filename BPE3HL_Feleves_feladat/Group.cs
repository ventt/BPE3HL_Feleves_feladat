﻿using System;
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
        public string name;
     
        public Group(Category category, string name)
        {
            this.category = category;
            this.name = name;

        }

        /// <summary>
        /// eldönti hogy a csoport létszáma a 2 valamely hatványa-e
        /// </summary>
        /// <returns>bool</returns>
        public bool canBeStarted()
        {
            return (players.Count != 0) && ((players.Count & (players.Count - 1)) == 0);
        }

        public bool isPlayerEligible(Player p)
        {
            return p.age >= category.ageMin && p.age <= category.ageMax;
        }
    }
}

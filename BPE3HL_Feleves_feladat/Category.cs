using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Category
    {
        public string name;
        public int ageMin;
        public int ageMax;
        public List<Group> groups = new List<Group>();

        public Category() { }

        public Category(string categoryName, int ageMin, int ageMax)
        {
            this.name = categoryName;
            this.ageMin = ageMin;
            this.ageMax = ageMax;
        }

        public bool isWithinRange(int age)
        {
            return age >= ageMin && age <= ageMax;
        }

        public void partitionGroups()
        {
            while (true)
            {
                bool wasPartitioned = false;
                List<Group> newGroups = new List<Group>();

                foreach (var group in this.groups)
                {
                    var newGroup = new Group(group.category);

                    // Ha a csoport letszama nagyobb, mint 1, es nem lehet elinditani
                    while (group.players.Count > 1 && !group.canBeStarted())
                    {
                        var player = group.players.Last();
                        group.players.Remove(player);
                        newGroup.players.Add(player);

                        // Ha particionalni kellett, akkor igazra allitjuk a kapcsolot
                        wasPartitioned = true;
                    }

                    // Csak akkor adjuk hozza az uj csoportot ha tartalmaz jatekost
                    if (newGroup.players.Count > 0)
                        newGroups.Add(newGroup);
                }

                this.groups.AddRange(newGroups);

                // Ha nem kellet particionalni, akkor kilepunk a ciklusbol
                if (wasPartitioned == false)
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Category
    {
        public string categoryName;
        public int ageMin;
        public int ageMax;

        public Category() { }

        public Category(string categoryName, int ageMin, int ageMax)
        {
            this.categoryName = categoryName;
            this.ageMin = ageMin;
            this.ageMax = ageMax;
        }

        public bool isWithinRange(int age)
        {
            return age >= ageMin && age <= ageMax;
        }
    }
}

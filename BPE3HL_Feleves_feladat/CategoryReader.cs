using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class CategoryReader
    {
        private const string CATEGORIES_FILE = "Categories.txt";

        public List<Category> readCategories()
        {
            List<Category> categories = new List<Category>();
            foreach (var line in File.ReadLines(CATEGORIES_FILE))
            {
                Category category = new Category();
                if (line == null) continue;
                string[] str = Utils.splitString(line, '|', 3);

                if (str[0] == null || str[1] == null || str[2] == null) continue;
                category.categoryName = str[0];
                category.ageMin = int.Parse(str[1]);
                category.ageMax = int.Parse(str[2]);

                categories.Add(category);
            }
            return categories;
        }
       
        
        /// <summary>
        /// Ellenörzi hogy a kategóriák összeérnek-e
        /// </summary>
        /// <param name="categories">A lista</param>
        /// <returns>Igaz értéket, ha összeérnek!</returns>
        public bool isCategoriesOverlapping(List<Category> categories)  
        {
            for (int i = 0; i < 255; i++)
            {
                int count = 0;

                foreach (var category in categories)
                {
                    if (category.isWithinRange(i))
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    return true;
                }
            }

            return false;
        }
        
    }
}

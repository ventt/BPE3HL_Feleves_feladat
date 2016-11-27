using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPE3HL_Feleves_feladat
{
    class Utils
    {
        /// <summary>
        /// Feldarabol egy stringet elválasztók mentén
        /// </summary>
        /// <param name="str">szöveg</param>
        /// <param name="separator">elválasztó karakter</param>
        /// <param name="size">a visszaadott tömb mérete</param>
        /// <returns>egy tömb a szövegdarabokkal</returns>
        public static string[] splitString(string str, char separator, int size)
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

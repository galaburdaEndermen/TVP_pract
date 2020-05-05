using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace site
{
    namespace Extentions
    {
        static class StringExentions
        {
       
            public static string Filtre(this string str, char toDelete)
            {
                int count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == toDelete)
                    {
                        count++;
                    }
                }

                string toDel = "";
                for (int i = 0; i < count; i++)
                {
                    toDel += " ";
                }
                return str.Replace(toDel, "");

            }
        }


    }
}

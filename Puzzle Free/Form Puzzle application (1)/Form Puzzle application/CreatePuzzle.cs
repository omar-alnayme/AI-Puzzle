using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// this is temprary class
namespace Puzzel_project
{
   public static class CreatePuzzle
    {
        public static string[,] GetGoal ( int N )
        {
            Random r = new Random();
            if (N == 1)
            {
                string[,] Puzzel = new string[,] { { "1", "2" , "3"}, {"8", "-", "4" }, { "7", "6", "5" } };
              
                return Puzzel;
            }
            if (N == 2)
            {
                //string[,] Puzzel = new string[,] { { "2", "8", "3" }, { "1", "6", "4" }, { "7", "-", "5" } };

                string[,] Puzzel = new string[,] { { "1", "2", "4","7" },
                    { "5", "6", "3","-" },
                    { "10", "13", "11","8" },
                    { "9", "14", "15","12" }
                };

                return Puzzel;
            }
            return null;
// 1  2  4  7
// 5  6  3  0
//10 13 11  8
// 9 14 15 12
        }
    }
}

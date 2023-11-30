using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel_project
{
   public static  class Service_Class
    {
        public static  obj_location GetLocationOfEmpty(string[,] Puzzel)
        {
            obj_location location = new obj_location();
            int len = 0;
         
            len = Puzzel.GetLength(0)-1;
            for (int i = 0; i <= len; i++)
            {
                for (int j = 0; j <= len; j++)
                {
                    if (Puzzel[i, j] == "*")
                    {
                        location.i = i;
                        location.j = j;
                        return location;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// input is the direction of the movements
        /// </summary>
        /// <param name="input"></param>
        /// <param name="puzzel"></param>
        /// <returns></returns>
        public  static string[,] MovePuzzel(string input, string[,] puzzel)
        {
            int max = puzzel.GetLength(0); 
            obj_location location = new obj_location();
            location = Service_Class.GetLocationOfEmpty(puzzel);
            if (input == "0")
            {
                if (location.j == 0)
                {
                    return puzzel;
                }
                string temp = puzzel[location.i, location.j - 1];
                puzzel[location.i, location.j - 1] = puzzel[location.i, location.j];
                puzzel[location.i, location.j] = temp;
            }
            if (input == "1")
            {
                if (location.i == 0)
                {
                    return puzzel;
                }
                string temp = puzzel[location.i - 1, location.j];
                puzzel[location.i - 1, location.j] = puzzel[location.i, location.j];
                puzzel[location.i, location.j] = temp;
            }
            if (input == "2")
            {
                if (location.j == max - 1)
                {
                    return puzzel;
                }
                string temp = puzzel[location.i, location.j + 1];
                puzzel[location.i, location.j + 1] = puzzel[location.i, location.j];
                puzzel[location.i, location.j] = temp;
            }
            if (input == "3")
            {
                if (location.i == max - 1)
                {
                   
                    return puzzel;
                }
                string temp = puzzel[location.i + 1, location.j];
                puzzel[location.i + 1, location.j] = puzzel[location.i, location.j];
                puzzel[location.i, location.j] = temp;
            }
            return puzzel;
        }
    }

    public class obj_location
    {
        public int i { get; set; }
        public int j { get; set; }
    }
}

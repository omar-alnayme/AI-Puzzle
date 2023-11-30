using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel_project
{
    public static  class Puzzle_Class
    {
        public static string[,] GetPuzzle ( int N )
        {
            Random r = new Random();

            if (N == 9)
            {
                string[,] Puzzel = new string[3, 3]; 
                int Number = 1;
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (Number == 9)
                        {
                            Puzzel[i, j] = "*";
                        }
                        else
                        {
                            Puzzel[i, j] = Number.ToString();
                        }
                        Number += 1;
                    }
                }
                return Puzzel;
            }
            if (N == 16)
            {
                    string[,] Puzzel = new string[4, 4]; 
                    int Number = 1;
                    for (int i = 0; i <= 3; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            if (Number==16)
                            {
                                Puzzel[i, j] ="*";
                            }
                            else
                            {
                                Puzzel[i, j] = Number.ToString();
                            }
                            
                            Number += 1;
                        }
                    }
                    return Puzzel;
            }
            
            if (N == 25)
            {
                string[,] Puzzel = new string[5, 5];
                int Number = 1;
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        if (Number == N)
                        {
                            Puzzel[i, j] = "*";
                        }
                        else
                        {
                            Puzzel[i, j] = Number.ToString();
                        }

                        Number += 1;
                    }
                }
                return Puzzel;
            }
         
            if (N == 4)
            {
                string[,] Puzzel = new string[2, 2]; 
                int Number = 1;
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (Number == N)
                        {
                            Puzzel[i, j] = "*";
                        }
                        else
                        {
                            Puzzel[i, j] = Number.ToString();
                        }

                        Number += 1;
                    }
                }
                return Puzzel;
            }
            return null;
        }

    }
}

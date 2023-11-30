using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_Puzzle_application
{
   public static class ManualPuzzle
    {
        public static string[,] CreatePuzzleManualy (int x)
        {
            string[,] Puzzel = null;
            if (x==8)
            {
                Puzzel = new string[3, 3];
                int Number = 1;
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        Puzzel[i, j] = Input.ShowDialog("Puzzle[" + i + "," + j + "]", "Enter Puzzle values");
                        Number += 1;
                    }
                }
            }

            if (x==15)
            {
                Puzzel = new string[4, 4];
               
                int Number = 1;
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        Puzzel[i, j] = Input.ShowDialog("Puzzle[" + i + "," + j + "]", "Enter Puzzle values");
                        Number += 1;
                    }
                }
            }

            if (x==3)
            {
                Puzzel = new string[2, 2];
                int Number = 1;
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        Puzzel[i, j] = Input.ShowDialog("Puzzle[" + i + "," + j + "]", "Enter Puzzle values");
                        Number += 1;
                    }
                }
            }

            if (x==24)
            {
                Puzzel = new string[5, 5]; 
                int Number = 1;
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        Puzzel[i, j] = Input.ShowDialog("Puzzle[" + i + "," + j + "]", "Enter Puzzle values");
                        Number += 1;
                    }
                }
            }
            return Puzzel;
        }
    }
}

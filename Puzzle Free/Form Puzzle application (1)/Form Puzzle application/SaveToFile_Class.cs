using Form_Puzzle_application;
using PuzzleSolver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel_project
{
   public static  class SaveToFile_Class
    {
        public static void savetofile(List<nodes_info> l)
        {
            using (TextWriter tw = new StreamWriter(@"c:\temp\data.txt"))
            {
                int len = 0;
                foreach (var s in l)
                {
                    len=s.node_parent.GetLength(0);
                    string x = "";
                    tw.WriteLine("===========================================================================");
                    tw.WriteLine("Parent Node ...");
                    tw.WriteLine("Depth : " + s.depth);
                    for (int i = 0; i < len; i++)
                    {
                        x = "";
                        for (int j = 0; j < len; j++)
                        {
                            x = x + "\t"+ s.node_parent[i, j];
                           
                        }
                        tw.WriteLine(x);
                    }
                    tw.WriteLine("---------------------------------------------------------------------------");
                    foreach (var childNode in s.node_childrens)
                    {
                        tw.WriteLine("Child Node ...");
                        x = "";
                        for (int i = 0; i < len; i++)
                        {
                            x = "";
                            for (int j = 0; j < len; j++)
                            {
                                x = x + "\t" + childNode[i, j];

                            }
                            tw.WriteLine(x);
                        }
                    }
                }
    
            }
        }
    }
}

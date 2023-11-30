using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Puzzel_project;
using System.Collections;
using System.Threading;
using System.IO;
using PuzzleSolver;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Form_Puzzle_application
{
    public partial class Form1 : Form
    {
        private TimeSpan ST;
        private int MaxDepth = 0;
        private int step=0;
        private string[,] puzzle;
        private string[,] goal;
        public Form1 ()
        {
            InitializeComponent();
        }

        private void cmd_start_Click ( object sender, EventArgs e )
        {
            cmd_start.Enabled = false;
            cmd_reshuffle.Enabled = true;
            radio_15.Enabled = false;
            radio_8.Enabled = false;
            radio_24.Enabled = false;
            radio_3.Enabled = false;
            cmd_manualGoal.Enabled = true;
            cmd_ManualState.Enabled = true;
            g_solve.Enabled = true;
            g_move.Enabled = true;
            cmd_restart.Enabled = true;
            if (radio_8.Checked)
            {
                puzzle= Puzzle_Class.GetPuzzle(9);
                DrawPuzzle(puzzle);
            }
            if (radio_15.Checked)
            {
                puzzle = Puzzle_Class.GetPuzzle(16);
                DrawPuzzle(puzzle);
            }
            if (radio_3.Checked)
            {
                puzzle = Puzzle_Class.GetPuzzle(4);
                DrawPuzzle(puzzle);
            }
            if (radio_24.Checked)
            {
                puzzle = Puzzle_Class.GetPuzzle(25);
                DrawPuzzle(puzzle);
            }
            goal = (string[,])puzzle.Clone(); // Save the goal status.
        }

      
        private void DrawPuzzle ( string[,] puz )
        {
            listBox1.Items.Add("Move number : " + step);
            listBox1.Items.Add("-----------------------------------------");
            panel1.Controls.Clear();
            int rows = puz.GetLength(0);
            int posy = 5;
            for (int i = 0; i < rows; i++)
            {
                int posx = 5;
                string x = "";
                for (int j = 0; j < rows; j++)
                {
                    x = x +(puz[i, j]) + "\t" ;
                    
                    btnAdd = new Button();
                    btnAdd.BackColor = Color.Gray;
                    int newSize = 12;
                    btnAdd.Font = new Font(btnAdd.Font.FontFamily, newSize);
                    btnAdd.Font = new Font(btnAdd.Font.Name, btnAdd.Font.Size, FontStyle.Bold);
                    btnAdd.Text = puz[i,j];
                    if (puz[i,j]=="*")
                    {
                        btnAdd.ForeColor = Color.Blue;
                    }
                    btnAdd.Location = new System.Drawing.Point(1+posx, 1+posy);
                    btnAdd.Size = new System.Drawing.Size(50,50);
                    panel1 .Controls.Add(btnAdd);
                    posx = posx + 50;
                }
                posy = posy +50;
                listBox1.Items.Add(x);
            }
            listBox1.Items.Add("-----------------------------------------");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private Button btnAdd;

        private void Form1_Load ( object sender, EventArgs e )
        {
            for (int i = 2; i < 30; i++)
            {
                combo_maxdepth.Items.Add(i.ToString());
            }
            combo_maxdepth.SelectedItem   = "2";
        }

        private void cmd_reshuffle_Click ( object sender, EventArgs e )
        {
            cmd_reshuffle.Enabled = false;
            Random r = new Random();
            int Direction = 0;
            int oldDirection = -1;
            for (int i = 0; i < 8; i++)
            {
                while (oldDirection == Direction || Direction < 0)
                {
                    Direction = r.Next(5) - 1;
                }
                oldDirection = Direction;
                puzzle = Service_Class.MovePuzzel(Direction.ToString(), puzzle);
            }
            DrawPuzzle(puzzle);
        }

        private void cmd_up_Click ( object sender, EventArgs e )
        {
            step = step + 1;
           puzzle= Service_Class.MovePuzzel("1", puzzle);
           DrawPuzzle(puzzle);
        }

        private void cmd_left_Click ( object sender, EventArgs e )
        {
            step = step + 1;
            puzzle = Service_Class.MovePuzzel("0", puzzle);
            DrawPuzzle(puzzle);
        }

        private void cmd_down_Click ( object sender, EventArgs e )
        {
            step = step + 1;
            puzzle = Service_Class.MovePuzzel("3", puzzle);
            DrawPuzzle(puzzle);
        }

        private void cmd_right_Click ( object sender, EventArgs e )
        {
            step = step + 1;
            puzzle = Service_Class.MovePuzzel("2", puzzle);
            DrawPuzzle(puzzle);
        }

        private void cmd_quit_Click ( object sender, EventArgs e )
        {
            listBox2.BackColor = Color.White;
            cmd_start.Enabled = true;
            cmd_reshuffle.Enabled = true;
            radio_15.Enabled = true;
            radio_8.Enabled = true;
            radio_3.Enabled = true;
            radio_24.Enabled = true;
            g_move.Enabled = false;
            g_solve.Enabled = false;
            cmd_manualGoal.Enabled = true;
            cmd_ManualState.Enabled = true;
            cmd_restart.Enabled = false;
            cmd_reshuffle.Enabled = false;
            listBox1.Items.Clear();
            panel1.Controls.Clear();
            listBox2.Items.Clear();
            txt_steps.Text = "";
            txt_nodes.Text = "";
        }

        private async void StartSolving_Click ( object sender, EventArgs e )
        {
            ST = DateTime.Now.TimeOfDay;
            listBox2.BackColor = Color.LightPink;
            timer1.Enabled = true;
            g_move.Enabled = false;
            g_puzzle.Enabled = false;
            g_solve.Enabled = false;

            if (radio_bfs.Checked)
            {
                MaxDepth = 100000;
            }
          
            if (radio_dfs.Checked)
            {
                MaxDepth = Convert.ToInt16(combo_maxdepth.GetItemText(combo_maxdepth.SelectedItem));
            }

            if (radio_bestfs.Checked)
            {
                MaxDepth = 100000;
            }

            
            var x = await Solveit();
            timer1.Enabled = false;
            if(x.SoloutionFound)
                listBox2.BackColor = Color.LightGreen;
            else
                listBox2.BackColor = Color.Orange;
            listBox2.Items.Clear();
            listBox2.Items.Add("==========================================================");
            listBox2.Items.Add("Search Type \t:" + x.SearchType);
            listBox2.Items.Add("----------------------------------------------------------");
            listBox2.Items.Add("Solution Found \t:" + x.SoloutionFound);
            listBox2.Items.Add("----------------------------------------------------------");
            listBox2.Items.Add("Start Time \t:" + x.startTime);
            listBox2.Items.Add("End Time \t\t:" + x.endTime);
            listBox2.Items.Add("Total time in ms \t:" + x.totalTimeinMS);
            listBox2.Items.Add("----------------------------------------------------------");
            listBox2.Items.Add("Depth \t \t:" + x.depth);
            listBox2.Items.Add("Total Parents \t:" + x.totalParents);
            listBox2.Items.Add("Total Nodes \t:" + x.totalNodes);
            listBox2.Items.Add("----------------------------------------------------------");
            listBox2.Items.Add("Done........");
            txt_nodes.Text = x.totalNodes;
            txt_steps.Text = x.totalParents;
            if (x.SoloutionFound)
            {
                DrawPuzzle(goal);
            }
            g_move.Enabled = true;
            g_puzzle.Enabled = true;
            g_solve.Enabled = true;
        }

        private Task<PuzzleSolver.SendBackInfo> Solveit ()
        {
            string searchType=null;
            if (radio_dfs.Checked)
            {
                searchType = "DFS";
            }
            if (radio_bfs.Checked)
            {
                searchType = "BFS";
            }
            if (radio_bestfs.Checked)
            {
                searchType = "ABFS";
            }
            combo_maxdepth.Enabled = true;
            combo_maxdepth.Enabled = false;
            return Task.Factory.StartNew(() => StartSolving(searchType));
        }

        private SendBackInfo StartSolving (string searchType)
        {
            string SearchType;
            BDBFS_Class x = new BDBFS_Class();
            if (searchType=="DFS")
            {
                return x.DBFS(goal, puzzle, MaxDepth, searchType);
            }
            if (searchType=="BFS")
            {
                return x.DBFS(goal, puzzle, MaxDepth, searchType);
            }

            if (searchType=="ABFS")
            {
               return x.BestFS(goal, puzzle);
            }

            return null;
        }

        private void radio_dfs_CheckedChanged ( object sender, EventArgs e )
        {
            EnableDisableDepthmax();
        }
        private void EnableDisableDepthmax ()
        {
            if (radio_dfs.Checked)
            {
                combo_maxdepth.Enabled = true;
            }
            else
            {
                combo_maxdepth.Enabled = false;
            }
        }

        private void radio_bfs_CheckedChanged ( object sender, EventArgs e )
        {
            EnableDisableDepthmax();
        }

        
        private void CreatePuzzleManually ( string fromcmd )
        {
            if (radio_3.Checked)
            {
                puzzle = ManualPuzzle.CreatePuzzleManualy(3);
            }
            if (radio_8.Checked)
            {
                puzzle = ManualPuzzle.CreatePuzzleManualy(8);
            }
            if (radio_15.Checked)
            {
                puzzle = ManualPuzzle.CreatePuzzleManualy(15);
            }
            if (radio_24.Checked)
            {
                puzzle = ManualPuzzle.CreatePuzzleManualy(24);
            }
            DrawPuzzle(puzzle);
            if(fromcmd=="goal")
                goal = (string[,])puzzle.Clone();
        }

        private void cmd_manualGoal_Click ( object sender, EventArgs e )
        {
            CreatePuzzleManually("goal");
        }

        private void cmd_ManualState_Click ( object sender, EventArgs e )
        {
            CreatePuzzleManually("state");
        }

        private void cmd_GetSoloution_Click ( object sender, EventArgs e )
        {
            Process.Start(@"c:\temp\data.txt");
        }

        private void timer1_Tick ( object sender, EventArgs e )
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("Please Waite, Working on it...");
            listBox2.Items.Add("Start Time \t: " + ST.ToString());
            listBox2.Items.Add("Elapsed time \t: " + DateTime.Now.TimeOfDay.ToString());
            listBox2.Items.Add("Total Millisecond \t: " + (DateTime.Now.TimeOfDay-ST).TotalMilliseconds);
        }
    }
}

namespace Form_Puzzle_application
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.cmd_start = new System.Windows.Forms.Button();
            this.radio_8 = new System.Windows.Forms.RadioButton();
            this.radio_15 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmd_restart = new System.Windows.Forms.Button();
            this.cmd_reshuffle = new System.Windows.Forms.Button();
            this.cmd_right = new System.Windows.Forms.Button();
            this.cmd_up = new System.Windows.Forms.Button();
            this.cmd_down = new System.Windows.Forms.Button();
            this.cmd_left = new System.Windows.Forms.Button();
            this.g_solve = new System.Windows.Forms.GroupBox();
            this.radio_bestfs = new System.Windows.Forms.RadioButton();
            this.combo_maxdepth = new System.Windows.Forms.ComboBox();
            this.radio_bfs = new System.Windows.Forms.RadioButton();
            this.radio_dfs = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.g_puzzle = new System.Windows.Forms.GroupBox();
            this.cmd_ManualState = new System.Windows.Forms.Button();
            this.cmd_manualGoal = new System.Windows.Forms.Button();
            this.radio_24 = new System.Windows.Forms.RadioButton();
            this.radio_3 = new System.Windows.Forms.RadioButton();
            this.g_move = new System.Windows.Forms.GroupBox();
            this.txt_steps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nodes = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmd_GetSoloution = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.g_solve.SuspendLayout();
            this.g_puzzle.SuspendLayout();
            this.g_move.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmd_start
            // 
            this.cmd_start.Location = new System.Drawing.Point(100, 8);
            this.cmd_start.Name = "cmd_start";
            this.cmd_start.Size = new System.Drawing.Size(94, 29);
            this.cmd_start.TabIndex = 0;
            this.cmd_start.Text = "Build pzzle";
            this.cmd_start.UseVisualStyleBackColor = true;
            this.cmd_start.Click += new System.EventHandler(this.cmd_start_Click);
            // 
            // radio_8
            // 
            this.radio_8.AutoSize = true;
            this.radio_8.Checked = true;
            this.radio_8.Location = new System.Drawing.Point(9, 36);
            this.radio_8.Name = "radio_8";
            this.radio_8.Size = new System.Drawing.Size(65, 17);
            this.radio_8.TabIndex = 1;
            this.radio_8.TabStop = true;
            this.radio_8.Text = "8 Puzzle";
            this.radio_8.UseVisualStyleBackColor = true;
            // 
            // radio_15
            // 
            this.radio_15.AutoSize = true;
            this.radio_15.Location = new System.Drawing.Point(9, 56);
            this.radio_15.Name = "radio_15";
            this.radio_15.Size = new System.Drawing.Size(71, 17);
            this.radio_15.TabIndex = 2;
            this.radio_15.TabStop = true;
            this.radio_15.Text = "15 Puzzle";
            this.radio_15.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(391, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 270);
            this.panel1.TabIndex = 4;
            // 
            // cmd_restart
            // 
            this.cmd_restart.Enabled = false;
            this.cmd_restart.Location = new System.Drawing.Point(100, 71);
            this.cmd_restart.Name = "cmd_restart";
            this.cmd_restart.Size = new System.Drawing.Size(94, 23);
            this.cmd_restart.TabIndex = 4;
            this.cmd_restart.Text = "New game";
            this.cmd_restart.UseVisualStyleBackColor = true;
            this.cmd_restart.Click += new System.EventHandler(this.cmd_quit_Click);
            // 
            // cmd_reshuffle
            // 
            this.cmd_reshuffle.Enabled = false;
            this.cmd_reshuffle.Location = new System.Drawing.Point(100, 38);
            this.cmd_reshuffle.Name = "cmd_reshuffle";
            this.cmd_reshuffle.Size = new System.Drawing.Size(94, 29);
            this.cmd_reshuffle.TabIndex = 3;
            this.cmd_reshuffle.Text = "Reshuffle";
            this.cmd_reshuffle.UseVisualStyleBackColor = true;
            this.cmd_reshuffle.Click += new System.EventHandler(this.cmd_reshuffle_Click);
            // 
            // cmd_right
            // 
            this.cmd_right.Location = new System.Drawing.Point(119, 39);
            this.cmd_right.Name = "cmd_right";
            this.cmd_right.Size = new System.Drawing.Size(45, 23);
            this.cmd_right.TabIndex = 3;
            this.cmd_right.Text = ">>";
            this.cmd_right.UseVisualStyleBackColor = true;
            this.cmd_right.Click += new System.EventHandler(this.cmd_right_Click);
            // 
            // cmd_up
            // 
            this.cmd_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd_up.Location = new System.Drawing.Point(76, 19);
            this.cmd_up.Name = "cmd_up";
            this.cmd_up.Size = new System.Drawing.Size(45, 23);
            this.cmd_up.TabIndex = 2;
            this.cmd_up.Text = "^";
            this.cmd_up.UseVisualStyleBackColor = true;
            this.cmd_up.Click += new System.EventHandler(this.cmd_up_Click);
            // 
            // cmd_down
            // 
            this.cmd_down.Location = new System.Drawing.Point(76, 60);
            this.cmd_down.Name = "cmd_down";
            this.cmd_down.Size = new System.Drawing.Size(45, 23);
            this.cmd_down.TabIndex = 1;
            this.cmd_down.Text = "v";
            this.cmd_down.UseVisualStyleBackColor = true;
            this.cmd_down.Click += new System.EventHandler(this.cmd_down_Click);
            // 
            // cmd_left
            // 
            this.cmd_left.Location = new System.Drawing.Point(33, 39);
            this.cmd_left.Name = "cmd_left";
            this.cmd_left.Size = new System.Drawing.Size(45, 23);
            this.cmd_left.TabIndex = 0;
            this.cmd_left.Text = "<<";
            this.cmd_left.UseVisualStyleBackColor = true;
            this.cmd_left.Click += new System.EventHandler(this.cmd_left_Click);
            // 
            // g_solve
            // 
            this.g_solve.BackColor = System.Drawing.Color.Transparent;
            this.g_solve.Controls.Add(this.radio_bestfs);
            this.g_solve.Controls.Add(this.combo_maxdepth);
            this.g_solve.Controls.Add(this.radio_bfs);
            this.g_solve.Controls.Add(this.radio_dfs);
            this.g_solve.Controls.Add(this.button1);
            this.g_solve.Enabled = false;
            this.g_solve.Location = new System.Drawing.Point(12, 12);
            this.g_solve.Name = "g_solve";
            this.g_solve.Size = new System.Drawing.Size(374, 64);
            this.g_solve.TabIndex = 7;
            this.g_solve.TabStop = false;
            this.g_solve.Text = "Solving Puzzle Automaticaly";
            // 
            // radio_bestfs
            // 
            this.radio_bestfs.AutoSize = true;
            this.radio_bestfs.Location = new System.Drawing.Point(127, 41);
            this.radio_bestfs.Name = "radio_bestfs";
            this.radio_bestfs.Size = new System.Drawing.Size(100, 17);
            this.radio_bestfs.TabIndex = 12;
            this.radio_bestfs.TabStop = true;
            this.radio_bestfs.Text = "Best-first search";
            this.radio_bestfs.UseVisualStyleBackColor = true;
            // 
            // combo_maxdepth
            // 
            this.combo_maxdepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_maxdepth.FormattingEnabled = true;
            this.combo_maxdepth.Location = new System.Drawing.Point(127, 16);
            this.combo_maxdepth.Name = "combo_maxdepth";
            this.combo_maxdepth.Size = new System.Drawing.Size(71, 21);
            this.combo_maxdepth.TabIndex = 11;
            // 
            // radio_bfs
            // 
            this.radio_bfs.AutoSize = true;
            this.radio_bfs.Location = new System.Drawing.Point(10, 40);
            this.radio_bfs.Name = "radio_bfs";
            this.radio_bfs.Size = new System.Drawing.Size(116, 17);
            this.radio_bfs.TabIndex = 10;
            this.radio_bfs.TabStop = true;
            this.radio_bfs.Text = "Breadth-first search";
            this.radio_bfs.UseVisualStyleBackColor = true;
            this.radio_bfs.CheckedChanged += new System.EventHandler(this.radio_bfs_CheckedChanged);
            // 
            // radio_dfs
            // 
            this.radio_dfs.AutoSize = true;
            this.radio_dfs.Checked = true;
            this.radio_dfs.Location = new System.Drawing.Point(10, 17);
            this.radio_dfs.Name = "radio_dfs";
            this.radio_dfs.Size = new System.Drawing.Size(108, 17);
            this.radio_dfs.TabIndex = 9;
            this.radio_dfs.TabStop = true;
            this.radio_dfs.Text = "Depth-first search";
            this.radio_dfs.UseVisualStyleBackColor = true;
            this.radio_dfs.CheckedChanged += new System.EventHandler(this.radio_dfs_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(293, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartSolving_Click);
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(12, 109);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(374, 386);
            this.listBox2.TabIndex = 9;
            // 
            // g_puzzle
            // 
            this.g_puzzle.Controls.Add(this.cmd_ManualState);
            this.g_puzzle.Controls.Add(this.cmd_manualGoal);
            this.g_puzzle.Controls.Add(this.radio_24);
            this.g_puzzle.Controls.Add(this.radio_3);
            this.g_puzzle.Controls.Add(this.cmd_restart);
            this.g_puzzle.Controls.Add(this.cmd_start);
            this.g_puzzle.Controls.Add(this.cmd_reshuffle);
            this.g_puzzle.Controls.Add(this.radio_15);
            this.g_puzzle.Controls.Add(this.radio_8);
            this.g_puzzle.Location = new System.Drawing.Point(682, 3);
            this.g_puzzle.Name = "g_puzzle";
            this.g_puzzle.Size = new System.Drawing.Size(200, 189);
            this.g_puzzle.TabIndex = 11;
            this.g_puzzle.TabStop = false;
            this.g_puzzle.Text = "Start Game";
            // 
            // cmd_ManualState
            // 
            this.cmd_ManualState.Enabled = false;
            this.cmd_ManualState.Location = new System.Drawing.Point(6, 150);
            this.cmd_ManualState.Name = "cmd_ManualState";
            this.cmd_ManualState.Size = new System.Drawing.Size(188, 23);
            this.cmd_ManualState.TabIndex = 8;
            this.cmd_ManualState.Text = "Enter start state manually";
            this.cmd_ManualState.UseVisualStyleBackColor = true;
            this.cmd_ManualState.Click += new System.EventHandler(this.cmd_ManualState_Click);
            // 
            // cmd_manualGoal
            // 
            this.cmd_manualGoal.Enabled = false;
            this.cmd_manualGoal.Location = new System.Drawing.Point(5, 121);
            this.cmd_manualGoal.Name = "cmd_manualGoal";
            this.cmd_manualGoal.Size = new System.Drawing.Size(189, 23);
            this.cmd_manualGoal.TabIndex = 7;
            this.cmd_manualGoal.Text = "Enter goal state manually";
            this.cmd_manualGoal.UseVisualStyleBackColor = true;
            this.cmd_manualGoal.Click += new System.EventHandler(this.cmd_manualGoal_Click);
            // 
            // radio_24
            // 
            this.radio_24.AutoSize = true;
            this.radio_24.Location = new System.Drawing.Point(9, 76);
            this.radio_24.Name = "radio_24";
            this.radio_24.Size = new System.Drawing.Size(71, 17);
            this.radio_24.TabIndex = 6;
            this.radio_24.TabStop = true;
            this.radio_24.Text = "24 Puzzle";
            this.radio_24.UseVisualStyleBackColor = true;
            // 
            // radio_3
            // 
            this.radio_3.AutoSize = true;
            this.radio_3.Location = new System.Drawing.Point(9, 17);
            this.radio_3.Name = "radio_3";
            this.radio_3.Size = new System.Drawing.Size(65, 17);
            this.radio_3.TabIndex = 5;
            this.radio_3.TabStop = true;
            this.radio_3.Text = "3 Puzzle";
            this.radio_3.UseVisualStyleBackColor = true;
            // 
            // g_move
            // 
            this.g_move.Controls.Add(this.cmd_right);
            this.g_move.Controls.Add(this.cmd_up);
            this.g_move.Controls.Add(this.cmd_left);
            this.g_move.Controls.Add(this.cmd_down);
            this.g_move.Enabled = false;
            this.g_move.Location = new System.Drawing.Point(684, 196);
            this.g_move.Name = "g_move";
            this.g_move.Size = new System.Drawing.Size(200, 100);
            this.g_move.TabIndex = 12;
            this.g_move.TabStop = false;
            this.g_move.Text = "Navigation";
            // 
            // txt_steps
            // 
            this.txt_steps.Location = new System.Drawing.Point(55, 83);
            this.txt_steps.Name = "txt_steps";
            this.txt_steps.ReadOnly = true;
            this.txt_steps.Size = new System.Drawing.Size(74, 20);
            this.txt_steps.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Steps :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nodes #:";
            // 
            // txt_nodes
            // 
            this.txt_nodes.Location = new System.Drawing.Point(193, 83);
            this.txt_nodes.Name = "txt_nodes";
            this.txt_nodes.ReadOnly = true;
            this.txt_nodes.Size = new System.Drawing.Size(74, 20);
            this.txt_nodes.TabIndex = 16;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(389, 288);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(292, 196);
            this.listBox1.TabIndex = 3;
            // 
            // cmd_GetSoloution
            // 
            this.cmd_GetSoloution.Location = new System.Drawing.Point(305, 80);
            this.cmd_GetSoloution.Name = "cmd_GetSoloution";
            this.cmd_GetSoloution.Size = new System.Drawing.Size(75, 23);
            this.cmd_GetSoloution.TabIndex = 17;
            this.cmd_GetSoloution.Text = "Solution tree";
            this.cmd_GetSoloution.UseVisualStyleBackColor = true;
            this.cmd_GetSoloution.Click += new System.EventHandler(this.cmd_GetSoloution_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 497);
            this.Controls.Add(this.cmd_GetSoloution);
            this.Controls.Add(this.txt_nodes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_steps);
            this.Controls.Add(this.g_move);
            this.Controls.Add(this.g_puzzle);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.g_solve);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Puzzle game By: Omar Alnyme";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.g_solve.ResumeLayout(false);
            this.g_solve.PerformLayout();
            this.g_puzzle.ResumeLayout(false);
            this.g_puzzle.PerformLayout();
            this.g_move.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_start;
        private System.Windows.Forms.RadioButton radio_8;
        private System.Windows.Forms.RadioButton radio_15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmd_reshuffle;
        private System.Windows.Forms.Button cmd_right;
        private System.Windows.Forms.Button cmd_up;
        private System.Windows.Forms.Button cmd_down;
        private System.Windows.Forms.Button cmd_left;
        private System.Windows.Forms.GroupBox g_solve;
        private System.Windows.Forms.Button cmd_restart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.RadioButton radio_bfs;
        private System.Windows.Forms.RadioButton radio_dfs;
        private System.Windows.Forms.ComboBox combo_maxdepth;
        private System.Windows.Forms.GroupBox g_puzzle;
        private System.Windows.Forms.GroupBox g_move;
        private System.Windows.Forms.TextBox txt_steps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nodes;
        private System.Windows.Forms.RadioButton radio_24;
        private System.Windows.Forms.RadioButton radio_3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RadioButton radio_bestfs;
        private System.Windows.Forms.Button cmd_manualGoal;
        private System.Windows.Forms.Button cmd_ManualState;
        private System.Windows.Forms.Button cmd_GetSoloution;
        private System.Windows.Forms.Timer timer1;
    }
}


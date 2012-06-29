namespace GameOfLife {
	partial class SettingsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.highLifeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mayanMazeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkBorn9 = new System.Windows.Forms.CheckBox();
			this.chkBorn8 = new System.Windows.Forms.CheckBox();
			this.chkBorn7 = new System.Windows.Forms.CheckBox();
			this.chkBorn6 = new System.Windows.Forms.CheckBox();
			this.chkBorn5 = new System.Windows.Forms.CheckBox();
			this.chkBorn4 = new System.Windows.Forms.CheckBox();
			this.chkBorn3 = new System.Windows.Forms.CheckBox();
			this.chkBorn2 = new System.Windows.Forms.CheckBox();
			this.chkBorn1 = new System.Windows.Forms.CheckBox();
			this.chkBorn0 = new System.Windows.Forms.CheckBox();
			this.chkAltMode = new System.Windows.Forms.CheckBox();
			this.numTick = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numSimLimit = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkLive9 = new System.Windows.Forms.CheckBox();
			this.chkLive8 = new System.Windows.Forms.CheckBox();
			this.chkLive7 = new System.Windows.Forms.CheckBox();
			this.chkLive6 = new System.Windows.Forms.CheckBox();
			this.chkLive5 = new System.Windows.Forms.CheckBox();
			this.chkLive4 = new System.Windows.Forms.CheckBox();
			this.chkLive3 = new System.Windows.Forms.CheckBox();
			this.chkLive2 = new System.Windows.Forms.CheckBox();
			this.chkLive1 = new System.Windows.Forms.CheckBox();
			this.chkLive0 = new System.Windows.Forms.CheckBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.chkClockApply = new System.Windows.Forms.CheckBox();
			this.chkClockEnable = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.boxPixelSize = new System.Windows.Forms.ComboBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnOk = new System.Windows.Forms.Button();
			this.dayNightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lifeWithoutDeathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.seedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuStrip1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTick)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSimLimit)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presetsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(425, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// presetsToolStripMenuItem
			// 
			this.presetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.toolStripSeparator2,
            this.highLifeToolStripMenuItem,
            this.dayNightToolStripMenuItem,
            this.lifeWithoutDeathToolStripMenuItem,
            this.seedsToolStripMenuItem,
            this.toolStripSeparator1,
            this.mayanMazeToolStripMenuItem});
			this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
			this.presetsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
			this.presetsToolStripMenuItem.Text = "Apply Presets";
			// 
			// standardToolStripMenuItem
			// 
			this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
			this.standardToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.standardToolStripMenuItem.Text = "Standard Game of Life";
			this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
			// 
			// highLifeToolStripMenuItem
			// 
			this.highLifeToolStripMenuItem.Name = "highLifeToolStripMenuItem";
			this.highLifeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.highLifeToolStripMenuItem.Text = "HighLife";
			this.highLifeToolStripMenuItem.Click += new System.EventHandler(this.highLifeToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
			// 
			// mayanMazeToolStripMenuItem
			// 
			this.mayanMazeToolStripMenuItem.Name = "mayanMazeToolStripMenuItem";
			this.mayanMazeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.mayanMazeToolStripMenuItem.Text = "Mayan Maze";
			this.mayanMazeToolStripMenuItem.Click += new System.EventHandler(this.mayanMazeToolStripMenuItem_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkBorn9);
			this.groupBox3.Controls.Add(this.chkBorn8);
			this.groupBox3.Controls.Add(this.chkBorn7);
			this.groupBox3.Controls.Add(this.chkBorn6);
			this.groupBox3.Controls.Add(this.chkBorn5);
			this.groupBox3.Controls.Add(this.chkBorn4);
			this.groupBox3.Controls.Add(this.chkBorn3);
			this.groupBox3.Controls.Add(this.chkBorn2);
			this.groupBox3.Controls.Add(this.chkBorn1);
			this.groupBox3.Controls.Add(this.chkBorn0);
			this.groupBox3.Location = new System.Drawing.Point(12, 165);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(395, 46);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Cells Born when N cells are Alive around it";
			// 
			// chkBorn9
			// 
			this.chkBorn9.AutoSize = true;
			this.chkBorn9.Location = new System.Drawing.Point(353, 19);
			this.chkBorn9.Name = "chkBorn9";
			this.chkBorn9.Size = new System.Drawing.Size(32, 17);
			this.chkBorn9.TabIndex = 9;
			this.chkBorn9.Text = "9";
			this.chkBorn9.UseVisualStyleBackColor = true;
			// 
			// chkBorn8
			// 
			this.chkBorn8.AutoSize = true;
			this.chkBorn8.Location = new System.Drawing.Point(315, 19);
			this.chkBorn8.Name = "chkBorn8";
			this.chkBorn8.Size = new System.Drawing.Size(32, 17);
			this.chkBorn8.TabIndex = 8;
			this.chkBorn8.Text = "8";
			this.chkBorn8.UseVisualStyleBackColor = true;
			// 
			// chkBorn7
			// 
			this.chkBorn7.AutoSize = true;
			this.chkBorn7.Location = new System.Drawing.Point(277, 19);
			this.chkBorn7.Name = "chkBorn7";
			this.chkBorn7.Size = new System.Drawing.Size(32, 17);
			this.chkBorn7.TabIndex = 7;
			this.chkBorn7.Text = "7";
			this.chkBorn7.UseVisualStyleBackColor = true;
			// 
			// chkBorn6
			// 
			this.chkBorn6.AutoSize = true;
			this.chkBorn6.Location = new System.Drawing.Point(239, 19);
			this.chkBorn6.Name = "chkBorn6";
			this.chkBorn6.Size = new System.Drawing.Size(32, 17);
			this.chkBorn6.TabIndex = 6;
			this.chkBorn6.Text = "6";
			this.chkBorn6.UseVisualStyleBackColor = true;
			// 
			// chkBorn5
			// 
			this.chkBorn5.AutoSize = true;
			this.chkBorn5.Location = new System.Drawing.Point(201, 19);
			this.chkBorn5.Name = "chkBorn5";
			this.chkBorn5.Size = new System.Drawing.Size(32, 17);
			this.chkBorn5.TabIndex = 5;
			this.chkBorn5.Text = "5";
			this.chkBorn5.UseVisualStyleBackColor = true;
			// 
			// chkBorn4
			// 
			this.chkBorn4.AutoSize = true;
			this.chkBorn4.Location = new System.Drawing.Point(163, 19);
			this.chkBorn4.Name = "chkBorn4";
			this.chkBorn4.Size = new System.Drawing.Size(32, 17);
			this.chkBorn4.TabIndex = 4;
			this.chkBorn4.Text = "4";
			this.chkBorn4.UseVisualStyleBackColor = true;
			// 
			// chkBorn3
			// 
			this.chkBorn3.AutoSize = true;
			this.chkBorn3.Location = new System.Drawing.Point(125, 19);
			this.chkBorn3.Name = "chkBorn3";
			this.chkBorn3.Size = new System.Drawing.Size(32, 17);
			this.chkBorn3.TabIndex = 3;
			this.chkBorn3.Text = "3";
			this.chkBorn3.UseVisualStyleBackColor = true;
			// 
			// chkBorn2
			// 
			this.chkBorn2.AutoSize = true;
			this.chkBorn2.Location = new System.Drawing.Point(87, 19);
			this.chkBorn2.Name = "chkBorn2";
			this.chkBorn2.Size = new System.Drawing.Size(32, 17);
			this.chkBorn2.TabIndex = 2;
			this.chkBorn2.Text = "2";
			this.chkBorn2.UseVisualStyleBackColor = true;
			// 
			// chkBorn1
			// 
			this.chkBorn1.AutoSize = true;
			this.chkBorn1.Location = new System.Drawing.Point(49, 19);
			this.chkBorn1.Name = "chkBorn1";
			this.chkBorn1.Size = new System.Drawing.Size(32, 17);
			this.chkBorn1.TabIndex = 1;
			this.chkBorn1.Text = "1";
			this.chkBorn1.UseVisualStyleBackColor = true;
			// 
			// chkBorn0
			// 
			this.chkBorn0.AutoSize = true;
			this.chkBorn0.Location = new System.Drawing.Point(11, 19);
			this.chkBorn0.Name = "chkBorn0";
			this.chkBorn0.Size = new System.Drawing.Size(32, 17);
			this.chkBorn0.TabIndex = 0;
			this.chkBorn0.Text = "0";
			this.chkBorn0.UseVisualStyleBackColor = true;
			// 
			// chkAltMode
			// 
			this.chkAltMode.AutoSize = true;
			this.chkAltMode.Location = new System.Drawing.Point(259, 49);
			this.chkAltMode.Name = "chkAltMode";
			this.chkAltMode.Size = new System.Drawing.Size(148, 17);
			this.chkAltMode.TabIndex = 3;
			this.chkAltMode.Text = "Enable Single Array Mode";
			this.chkAltMode.UseVisualStyleBackColor = true;
			// 
			// numTick
			// 
			this.numTick.Location = new System.Drawing.Point(342, 11);
			this.numTick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numTick.Name = "numTick";
			this.numTick.Size = new System.Drawing.Size(65, 20);
			this.numTick.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(249, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tick Speed (ms):";
			// 
			// numSimLimit
			// 
			this.numSimLimit.Location = new System.Drawing.Point(128, 11);
			this.numSimLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numSimLimit.Name = "numSimLimit";
			this.numSimLimit.Size = new System.Drawing.Size(87, 20);
			this.numSimLimit.TabIndex = 1;
			this.numSimLimit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Simulation Limit (ticks):";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkLive9);
			this.groupBox4.Controls.Add(this.chkLive8);
			this.groupBox4.Controls.Add(this.chkLive7);
			this.groupBox4.Controls.Add(this.chkLive6);
			this.groupBox4.Controls.Add(this.chkLive5);
			this.groupBox4.Controls.Add(this.chkLive4);
			this.groupBox4.Controls.Add(this.chkLive3);
			this.groupBox4.Controls.Add(this.chkLive2);
			this.groupBox4.Controls.Add(this.chkLive1);
			this.groupBox4.Controls.Add(this.chkLive0);
			this.groupBox4.Location = new System.Drawing.Point(12, 217);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(395, 46);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Cells Live when N cells are Alive around it";
			// 
			// chkLive9
			// 
			this.chkLive9.AutoSize = true;
			this.chkLive9.Location = new System.Drawing.Point(353, 19);
			this.chkLive9.Name = "chkLive9";
			this.chkLive9.Size = new System.Drawing.Size(32, 17);
			this.chkLive9.TabIndex = 9;
			this.chkLive9.Text = "9";
			this.chkLive9.UseVisualStyleBackColor = true;
			// 
			// chkLive8
			// 
			this.chkLive8.AutoSize = true;
			this.chkLive8.Location = new System.Drawing.Point(315, 19);
			this.chkLive8.Name = "chkLive8";
			this.chkLive8.Size = new System.Drawing.Size(32, 17);
			this.chkLive8.TabIndex = 8;
			this.chkLive8.Text = "8";
			this.chkLive8.UseVisualStyleBackColor = true;
			// 
			// chkLive7
			// 
			this.chkLive7.AutoSize = true;
			this.chkLive7.Location = new System.Drawing.Point(277, 19);
			this.chkLive7.Name = "chkLive7";
			this.chkLive7.Size = new System.Drawing.Size(32, 17);
			this.chkLive7.TabIndex = 7;
			this.chkLive7.Text = "7";
			this.chkLive7.UseVisualStyleBackColor = true;
			// 
			// chkLive6
			// 
			this.chkLive6.AutoSize = true;
			this.chkLive6.Location = new System.Drawing.Point(239, 19);
			this.chkLive6.Name = "chkLive6";
			this.chkLive6.Size = new System.Drawing.Size(32, 17);
			this.chkLive6.TabIndex = 6;
			this.chkLive6.Text = "6";
			this.chkLive6.UseVisualStyleBackColor = true;
			// 
			// chkLive5
			// 
			this.chkLive5.AutoSize = true;
			this.chkLive5.Location = new System.Drawing.Point(201, 19);
			this.chkLive5.Name = "chkLive5";
			this.chkLive5.Size = new System.Drawing.Size(32, 17);
			this.chkLive5.TabIndex = 5;
			this.chkLive5.Text = "5";
			this.chkLive5.UseVisualStyleBackColor = true;
			// 
			// chkLive4
			// 
			this.chkLive4.AutoSize = true;
			this.chkLive4.Location = new System.Drawing.Point(163, 19);
			this.chkLive4.Name = "chkLive4";
			this.chkLive4.Size = new System.Drawing.Size(32, 17);
			this.chkLive4.TabIndex = 4;
			this.chkLive4.Text = "4";
			this.chkLive4.UseVisualStyleBackColor = true;
			// 
			// chkLive3
			// 
			this.chkLive3.AutoSize = true;
			this.chkLive3.Location = new System.Drawing.Point(125, 19);
			this.chkLive3.Name = "chkLive3";
			this.chkLive3.Size = new System.Drawing.Size(32, 17);
			this.chkLive3.TabIndex = 3;
			this.chkLive3.Text = "3";
			this.chkLive3.UseVisualStyleBackColor = true;
			// 
			// chkLive2
			// 
			this.chkLive2.AutoSize = true;
			this.chkLive2.Location = new System.Drawing.Point(87, 19);
			this.chkLive2.Name = "chkLive2";
			this.chkLive2.Size = new System.Drawing.Size(32, 17);
			this.chkLive2.TabIndex = 2;
			this.chkLive2.Text = "2";
			this.chkLive2.UseVisualStyleBackColor = true;
			// 
			// chkLive1
			// 
			this.chkLive1.AutoSize = true;
			this.chkLive1.Location = new System.Drawing.Point(49, 19);
			this.chkLive1.Name = "chkLive1";
			this.chkLive1.Size = new System.Drawing.Size(32, 17);
			this.chkLive1.TabIndex = 1;
			this.chkLive1.Text = "1";
			this.chkLive1.UseVisualStyleBackColor = true;
			// 
			// chkLive0
			// 
			this.chkLive0.AutoSize = true;
			this.chkLive0.Location = new System.Drawing.Point(11, 19);
			this.chkLive0.Name = "chkLive0";
			this.chkLive0.Size = new System.Drawing.Size(32, 17);
			this.chkLive0.TabIndex = 0;
			this.chkLive0.Text = "0";
			this.chkLive0.UseVisualStyleBackColor = true;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Location = new System.Drawing.Point(3, 3);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(419, 351);
			this.tabControl.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.chkAltMode);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.numTick);
			this.tabPage1.Controls.Add(this.numSimLimit);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(411, 325);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Simulation";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(411, 325);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Display";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.chkClockApply);
			this.groupBox5.Controls.Add(this.chkClockEnable);
			this.groupBox5.Location = new System.Drawing.Point(192, 13);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(217, 79);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Clock Display";
			// 
			// chkClockApply
			// 
			this.chkClockApply.AutoSize = true;
			this.chkClockApply.Location = new System.Drawing.Point(6, 42);
			this.chkClockApply.Name = "chkClockApply";
			this.chkClockApply.Size = new System.Drawing.Size(114, 17);
			this.chkClockApply.TabIndex = 1;
			this.chkClockApply.Text = "Apply Clock to Sim";
			this.chkClockApply.UseVisualStyleBackColor = true;
			// 
			// chkClockEnable
			// 
			this.chkClockEnable.AutoSize = true;
			this.chkClockEnable.Location = new System.Drawing.Point(7, 19);
			this.chkClockEnable.Name = "chkClockEnable";
			this.chkClockEnable.Size = new System.Drawing.Size(90, 17);
			this.chkClockEnable.TabIndex = 0;
			this.chkClockEnable.Text = "Display Clock";
			this.chkClockEnable.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.boxPixelSize);
			this.groupBox2.Location = new System.Drawing.Point(8, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(178, 112);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sim Display";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Cell Color:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cell Size:";
			// 
			// boxPixelSize
			// 
			this.boxPixelSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.boxPixelSize.FormatString = "N0";
			this.boxPixelSize.FormattingEnabled = true;
			this.boxPixelSize.Items.AddRange(new object[] {
            "6",
            "12",
            "18",
            "24"});
			this.boxPixelSize.Location = new System.Drawing.Point(111, 24);
			this.boxPixelSize.Name = "boxPixelSize";
			this.boxPixelSize.Size = new System.Drawing.Size(57, 21);
			this.boxPixelSize.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.comboBox2);
			this.tabPage3.Controls.Add(this.comboBox1);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(411, 325);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Control Keys";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Center",
            "Random"});
			this.comboBox2.Location = new System.Drawing.Point(298, 12);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(111, 21);
			this.comboBox2.TabIndex = 2;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "<None>",
            "TODO insert items"});
			this.comboBox1.Location = new System.Drawing.Point(58, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(234, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "#1 Key:";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 396);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(347, 363);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 30);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// dayNightToolStripMenuItem
			// 
			this.dayNightToolStripMenuItem.Name = "dayNightToolStripMenuItem";
			this.dayNightToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.dayNightToolStripMenuItem.Text = "Day && Night";
			this.dayNightToolStripMenuItem.Click += new System.EventHandler(this.dayNightToolStripMenuItem_Click);
			// 
			// lifeWithoutDeathToolStripMenuItem
			// 
			this.lifeWithoutDeathToolStripMenuItem.Name = "lifeWithoutDeathToolStripMenuItem";
			this.lifeWithoutDeathToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.lifeWithoutDeathToolStripMenuItem.Text = "Life without Death";
			this.lifeWithoutDeathToolStripMenuItem.Click += new System.EventHandler(this.lifeWithoutDeathToolStripMenuItem_Click);
			// 
			// seedsToolStripMenuItem
			// 
			this.seedsToolStripMenuItem.Name = "seedsToolStripMenuItem";
			this.seedsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.seedsToolStripMenuItem.Text = "Seeds";
			this.seedsToolStripMenuItem.Click += new System.EventHandler(this.seedsToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 420);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "SettingsForm";
			this.Text = "Conway\'s Game of Life Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTick)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSimLimit)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mayanMazeToolStripMenuItem;
		private System.Windows.Forms.NumericUpDown numSimLimit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numTick;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkBorn9;
		private System.Windows.Forms.CheckBox chkBorn8;
		private System.Windows.Forms.CheckBox chkBorn7;
		private System.Windows.Forms.CheckBox chkBorn6;
		private System.Windows.Forms.CheckBox chkBorn5;
		private System.Windows.Forms.CheckBox chkBorn4;
		private System.Windows.Forms.CheckBox chkBorn3;
		private System.Windows.Forms.CheckBox chkBorn2;
		private System.Windows.Forms.CheckBox chkBorn1;
		private System.Windows.Forms.CheckBox chkBorn0;
		private System.Windows.Forms.CheckBox chkAltMode;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox chkLive9;
		private System.Windows.Forms.CheckBox chkLive8;
		private System.Windows.Forms.CheckBox chkLive7;
		private System.Windows.Forms.CheckBox chkLive6;
		private System.Windows.Forms.CheckBox chkLive5;
		private System.Windows.Forms.CheckBox chkLive4;
		private System.Windows.Forms.CheckBox chkLive3;
		private System.Windows.Forms.CheckBox chkLive2;
		private System.Windows.Forms.CheckBox chkLive1;
		private System.Windows.Forms.CheckBox chkLive0;
		private System.Windows.Forms.ToolStripMenuItem highLifeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox chkClockApply;
		private System.Windows.Forms.CheckBox chkClockEnable;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox boxPixelSize;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ToolStripMenuItem dayNightToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lifeWithoutDeathToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem seedsToolStripMenuItem;
	}
}
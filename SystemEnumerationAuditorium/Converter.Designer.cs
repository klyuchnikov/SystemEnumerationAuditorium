namespace SystemEnumerationAuditorium
{
	partial class Converter
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
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
		private void InitializeComponent()
		{
      this.button1 = new System.Windows.Forms.Button();
      this.openFileGroup = new System.Windows.Forms.OpenFileDialog();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.Period = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.list = new System.Windows.Forms.ListBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.Fidelity = new System.Windows.Forms.TextBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.Edu = new System.Windows.Forms.ComboBox();
      this.openFileFidelity = new System.Windows.Forms.OpenFileDialog();
      this.button3 = new System.Windows.Forms.Button();
      this.statusStrip1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.AutoSize = true;
      this.button1.Dock = System.Windows.Forms.DockStyle.Top;
      this.button1.Location = new System.Drawing.Point(3, 16);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(230, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Выбрать файлы для импорта расписания";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // openFileGroup
      // 
      this.openFileGroup.Filter = "HTML  файлы|*.htm";
      this.openFileGroup.Multiselect = true;
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.AutoSize = false;
      this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
      this.toolStripStatusLabel1.Text = "0 из 0";
      // 
      // toolStripProgressBar1
      // 
      this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripProgressBar1.Maximum = 96;
      this.toolStripProgressBar1.Name = "toolStripProgressBar1";
      this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
      this.toolStripProgressBar1.Step = 2;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 198);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(492, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.AutoSize = false;
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(185, 17);
      // 
      // Period
      // 
      this.Period.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Period.FormattingEnabled = true;
      this.Period.Items.AddRange(new object[] {
            "1 Полупериод",
            "2 Полупериод"});
      this.Period.Location = new System.Drawing.Point(3, 16);
      this.Period.Name = "Period";
      this.Period.Size = new System.Drawing.Size(230, 21);
      this.Period.TabIndex = 3;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.list);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Location = new System.Drawing.Point(9, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(236, 157);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Выберите файлы для импорта";
      // 
      // list
      // 
      this.list.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.list.FormattingEnabled = true;
      this.list.Location = new System.Drawing.Point(3, 46);
      this.list.Name = "list";
      this.list.Size = new System.Drawing.Size(230, 108);
      this.list.TabIndex = 1;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.Period);
      this.groupBox2.Location = new System.Drawing.Point(248, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(236, 41);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Выберите период";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.button2);
      this.groupBox3.Controls.Add(this.Fidelity);
      this.groupBox3.Location = new System.Drawing.Point(248, 59);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(236, 63);
      this.groupBox3.TabIndex = 7;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Выберите файл соответствия групп и факультетов";
      // 
      // button2
      // 
      this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.button2.Location = new System.Drawing.Point(3, 37);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(230, 23);
      this.button2.TabIndex = 1;
      this.button2.Text = "Выберите файл";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Fidelity
      // 
      this.Fidelity.Dock = System.Windows.Forms.DockStyle.Top;
      this.Fidelity.Location = new System.Drawing.Point(3, 16);
      this.Fidelity.Name = "Fidelity";
      this.Fidelity.ReadOnly = true;
      this.Fidelity.Size = new System.Drawing.Size(230, 20);
      this.Fidelity.TabIndex = 0;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.Edu);
      this.groupBox4.Location = new System.Drawing.Point(251, 128);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(233, 41);
      this.groupBox4.TabIndex = 8;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Выберите форму обучения для добавляемых групп";
      // 
      // Edu
      // 
      this.Edu.Dock = System.Windows.Forms.DockStyle.Top;
      this.Edu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Edu.FormattingEnabled = true;
      this.Edu.Location = new System.Drawing.Point(3, 16);
      this.Edu.Name = "Edu";
      this.Edu.Size = new System.Drawing.Size(227, 21);
      this.Edu.TabIndex = 0;
      // 
      // openFileFidelity
      // 
      this.openFileFidelity.Filter = "CSV файл|*.csv";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(190, 172);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(112, 23);
      this.button3.TabIndex = 9;
      this.button3.Text = "Начать";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // Converter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 220);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.statusStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "Converter";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Converter";
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileGroup;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ComboBox Period;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox list;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox Fidelity;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox Edu;
		private System.Windows.Forms.OpenFileDialog openFileFidelity;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
	}
}
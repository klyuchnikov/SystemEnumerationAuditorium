namespace SystemEnumerationAuditorium
{
	sealed partial class AddParaAuditorium
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Disp = new System.Windows.Forms.ComboBox();
			this.Teacher = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.List = new System.Windows.Forms.CheckedListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Curs = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.Faculty = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Disp
			// 
			this.Disp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Disp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Disp.FormattingEnabled = true;
			this.Disp.Location = new System.Drawing.Point(3, 16);
			this.Disp.Name = "Disp";
			this.Disp.Size = new System.Drawing.Size(195, 21);
			this.Disp.Sorted = true;
			this.Disp.TabIndex = 0;
			// 
			// Teacher
			// 
			this.Teacher.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Teacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Teacher.FormattingEnabled = true;
			this.Teacher.Location = new System.Drawing.Point(3, 16);
			this.Teacher.Name = "Teacher";
			this.Teacher.Size = new System.Drawing.Size(195, 21);
			this.Teacher.Sorted = true;
			this.Teacher.TabIndex = 1;
			this.Teacher.SelectedIndexChanged += new System.EventHandler(this.Teacher_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(15, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(195, 36);
			this.button1.TabIndex = 6;
			this.button1.Text = "Добавить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.List);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.Curs);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.Faculty);
			this.groupBox2.Location = new System.Drawing.Point(219, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 197);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Выберите группу";
			// 
			// List
			// 
			this.List.CheckOnClick = true;
			this.List.Enabled = false;
			this.List.FormattingEnabled = true;
			this.List.Location = new System.Drawing.Point(2, 113);
			this.List.Name = "List";
			this.List.Size = new System.Drawing.Size(195, 79);
			this.List.Sorted = true;
			this.List.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(53, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Выберите группу";
			// 
			// Curs
			// 
			this.Curs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Curs.Enabled = false;
			this.Curs.FormattingEnabled = true;
			this.Curs.Items.AddRange(new object[] {
            "1 Курс",
            "2 Курс",
            "3 Курс",
            "4 Курс",
            "5 Курс",
            "6 Курс"});
			this.Curs.Location = new System.Drawing.Point(2, 73);
			this.Curs.Name = "Curs";
			this.Curs.Size = new System.Drawing.Size(195, 21);
			this.Curs.Sorted = true;
			this.Curs.TabIndex = 3;
			this.Curs.SelectedIndexChanged += new System.EventHandler(this.Curs_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(58, 57);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Выберите курс";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(43, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Выберите факультет";
			// 
			// Faculty
			// 
			this.Faculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Faculty.FormattingEnabled = true;
			this.Faculty.Location = new System.Drawing.Point(2, 33);
			this.Faculty.Name = "Faculty";
			this.Faculty.Size = new System.Drawing.Size(195, 21);
			this.Faculty.Sorted = true;
			this.Faculty.TabIndex = 0;
			this.Faculty.SelectedIndexChanged += new System.EventHandler(this.Faculty_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Teacher);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(201, 45);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите Преподавателя";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Disp);
			this.groupBox3.Enabled = false;
			this.groupBox3.Location = new System.Drawing.Point(12, 63);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(201, 43);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Выберите Дисциплину";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(15, 210);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(200, 17);
			this.checkBox2.TabIndex = 0;
			this.checkBox2.Text = "Добавить и на второй полупериод";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// AddParaAuditorium
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 233);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddParaAuditorium";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddPara_KeyDown);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox Disp;
		private System.Windows.Forms.ComboBox Teacher;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckedListBox List;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox Curs;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox Faculty;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}
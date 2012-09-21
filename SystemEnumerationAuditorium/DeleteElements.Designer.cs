namespace SystemEnumerationAuditorium
{
	partial class DeleteElements
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
			this.Fac = new System.Windows.Forms.CheckBox();
			this.Aud = new System.Windows.Forms.CheckBox();
			this.Disp = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.Edu = new System.Windows.Forms.CheckBox();
			this.Teacher = new System.Windows.Forms.CheckBox();
			this.Loc = new System.Windows.Forms.CheckBox();
			this.Group = new System.Windows.Forms.CheckBox();
			this.Abridment = new System.Windows.Forms.CheckBox();
			this.ScheduleException = new System.Windows.Forms.CheckBox();
			this.Schedule = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Fac
			// 
			this.Fac.AutoSize = true;
			this.Fac.Location = new System.Drawing.Point(6, 19);
			this.Fac.Name = "Fac";
			this.Fac.Size = new System.Drawing.Size(90, 17);
			this.Fac.TabIndex = 0;
			this.Fac.Text = "Факультеты";
			this.Fac.UseVisualStyleBackColor = true;
			this.Fac.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Aud
			// 
			this.Aud.AutoSize = true;
			this.Aud.Location = new System.Drawing.Point(22, 135);
			this.Aud.Name = "Aud";
			this.Aud.Size = new System.Drawing.Size(79, 17);
			this.Aud.TabIndex = 1;
			this.Aud.Text = "Аудитории";
			this.Aud.UseVisualStyleBackColor = true;
			this.Aud.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Disp
			// 
			this.Disp.AutoSize = true;
			this.Disp.Location = new System.Drawing.Point(22, 89);
			this.Disp.Name = "Disp";
			this.Disp.Size = new System.Drawing.Size(91, 17);
			this.Disp.TabIndex = 1;
			this.Disp.Text = "Дисциплины";
			this.Disp.UseVisualStyleBackColor = true;
			this.Disp.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.Fac);
			this.groupBox1.Controls.Add(this.Edu);
			this.groupBox1.Controls.Add(this.Teacher);
			this.groupBox1.Controls.Add(this.Loc);
			this.groupBox1.Controls.Add(this.Aud);
			this.groupBox1.Controls.Add(this.Disp);
			this.groupBox1.Controls.Add(this.Group);
			this.groupBox1.Controls.Add(this.Abridment);
			this.groupBox1.Controls.Add(this.ScheduleException);
			this.groupBox1.Controls.Add(this.Schedule);
			this.groupBox1.Location = new System.Drawing.Point(9, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(321, 158);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите элементы для удаления";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(138, 112);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(96, 17);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Выделить все";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// Edu
			// 
			this.Edu.AutoSize = true;
			this.Edu.Location = new System.Drawing.Point(138, 19);
			this.Edu.Name = "Edu";
			this.Edu.Size = new System.Drawing.Size(114, 17);
			this.Edu.TabIndex = 1;
			this.Edu.Text = "Формы обучения";
			this.Edu.UseVisualStyleBackColor = true;
			this.Edu.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Teacher
			// 
			this.Teacher.AutoSize = true;
			this.Teacher.Location = new System.Drawing.Point(6, 65);
			this.Teacher.Name = "Teacher";
			this.Teacher.Size = new System.Drawing.Size(105, 17);
			this.Teacher.TabIndex = 0;
			this.Teacher.Text = "Преподаватели";
			this.Teacher.UseVisualStyleBackColor = true;
			this.Teacher.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Loc
			// 
			this.Loc.AutoSize = true;
			this.Loc.Location = new System.Drawing.Point(6, 112);
			this.Loc.Name = "Loc";
			this.Loc.Size = new System.Drawing.Size(68, 17);
			this.Loc.TabIndex = 1;
			this.Loc.Text = "Корпуса";
			this.Loc.UseVisualStyleBackColor = true;
			this.Loc.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Group
			// 
			this.Group.AutoSize = true;
			this.Group.Location = new System.Drawing.Point(22, 42);
			this.Group.Name = "Group";
			this.Group.Size = new System.Drawing.Size(63, 17);
			this.Group.TabIndex = 1;
			this.Group.Text = "Группы";
			this.Group.UseVisualStyleBackColor = true;
			this.Group.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Abridment
			// 
			this.Abridment.AutoSize = true;
			this.Abridment.Location = new System.Drawing.Point(138, 89);
			this.Abridment.Name = "Abridment";
			this.Abridment.Size = new System.Drawing.Size(90, 17);
			this.Abridment.TabIndex = 1;
			this.Abridment.Text = "Сокращения";
			this.Abridment.UseVisualStyleBackColor = true;
			this.Abridment.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// ScheduleException
			// 
			this.ScheduleException.AutoSize = true;
			this.ScheduleException.Location = new System.Drawing.Point(138, 65);
			this.ScheduleException.Name = "ScheduleException";
			this.ScheduleException.Size = new System.Drawing.Size(176, 17);
			this.ScheduleException.TabIndex = 1;
			this.ScheduleException.Text = "Индивидуальные расписания";
			this.ScheduleException.UseVisualStyleBackColor = true;
			this.ScheduleException.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Schedule
			// 
			this.Schedule.AutoSize = true;
			this.Schedule.Location = new System.Drawing.Point(138, 42);
			this.Schedule.Name = "Schedule";
			this.Schedule.Size = new System.Drawing.Size(87, 17);
			this.Schedule.TabIndex = 1;
			this.Schedule.Text = "Расписание";
			this.Schedule.UseVisualStyleBackColor = true;
			this.Schedule.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(119, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Удалить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(138, 134);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(96, 17);
			this.radioButton2.TabIndex = 4;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Отменить все";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// DeleteElements
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 204);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "DeleteElements";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Удаление элементов базы";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox Fac;
		private System.Windows.Forms.CheckBox Aud;
		private System.Windows.Forms.CheckBox Disp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox Teacher;
		private System.Windows.Forms.CheckBox Group;
		private System.Windows.Forms.CheckBox Loc;
		private System.Windows.Forms.CheckBox Schedule;
		private System.Windows.Forms.CheckBox Edu;
		private System.Windows.Forms.CheckBox ScheduleException;
		private System.Windows.Forms.CheckBox Abridment;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
	}
}
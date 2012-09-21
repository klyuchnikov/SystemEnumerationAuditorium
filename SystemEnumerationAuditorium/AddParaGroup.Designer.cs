namespace SystemEnumerationAuditorium
{
	partial class AddParaGroup
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
			this.label5 = new System.Windows.Forms.Label();
			this.Location1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Disp = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.Teacher2 = new System.Windows.Forms.ComboBox();
			this.Teacher1 = new System.Windows.Forms.ComboBox();
			this.Aud1 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Location2 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Aud2 = new System.Windows.Forms.ComboBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(115, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(195, 27);
			this.button1.TabIndex = 7;
			this.button1.Text = "Добавить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(49, 133);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(114, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Выберите аудиторию";
			// 
			// Location1
			// 
			this.Location1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Location1.FormattingEnabled = true;
			this.Location1.Location = new System.Drawing.Point(9, 109);
			this.Location1.Name = "Location1";
			this.Location1.Size = new System.Drawing.Size(195, 21);
			this.Location1.Sorted = true;
			this.Location1.TabIndex = 0;
			this.Location1.SelectedIndexChanged += new System.EventHandler(this.Location1_SelectedIndexChanged);
			this.Location1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(59, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Выберите корпус";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(161, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Выберите предмет";
			// 
			// Disp
			// 
			this.Disp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Disp.Enabled = false;
			this.Disp.FormattingEnabled = true;
			this.Disp.Location = new System.Drawing.Point(115, 69);
			this.Disp.Name = "Disp";
			this.Disp.Size = new System.Drawing.Size(195, 21);
			this.Disp.Sorted = true;
			this.Disp.TabIndex = 2;
			this.Disp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(224, 5);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(195, 17);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Поддержка двух преподавателей";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// Teacher2
			// 
			this.Teacher2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Teacher2.Enabled = false;
			this.Teacher2.FormattingEnabled = true;
			this.Teacher2.Location = new System.Drawing.Point(224, 29);
			this.Teacher2.Name = "Teacher2";
			this.Teacher2.Size = new System.Drawing.Size(195, 21);
			this.Teacher2.Sorted = true;
			this.Teacher2.TabIndex = 0;
			this.Teacher2.SelectedIndexChanged += new System.EventHandler(this.Teacher2_SelectedIndexChanged);
			this.Teacher2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// Teacher1
			// 
			this.Teacher1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Teacher1.FormattingEnabled = true;
			this.Teacher1.Location = new System.Drawing.Point(12, 29);
			this.Teacher1.Name = "Teacher1";
			this.Teacher1.Size = new System.Drawing.Size(192, 21);
			this.Teacher1.Sorted = true;
			this.Teacher1.TabIndex = 0;
			this.Teacher1.SelectedIndexChanged += new System.EventHandler(this.Teacher1_SelectedIndexChanged);
			this.Teacher1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// Aud1
			// 
			this.Aud1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Aud1.Enabled = false;
			this.Aud1.FormattingEnabled = true;
			this.Aud1.Location = new System.Drawing.Point(9, 149);
			this.Aud1.Name = "Aud1";
			this.Aud1.Size = new System.Drawing.Size(195, 21);
			this.Aud1.Sorted = true;
			this.Aud1.TabIndex = 3;
			this.Aud1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(137, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Выберите преподавателя";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(274, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Выберите корпус";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Location2
			// 
			this.Location2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Location2.Enabled = false;
			this.Location2.FormattingEnabled = true;
			this.Location2.Location = new System.Drawing.Point(224, 109);
			this.Location2.Name = "Location2";
			this.Location2.Size = new System.Drawing.Size(195, 21);
			this.Location2.Sorted = true;
			this.Location2.TabIndex = 0;
			this.Location2.SelectedIndexChanged += new System.EventHandler(this.Location2_SelectedIndexChanged);
			this.Location2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(264, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Выберите аудиторию";
			// 
			// Aud2
			// 
			this.Aud2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Aud2.Enabled = false;
			this.Aud2.FormattingEnabled = true;
			this.Aud2.Location = new System.Drawing.Point(224, 149);
			this.Aud2.Name = "Aud2";
			this.Aud2.Size = new System.Drawing.Size(195, 21);
			this.Aud2.Sorted = true;
			this.Aud2.TabIndex = 3;
			this.Aud2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(115, 209);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(200, 17);
			this.checkBox2.TabIndex = 12;
			this.checkBox2.Text = "Добавить и на второй полупериод";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// AddParaGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 233);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Aud2);
			this.Controls.Add(this.Aud1);
			this.Controls.Add(this.Disp);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Teacher2);
			this.Controls.Add(this.Teacher1);
			this.Controls.Add(this.Location2);
			this.Controls.Add(this.Location1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddParaGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AddParaGroup";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESC_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox Location1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox Teacher1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox Teacher2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox Disp;
		private System.Windows.Forms.ComboBox Aud1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox Location2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox Aud2;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}
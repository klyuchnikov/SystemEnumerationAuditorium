namespace SystemEnumerationAuditorium
{
	partial class PrintForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.Doc = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Преподаватели",
            "Аудитории",
            "Группы"});
			this.comboBox1.Location = new System.Drawing.Point(3, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(194, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkedListBox1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 196);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите что печатать";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(3, 37);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(194, 154);
			this.checkedListBox1.TabIndex = 2;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(15, 217);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(44, 17);
			this.radioButton1.TabIndex = 3;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Все";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkedListBox2);
			this.groupBox2.Location = new System.Drawing.Point(215, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 196);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Какие периоды";
			// 
			// checkedListBox2
			// 
			this.checkedListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkedListBox2.FormattingEnabled = true;
			this.checkedListBox2.Location = new System.Drawing.Point(3, 16);
			this.checkedListBox2.Name = "checkedListBox2";
			this.checkedListBox2.Size = new System.Drawing.Size(194, 169);
			this.checkedListBox2.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(218, 214);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(194, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Печать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Doc
			// 
			this.Doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Doc_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.Doc;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// pageSetupDialog1
			// 
			this.pageSetupDialog1.Document = this.Doc;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(65, 214);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Настройки принтера";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// PrintForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(428, 247);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "PrintForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Печать Расписания";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Drawing.Printing.PrintDocument Doc;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.CheckedListBox checkedListBox2;

	}
}
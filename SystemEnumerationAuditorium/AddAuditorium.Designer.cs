namespace SystemEnumerationAuditorium
{
	partial class AddAuditorium
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
			this.Add = new System.Windows.Forms.Button();
			this.addText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.capacity = new System.Windows.Forms.NumericUpDown();
			this.comp = new System.Windows.Forms.NumericUpDown();
			this.quality = new System.Windows.Forms.ComboBox();
			this.projector = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.capacity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comp)).BeginInit();
			this.SuspendLayout();
			// 
			// Add
			// 
			this.Add.Location = new System.Drawing.Point(12, 146);
			this.Add.Name = "Add";
			this.Add.Size = new System.Drawing.Size(217, 23);
			this.Add.TabIndex = 0;
			this.Add.Text = "Добавить";
			this.Add.UseVisualStyleBackColor = true;
			this.Add.Click += new System.EventHandler(this.Add_Click);
			// 
			// addText
			// 
			this.addText.Location = new System.Drawing.Point(12, 12);
			this.addText.Name = "addText";
			this.addText.Size = new System.Drawing.Size(217, 20);
			this.addText.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Вместимость";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Наличие компьютеров";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Enabled = false;
			this.label3.Location = new System.Drawing.Point(9, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Качество компьютеров";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Наличие проектора";
			// 
			// capacity
			// 
			this.capacity.Location = new System.Drawing.Point(91, 38);
			this.capacity.Name = "capacity";
			this.capacity.Size = new System.Drawing.Size(138, 20);
			this.capacity.TabIndex = 7;
			// 
			// comp
			// 
			this.comp.Location = new System.Drawing.Point(137, 66);
			this.comp.Name = "comp";
			this.comp.Size = new System.Drawing.Size(92, 20);
			this.comp.TabIndex = 8;
			this.comp.ValueChanged += new System.EventHandler(this.comp_ValueChanged);
			// 
			// quality
			// 
			this.quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.quality.Enabled = false;
			this.quality.FormattingEnabled = true;
			this.quality.Items.AddRange(new object[] {
            "Хорошее",
            "Среднее",
            "Низкое"});
			this.quality.Location = new System.Drawing.Point(137, 92);
			this.quality.Name = "quality";
			this.quality.Size = new System.Drawing.Size(92, 21);
			this.quality.TabIndex = 9;
			// 
			// projector
			// 
			this.projector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.projector.FormattingEnabled = true;
			this.projector.Items.AddRange(new object[] {
            "Есть",
            "Нет"});
			this.projector.Location = new System.Drawing.Point(121, 119);
			this.projector.Name = "projector";
			this.projector.Size = new System.Drawing.Size(108, 21);
			this.projector.TabIndex = 10;
			// 
			// AddAuditorium
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(241, 176);
			this.Controls.Add(this.projector);
			this.Controls.Add(this.quality);
			this.Controls.Add(this.comp);
			this.Controls.Add(this.capacity);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.addText);
			this.Controls.Add(this.Add);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddAuditorium";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Добавить аудиторию";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddAuditorium_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.capacity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Add;
		private System.Windows.Forms.TextBox addText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown capacity;
		private System.Windows.Forms.NumericUpDown comp;
		private System.Windows.Forms.ComboBox quality;
		private System.Windows.Forms.ComboBox projector;
	}
}
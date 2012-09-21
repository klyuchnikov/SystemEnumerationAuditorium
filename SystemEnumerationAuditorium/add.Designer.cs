namespace SystemEnumerationAuditorium
{
	partial class Add
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
			this.addText = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// addText
			// 
			this.addText.Location = new System.Drawing.Point(11, 12);
			this.addText.Name = "addText";
			this.addText.Size = new System.Drawing.Size(217, 20);
			this.addText.TabIndex = 0;
			this.addText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addText_KeyDown);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(10, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(217, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Добавить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Add
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(239, 71);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.addText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Add";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Добавить";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Add_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox addText;
		private System.Windows.Forms.Button button1;
	}
}
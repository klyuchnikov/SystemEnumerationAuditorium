namespace SystemEnumerationAuditorium
{
	partial class Abrid
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.HorizontalScrollbar = true;
      this.listBox1.Location = new System.Drawing.Point(12, 12);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(293, 225);
      this.listBox1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(98, 243);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(121, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Удалить";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Abrid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(317, 274);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.listBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "Abrid";
      this.Text = "Сокращения";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
	}
}
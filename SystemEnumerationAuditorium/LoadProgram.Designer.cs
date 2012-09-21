namespace SystemEnumerationAuditorium
{
	partial class LoadProgram
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
			this.Bar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// Bar
			// 
			this.Bar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Bar.Location = new System.Drawing.Point(0, 0);
			this.Bar.Maximum = 10000;
			this.Bar.Name = "Bar";
			this.Bar.Size = new System.Drawing.Size(264, 27);
			this.Bar.Step = 1;
			this.Bar.TabIndex = 0;
			// 
			// LoadProgram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(264, 27);
			this.Controls.Add(this.Bar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "LoadProgram";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ProgressBar Bar;

	}
}
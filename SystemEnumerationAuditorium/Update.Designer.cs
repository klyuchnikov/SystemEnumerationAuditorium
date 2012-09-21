namespace SystemEnumerationAuditorium
{
	partial class Update
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
			this.progress = new System.Windows.Forms.ProgressBar();
			this.button1 = new System.Windows.Forms.Button();
			this.labelVersion = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(93, 54);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(273, 23);
			this.progress.Step = 1;
			this.progress.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(154, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Проверить обновления";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(172, 30);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(107, 13);
			this.labelVersion.TabIndex = 2;
			this.labelVersion.Text = "Доступная версия: ";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 54);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Обновить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Текущая версия продукта: ";
			// 
			// Update
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 85);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Update";
			this.Text = "Update";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
	}
}
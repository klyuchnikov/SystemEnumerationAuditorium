namespace ConverterBDSQLToXML
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "MDF File|*.mdf";
			this.openFileDialog1.Title = "Выберите файл MDF с базой данных...";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "XML File|*.xml";
			this.saveFileDialog1.Title = "Сохранить файл XML...";
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(246, 35);
			this.button1.TabIndex = 0;
			this.button1.Text = "Выбрать файл MDF";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(246, 35);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converter DataBaseSQL to DataSetXML";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button1;
	}
}


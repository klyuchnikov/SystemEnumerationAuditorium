//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Net;


namespace SystemEnumerationAuditorium
{
	public partial class Update : Form
	{
		private bool IsUpdate;
		private void SaveVersion()
		{
			var write = new StreamWriter("Version.txt");
			write.WriteLine(Assembly.GetAssembly(typeof(TeacherInfo)).GetName().Version);
			var file = new FileStream("SystemEnumerationAuditorium.exe", FileMode.Open, FileAccess.Read, FileShare.Read);
			write.WriteLine(file.Length);
			var fileConf = new FileStream("SystemEnumerationAuditorium.exe.config", FileMode.Open, FileAccess.Read, FileShare.Read);
			write.WriteLine(fileConf.Length);
			write.Close();
		}


		public Update()
		{
			InitializeComponent();
			IsUpdate = false;
			label1.Text += Assembly.GetAssembly(typeof(TeacherInfo)).GetName().Version.ToString();
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progress.Value = e.ProgressPercentage;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!IsUpdate)
			{
				MessageBox.Show("Проверьте доступную версию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			progress.Value = 0;
			var client = new WebClient();
			var temp = Process.GetCurrentProcess();
			temp.Close();
			var t = 0;
			var file = new FileStream("SystemEnumerationAuditorium.exe", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
			var uri = new Uri("http://377407.xost.ru/Setup/SystemEnumerationAuditorium.exe");
			client.DownloadProgressChanged += client_DownloadProgressChanged;
			client.DownloadFileCompleted += client_DownloadFileCompleted;
			client.DownloadFileAsync(uri, "SystemEnumerationAuditorium.ex");
		}

		void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				MessageBox.Show("Загрузка завершена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var uri = new Uri("http://377407.xost.ru/Setup/Version.txt");
			var client = new WebClient();
			client.DownloadFile(uri, "temp.txt");
			var temp = File.ReadAllLines("temp.txt");
			labelVersion.Text += temp[0];
			IsUpdate = true;
			File.Delete("temp.txt");
		}
	}
}

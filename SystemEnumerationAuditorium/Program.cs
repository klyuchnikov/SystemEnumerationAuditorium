using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium {

  static class Program 
	{
		
  	[STAThread]
    static void Main()
  	{
			var curProcessName = Process.GetCurrentProcess().ProcessName;
			var temp = Process.GetProcesses().Where(a => a.ProcessName == curProcessName).ToArray();
			if (temp.Count() != 1)
			{
				MessageBox.Show("Программа уже запущена");
				return;
			}
  		Application.EnableVisualStyles();
  		Application.SetCompatibleTextRenderingDefault(false);
     	Application.Run(new MainForm());
  		Application.ExitThread();
  		Application.Exit();
  	}
	}
}
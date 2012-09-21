using System;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class Abrid : Form
	{
		public Abrid()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listBox1.Items.AddRange(Model.GetAll.Abridgement());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex == -1)
				MessageBox.Show("Вы ничего не выбрали");
			else
			{
				Model.Delete.Abridgement((AbridgementInfo)listBox1.SelectedItem);
				listBox1.Items.Remove(listBox1.SelectedItem);
			}
		}
	}
}

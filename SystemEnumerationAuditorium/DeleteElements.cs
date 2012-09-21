using System;
using System.Linq;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class DeleteElements : Form
	{
		public DeleteElements()
		{
			InitializeComponent();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (!radioButton1.Checked) 
				return;
			var control = groupBox1.Controls.OfType<CheckBox>();
			foreach (var box in control)
				box.Checked = true;
		}

		private void CheckedChanged(object sender, EventArgs e)
		{
			var temp = true;
			var control = groupBox1.Controls.OfType<CheckBox>();
			foreach (var box in control)
				if(!box.Checked)
					temp = false;
			radioButton1.Checked = temp;
			temp = true;
			control = groupBox1.Controls.OfType<CheckBox>();
			foreach (var box in control)
				if (box.Checked)
					temp = false;
			radioButton2.Checked = temp;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show("Вы действительно хотите удалить выбранное?", "Внимание", MessageBoxButtons.YesNo,
				                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
			if (Fac.Checked)
				Model.Delete.All.Faculty();
			if (Group.Checked)
				Model.Delete.All.Group();
			if (Abridment.Checked)
				Model.Delete.All.Abridgement();
			if (Aud.Checked)
				Model.Delete.All.Auditorium();
			if (Disp.Checked)
				Model.Delete.All.Discipline();
			if (Edu.Checked)
				Model.Delete.All.Education();
			if (Loc.Checked)
				Model.Delete.All.Location();
			if (Schedule.Checked)
				Model.Delete.All.Schedule();
			if (ScheduleException.Checked)
				Model.Delete.All.ScheduleException();
			if (Teacher.Checked)
				Model.Delete.All.Teacher();
			Close();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (!radioButton2.Checked)
				return;
			var control = groupBox1.Controls.OfType<CheckBox>();
			foreach (var box in control)
				box.Checked = false;
		}
	}
}
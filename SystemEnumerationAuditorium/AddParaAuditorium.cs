using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public sealed partial class AddParaAuditorium : Form
	{
		public List<ScheduleInfo> Sched;
		private readonly int DayWeek;
		private readonly int Para;
		private readonly int IDPeriod;
		private readonly int IDAud;
		public AddParaAuditorium(AuditoriumInfo auditoriumInfo, IEnumerable<ScheduleInfo> scheduleInfos, int para, int dayWeek, int idPeriod, string text, bool edit)
		{
			InitializeComponent();
			Text = text;
			IDAud = auditoriumInfo.ID_Auditorium;
			Para = para;
			DayWeek = dayWeek;
			IDPeriod = idPeriod;
			if (IDPeriod != 1 && IDPeriod != 2)
			{
				checkBox2.Visible = false;
				Size = new Size(431, 238);
			}
			Sched = edit ? new List<ScheduleInfo>(scheduleInfos) : new List<ScheduleInfo>();
			if (edit)
			{
				var teacher = Model.GetFreeTeachersAndCurrent(IDPeriod, Para, DayWeek, Sched[0].ID_Teacher);
				Teacher.Items.AddRange(teacher);
				var t = teacher.Single(q => q.ID_Teacher == Sched[0].ID_Teacher);
				Teacher.SelectedItem = t;
				Disp.Items.Clear();
				var dispAll = Model.GetDisciplinesFromTeacher((TeacherInfo)Teacher.SelectedItem);
				var d = dispAll.Single(q => q.ID_Discipline == Sched[0].ID_Discipline);
				Disp.Items.AddRange(dispAll);
				Disp.SelectedItem = d;
				var facAll = Model.GetAll.Fuculty();
				var fac = facAll.Single(a => a.ID_Faculty == Sched.First().ID_Faculty);
				Faculty.Items.AddRange(facAll);
				Faculty.SelectedItem = fac;
				try
				{
					var temp = Sched.First().GroupName.Substring(Sched.First().GroupName.Length - 2, 1);
					Curs.SelectedIndex = Convert.ToInt32(temp) - 1;
				}
				catch (Exception)
				{
				}
				for (int i = 0; i < List.Items.Count; i++)
					foreach (var list in Sched)
						if (((GroupInfo)List.Items[i]).ID_Group == list.ID_Group)
							List.SetItemChecked(i, true);
				groupBox3.Enabled = true;
			}
			else
			{
                var teachers = Model.GetFreeTeachers(IDPeriod, Para, DayWeek);
                Teacher.Items.AddRange(teachers);
                if (teachers.Count() == 1)
                    Teacher.SelectedItem = teachers[0];
                var faculty = Model.GetAll.Fuculty();
                Faculty.Items.AddRange(faculty);
                if (faculty.Count() == 1)
                    Faculty.SelectedItem = faculty[0];
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (Disp.SelectedItem == null || List.CheckedIndices.Count == 0)
				MessageBox.Show("Не все пункты выбраны");
			else
			{
				Sched.Clear();
				foreach (var s in List.CheckedItems)
				{
					var temp = new ScheduleInfo
					{
						DayWeek = DayWeek,
						Para = Para,
						ID_Auditorium = IDAud,
						ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
						ID_Period = IDPeriod,
						ID_Group = ((GroupInfo)s).ID_Group,
						ID_Teacher = ((TeacherInfo)Teacher.SelectedItem).ID_Teacher
					};
					Sched.Add(temp);
				}
				if (checkBox2.Checked && (IDPeriod == 1 || IDPeriod == 2))
				{
					foreach (var s in List.CheckedItems)
					{
						var temp = new ScheduleInfo
						{
							DayWeek = DayWeek,
							Para = Para,
							ID_Auditorium = IDAud,
							ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
							ID_Period = IDPeriod + 4,
							ID_Group = ((GroupInfo)s).ID_Group,
							ID_Teacher = ((TeacherInfo)Teacher.SelectedItem).ID_Teacher
						};
						Sched.Add(temp);
					}
				}
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void AddPara_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
				Close();
		}

		private void Teacher_SelectedIndexChanged(object sender, EventArgs e)
		{
			Disp.Items.Clear();
			var disp = Model.GetDisciplinesFromTeacher((TeacherInfo)Teacher.SelectedItem);
			Disp.Items.AddRange(disp);
            if (disp.Count() == 1)
                Disp.SelectedItem = disp[0];
			groupBox3.Enabled = true;
		}

		private void Faculty_SelectedIndexChanged(object sender, EventArgs e)
		{
			Curs.Enabled = true;
			Curs.SelectedIndex = -1;
			List.Enabled = false;
		}

		private void Curs_SelectedIndexChanged(object sender, EventArgs e)
		{
			List.Enabled = true;
			List.Items.Clear();
			var temp = Model.GetGroupFromFacultyAndKurs(
				(FacultyInfo)Faculty.SelectedItem, Curs.SelectedIndex + 1);
		    if (temp == null) 
                return;
		    List.Items.AddRange(temp);
            if (temp.Count() == 1)
                List.SetItemChecked(0, true);
		}
	}
}

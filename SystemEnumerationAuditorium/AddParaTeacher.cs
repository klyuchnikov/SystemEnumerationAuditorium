using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public sealed partial class AddParaTeacher : Form
	{
		public List<ScheduleInfo> Sched;
		private readonly int DayWeek;
		private readonly int Para;
		private readonly int IDPeriod;
		private readonly int IDTeacher;
		public AddParaTeacher(
			TeacherInfo teacherInfo, IEnumerable<ScheduleInfo> scheduleInfos, int para, int dayWeek, int idPeriod, string text, bool edit)
		{
			InitializeComponent();
			Text = text;
			IDTeacher = teacherInfo.ID_Teacher;
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
				var locAll = Model.GetAll.Location();
				var dispAll = Model.GetDisciplinesFromTeacher(teacherInfo);
				var facAll = Model.GetAll.Fuculty();
				var loc = (from a in locAll
									 where a.ID_Location == Sched.First().ID_Location
									 select a).Single();
				var disp = (from a in dispAll
										where a.ID_Discipline == Sched.First().ID_Discipline
										select a).Single();
				var fac = (from a in facAll
									 where a.ID_Faculty == Sched.First().ID_Faculty
									 select a).Single();
				Location.Items.AddRange(locAll);
				Location.SelectedItem = loc;
				Disp.Items.AddRange(dispAll);
				Disp.SelectedItem = disp;
				Faculty.Items.AddRange(facAll);
				Faculty.SelectedItem = fac;
				var auAll = Model.GetAuditoriumsFromLocation(loc);
				var au = (from a in auAll
									where a.ID_Auditorium == Sched.First().ID_Auditorium
									select a).Single();
				Aud.Items.Clear();
				Aud.Items.AddRange(auAll);
				Aud.Enabled = true;
				Aud.SelectedItem = au;
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
			}
			else
			{
			    var loc = Model.GetAll.Location();
                Location.Items.AddRange(loc);
                if (loc.Count() == 1)
                    Location.SelectedIndex = 0;
			    var disp = Model.GetDisciplinesFromTeacher(teacherInfo);
				Disp.Items.AddRange(disp);
                if (disp.Count() == 1)
                    Disp.SelectedIndex = 0;
			    var fac = Model.GetAll.Fuculty();
				Faculty.Items.AddRange(fac);
                if (fac.Count() == 1)
                    Faculty.SelectedIndex = 0;
			}
		}

		private void Location_SelectedIndexChanged(object sender, EventArgs e)
		{
			Aud.Items.Clear();
		    var au = Model.GetAuditoriumsFromLocation((LocationInfo) Location.SelectedItem);
			Aud.Items.AddRange(au);
            if (au.Count() == 1)
                Aud.SelectedIndex = 0;
            Aud.Enabled = true;
			Aud.SelectedIndex = -1;
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
                List.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Aud.SelectedIndex == -1 || List.CheckedIndices.Count == 0 || Disp.SelectedIndex == -1)
			{
				MessageBox.Show("Не все пункты выбраны");
				return;
			}
			Sched.Clear();
			foreach (var s in List.CheckedItems)
			{
				var temp = new ScheduleInfo
										{
											DayWeek = DayWeek,
											Para = Para,
											ID_Auditorium = ((AuditoriumInfo)Aud.SelectedItem).ID_Auditorium,
											ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
											ID_Period = IDPeriod,
											ID_Group = ((GroupInfo)s).ID_Group,
											ID_Teacher = IDTeacher
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
						ID_Auditorium = ((AuditoriumInfo)Aud.SelectedItem).ID_Auditorium,
						ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
						ID_Period = IDPeriod + 4,
						ID_Group = ((GroupInfo)s).ID_Group,
						ID_Teacher = IDTeacher
					};
					Sched.Add(temp);
				}
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void AddParaTeacher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
				Close();
		}
	}
}

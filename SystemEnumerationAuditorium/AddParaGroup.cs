using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class AddParaGroup : Form
	{
		public List<ScheduleInfo> Sched;
		private readonly int DayWeek;
		private readonly int Para;
		private readonly int IDPeriod;
		private readonly int IDGroup;

		public AddParaGroup(GroupInfo teacherInfo, IEnumerable<ScheduleInfo> scheduleInfos, int para, int dayWeek, int idPeriod, string text, bool edit)
		{
			InitializeComponent();
			Text = text;
			IDGroup = teacherInfo.ID_Group;
			Para = para;
			DayWeek = dayWeek;
			IDPeriod = idPeriod;
			if (IDPeriod != 1 && IDPeriod != 2)
			{
				checkBox2.Visible = false;
				Size = new Size(431, 231);
			}
			Sched = edit ? new List<ScheduleInfo>(scheduleInfos) : new List<ScheduleInfo>();
			if (edit)
			{
				switch (scheduleInfos.Count())
				{
					case 1:
						{
							Teacher2.Items.AddRange(Model.GetFreeTeachers(IDPeriod, Para, DayWeek));
							var teacher = Model.GetFreeTeachersAndCurrent(
								IDPeriod, Para, DayWeek, Sched[0].ID_Teacher);
							Teacher1.Items.AddRange(teacher);
							var t = (from info in teacher
							         where info.ID_Teacher == Sched[0].ID_Teacher
							         select info).Single();
							Teacher1.SelectedItem = t;
							var loc = Model.GetAll.Location();
							Location1.Items.AddRange(loc);
							Location2.Items.AddRange(loc);
							var l = (from a in loc
							         where a.ID_Location == Sched[0].ID_Location
							         select a).Single();
							Location1.SelectedItem = l;
							var aud = Model.GetAuditoriumsFromLocation(l);
							Aud1.Items.Clear();
							Aud1.Items.AddRange(aud);
							var au = (from info in aud
							          where info.ID_Auditorium == Sched[0].ID_Auditorium
							          select info).Single();
							Aud1.SelectedItem = au;
							var disp = Model.GetDisciplinesFromTeacher((TeacherInfo)Teacher1.SelectedItem);
							Disp.Items.Clear();
							Disp.Items.AddRange(disp);
							var d = (from a in disp
							         where a.ID_Discipline == Sched[0].ID_Discipline
							         select a).Single();
							Disp.SelectedItem = d;
						}
						break;
					case 2:
						{
							var teacher = Model.GetFreeTeachersAndCurrent(
								IDPeriod, Para, DayWeek, Sched[0].ID_Teacher);
							Teacher1.Items.AddRange(teacher);
							var t = (from info in teacher
							         where info.ID_Teacher == Sched[0].ID_Teacher
							         select info).Single();
							Teacher1.SelectedItem = t;
							var loc = Model.GetAll.Location();
							Location1.Items.AddRange(loc);
							var l = (from a in loc
							         where a.ID_Location == Sched[0].ID_Location
							         select a).Single();
							Location1.SelectedItem = l;
							var aud = Model.GetAuditoriumsFromLocation(l);
							Aud1.Items.AddRange(aud);
							var au = (from info in aud
							          where info.ID_Auditorium == Sched[0].ID_Auditorium
							          select info).Single();
							Aud1.SelectedItem = au;
							var disp = Model.GetDisciplinesFromTeacher((TeacherInfo)Teacher1.SelectedItem);
							Disp.Items.Clear();
							Disp.Items.AddRange(disp);
							var d = (from a in disp
							         where a.ID_Discipline == Sched[0].ID_Discipline
							         select a).Single();
							Disp.SelectedItem = d;
							teacher = Model.GetFreeTeachersAndCurrent(
								IDPeriod, Para, DayWeek, Sched[1].ID_Teacher);
							Teacher2.Items.AddRange(teacher);
							t = (from info in teacher
							     where info.ID_Teacher == Sched[1].ID_Teacher
							     select info).Single();
							Teacher2.SelectedItem = t;
							loc = Model.GetAll.Location();
							Location2.Items.AddRange(loc);
							l = (from a in loc
							     where a.ID_Location == Sched[1].ID_Location
							     select a).Single();
							Location2.SelectedItem = l;
							aud = Model.GetAuditoriumsFromLocation(l);
							Aud2.Items.AddRange(aud);
							au = (from info in aud
							      where info.ID_Auditorium == Sched[1].ID_Auditorium
							      select info).Single();
							Aud2.SelectedItem = au;
							disp = Model.GetDisciplinesFromTeacher((TeacherInfo)Teacher1.SelectedItem);
							Disp.Items.Clear();
							Disp.Items.AddRange(disp);
							d = (from a in disp
							     where a.ID_Discipline == Sched[1].ID_Discipline
							     select a).Single();
							Disp.SelectedItem = d;
							checkBox1.Checked = true;
							Teacher2.Enabled = true;
							Location2.Enabled = true;
						}
						break;
				}
			}
			else
			{
				var loc = Model.GetAll.Location();
				Location1.Items.AddRange(loc);
                Location2.Items.AddRange(loc);
                if (loc.Count() == 1)
                {
                    Location1.SelectedItem = loc[0];
                    Location2.SelectedItem = loc[0];
                }
				
				var teacher = Model.GetFreeTeachers(IDPeriod, Para, DayWeek);
				Teacher1.Items.AddRange(teacher);
				Teacher2.Items.AddRange(teacher);
                if (teacher.Count() == 1)
                {
                    Teacher1.SelectedIndex = 0;
                    Teacher2.SelectedIndex = 0;
                }
			}
		}

		private void Location1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Aud1.Items.Clear();
			var au = Model.GetAuditoriumsFromLocation((LocationInfo)Location1.SelectedItem);
			Aud1.Items.AddRange(au);
            if (au.Count() == 1)
                Aud1.SelectedIndex = 0;
			Aud1.Enabled = true;
		}

		private void Location2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Aud2.Items.Clear();
			var au = Model.GetAuditoriumsFromLocation((LocationInfo)Location2.SelectedItem);
			Aud2.Items.AddRange(au);
            if (au.Count() == 1)
                Aud2.SelectedIndex = 0;
			Aud2.Enabled = true;
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (Teacher1.SelectedIndex == -1)
				return;
			Teacher2.Enabled = !Teacher2.Enabled;
			Location2.Enabled = !Location2.Enabled;
		}

		private void Teacher1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!Teacher2.Enabled)
			{
				Disp.Items.Clear();
				var disp = Model.GetDisciplinesFromTeacher((TeacherInfo)Teacher1.SelectedItem);
				Disp.Items.AddRange(disp);
                if (disp.Count() == 1)
                    Disp.SelectedIndex = 0;
				checkBox1.Enabled = true;
				Disp.Enabled = true;
			}
			else
			{
				Disp.Items.Clear();
				var disp = Model.GetDisciplinesFromTwoTeacher(
					(TeacherInfo)Teacher1.SelectedItem, (TeacherInfo)Teacher2.SelectedItem);
			    if (disp == null) 
                    return;
			    Disp.Items.AddRange(disp);
                if (disp.Count() == 1)
                    Disp.SelectedIndex = 0;
			}
		}

		private void Teacher2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Disp.Items.Clear();
			var disp = Model.GetDisciplinesFromTwoTeacher(
				(TeacherInfo)Teacher1.SelectedItem, (TeacherInfo)Teacher2.SelectedItem);
			Disp.Items.AddRange(disp);
            if (disp.Count() == 1)
                Disp.SelectedIndex = 0;
			Disp.Enabled = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				if (Aud1.SelectedIndex == -1 || Aud2.SelectedIndex == -1 || Disp.SelectedIndex == -1)
				{
					MessageBox.Show("Не все пункты выбраны");
					return;
				}
				Sched.Clear();
				Sched.Add(new ScheduleInfo
				          	{
				          		DayWeek = DayWeek,
				          		Para = Para,
				          		ID_Auditorium = ((AuditoriumInfo) Aud1.SelectedItem).ID_Auditorium,
				          		ID_Discipline = ((DisciplineInfo) Disp.SelectedItem).ID_Discipline,
				          		ID_Period = IDPeriod,
				          		ID_Group = IDGroup,
				          		ID_Teacher = ((TeacherInfo) Teacher1.SelectedItem).ID_Teacher
				          	});
				Sched.Add(new ScheduleInfo
				{
					DayWeek = DayWeek,
					Para = Para,
					ID_Auditorium = ((AuditoriumInfo)Aud2.SelectedItem).ID_Auditorium,
					ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
					ID_Period = IDPeriod,
					ID_Group = IDGroup,
					ID_Teacher = ((TeacherInfo)Teacher2.SelectedItem).ID_Teacher
				});
				if (checkBox2.Checked && (IDPeriod == 1 || IDPeriod == 2))
				{
					Sched.Add(new ScheduleInfo
					{
						DayWeek = DayWeek,
						Para = Para,
						ID_Auditorium = ((AuditoriumInfo)Aud1.SelectedItem).ID_Auditorium,
						ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
						ID_Period = IDPeriod + 4,
						ID_Group = IDGroup,
						ID_Teacher = ((TeacherInfo)Teacher1.SelectedItem).ID_Teacher
					});
					Sched.Add(new ScheduleInfo
					{
						DayWeek = DayWeek,
						Para = Para,
						ID_Auditorium = ((AuditoriumInfo)Aud2.SelectedItem).ID_Auditorium,
						ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
						ID_Period = IDPeriod + 4,
						ID_Group = IDGroup,
						ID_Teacher = ((TeacherInfo)Teacher2.SelectedItem).ID_Teacher
					});
				}
			}
			else
			{
				if (Aud1.SelectedIndex == -1 || Disp.SelectedIndex == -1)
				{
					MessageBox.Show("Не все пункты выбраны");
					return;
				}
				Sched.Clear();
				Sched.Add(new ScheduleInfo
				{
					DayWeek = DayWeek,
					Para = Para,
					ID_Auditorium = ((AuditoriumInfo)Aud1.SelectedItem).ID_Auditorium,
					ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
					ID_Period = IDPeriod,
					ID_Group = IDGroup,
					ID_Teacher = ((TeacherInfo)Teacher1.SelectedItem).ID_Teacher
				});
				if (checkBox2.Checked && (IDPeriod == 1 || IDPeriod == 2))
				{
					Sched.Add(new ScheduleInfo
					{
						DayWeek = DayWeek,
						Para = Para,
						ID_Auditorium = ((AuditoriumInfo)Aud1.SelectedItem).ID_Auditorium,
						ID_Discipline = ((DisciplineInfo)Disp.SelectedItem).ID_Discipline,
						ID_Period = IDPeriod + 4,
						ID_Group = IDGroup,
						ID_Teacher = ((TeacherInfo)Teacher1.SelectedItem).ID_Teacher
					});
				}

			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void ESC_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
				Close();
		}
	}
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class MainForm : Form
	{
		private DataGridViewCell _cell;

		private void LoadTabTeachers(TabControl control)
		{
			Status.Text = "Загрузка вкладок преподавателей";
			Application.DoEvents();
			control.Selected -= Tab_Selected;
			control.TabPages.Clear();
			control.Selected += Tab_Selected;
			var list = Model.GetAll.Teachers();
			var my = new Model.MyComparerName();
			Array.Sort(list, my.Compare);
			TabTeachers.Tag = list;
			ProgressBar.Value = 0;
			ProgressBar.Maximum = list.Length;
			foreach (var i in list)
			{
				ProgressBar.PerformStep();
				var tabPage = new ExtendedTabPage(i.ToString())
				{
					Tag = i,
					Name = i.ToString(),
					UseVisualStyleBackColor = true
				};
				control.TabPages.Add(tabPage);
			}
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
			control.SelectedIndex = 0;
		}

		private void LoadTabAuditoriums(LocationInfo location)
		{
			Status.Text = "Загрузка вкладок аудиторий";
			Application.DoEvents();
			Auditoriums.Selected -= Tab_Selected;
			Auditoriums.TabPages.Clear();
			Auditoriums.Selected += Tab_Selected;
			var list = new List<AuditoriumInfo>(Model.GetAuditoriumsFromLocation(location));
			list.Sort(new Model.MyComparerName().Compare);
			ProgressBar.Value = 0;
			ProgressBar.Maximum = list.Count;
			foreach (var i in list)
			{
				ProgressBar.PerformStep();
				var tabPage = new ExtendedTabPage(i.ToString())
				{
					Tag = i,
					Name = i.ToString(),
					UseVisualStyleBackColor = true
				};
				Auditoriums.TabPages.Add(tabPage);
			}
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
		}

		private void LoadTabGroup(FacultyInfo faculty)
		{
			Status.Text = "Загрузка вкладок для групп";
			Application.DoEvents();
			Group.Selected -= Tab_Selected;
			Group.TabPages.Clear();
			Group.Selected += Tab_Selected;
			var list = new List<GroupInfo>(Model.GetGroupFromFaculty(faculty));
			list.Sort(new Model.MyComparerName().Compare);
			ProgressBar.Value = 0;
			ProgressBar.Maximum = list.Count;
			foreach (var i in list)
			{
				ProgressBar.PerformStep();
				var tabPage = new ExtendedTabPage(i.ToString())
				{
					Tag = i,
					Name = i.Name,
					UseVisualStyleBackColor = true
				};
				Group.TabPages.Add(tabPage);
			}
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
		}

		private static void Temp(object sender, EventArgs arg)
		{
			var selPage = (ExtendedTabPage)((TabControl)sender).SelectedTab;
			if (selPage == null)
			{
				return;
			}
			if (selPage.wasLoaded)
			{
				return;
			}
			selPage.wasLoaded = true;
		}

		private void LoadTabPeriods()
		{
			Status.Text = "Загрузка вкладок для периодов";
			Application.DoEvents();
			Periods.SelectedIndexChanged -= Periods_SelectedIndexChanged;
			Periods.TabPages.Clear();
			Periods.SelectedIndexChanged += Periods_SelectedIndexChanged;
			var temp = Model.GetAll.Periods();
			ProgressBar.Value = 0;
			ProgressBar.Maximum = temp.Length;
			foreach (var i in temp)
			{
				ProgressBar.PerformStep();
				var tabPage = new TabPage
				{
					Tag = i,
					Name = i.Name,
					Text = i.ToString(),
					UseVisualStyleBackColor = true
				};
				Periods.TabPages.Add(tabPage);
			}
			Periods.SelectedIndex = 0;
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
		}

		private void LoadDataGridView()
		{
			Shcedule.Rows.Add();
			if (Periods.TabCount == 0)
				return;
			Shcedule.Parent = Periods.SelectedTab;
			ScheduleInfo[] sched = null;
			switch (Main.SelectedIndex)
			{
				case 0:
					if (TabTeachers.SelectedTab == null)
						return;
					sched = Model.GetScheduleFromTeachers(
						(TeacherInfo)TabTeachers.SelectedTab.Tag,
						(PeriodInfo)Periods.SelectedTab.Tag);
					break;
				case 1:
					if (Auditoriums.SelectedTab == null)
						return;
					sched = Model.GetScheduleFromAuditorium(
						(AuditoriumInfo)Auditoriums.SelectedTab.Tag,
						(PeriodInfo)Periods.SelectedTab.Tag);
					break;
				case 2:
					if (Group.SelectedTab == null)
						return;
					sched = Model.GetScheduleFromGroup(
						(GroupInfo)Group.SelectedTab.Tag,
						(PeriodInfo)Periods.SelectedTab.Tag);
					break;
			}
			if (sched == null)
				return;
			Status.Text = "Загрузка расписания";
			ProgressBar.Value = 0;
			ProgressBar.Maximum = sched.Length;
			Application.DoEvents();
			ClearDataGrid();
			for (var i = 0; i < 6; i++)
			{
				var s = sched.Where(a => a.DayWeek == i);
				for (var j = 1; j < 9; j++)
				{
					var temp = s.Where(a => a.Para == j).ToArray();
					if (temp.Count() == 0)
						continue;
					String groupName = null;
					String teacherName = null;
					String audNumber = null;
					var listGroup = new List<string>();
					var listTeacher = new List<string>();
					var listAud = new List<string>();
					foreach (var info in temp)
					{
						ProgressBar.PerformStep();
						if (listGroup.Contains(info.GroupName))
							continue;
						if (groupName == null)
							groupName = info.GroupName;
						else
							groupName += ";" + info.GroupName;
						listGroup.Add(info.GroupName);
					}
					foreach (var info in temp)
					{
						if (listTeacher.Contains(info.TeacherName))
							continue;
						if (teacherName == null)
							teacherName = info.TeacherName;
						else
							teacherName += ";" + info.TeacherName;
						listTeacher.Add(info.TeacherName);
					}
					foreach (var info in temp)
					{
						if (listAud.Contains(info.AuditoriumNumber))
							continue;
						if (audNumber == null)
							audNumber = info.LocationName + info.AuditoriumNumber;
						else
							audNumber += ";" + info.AuditoriumNumber;
						listAud.Add(info.AuditoriumNumber);
					}
					var val = (!(Main.SelectedIndex == 0) ? teacherName + "\n" : null) +
											 temp.First().DisciplineName +
											 (!(Main.SelectedIndex == 2) ? "\n" + groupName : null) +
											 (!(Main.SelectedIndex == 1) ? "\n" + audNumber : null);
					var arr = val.Split('\n');
					for (var k = 0; k < arr.Count(); k++)
					{
						if (arr[k].Length > 15 && CheckLength)
							if (!Model.IsExistsAbridgement(arr[k]))
							{
								if (MessageBox.Show("Строка '" + arr[k] +
										"' в расписании является длинной.\nВыбудете ее редактировать?", "Внимание",
										MessageBoxButtons.YesNo) == DialogResult.Yes)
								{
									var a = new Add(arr[k], null, null);
									if (a.ShowDialog() == DialogResult.OK)
									{
										Model.Add.Abridgement(arr[k], a.strNew);
										arr[k] = a.strNew;
									}
								}
							}
							else
							{
								arr[k] = Model.GetAbridgement(arr[k]);
							}
					}
					Shcedule.Rows[i].Cells[j].Value = String.Join("\n", arr);
					Shcedule.Rows[i].Cells[j].Tag = temp;
				}
			}
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
		}

		private delegate object[] DelegGetAll();

		private void LoadMenuElements(ToolStripDropDownItem tools, DelegGetAll d, string text, ProgressBar bar)
		{
			Status.Text = text;
			Application.DoEvents();
			tools.DropDownItems.Clear();
			Array t = d();
			if (t.GetType() == typeof(FacultyInfo[]))
			{
				var temp = t as FacultyInfo[]; 
				Array.Sort(temp, new Model.MyComparerName().Compare);
				t = temp;
			}
			if (t.GetType() == typeof(TeacherInfo[]))
			{
				var temp = t as TeacherInfo[];
				Array.Sort(temp, new Model.MyComparerName().Compare);
				t = temp;
			}
			if (t.GetType() == typeof(LocationInfo[]))
			{
				var temp = t as LocationInfo[]; 
				Array.Sort(temp, new Model.MyComparerName().Compare);
				t = temp;
			}

			foreach (var fac in t)
			{
				if (bar != null)
		   		bar.PerformStep();
				var tool = new ToolStripMenuItem(fac.ToString());
				tool.Click += MenuItem_Click;
				tool.Tag = fac;
				tools.DropDownItems.Add(tool);
			}

		}

		private void LoadMenu(ProgressBar bar)
		{
			var count = Model.GetAll.FucultyCount + Model.GetAll.LocationCount + Model.GetAll.TeachersCount;
			bar.Maximum = count;
			LoadMenuElements(AddGroupToolStrip, Model.GetAll.Fuculty, "Загрузка меню для факультетов", bar);
			LoadMenuElements(AddDispToolStrip, Model.GetAll.Teachers, "Загрузка меню для преподавателей", bar);
			LoadMenuElements(AddAuditoriumToolStrip, Model.GetAll.Location, "Загрузка меню для корпусов", bar);
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
		}
		private void LoadMenu()
		{
			LoadMenuElements(AddGroupToolStrip, Model.GetAll.Fuculty, "Загрузка меню для факультетов", null);
			LoadMenuElements(AddDispToolStrip, Model.GetAll.Teachers, "Загрузка меню для преподавателей", null);
			LoadMenuElements(AddAuditoriumToolStrip, Model.GetAll.Location, "Загрузка меню для корпусов", null);
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			Application.DoEvents();
		}


		private void AddEditSchedule()
		{
			var edit = false;
			if (_cell.Tag != null)
				edit = true;
			object obj = null;
			switch (Main.SelectedIndex)
			{
				case 0:
					obj = TabTeachers.SelectedTab.Tag;
					break;
				case 1:
					obj = Auditoriums.SelectedTab.Tag;
					break;
				case 2:
					obj = Group.SelectedTab.Tag;
					break;
			}
			var period = (PeriodInfo)Periods.SelectedTab.Tag;
			switch (Main.SelectedIndex)
			{
				case 1:
					{

						var add = new AddParaAuditorium(
							(AuditoriumInfo)obj, ((ScheduleInfo[])_cell.Tag).AsEnumerable(), _cell.ColumnIndex, _cell.RowIndex,
							period.ID_Period,
							Shcedule.Rows[_cell.RowIndex].Cells[0].Value + " " + Shcedule.Columns[_cell.ColumnIndex].HeaderText, edit);
						if (add.ShowDialog() == DialogResult.OK)
						{
							if (edit)
								Model.Delete.Schedule((ScheduleInfo[])_cell.Tag);
							foreach (var s in add.Sched)
								Model.Add.Schedule(s);
							_cell.Tag = add.Sched;
						}
					}
					break;
				case 0:
					{
						var add = new AddParaTeacher(
							(TeacherInfo)obj, ((ScheduleInfo[])_cell.Tag).AsEnumerable(), _cell.ColumnIndex, _cell.RowIndex, period.ID_Period, 
							Shcedule.Rows[_cell.RowIndex].Cells[0].Value + " " + Shcedule.Columns[_cell.ColumnIndex].HeaderText, edit);
						if (add.ShowDialog() == DialogResult.OK)
						{
							if (edit)
								Model.Delete.Schedule((ScheduleInfo[])_cell.Tag);
							foreach (var s in add.Sched)
								Model.Add.Schedule(s);
							_cell.Tag = add.Sched;
						}
					}
					break;
				case 2:
					{
						var add = new AddParaGroup((GroupInfo)obj, ((ScheduleInfo[])_cell.Tag).AsEnumerable(), _cell.ColumnIndex, 
							_cell.RowIndex, period.ID_Period, 
							Shcedule.Rows[_cell.RowIndex].Cells[0].Value + " " + Shcedule.Columns[_cell.ColumnIndex].HeaderText, edit);
						if (add.ShowDialog() == DialogResult.OK)
						{
							if (edit)
								Model.Delete.Schedule((ScheduleInfo[])_cell.Tag);
							foreach (var s in add.Sched)
								Model.Add.Schedule(s);
							_cell.Tag = add.Sched;
						}
					}
					break;
			}
			LoadDataGridView();
		}

		private void AbridgementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var ad = new Abrid();
			ad.ShowDialog();
		}
	}
}

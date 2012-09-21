using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class PrintForm : Form
	{
		public PrintForm(bool Check)
		{
			InitializeComponent();
			CheckLength = Check;
			checkedListBox1.CheckOnClick = true;
			checkedListBox2.CheckOnClick = true;
		}

		public bool CheckLength;

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == -1)
				return;
			radioButton1.Checked = false;
			checkedListBox1.Items.Clear();
			switch (comboBox1.SelectedIndex)
			{
				case 0:
					checkedListBox1.Items.AddRange(Model.GetAll.Teachers());
					break;
				case 1:
					checkedListBox1.Items.AddRange(Model.GetAll.Auditoriums());
					break;
				case 2:
					checkedListBox1.Items.AddRange(Model.GetAll.Group());
					break;
			}
			checkedListBox2.Items.Clear();
			checkedListBox2.Items.AddRange(new[]
			                        	{
			                        		"1 Полупериод", "2 Полупериод", "Зачетная неделя", "Сессия"
			                        	});
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			for (var i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, true);
			}
		}
		private delegate object[] DelegGetAll();

		private static void  Check(DelegGetAll action)
		{
			var temp = action().Where(a => a.ToString().Length > 12);
			if (temp.Count() != 0)
			{
				if (MessageBox.Show(
					"Некоторые элементы будут отображться маленьким шрифтом, вы будете редактировать эти значения?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					foreach (var info in temp)
					{
						var type = info.GetType();
						var a = new Add(info.ToString(), type, null);
						string strAdd = null;
						if (a.ShowDialog() == DialogResult.OK)
						{
							strAdd = a.strNew;
						}
						if (type == typeof(FacultyInfo))
							Model.Edit.Faculty(((FacultyInfo)info), strAdd);
						else if (type == typeof(TeacherInfo))
							Model.Edit.Teacher(((TeacherInfo)info), strAdd);
						else if (type == typeof(DisciplineInfo))
							Model.Edit.Discipline(((DisciplineInfo)info), strAdd);
					}
				}
			}
		}


		private void button1_Click(object sender, EventArgs e)
		{
			if (checkedListBox1.CheckedItems.Count == 0 || checkedListBox2.CheckedItems.Count == 0)
			{
				MessageBox.Show("Вы что-то не выбрали");
				return;
			}
		//	Check(Model.GetAll.Disciplines);
		//	Check(Model.GetAll.Teachers);
			printPreviewDialog1.ShowDialog();
		}


		private Font GetFont(Rectangle rect, string str, Graphics g)
		{
			var tempFont = new Font(Font.FontFamily, 40);
			while (true)
			{
				var size = g.MeasureString(str, tempFont);
				if (size.Width >= rect.Width)
				{
					tempFont = new Font(tempFont.FontFamily, tempFont.Size - 1);
					continue;
				}
				if (size.Height >= rect.Height)
				{
					tempFont = new Font(tempFont.FontFamily, tempFont.Size - 1);
					continue;
				}
				break;
			}
			return tempFont;
		}


		private int DocPrint(IEnumerable<ScheduleInfo> sched, Graphics g, 
			int startX, int startY, int widthX, int heightPara, int widthDay, int heightY, Brush brush)
		{
			if (sched.Count() == 0)
					return 0;		
			var strFormat = new StringFormat
			{
				Alignment = StringAlignment.Center
			};
			var day = new Dictionary<int, string>
			          	{
			          		{0, "Пн"},
			          		{1, "Вт"},
			          		{2, "Ср"},
			          		{3, "Чт"},
			          		{4, "Пт"},
			          		{5, "Сб"}
			          	};

      var para = new Dictionary<int, string>
			           	{
			           		{0, "1 Пара"},
			           		{1, "2 Пара"},
			           		{2, "3 Пара"},
			           		{3, "4 Пара"},
			           		{4, "5 Пара"},
			           		{5, "6 Пара"},
			           		{6, "7 Пара"},
			           		{7, "8 Пара"}
			           	};
			var y = startY;
			int t = -1;
			for (var i = 0; i < 6; i++)
			{
				int i1 = i;
				var s = sched.Where(a => a.DayWeek == i1);
				if (s.Count() == 0)
					continue;
				int maxPara = Model.GetMaxPara(sched);
				if (t == 0)
					y = y + heightY;
				t = 0;
				// Печать дней недели
				var rect = new Rectangle(startX - widthDay, y, widthDay, heightY);
				g.DrawRectangle(new Pen(Brushes.Black), rect);
				var tempFont = GetFont(rect, day[i], g);
				g.DrawString(day[i], tempFont, brush, rect, strFormat);

				for (var j = 0; j < maxPara; j++)
				{
					var x = startX + widthX * j;		
					// Печать номеров пар
					rect = new Rectangle(x, startY - heightPara, widthX, heightPara);
					g.DrawRectangle(new Pen(Brushes.Black), rect);
					tempFont = GetFont(rect, para[j], g);
					g.DrawString(para[j], tempFont, brush, rect, strFormat);

					// Печать расписания
					rect = new Rectangle(x, y, widthX, heightY);
          g.DrawRectangle(new Pen(Brushes.Black), rect);
					int i2 = j;
					var temp = s.Where(a => a.Para == i2 + 1).ToArray();
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
						if (!listGroup.Contains(info.GroupName))
						{
							if (groupName == null)
								groupName = info.GroupName;
							else
								groupName += ";" + info.GroupName;
							listGroup.Add(info.GroupName);
						}
					}
					foreach (var info in temp)
					{
						if (!listTeacher.Contains(info.TeacherName))
						{
							if (teacherName == null)
								teacherName = info.TeacherName;
							else
								teacherName += ";" + info.TeacherName;
							listTeacher.Add(info.TeacherName);
						}
					}
					foreach (var info in temp)
					{
						if (!listAud.Contains(info.AuditoriumNumber))
						{
							if (audNumber == null)
								audNumber = info.LocationName + info.AuditoriumNumber;
							else
								audNumber += ";" + info.AuditoriumNumber;
							listAud.Add(info.AuditoriumNumber);
						}
					}
					var val = (!(comboBox1.SelectedIndex == 0) ? teacherName + "\n" : null) +
											 temp.First().DisciplineName +
											 (!(comboBox1.SelectedIndex == 2) ? "\n" + groupName : null) +
											 (!(comboBox1.SelectedIndex == 1) ? "\n" + audNumber : null);
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
					for (var k = 0; k < arr.Count(); k++)
						arr[k] = Model.GetAbridgement(arr[k]);
					rect = new Rectangle(x, y, widthX, heightY * 3 / 4);
					for (var k = 0; k < arr.Count(); k++)
					{
						tempFont = GetFont(rect, arr[k], g);
						var size = g.MeasureString(arr[k], tempFont);
						g.DrawString(arr[k], tempFont, brush, rect, strFormat);
						rect = new Rectangle(rect.X, rect.Y + (int)size.Height, widthX, heightY * 1 / 3);
					}
				}
			}
			return y;
		}


		private int PageCurrent;
		private int PeriodCurrent = -1;
		private void Doc_PrintPage(object sender, PrintPageEventArgs e)
		{
			const int widthDay = 30;
			const int heightPara = 20;
			const int widthX = 90;
			const int heightY = 60;
			const int startX = 60;
			const int startY = 130;

			var val = checkedListBox1.CheckedItems[PageCurrent];
			string str = null;
			if (comboBox1.SelectedIndex == 0)
				str = "Расписание Преподавателя: " + val;
			else if (comboBox1.SelectedIndex == 1)
				str = "Расписание на Аудиторию: " + val;
			else if (comboBox1.SelectedIndex == 2)
				str = "Расписание группы: " + val;
			e.Graphics.DrawString(str, new Font("Arial", 15), Brushes.Black,
				startX, startY - heightPara - 60);
			ScheduleInfo[] sched = null;
			PeriodInfo[] period = null;
			if (PeriodCurrent == -1)
				PeriodCurrent = 0;
			var item = checkedListBox2.CheckedIndices[PeriodCurrent];

			if (item == 0)   
				period = Model.GetAll.Periods().Where(a => a.Name.Contains("1 Полупериод")).ToArray();
			if (item == 1)
				period = Model.GetAll.Periods().Where(a => a.Name.Contains("2 Полупериод")).ToArray();
			if (item == 2)
				period = Model.GetAll.Periods().Where(a => a.Name.Contains("Зачетная Неделя")).ToArray();
			var start = startY;
			var brush = Brushes.Black;
			if (period != null)
			{
				foreach (var info in period)
				{
					if (comboBox1.SelectedIndex == 0)
						sched = Model.GetScheduleFromTeachers((TeacherInfo) val, info);
					if (comboBox1.SelectedIndex == 1)
						sched = Model.GetScheduleFromAuditorium((AuditoriumInfo) val, info);
					if (comboBox1.SelectedIndex == 2)
						sched = Model.GetScheduleFromGroup((GroupInfo) val, info);
					if (sched.Count() != 0)
					{
						e.Graphics.DrawString(sched.First().PeriodName, new Font("Arial", 15), Brushes.Black,
				                      startX, start - heightPara - 30);
						start = DocPrint(sched, e.Graphics, startX, start, widthX, heightPara, widthDay, heightY, brush) + 120;
					}
					else
					{
						e.Graphics.DrawString(info.Name + ": занятия отсутствуют", 
							new Font("Arial", 20), Brushes.Black, e.PageBounds.Width / 2, 
							start - heightPara - 30, new StringFormat{Alignment = StringAlignment.Center});
						start += 50;
					}
					brush = Brushes.Blue;
				}

			}
			if (PeriodCurrent == checkedListBox2.CheckedItems.Count - 1)
			{
				PeriodCurrent = -1;
				PageCurrent++;
			}
			else
				PeriodCurrent++;
			e.HasMorePages = PageCurrent < checkedListBox1.CheckedItems.Count;
			if (!e.HasMorePages)
				PageCurrent = 0;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
			{
				Doc.PrinterSettings = pageSetupDialog1.PrinterSettings;
			}
			
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace SystemEnumerationAuditorium
{
	public partial class MainForm
	{
	    public MainForm()
		{
			InitializeComponent();
           // this.MinimumSizeChanged +
         //  tableLayoutPanel1.senro
            var t = this.Controls;
            foreach (Control a in t)
                a.Resize += MainForm_Resize;
			var load = new LoadProgram();
			load.Show();
			Model.Load();
			LoadMenu(load.Bar);
            load.Close();
			foreach (DataGridViewColumn a in Shcedule.Columns)
				a.SortMode = DataGridViewColumnSortMode.NotSortable;
			Main.TabPages.RemoveByKey("tabPage1");
            LoadTabTeachers(TabTeachers);
	        if (TabTeachers.TabCount == 0) 
                return;
	        LoadTabPeriods();
	        Periods.Parent = TabTeachers.SelectedTab;
	        LoadDataGridView();
            MainForm_Resize(null, null);
		}

		public bool CheckLength;

		private void FilterTeacher_TextChanged(object sender, EventArgs e)
		{
			if (TabTeachers.TabCount == 0)
				return;
			var list = (TeacherInfo[])TabTeachers.Tag;
            FilterTeacher.Focus();
            var temp = list.Where(q => q.Name.ToUpper().StartsWith(FilterTeacher.Text.ToUpper()));
            if (temp.Count() == 0)
            {
                MessageBox.Show("Такого преподавателя не существует");
                return;
            }
            TabTeachers.TabPages.Clear();
            foreach (var i in list)
            {
                if (!i.Name.ToUpper().StartsWith(FilterTeacher.Text.ToUpper()))
                    continue;
                var tabPage = new ExtendedTabPage(i.ToString())
                                                {
                                                    Tag = i,
                                                    Name = i.ToString(),
                                                    UseVisualStyleBackColor = true
                                                };
                TabTeachers.TabPages.Add(tabPage);
            }
            TabTeachers.SelectedIndex = -1;
            TabTeachers.SelectedIndex = 0;
            
        }
		private void ClearDataGrid()
		{
			Shcedule.Rows.Clear();
			var dictionary = new Dictionary<int, string>{
			  {0,"Пн"},{1,"Вт"},{2,"Ср"},{3,"Чт"},{4,"Пт"},{5,"Сб"}};
			for (var i = 0; i < 6; i++)
				Shcedule.Rows.Add(dictionary[i]);
		}

		private void MenuItem_Click(object send, EventArgs e)
		{
			EditElements edit = null;
			var sender = (ToolStripMenuItem)send;
			if (sender.Tag == null)
			{
				var dict = new Dictionary<string, Type> { 
				{ "Преподаватели", typeof(TeacherInfo) }, {"Факультеты", typeof(FacultyInfo)},
				{"Корпуса", typeof(LocationInfo)}, {"Форму образования", typeof(EducationInfo)}
				};
				edit = new EditElements(dict[sender.Text], null);
			}
			else
			{
				if (sender.Tag is FacultyInfo)
					edit = new EditElements(typeof(GroupInfo), sender.Tag);
				else if (sender.Tag is TeacherInfo)
					edit = new EditElements(typeof(DisciplineInfo), sender.Tag);
				else if (sender.Tag is LocationInfo)
					edit = new EditElements(typeof(AuditoriumInfo), sender.Tag);
			}
			edit.ShowDialog();
			if (edit.EditBase)
				LoadMenu();
			Main_SelectedIndexChanged(send, e);
		}

		private void Shcedule_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			var ColumnIndex = e.ColumnIndex;
			var RowIndex = e.RowIndex;
			if (ColumnIndex < 0 || RowIndex < 0)
				return;
			if (Shcedule.Rows[RowIndex].Cells[ColumnIndex] == null)
				return;
			var gridPen = new Pen(new SolidBrush(Shcedule.GridColor));
			e.Graphics.FillRectangle((RowIndex % 2 == 0 ? Brushes.Aqua : Brushes.Bisque), e.CellBounds);
			e.Graphics.DrawLine(gridPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
				 e.CellBounds.Bottom - 1);
			e.Graphics.DrawLine(gridPen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1,
					e.CellBounds.Bottom);
			if (e.Value != null)
			{
				var temp = ((string)e.Value).Split('\n');
				var rect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
				foreach (var a in temp)
				{
					var tempFont = GetFont(rect, (String)e.Value, e.Graphics);
					var size = e.Graphics.MeasureString(a, tempFont);
					e.Graphics.DrawString(a, tempFont, Brushes.Black, rect, new StringFormat
					{
						Alignment = StringAlignment.Center
					});
					rect = new Rectangle(rect.X, rect.Y + (int)size.Height, e.CellBounds.Width, e.CellBounds.Height - (int)size.Height);
				}
			}
			e.Handled = true;
		}

		public class ExtendedTabPage : TabPage
		{
			public bool wasLoaded
			{
				get;
				set;
			}

			public ExtendedTabPage(string name)
				: base(name)
			{
				wasLoaded = false;
			}
		}

		private void Shcedule_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 1 || e.RowIndex < 0)
				return;
			AddEditSchedule();

		}
		private void Periods_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadDataGridView();
		}

		private void AddEditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddEditSchedule();
		}

		private void Shcedule_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;
			var sched = (DataGridView)sender;
			_cell = sched.Rows[e.RowIndex].Cells[e.ColumnIndex];
			_cell.ContextMenuStrip = null;
			if (e.Button != MouseButtons.Right)
				return;
			contextMenu.Items.Clear();
			if (e.ColumnIndex > 0)
			{
				if (_cell.Tag == null)
					contextMenu.Items.Add(new ToolStripMenuItem("Добавить", null, AddEditToolStripMenuItem_Click));
				else
				{
					contextMenu.Items.Add(new ToolStripMenuItem("Редактировать", null, AddEditToolStripMenuItem_Click));
					contextMenu.Items.Add(new ToolStripMenuItem("Удалить", null, DeleteToolStripMenuItem_Click));
				}
			}
			else
			{
				contextMenu.Items.Add(new ToolStripMenuItem("Удалить расписание на весь день", null, DeleteDaySchedule_Click));
				contextMenu.Items.Add(new ToolStripMenuItem("Удалить расписание на всю неделю", null, DeleteWeekSchedule_Click));

			}
			_cell.ContextMenuStrip = contextMenu;
		}

		private void DeleteDaySchedule_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить\nрасписание на весь день?",
													"Внимание", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;
			var period = (PeriodInfo)Periods.SelectedTab.Tag;
			switch (Main.SelectedIndex)
			{
				case 0:
					var teacher = (TeacherInfo)TabTeachers.SelectedTab.Tag;
					Model.Delete.ScheduleDayTeacher(period.ID_Period, teacher.ID_Teacher, _cell.RowIndex);
					break;
				case 1:
					var auditorium = (AuditoriumInfo)Auditoriums.SelectedTab.Tag;
					Model.Delete.ScheduleDayAuditorium(period.ID_Period, auditorium.ID_Auditorium, _cell.RowIndex);
					break;
				case 2:
					var groupp = (GroupInfo)Group.SelectedTab.Tag;
					Model.Delete.ScheduleDayGroup(period.ID_Period, groupp.ID_Group, _cell.RowIndex);
					break;
			}
			LoadDataGridView();
		}
		private void DeleteWeekSchedule_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить\nрасписание на всю неделю?",
													"Внимание", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;
			var period = (PeriodInfo)Periods.SelectedTab.Tag;
			switch (Main.SelectedIndex)
			{
				case 0:
					var teacher = (TeacherInfo)TabTeachers.SelectedTab.Tag;
					Model.Delete.ScheduleWeekTeacher(period.ID_Period, teacher.ID_Teacher);
					break;
				case 1:
					var auditorium = (AuditoriumInfo)Auditoriums.SelectedTab.Tag;
					Model.Delete.ScheduleWeekAuditorium(period.ID_Period, auditorium.ID_Auditorium);
					break;
				case 2:
					var groupp = (GroupInfo)Group.SelectedTab.Tag;
					Model.Delete.ScheduleWeekGroup(period.ID_Period, groupp.ID_Group);
					break;
			}
			LoadDataGridView();
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить\nрасписание на эту пару?",
													"Внимание", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;
			Model.Delete.Schedule((ScheduleInfo[])_cell.Tag);
			LoadDataGridView();
		}

		private void Location_SelectedIndexChanged(object sender, EventArgs e)
		{
			var location = (LocationInfo)Location.SelectedItem;
			Auditoriums.Enabled = true;
			LoadTabAuditoriums(location);
			LoadTabPeriods();
			if (Auditoriums.SelectedTab != null)
			{
				Periods.Parent = Auditoriums.SelectedTab;
				LoadDataGridView();
			}
			else
				MessageBox.Show("Аудиторий нет");

		}

		private void Main_SelectedIndexChanged(object sender, EventArgs e)
		{
			ProgressBar.Value = 0;
			switch (Main.SelectedIndex)
			{
				case 0:
					FilterTeacher.Text = "";
					LoadTabTeachers(TabTeachers);
					if (TabTeachers.TabCount != 0)
					{
						LoadTabPeriods();
						Periods.Parent = TabTeachers.SelectedTab;
						LoadDataGridView();
					}
					break;
				case 1:
					FilterAudit.Text = "";
			        Auditoriums.Selected -= Tab_Selected;
					Auditoriums.TabPages.Clear();
					Auditoriums.Selected += Tab_Selected;
                    var loc = Model.GetAll.Location();
					Location.Items.Clear();
					Location.Items.AddRange(loc);
                    if (loc.Count() == 1)
                        Location.SelectedIndex = 0;
					break;
				case 2:
					FilterGroup.Text = "";
					Group.Selected -= Tab_Selected;
					Group.TabPages.Clear();
					Group.Selected += Tab_Selected;
                    Faculty.Items.Clear();
			        var fac = Model.GetAll.Fuculty();
					Faculty.Items.AddRange(fac);
                    if (fac.Count() == 1)
                        Faculty.SelectedIndex = 0;
					break;
			}
			MainForm_Resize(sender, e);
		}

		private void Tab_Selected(object sender, TabControlEventArgs e)
		{
			var tab = (TabControl)sender;
			Periods.Parent = tab.SelectedTab;
			LoadDataGridView();
			MainForm_Resize(sender, e);
		}

		private void Faculty_SelectedIndexChanged(object sender, EventArgs e)
		{
			var faculty = (FacultyInfo)Faculty.SelectedItem;
			LoadTabGroup(faculty);
			if (Group.SelectedTab != null)
			{
				LoadTabPeriods();
				Periods.Parent = Group.SelectedTab;
				LoadDataGridView();
				Group.Enabled = true;
			}
			else
				MessageBox.Show("Групп нет");
		}

		private Font GetFont(Rectangle rect, string str, Graphics g)
		{
			var tempFont = new Font(Font.FontFamily, 40);
			while (true)
			{
				var size = g.MeasureString(str, tempFont);
				if (tempFont.Size == 1)
					break;
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

		private void ПринтерToolStripMenuItemClick(object sender, EventArgs e)
		{
			var print = new PrintForm(CheckLength);
			print.ShowDialog();
		}

		private void FilterAudit_TextChanged(object sender, EventArgs e)
		{
			if (Location.SelectedItem == null)
				return;
			var temp = Model.GetAuditoriumIDPartial(FilterAudit.Text, (LocationInfo)Location.SelectedItem);
			if (temp != null)
			{
				Auditoriums.SelectTab(temp);
			}
			else
				MessageBox.Show("Такой аудитории не существует");
			FilterAudit.Focus();
		}

		private void FilterGroup_TextChanged(object sender, EventArgs e)
		{
			if (Faculty.SelectedItem == null)
				return;
			var temp = Model.GetGroupIDPartial(FilterGroup.Text, (FacultyInfo)Faculty.SelectedItem);
			if (temp != null)
			{
				Group.SelectTab(temp);
			}
			else
			{
				MessageBox.Show("Такой группы не существует");
			}
			FilterGroup.Focus();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{

		}

		private void converterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var converter = new Converter();
			converter.ShowDialog();
			LoadMenu();
			Main_SelectedIndexChanged(sender, e);
		}

		private void включитьПроверкуНаДлинуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CheckLength)
			{
				включитьПроверкуНаДлинуToolStripMenuItem.CheckState = CheckState.Unchecked;
				CheckLength = false;
			}
			else
			{
				включитьПроверкуНаДлинуToolStripMenuItem.CheckState = CheckState.Checked;
				CheckLength = true;
			}
		}

		private void ExportMenuItem_Click(object sender, EventArgs e)
		{

			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			Status.Text = "Сохраняю...";
	//		Model.SaveToXML(saveFileDialog1.FileName);
			Model.GetShema(saveFileDialog1.FileName);
			Status.Text = "Готово";
			ProgressBar.Value = 0;
			MessageBox.Show("Данные успешно сохраны.");
		}

		private void ImportMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			ProgressBar.Step = 1;
			ProgressBar.Value = 0;
			ProgressBar.Maximum = File.ReadAllLines(openFileDialog1.FileName).Length - 25;
			Model.XMLToBase(openFileDialog1.FileName);
			Main.SelectedIndex = -1;
			MessageBox.Show("Импорт завершен.", "Внимание!");
		}

		private void DeleteBaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var delete = new DeleteElements();
			delete.ShowDialog();
			LoadMenu();
			Main_SelectedIndexChanged(sender, e);
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите выйти?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;
			Model.Serializable();
			Close();
		}
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите выйти?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				e.Cancel = true;
			Model.Serializable();
		}

		private void Update_Click(object sender, EventArgs e)
		{
			var up = new Update();
			up.ShowDialog();

		}

		private void конвертироватьДанныеИзФайлаSQLServerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(Application.StartupPath + @"\ConverterBDSQLToXML.exe");
		}

    private void hjToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var newForm = new ViewTwo();
      newForm.ShowDialog();
    }

    private void MainForm_ResizeEnd(object sender, EventArgs e)
    {
        Shcedule.Columns[0].Width = 50;
        var temp = Shcedule.ClientSize;
        for (var i = 1; i < Shcedule.ColumnCount; i++)
        {
            Shcedule.Columns[i].Width = (temp.Width - 81) / 8;
            Shcedule.Columns[i].MinimumWidth = (temp.Width - 81) / 8;
        }
        foreach (DataGridViewRow a in Shcedule.Rows)
            a.Height = (temp.Height - 30) / 6;
        Shcedule.RowTemplate.Height = temp.Height / 6;

    }

  }
}
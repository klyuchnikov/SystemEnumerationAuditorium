using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
    public partial class Viewer : UserControl
    {
        public Viewer()
        {
            InitializeComponent();
        }
        //public delegate void Resize(object sender, EventArgs e);
     //   public event  
        private void Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Main.SelectedIndex)
            {
                case 0:
                    ElemLabel.Text = "Преподаватель";
                    Elem.Items.Clear();
                    Elem.Items.AddRange(Model.GetAll.Teachers());
                    Period.SelectedIndex = -1;
                    PodElem.Visible = false;
                    PodElemLabel.Visible = false;
                    Elem.Enabled = true;
                    break;
                case 1:
                    ElemLabel.Text = "Аудитория";
                    PodElemLabel.Text = "Корпус";
                    PodElem.Items.Clear();
                    PodElem.Items.AddRange(Model.GetAll.Location());
                    Elem.SelectedIndex = -1;
                    Period.SelectedIndex = -1;
                    PodElemLabel.Visible = true;
                    PodElem.Visible = true;
                    Elem.Enabled = false;
                    break;
                case 2:
                    ElemLabel.Text = "Группа";
                    PodElemLabel.Text = "Факультет";
                    PodElem.Items.Clear();
                    PodElem.Items.AddRange(Model.GetAll.Fuculty());
                    Elem.SelectedIndex = -1;
                    Period.SelectedIndex = -1;
                    PodElemLabel.Visible = true;
                    PodElem.Visible = true;
                    Elem.Enabled = false;
                    break;
            }
            Period.Enabled = false;
        }

        private void Elem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Period.Items.Clear();
            Period.Enabled = true;
            Period.Items.AddRange(Model.GetAll.Periods());
        }

        private void PodElem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Elem.Items.Clear();
            Period.SelectedIndex = -1;
            Period.Enabled = false;
            Elem.Enabled = true;
            if (Main.SelectedIndex == 1)
                Elem.Items.AddRange(Model.GetAuditoriumsFromLocation((LocationInfo)PodElem.SelectedItem));
            if (Main.SelectedIndex == 2)
                Elem.Items.AddRange(Model.GetGroupFromFaculty((FacultyInfo)PodElem.SelectedItem));
        }

        private void ClearDataGrid()
        {
            Shcedule.Rows.Clear();
            var dictionary = new Dictionary<int, string>{
			  {0,"Пн"},{1,"Вт"},{2,"Ср"},{3,"Чт"},{4,"Пт"},{5,"Сб"}};
            for (var i = 0; i < 6; i++)
                Shcedule.Rows.Add(dictionary[i]);
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

        private void Period_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataGrid();
            if (Period.SelectedIndex == -1)
                return;
            ScheduleInfo[] sched = null;
            switch (Main.SelectedIndex)
            {
                case 0:
                    sched = Model.GetScheduleFromTeachers(
                        (TeacherInfo)Elem.SelectedItem,
                        (PeriodInfo)Period.SelectedItem);
                    break;
                case 1:
                    sched = Model.GetScheduleFromAuditorium(
                        (AuditoriumInfo)Elem.SelectedItem,
                        (PeriodInfo)Period.SelectedItem);
                    break;
                case 2:
                    sched = Model.GetScheduleFromGroup(
                        (GroupInfo)Elem.SelectedItem,
                        (PeriodInfo)Period.SelectedItem);
                    break;
            }
            if (sched == null)
                return;
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
                        arr[k] = Model.GetAbridgement(arr[k]);
                    Shcedule.Rows[i].Cells[j].Value = String.Join("\n", arr);
                    Shcedule.Rows[i].Cells[j].Tag = temp;
                }
            }
            Shcedule_Resize(sender, e);
        }

        private void Shcedule_Resize(object sender, EventArgs e)
        {
            Shcedule.Columns[0].Width = 50;
            var size = Shcedule.ClientSize;
            for (var i = 1; i < Shcedule.ColumnCount; i++)
            {
                Shcedule.Columns[i].Width = (size.Width - 81) / 8;
                Shcedule.Columns[i].MinimumWidth = (size.Width - 81) / 8;
            }
            foreach (DataGridViewRow a in Shcedule.Rows)
                a.Height = size.Height / 6;
            Shcedule.RowTemplate.Height = size.Height / 6;
        }
    }

}

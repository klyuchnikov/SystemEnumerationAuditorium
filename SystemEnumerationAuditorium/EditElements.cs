using System;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class EditElements : Form
	{
		public EditElements(Type type, object add)
		{
			_added = add;
			_type = type;
			InitializeComponent();
			LoadListBox();
			EditBase = false;
		}
		private readonly Type _type;
		private readonly object _added;
		public bool EditBase;
		private void Add_Click(object sender, EventArgs e)
		{
			string strAdd = null;
			if (_type == typeof(AuditoriumInfo))
			{
				var add = new AddAuditorium(null, 0, "", 0, "", false);
				if (add.ShowDialog() == DialogResult.OK)
				{
					EditBase = true;
					Model.Add.Auditorium(add.number,
					add.Capacity, add.NumbComp, add.QualityComp,
					add.AvailabilityProjector, (LocationInfo)_added);
				}
			}
			else
			{
				var a = new Add(null, _type, null);
				EducationInfo edu = null;
				if (a.ShowDialog() == DialogResult.OK)
				{
					strAdd = a.strNew;
					edu = a.Edu;
				}
				if (strAdd != null)
				{
					EditBase = true;
					if (_type == typeof(FacultyInfo))
						Model.Add.Faculty(strAdd);
					else if (_type == typeof(TeacherInfo))
						Model.Add.Teacher(strAdd);
					else if (_type == typeof(LocationInfo))
						Model.Add.Location(strAdd);
					else if (_type == typeof(EducationInfo))
						Model.Add.Education(strAdd);
					else if (_type == typeof(GroupInfo))
						Model.Add.Group(strAdd, (FacultyInfo)_added, edu);
					else if (_type == typeof(DisciplineInfo))
						Model.Add.Discipline(strAdd, (TeacherInfo)_added);
				}
			}
			LoadListBox();
		}
		private void LoadListBox()
		{
			list.Items.Clear();
			if (_type == typeof(TeacherInfo))
				foreach (var t in Model.GetAll.Teachers())
					list.Items.Add(t);
			else if (_type == typeof(FacultyInfo))
				foreach (var t in Model.GetAll.Fuculty())
					list.Items.Add(t);
			else if (_type == typeof(LocationInfo))
				foreach (var t in Model.GetAll.Location())
					list.Items.Add(t);
			else if (_type == typeof(AuditoriumInfo))
				foreach (var t in Model.GetAuditoriumsFromLocation((LocationInfo)_added))
					list.Items.Add(t);
			else if (_type == typeof(DisciplineInfo))
				foreach (var t in Model.GetDisciplinesFromTeacher((TeacherInfo)_added))
					list.Items.Add(t);
			else if (_type == typeof(GroupInfo))
				foreach (var t in Model.GetGroupFromFaculty((FacultyInfo)_added))
					list.Items.Add(t);
			else if (_type == typeof(EducationInfo))
				foreach (var t in Model.GetAll.Education())
					list.Items.Add(t);
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			if (list.SelectedItem == null)
			{
				MessageBox.Show("Элемент не выбран");
			}
			else
			{
				EditBase = true;
				foreach (var s in list.SelectedItems)
				{
					if (_type == typeof(TeacherInfo))
						Model.Delete.Teacher((TeacherInfo)s);
					if (_type == typeof(FacultyInfo))
						Model.Delete.Faculty((FacultyInfo)s);
					if (_type == typeof(DisciplineInfo))
						Model.Delete.Discipline((DisciplineInfo)s);
					if (_type == typeof(EducationInfo))
						Model.Delete.Education((EducationInfo)s);
					if (_type == typeof(GroupInfo))
						Model.Delete.Group((GroupInfo)s);
					if (_type == typeof(LocationInfo))
						Model.Delete.Location((LocationInfo)s);
					if (_type == typeof(AuditoriumInfo))
						Model.Delete.Auditorium((AuditoriumInfo)s);
				}
				LoadListBox();
			}
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			if (list.SelectedItem == null)
			{
				MessageBox.Show("Элемент не выбран");
			}
			else
			{
				if (_type == typeof(AuditoriumInfo))
				{
					var s = (AuditoriumInfo)list.SelectedItem;
					var au = new AddAuditorium(s.Number, s.Capacity,
						s.AvailabilityProjector, s.NumbComp, s.QualityComp, true);
					if (au.ShowDialog() == DialogResult.OK)
					{
						EditBase = true;
						Model.Edit.Auditorium(s, au.number, au.Capacity, au.NumbComp, au.QualityComp,
							au.AvailabilityProjector);
					}
				}
				else
				{
					var selected = list.SelectedItem;
					EducationInfo edu = null;
					if (_type == typeof(GroupInfo))
						edu = Model.GetEducationFromGroup((GroupInfo)selected);
					var a = new Add(selected.ToString(), _type, edu);
					string strAdd = null;
					if (a.ShowDialog() == DialogResult.OK)
					{
						strAdd = a.strNew;
						edu = a.Edu;
					}
					if (strAdd != null)
					{
						EditBase = true;
						if (_type == typeof(FacultyInfo))
							Model.Edit.Faculty(((FacultyInfo)selected), strAdd);
						else if (_type == typeof(TeacherInfo))
							Model.Edit.Teacher(((TeacherInfo)selected), strAdd);
						else if (_type == typeof(DisciplineInfo))
							Model.Edit.Discipline(((DisciplineInfo)selected), strAdd);
						else if (_type == typeof(EducationInfo))
							Model.Edit.Education(((EducationInfo)selected), strAdd);
						else if (_type == typeof(GroupInfo))
							Model.Edit.Group(((GroupInfo)selected), strAdd, edu);
						else if (_type == typeof(LocationInfo))
							Model.Edit.Location(((LocationInfo)selected), strAdd);
					}
				}
				LoadListBox();
			}
		}
	}
}

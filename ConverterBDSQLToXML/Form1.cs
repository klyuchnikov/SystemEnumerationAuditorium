using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ConverterBDSQLToXML
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();	
		}

		readonly BaseDataSet dataSet = new BaseDataSet();

		private void button1_Click(object sender, EventArgs e)
		{
			dataSet.ReadXmlSchema(Application.StartupPath + @"\Schema.xml");
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			var sb = new SqlConnectionStringBuilder
			{
				AttachDBFilename = openFileDialog1.FileName,
				DataSource = @".\SQLEXPRESS",
				IntegratedSecurity = true,
				UserInstance = true
			};
			var dataSQL = new DataDataContext(sb.ToString());
			foreach (var faculty in dataSQL.Faculty.Select(q => q))
			{
				dataSet.Faculty.AddFacultyRow(faculty.Name);
			}
			foreach (var faculty in dataSQL.Abridgement.Select(q => q))
			{
				dataSet.Abridgement.AddAbridgementRow(faculty.source, faculty.abridged);
			}
			foreach (var faculty in dataSQL.Teachers.Select(q => q))
			{
				dataSet.Teachers.AddTeachersRow(faculty.Name);
			}
			foreach (var faculty in dataSQL.Disciplines.Select(q => q))
			{
				dataSet.Disciplines.AddDisciplinesRow(faculty.Name);
			}
			foreach (var s in dataSQL.Education.Select(q => q))
			{
				dataSet.Education.AddEducationRow(s.Name);
			}
			foreach (var s in dataSQL.Location.Select(q => q))
			{
				dataSet.Location.AddLocationRow(s.Name);
			}
			foreach (var s in dataSQL.Periods.Select(q => q))
			{
				dataSet.Periods.AddPeriodsRow(s.Name);
			}
			foreach (var s in dataSQL.Group.Select(q => q))
			{
				dataSet.Group.AddGroupRow(s.Name,
					dataSet.Faculty.Single(q => q.Name == s.Faculty.Name),
					dataSet.Education.Single(q => q.Name == s.Education.Name));
			}
			foreach (var s in dataSQL.Auditoriums.Select(q => q))
			{
				dataSet.Auditoriums.AddAuditoriumsRow(s.Number, (int)s.Capacity, (int)s.NumbComp, s.QualityComp, s.AvailabilityProjector,
					dataSet.Location.Single(q => q.Name == s.Location.Name));
			}
			foreach (var s in dataSQL.DiscipTeachers.Select(q => q))
			{
				dataSet.DiscipTeachers.AddDiscipTeachersRow(
					dataSet.Disciplines.Single(q => q.Name == s.Disciplines.Name),
					dataSet.Teachers.Single(q => q.Name == s.Teachers.Name));
			}
			foreach (var s in dataSQL.Schedule.Select(q => q))
			{
				dataSet.Schedule.AddScheduleRow((int)s.Para, (int)s.DayWeek,
					dataSet.Periods.Single(q => q.Name == s.Periods.Name),
					dataSet.Group.Single(q => q.Name == s.Group.Name),
					dataSet.Disciplines.Single(q => q.Name == s.Disciplines.Name),
					dataSet.Teachers.Single(q => q.Name == s.Teachers.Name),
					dataSet.Auditoriums.Single(q => q.Number == s.Auditoriums.Number && q.LocationRow.Name == s.Auditoriums.Location.Name));
			}
			dataSet.WriteXml(saveFileDialog1.FileName);
			MessageBox.Show("Данные успешно конвертированы");
		}
	}
}

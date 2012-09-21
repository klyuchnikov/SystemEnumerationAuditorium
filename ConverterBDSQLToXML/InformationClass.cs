
namespace ConverterBDSQLToXML
{
	public class ScheduleExceptionInfo
	{
		public int ID_Exception
		{
			get;
			set;
		}
		public int ID_Auditorium
		{
			get;
			set;
		}
		public int ID_Discipline
		{
			get;
			set;
		}
		public int ID_Group
		{
			get;
			set;
		}
		public string Day
		{
			get;
			set;
		}
		public int ID_Teacher
		{
			get;
			set;
		}
		public int Para
		{
			get;
			set;
		}
		public int DayWeek
		{
			get;
			set;
		}
		public string AuditoriumNumber
		{
			get;
			set;
		}
		public int ID_Location
		{
			get;
			set;
		}
		public int ID_Faculty
		{
			get;
			set;
		}		
		public string GroupName
		{
			get;
			set;
		}
		public string PeriodName
		{
			get;
			set;
		}

		public string TeacherName
		{
			get;
			set;
		}
		public string DisciplineName
		{
			get;
			set;
		}
		public ScheduleExceptionInfo()
		{
		}

		public ScheduleExceptionInfo(BaseDataSet.ScheduleExceptionRow s)
		{
			ID_Exception = s.ID_Exception;
			ID_Auditorium = s.ID_Auditorium;
			AuditoriumNumber = s.AuditoriumsRow.Number;
			ID_Discipline = s.ID_Discipline;
			DisciplineName = s.DisciplinesRow.Name;
			ID_Group = s.ID_Group;
			GroupName = s.GroupRow.Name;
			Day = s.Day;
			ID_Teacher = s.ID_Teacher;
			TeacherName = s.TeachersRow.Name;
			Para = s.Para;
			DayWeek = s.DayWeek;
			ID_Location = s.AuditoriumsRow.ID_Location;
			ID_Faculty = s.GroupRow.ID_Faculty;
		}
	}

	public class AbridgementInfo
	{
		public string Source
		{
			get;
			set;
		}
		public string Abridged
		{
			get;
			set;
		}
		public int ID
		{
			get;
			set;
		}
		public  AbridgementInfo(BaseDataSet.AbridgementRow a)
		{
			ID = a.ID;
			Source = a.source;
			Abridged = a.abridged;
		}
		public override string ToString()
		{
			return Source + " -> " + Abridged;
		}
	}
	public class TeacherInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Teacher
		{
			get;
			set;
		}

		public TeacherInfo(BaseDataSet.TeachersRow p)
		{
			Name = p.Name;
			ID_Teacher = p.ID_Teacher;
		}
		public override string ToString()
		{
			return Name;
		}
	}
	public class DisciplineInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Discipline
		{
			get;
			set;
		}

		public DisciplineInfo(BaseDataSet.DisciplinesRow p)
		{
			Name = p.Name;
			ID_Discipline = p.ID_Discipline;
		}
		public override string ToString()
		{
			return Name;
		}
	}
	public class EducationInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Education
		{
			get;
			set;
		}

		public EducationInfo(BaseDataSet.EducationRow p)
		{
			Name = p.Name;
			ID_Education = p.ID_Education;
		}
		public override string ToString()
		{
			return Name;
		}
	}
	public class FacultyInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Faculty
		{
			get;
			set;
		}

		public FacultyInfo(BaseDataSet.FacultyRow p)
		{
			Name = p.Name;
			ID_Faculty = p.ID_Faculty;
		}
		public override string ToString()
		{
			return Name;
		}
	}

	public class GroupInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Group
		{
			get;
			set;
		}
		public int ID_Education
		{
			get;
			set;
		}
		public int ID_Faculty
		{
			get;
			set;
		}
		public GroupInfo(BaseDataSet.GroupRow p)
		{
			Name = p.Name;
			ID_Group = p.ID_Group;
			ID_Education = p.ID_Education;
			if (!p.IsID_FacultyNull())
				ID_Faculty = ID_Faculty;
		}
		public override string ToString()
		{
			return Name;
		}
	}
	public class PeriodInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Period
		{
			get;
			set;
		}

		public PeriodInfo(BaseDataSet.PeriodsRow p)
		{
			Name = p.Name;
			ID_Period = p.ID_Period;
		}
		public override string ToString()
		{
			return Name;
		}
	}
	public class AuditoriumInfo
	{
		public string Number
		{
			get;
			set;
		}
		public int ID_Auditorium
		{
			get;
			set;
		}
		public int Capacity
		{
			get;
			set;
		}
		public int NumbComp
		{
			get;
			set;
		}
		public string AvailabilityProjector
		{
			get;
			set;
		}
		public string QualityComp
		{
			get;
			set;
		}
		public int ID_Location
		{
			get;
			set;
		}
		public AuditoriumInfo(BaseDataSet.AuditoriumsRow p)
		{
			Number = p.Number;
			ID_Auditorium = p.ID_Auditorium;
			Capacity = p.Capacity;
			NumbComp = p.NumbComp;
			QualityComp = p.QualityComp;
			AvailabilityProjector = p.AvailabilityProjector;
			ID_Location = p.ID_Location;
		}
		public override string ToString()
		{
			return Number;
		}
	}

	public class ScheduleInfo
	{
		public int ID
		{
			get;
			set;
		}
		public int ID_Auditorium
		{
			get;
			set;
		}
		public int ID_Discipline
		{
			get;
			set;
		}
		public int ID_Group
		{
			get;
			set;
		}
		public int ID_Period
		{
			get;
			set;
		}
		public int ID_Teacher
		{
			get;
			set;
		}
		public int Para
		{
			get;
			set;
		}
		public int DayWeek
		{
			get;
			set;
		}
		public string AuditoriumNumber
		{
			get;
			set;
		}
		public int ID_Location
		{
			get;
			set;
		}
		public int ID_Faculty
		{
			get;
			set;
		}		
		public string GroupName
		{
			get;
			set;
		}
		public string PeriodName
		{
			get;
			set;
		}

		public string TeacherName
		{
			get;
			set;
		}
		public string DisciplineName
		{
			get;
			set;
		}
		public string LocationName
		{
			get;
			set;
		}

		public ScheduleInfo()
		{
		}

		public ScheduleInfo(BaseDataSet.ScheduleRow s)
		{
			ID = s.ID;
			ID_Auditorium = s.ID_Auditorium;
			AuditoriumNumber = s.AuditoriumsRow.Number;
			ID_Discipline = s.ID_Discipline;
			DisciplineName = s.DisciplinesRow.Name;
			ID_Group = s.ID_Group;
			GroupName = s.GroupRow.Name;
			ID_Period = s.ID_Period;
			PeriodName = s.PeriodsRow.Name;
			ID_Teacher = s.ID_Teacher;
			TeacherName = s.TeachersRow.Name;
			Para = s.Para;
			DayWeek = s.DayWeek;
			ID_Location = s.AuditoriumsRow.ID_Location;
			ID_Faculty = s.GroupRow.ID_Faculty;
			LocationName = s.AuditoriumsRow.LocationRow.Name;
		}
	}

	public class LocationInfo
	{
		public string Name
		{
			get;
			set;
		}
		public int ID_Location
		{
			get;
			set;
		}
		public LocationInfo(BaseDataSet.LocationRow p)
		{
			Name = p.Name;
			ID_Location = p.ID_Location;
		}
		public override string ToString()
		{
			return Name;
		}
	}
}
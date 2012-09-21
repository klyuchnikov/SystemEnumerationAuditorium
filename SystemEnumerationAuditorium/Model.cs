using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using SystemEnumerationAuditorium;
namespace SystemEnumerationAuditorium
{

	public class Model
	{
		private static readonly BaseDataSet Db = new BaseDataSet();
		public static void Load()
		{
			Db.Clear();
			if (File.Exists(Application.StartupPath + @"\base.ds"))
				Db.ReadXml(Application.StartupPath + @"\base.ds");
			else
			{
        Db.Periods.AddPeriodsRow("1 Неделя 1 Полупериод");
        Db.Periods.AddPeriodsRow("2 Неделя 1 Полупериод");
        Db.Periods.AddPeriodsRow("1 Неделя 2 Полупериод");
        Db.Periods.AddPeriodsRow("2 Неделя 2 Полупериод");
        Db.Periods.AddPeriodsRow("Зачетная Неделя");
        Db.Periods.AddPeriodsRow("1 Неделя Сессии");
        Db.Periods.AddPeriodsRow("2 Неделя Сессии");
        Db.Periods.AddPeriodsRow("3 Неделя Сессии");
  		}
			for (int i = 0; i < Db.Tables.Count; i++)
			{
				for (int j = 0; j < Db.Tables[i].Columns.Count; j++)
				{
					Db.Tables[i].Columns[j].AllowDBNull = false;
				} 
			}
		}
		public static void GetShema(string path)
		{
			Db.WriteXmlSchema(path);
		}

		public static GroupInfo GetGroupFromGroupID(int ID_Group)
		{
			return (from a in Db.Group
							where a.ID_Group == ID_Group
							select new GroupInfo(a)).Single();
		}
		public static AuditoriumInfo GetAuditoriumFromAuditoriumID(int ID_Auditorium)
		{
			return (from a in Db.Auditoriums
							where a.ID_Auditorium == ID_Auditorium
							select new AuditoriumInfo(a)).Single();
		}
		public static DisciplineInfo GetDisciplineFromDisciplineID(int ID_Discipline)
		{
			return (from a in Db.Disciplines
							where a.ID_Discipline == ID_Discipline
							select new DisciplineInfo(a)).Single();
		}

		public static DisciplineInfo GetDisciplineFromString(string str, TeacherInfo teacher)
		{
			var temp = (from a in Db.Disciplines
									where a.Name == str
									select a).SingleOrDefault();
			var teach = Db.Teachers.FindByID_Teacher(teacher.ID_Teacher);
			if (temp == null)
			{
				var disp = Db.Disciplines.AddDisciplinesRow(str);
				Db.AcceptChanges();

				Db.DiscipTeachers.AddDiscipTeachersRow(disp, teach);
				Db.AcceptChanges();
				return new DisciplineInfo(disp);
			}
			var temp2 = (from a in Db.DiscipTeachers
									 where a.ID_Teacher == teacher.ID_Teacher && a.ID_Discipline == temp.ID_Discipline
									 select a).SingleOrDefault();
			if (temp2 == null)
			{
				Db.DiscipTeachers.AddDiscipTeachersRow(temp, teach);
				Db.AcceptChanges();
			}
			return new DisciplineInfo(temp);
		}

		public static TeacherInfo GetTeacherFromString(string str)
		{
			var temp = (from a in Db.Teachers
									where a.Name == str
									select a).SingleOrDefault();
			if (temp == null)
			{
				var teacher = Db.Teachers.AddTeachersRow(str);
				Db.AcceptChanges();
				return new TeacherInfo(teacher);
			}
			return new TeacherInfo(temp);
		}

		public static AuditoriumInfo GetAuditoriumFromString(string str, LocationInfo loc)
		{
			var temp = (from a in Db.Auditoriums
									where a.Number == str && a.ID_Location == loc.ID_Location
									select a).SingleOrDefault();
			if (temp == null)
			{
				var au = Db.Auditoriums.NewAuditoriumsRow();
				au.ID_Location = loc.ID_Location;
				au.Number = str;
        au.AvailabilityProjector = "Нет";
        au.Capacity = 1;
        au.NumbComp = 0;
        au.QualityComp = "";
				Db.Auditoriums.AddAuditoriumsRow(au);
				Db.AcceptChanges();
				return new AuditoriumInfo(au);
			}
			return new AuditoriumInfo(temp);
		}
		public static LocationInfo GetLocationFromString(string str)
		{
			var temp = (from a in Db.Location
									where a.Name == str
									select a).SingleOrDefault();
			if (temp == null)
			{
				var loc = Db.Location.AddLocationRow(str);
				Db.AcceptChanges();
				return new LocationInfo(loc);
			}
			return new LocationInfo(temp);
		}

		public static GroupInfo GetGroupFromString(string str, EducationInfo edu, string fac)
		{
			var temp = (from a in Db.Group
									where a.Name == str
									select a).SingleOrDefault();
			if (temp == null)
			{
				var group = Db.Group.NewGroupRow();
				group.Name = str;
				group.ID_Education = edu.ID_Education;
        group.FacultyRow = GetFacultyFromString(fac);
				Db.Group.AddGroupRow(group);
				Db.AcceptChanges();
				return new GroupInfo(group);
			}
			return new GroupInfo(temp);
		}

    public static BaseDataSet.FacultyRow GetFacultyFromString(string str)
    {
      var temp = Db.Faculty.SingleOrDefault(a => a.Name == str);
      if (temp == null)
      {
        var fac = Db.Faculty.NewFacultyRow();
        fac.Name = str;
        Db.Faculty.AddFacultyRow(fac);
        Db.AcceptChanges();
        return fac;
      }
      return temp;
    }

		public static GroupInfo[] GetGroupFromFaculty(FacultyInfo faculy)
		{
			var group = from g in Db.Group
									where g.ID_Faculty == faculy.ID_Faculty
									select new GroupInfo(g);
			return group.ToArray();
		}

		public static GroupInfo[] GetGroupFromEducation(EducationInfo edu)
		{
			var group = from g in Db.Group
									where g.EducationRow.ID_Education == edu.ID_Education
									select new GroupInfo(g);
			return group.ToArray();
		}

		public static GroupInfo[] GetGroupFromFacultyAndKurs(FacultyInfo facultyInfo, int kurs)
		{
			GroupInfo[] temp;
			try
			{
				temp = (from a in Db.Group
				        where a.ID_Faculty == facultyInfo.ID_Faculty
				        where Convert.ToInt32(a.Name.Substring(a.Name.Length - 2, 1)) == kurs
				        select new GroupInfo(a)).ToArray();
			}
			catch (Exception)
			{
				return null;
			}

			return temp;
		}

		public static EducationInfo GetEducationFromGroup(GroupInfo gropp)
		{
			var temp = Db.Group.Single(a => a.ID_Group == gropp.ID_Group);
			return new EducationInfo(temp.EducationRow);
		}

		public static AuditoriumInfo[] GetAuditoriumsFromLocation(LocationInfo location)
		{
			var audit = from a in Db.Auditoriums
									where a.ID_Location == location.ID_Location
									select new AuditoriumInfo(a);
			return audit.ToArray();
		}

		public static DisciplineInfo[] GetDisciplinesFromTeacher(TeacherInfo teacher)
		{
			var disp = from d in Db.DiscipTeachers
								 where d.ID_Teacher == teacher.ID_Teacher
								 select new DisciplineInfo(d.DisciplinesRow);
			return disp.ToArray();
		}

		public static DisciplineInfo[] GetDisciplinesFromTwoTeacher(TeacherInfo teacher1, TeacherInfo teacher2)
		{
			if (teacher1 == null)
				return null;
			var disp1 = (Db.DiscipTeachers.Where(d => d.ID_Teacher == teacher1.ID_Teacher)
				.Select(d => new DisciplineInfo(d.DisciplinesRow))).ToArray();
			if (teacher2 == null)
				return null;
			var disp2 = (Db.DiscipTeachers.Where(d => d.ID_Teacher == teacher2.ID_Teacher)
					.Select(d => new DisciplineInfo(d.DisciplinesRow))).ToArray();
			return disp1.Intersect(disp2, new MyDisciplineComparer()).ToArray();
		}

		public static string GetTeacherIDPartial(string name)
		{
			var teacher = (from t in Db.Teachers
										 where t.Name.ToUpper().StartsWith(name.ToUpper())
										 select t).FirstOrDefault();
			return teacher != null ? teacher.Name : null;
		}

		public static TeacherInfo[] GetTeacherInfoIDPartial(string name)
		{
			var teacher = from t in Db.Teachers
										where t.Name.ToUpper().StartsWith(name.ToUpper())
										select new TeacherInfo(t);
			return teacher.ToArray();
		}

		public static string GetAuditoriumIDPartial(string name, LocationInfo loc)
		{
			var au = (from t in Db.Auditoriums
								where t.Number.ToUpper().StartsWith(name.ToUpper()) && t.ID_Location == loc.ID_Location
								select t).FirstOrDefault();
			return au != null ? au.Number : null;
		}

		public static string GetGroupIDPartial(string name, FacultyInfo fac)
		{
			var g = (from t in Db.Group
							 where t.Name.ToUpper().StartsWith(name.ToUpper()) && t.ID_Faculty == fac.ID_Faculty
							 select t).FirstOrDefault();
			return g != null ? g.Name : null;
		}
		public class MyTeacherComparer : IEqualityComparer<TeacherInfo>
		{
			public bool Equals(TeacherInfo a, TeacherInfo b)
			{
				return (a.ID_Teacher == b.ID_Teacher);
			}
			public int GetHashCode(TeacherInfo a)
			{
				return a.ID_Teacher.GetHashCode();
			}
		}

		public class MyComparerName : IComparer<TeacherInfo>, IComparer<GroupInfo>, IComparer<LocationInfo>, IComparer<FacultyInfo>,
			IComparer<AuditoriumInfo>, IComparer<EducationInfo>, IComparer<PeriodInfo>, IComparer<DisciplineInfo>
		{
			public int Compare(TeacherInfo a, TeacherInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
			public int Compare(GroupInfo a, GroupInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
			public int Compare(LocationInfo a, LocationInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
			public int Compare(FacultyInfo a, FacultyInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
			public int Compare(AuditoriumInfo a, AuditoriumInfo b)
			{
				return (a.Number.CompareTo(b.Number));
			}
			public int Compare(EducationInfo a, EducationInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
			public int Compare(PeriodInfo a, PeriodInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
			public int Compare(DisciplineInfo a, DisciplineInfo b)
			{
				return (a.Name.CompareTo(b.Name));
			}
		}

		public class MyAuditoriumComparer : IEqualityComparer<AuditoriumInfo>
		{
			public bool Equals(AuditoriumInfo a, AuditoriumInfo b)
			{
				return (a.ID_Auditorium == b.ID_Auditorium);
			}
			public int GetHashCode(AuditoriumInfo a)
			{
				return a.ID_Auditorium.GetHashCode();
			}
		}

		public class MyDisciplineComparer : IEqualityComparer<DisciplineInfo>
		{
			public bool Equals(DisciplineInfo a, DisciplineInfo b)
			{
				return (a.ID_Discipline == b.ID_Discipline);
			}
			public int GetHashCode(DisciplineInfo a)
			{
				return a.ID_Discipline.GetHashCode();
			}
		}

		public class MyGroupComparer : IEqualityComparer<GroupInfo>
		{
			public bool Equals(GroupInfo a, GroupInfo b)
			{
				return (a.ID_Group == b.ID_Group);
			}
			public int GetHashCode(GroupInfo a)
			{
				return a.ID_Group.GetHashCode();
			}
		}

		public static int GetKursFromGroup(GroupInfo groupInfo)
		{
			return (Convert.ToInt32(groupInfo.Name.Substring(groupInfo.Name.Length - 2, 1)));
		}

		public static int GetMaxPara(IEnumerable<ScheduleInfo> sched)
		{
			int maxPara = 0;
			for (int i = 0; i < 6; i++)
			{
				int i1 = i;
				var temp = sched.Where(a => a.DayWeek == i1);
				if (temp == null)
					continue;
				foreach (var info in temp)
				{
					if (info.Para > maxPara)
						maxPara = info.Para;
				}
			}
			return maxPara;
		}

		public static TeacherInfo[] GetFreeTeachers(int ID_Period, int Para, int DayWeek)
		{
			var temp = (Db.Schedule.Where(a => a.DayWeek == DayWeek &&
																				 a.ID_Period == ID_Period &&
																				 a.Para == Para).Select(a => new TeacherInfo(a.TeachersRow))).ToArray();
			var all = GetAll.Teachers();
			return all.Except(temp, new MyTeacherComparer()).ToArray();
		}

		public static TeacherInfo[] GetFreeTeachersAndCurrent(int ID_Period, int Para, int DayWeek, int ID_Teacher)
		{
			var temp = (from a in Db.Schedule
									where a.DayWeek == DayWeek &&
									a.ID_Period == ID_Period &&
									a.Para == Para &&
									a.ID_Teacher != ID_Teacher
									select new TeacherInfo(a.TeachersRow)).ToArray();
			var all = GetAll.Teachers();
			return all.Except(temp, new MyTeacherComparer()).ToArray();
		}

		public static AuditoriumInfo[] GetFreeAuditoriums(int ID_Period, int Para, int DayWeek)
		{
			var temp = (from a in Db.Schedule
									where a.DayWeek == DayWeek &&
									a.ID_Period == ID_Period &&
									a.Para == Para
									select new AuditoriumInfo(a.AuditoriumsRow)).ToArray();
			var all = GetAll.Auditoriums();
			return all.Except(temp, new MyAuditoriumComparer()).ToArray();
		}

		public static AuditoriumInfo[] GetFreeAuditoriumsAndCurrent(
			int ID_Period, int Para, int DayWeek, int ID_Auditorium)
		{
			var temp = (from a in Db.Schedule
									where a.DayWeek == DayWeek &&
									a.ID_Period == ID_Period &&
									a.Para == Para &&
									a.ID_Auditorium != ID_Auditorium
									select new AuditoriumInfo(a.AuditoriumsRow)).ToArray();
			var all = GetAll.Auditoriums();
			return all.Except(temp, new MyAuditoriumComparer()).ToArray();
		}

		public static GroupInfo[] GetFreeGroupsAndCurrent(int ID_Period, int Para, int DayWeek, int ID_Group)
		{
			var temp = (from a in Db.Schedule
									where a.DayWeek == DayWeek &&
									a.ID_Period == ID_Period &&
									a.Para == Para &&
									a.ID_Group != ID_Group
									select new GroupInfo(a.GroupRow)).ToArray();
			var all = GetAll.Group();
			return all.Except(temp, new MyGroupComparer()).ToArray();
		}

		public static GroupInfo[] GetFreeGroups(int ID_Period, int Para, int DayWeek)
		{
			var temp = (from a in Db.Schedule
									where a.DayWeek == DayWeek &&
									a.ID_Period == ID_Period &&
									a.Para == Para
									select new GroupInfo(a.GroupRow)).ToArray();
			var all = GetAll.Group();
			return all.Except(temp, new MyGroupComparer()).ToArray();
		}


		public static ScheduleInfo[] GetScheduleFromTeachers(TeacherInfo teacher, PeriodInfo period)
		{

			return (from s in Db.Schedule
							where (s.ID_Teacher == teacher.ID_Teacher) &&
							(s.ID_Period == period.ID_Period)
							select new ScheduleInfo(s)).ToArray();
		}

		public static ScheduleInfo[] GetScheduleFromAuditorium(AuditoriumInfo aud, PeriodInfo period)
		{
			return (from s in Db.Schedule
							where (s.ID_Auditorium == aud.ID_Auditorium) &&
							(s.ID_Period == period.ID_Period)
							select new ScheduleInfo(s)).ToArray();
		}

		public static string GetAbridgement(string str)
		{
			var temp = (from a in Db.Abridgement
									where a.source == str
									select a).SingleOrDefault();
			return temp == null ? str : temp.abridged;
		}


		public static ScheduleInfo[] GetScheduleFromGroup(GroupInfo g, PeriodInfo period)
		{
			return (from s in Db.Schedule
							where (s.ID_Group == g.ID_Group) &&
							(s.ID_Period == period.ID_Period)
							select new ScheduleInfo(s)).ToArray();
		}

		public static void SaveToXML(string fileName)
		{
			Db.WriteXml(fileName);
		}
		public static void XMLToBase(string path)
		{
			Db.Clear();
			Db.ReadXml(path);
		}

		public static void Serializable()
		{
			var t = File.Create(Application.StartupPath + @"\base.ds");
			Db.WriteXml(t);
			t.Close();
		}
		public static class GetAll
		{
			public static FacultyInfo[] Fuculty()
			{
				return (Db.Faculty.Select(f => new FacultyInfo(f))).ToArray();
			}
			public static int FucultyCount
			{
				get { return Db.Faculty.Count; }
			}

			public static TeacherInfo[] Teachers()
			{
				return (from f in Db.Teachers
								select new TeacherInfo(f)).ToArray();
			}
			public static int TeachersCount
			{
				get { return Db.Teachers.Count; }
			}
			public static AuditoriumInfo[] Auditoriums()
			{
				return (from f in Db.Auditoriums
								select new AuditoriumInfo(f)).ToArray();
			}

			public static DisciplineInfo[] Disciplines()
			{
				return (from f in Db.Disciplines
								select new DisciplineInfo(f)).ToArray();
			}

			public static EducationInfo[] Education()
			{
				return (from f in Db.Education
								select new EducationInfo(f)).ToArray();
			}

			public static GroupInfo[] Group()
			{
				return (from f in Db.Group
								select new GroupInfo(f)).ToArray();
			}

			public static PeriodInfo[] Periods()
			{
				return (from f in Db.Periods
								select new PeriodInfo(f)).ToArray();
			}

			public static LocationInfo[] Location()
			{
				return (from f in Db.Location
								select new LocationInfo(f)).ToArray();
			}
			public static int LocationCount
			{
				get { return Db.Location.Count; }
			}
			public static AbridgementInfo[] Abridgement()
			{
				return (from a in Db.Abridgement
								select new AbridgementInfo(a)).ToArray();
			}
		}
		public static bool IsExistsAbridgement(string str)
		{
			var temp = (from a in Db.Abridgement
									where a.source == str
									select a).SingleOrDefault();
			return temp == null ? false : true;
		}

		public static class Add
		{
			public static void Abridgement(string sourse, string abridged)
			{
				Db.Abridgement.AddAbridgementRow(sourse, abridged);
				Db.AcceptChanges();
			}

			public static void Schedule(int ID_Auditorium, int ID_Discipline, int ID_Group,
				int ID_Period, int ID_Teacher, int Para, int DayWeek)
			{
				var schedule = Db.Schedule.NewScheduleRow();
				schedule.ID_Auditorium = ID_Auditorium;
				schedule.ID_Discipline = ID_Discipline;
				schedule.ID_Group = ID_Group;
				schedule.ID_Period = ID_Period;
				schedule.ID_Teacher = ID_Teacher;
				schedule.Para = Para;
				schedule.DayWeek = DayWeek;
				Db.Schedule.AddScheduleRow(schedule);
				Db.AcceptChanges();
			}

			public static void Schedule(ScheduleInfo s)
			{
				Schedule(
					s.ID_Auditorium,
					s.ID_Discipline,
					s.ID_Group,
					s.ID_Period,
					s.ID_Teacher,
					s.Para,
					s.DayWeek);
			}


			public static void Faculty(string str)
			{
				Db.Faculty.AddFacultyRow(str);
				Db.AcceptChanges();
			}

			public static void Teacher(string str)
			{
				Db.Teachers.AddTeachersRow(str);
				Db.AcceptChanges();
			}

			public static void Group(string str, FacultyInfo faculty, EducationInfo edu)
			{
				var temp = Db.Group.NewGroupRow();
				temp.Name = str;
				temp.ID_Education = edu.ID_Education;
				temp.ID_Faculty = faculty.ID_Faculty;
				Db.Group.AddGroupRow(temp);
				Db.AcceptChanges();
			}

			public static void Discipline(string str, TeacherInfo teacher)
			{
				var disp = Db.Disciplines.AddDisciplinesRow(str);
				Db.AcceptChanges();
				var temp = Db.DiscipTeachers.NewDiscipTeachersRow();
				temp.ID_Teacher = teacher.ID_Teacher;
				temp.ID_Discipline = disp.ID_Discipline;
				Db.DiscipTeachers.AddDiscipTeachersRow(temp);
				Db.AcceptChanges();
			}
			public static void Location(string name)
			{
				Db.Location.AddLocationRow(name);
				Db.AcceptChanges();
			}
			public static void Auditorium(string number, int capacity, int comp, string quality, string projector, LocationInfo local)
			{
				var loc = Db.Location.FindByID_Location(local.ID_Location);
				Db.Auditoriums.AddAuditoriumsRow(number, capacity, comp, quality, projector, loc);
				Db.AcceptChanges();
			}

			public static void Education(string name)
			{
				Db.Education.AddEducationRow(name);
				Db.AcceptChanges();
			}

		}

		public static class Delete
		{
			public static class All
			{
				public static void Abridgement()
				{
					Db.Abridgement.Clear();
					Db.AcceptChanges();
				}

				public static void Schedule()
				{
					Db.Schedule.Clear();
					Db.AcceptChanges();
				}
				public static void ScheduleException()
				{
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Teacher()
				{
					Db.Teachers.Clear();
					Db.Disciplines.Clear();
					Db.DiscipTeachers.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Faculty()
				{
					Db.Faculty.Clear();
					Db.Group.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Group()
				{
					Db.Group.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Auditorium()
				{
					Db.Auditoriums.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Location()
				{
					Db.Location.Clear();
					Db.Auditoriums.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Education()
				{
					Db.Education.Clear();
					Db.Group.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
				public static void Discipline()
				{
					Db.Disciplines.Clear();
					Db.DiscipTeachers.Clear();
					Db.Schedule.Clear();
					Db.ScheduleException.Clear();
					Db.AcceptChanges();
				}
			}
			public static void Abridgement(AbridgementInfo abridgementInfo)
			{
				var temp = (from a in Db.Abridgement
										where a.ID == abridgementInfo.ID
										select a).Single();
				Db.Abridgement.RemoveAbridgementRow(temp);
				Db.AcceptChanges();
			}

			public static void Schedule(int ID_Period, int ID_Teacher, int Para, int DayWeek)
			{
				var temp = (from a in Db.Schedule
										where a.ID_Period == ID_Period &&
													a.ID_Teacher == ID_Teacher &&
													a.Para == Para &&
													a.DayWeek == DayWeek
										select a).ToArray();
				foreach (var schedule in temp)
					Db.Schedule.RemoveScheduleRow(schedule);
				Db.AcceptChanges();
			}
			public static void Schedule(ScheduleInfo[] s)
			{
				foreach (var info in s)
				{
					Schedule(info.ID_Period, info.ID_Teacher, info.Para, info.DayWeek);
				}
			}
			public static void ScheduleDayTeacher(int ID_Period, int ID_Teacher, int DayWeek)
			{
				var temp = (from a in Db.Schedule
									 where a.ID_Period == ID_Period &&
									 a.ID_Teacher == ID_Teacher &&
									 a.DayWeek == DayWeek
                    select a).ToArray();
				foreach (var t in temp)
					Db.Schedule.RemoveScheduleRow(t);
				Db.AcceptChanges();
			}
			public static void ScheduleWeekTeacher(int ID_Period, int ID_Teacher)
			{
				var temp = (from a in Db.Schedule
									 where a.ID_Period == ID_Period &&
									 a.ID_Teacher == ID_Teacher
                    select a).ToArray();
				foreach (var t in temp)
					Db.Schedule.RemoveScheduleRow(t);
				Db.AcceptChanges();
			}
			public static void ScheduleDayGroup(int ID_Period, int ID_Group, int DayWeek)
			{
				var temp = (from a in Db.Schedule
									 where a.ID_Period == ID_Period &&
									 a.ID_Group == ID_Group &&
									 a.DayWeek == DayWeek
                    select a).ToArray();
				foreach (var t in temp)
					Db.Schedule.RemoveScheduleRow(t);
				Db.AcceptChanges();
			}
			public static void ScheduleWeekGroup(int ID_Period, int ID_Group)
			{
				var temp = (from a in Db.Schedule
									 where a.ID_Group == ID_Group &&
									 a.ID_Period == ID_Period
									 select a).ToArray();
				foreach (var t in temp)
					Db.Schedule.RemoveScheduleRow(t);
				Db.AcceptChanges();
			}
			public static void ScheduleWeekAuditorium(int ID_Period, int ID_Auditorium)
			{
				var temp = (from a in Db.Schedule
									 where a.ID_Auditorium == ID_Auditorium &&
									 a.ID_Period == ID_Period
                    select a).ToArray();
				foreach (var t in temp)
					Db.Schedule.RemoveScheduleRow(t);
				Db.AcceptChanges();
			}

			public static void ScheduleDayAuditorium(int ID_Period, int ID_Auditorium, int DayWeek)
			{
				var temp = (from a in Db.Schedule
									 where a.ID_Period == ID_Period &&
									 a.ID_Auditorium == ID_Auditorium &&
									 a.DayWeek == DayWeek
									 select a).ToArray();
				foreach (var t in temp)
					Db.Schedule.RemoveScheduleRow(t);
				Db.AcceptChanges();
			}

			public static void Teacher(TeacherInfo teacher)
			{
				var temp = (from a in Db.DiscipTeachers
									 where a.ID_Teacher == teacher.ID_Teacher
                    select a.DisciplinesRow).ToArray();
				foreach (var t in temp)
					Db.Disciplines.RemoveDisciplinesRow(t);
				foreach (var row in Db.DiscipTeachers.Where(a => a.TeachersRow.Name == teacher.Name).ToArray())
					Db.DiscipTeachers.RemoveDiscipTeachersRow(row);
				foreach (var row in Db.Schedule.Where(a => a.TeachersRow.Name == teacher.Name).ToArray())
					Db.Schedule.RemoveScheduleRow(row);
				foreach (var row in Db.ScheduleException.Where(a => a.TeachersRow.Name == teacher.Name).ToArray())
					Db.ScheduleException.RemoveScheduleExceptionRow(row);
				Db.Teachers.RemoveTeachersRow(Db.Teachers.Single(a => a.ID_Teacher == teacher.ID_Teacher));
				Db.AcceptChanges();
			}
			public static void Faculty(FacultyInfo faculty)
			{
				foreach (GroupInfo f in GetGroupFromFaculty(faculty))
					Group(f);
        Db.Faculty.RemoveFacultyRow(Db.Faculty.Single(a => a.ID_Faculty == faculty.ID_Faculty));
				Db.AcceptChanges();
			}
			public static void Group(GroupInfo groupp)
			{
				foreach (var row in Db.Schedule.Where(a => a.GroupRow.Name == groupp.Name).ToArray())
					Db.Schedule.RemoveScheduleRow(row);
				foreach (var row in Db.ScheduleException.Where(a => a.GroupRow.Name == groupp.Name).ToArray())
					Db.ScheduleException.RemoveScheduleExceptionRow(row);
				Db.Group.RemoveGroupRow(Db.Group.Single(a => a.ID_Group == groupp.ID_Group));
				Db.AcceptChanges();
			}
			public static void Auditorium(AuditoriumInfo aud)
			{
				foreach (var row in Db.Schedule.Where(a => a.AuditoriumsRow.ID_Auditorium == aud.ID_Auditorium).ToArray())
					Db.Schedule.RemoveScheduleRow(row);
				foreach (var row in Db.ScheduleException.Where(a => a.AuditoriumsRow.ID_Auditorium == aud.ID_Auditorium).ToArray())
					Db.ScheduleException.RemoveScheduleExceptionRow(row);
				Db.Auditoriums.RemoveAuditoriumsRow(Db.Auditoriums.Single(a => a.ID_Auditorium == aud.ID_Auditorium));
				Db.AcceptChanges();
			}
			public static void Location(LocationInfo loc)
			{
				foreach (var info in GetAuditoriumsFromLocation(loc))
					Auditorium(info);
				Db.Location.RemoveLocationRow(Db.Location.Single(a => a.ID_Location == loc.ID_Location));
				Db.AcceptChanges();
			}
			public static void Education(EducationInfo edu)
			{
				foreach (var row in GetGroupFromEducation(edu))
					Group(row);
				Db.Education.RemoveEducationRow(Db.Education.Single(a => a.ID_Education == edu.ID_Education));
				Db.AcceptChanges();
			}
			public static void Discipline(DisciplineInfo dis)
			{
				foreach (var row in Db.DiscipTeachers.Where(a => a.DisciplinesRow.Name == dis.Name).ToArray())
					Db.DiscipTeachers.RemoveDiscipTeachersRow(row);
				foreach (var row in Db.Schedule.Where(a => a.DisciplinesRow.Name == dis.Name).ToArray())
					Db.Schedule.RemoveScheduleRow(row);
				foreach (var row in Db.ScheduleException.Where(a => a.DisciplinesRow.Name == dis.Name).ToArray())
					Db.ScheduleException.RemoveScheduleExceptionRow(row);
				Db.Disciplines.RemoveDisciplinesRow(Db.Disciplines.Single(a => a.ID_Discipline == dis.ID_Discipline));
				Db.AcceptChanges();
			}
		}

		public static class Edit
		{

			public static void Schedule(int ID, int ID_Discipline, int ID_Group, int ID_Auditorium)
			{
				var temp = (from a in Db.Schedule
										where a.ID == ID
										select a).Single();
				var t = Db.Schedule.NewScheduleRow();
				t.ID_Auditorium = ID_Auditorium;
				t.ID_Discipline = ID_Discipline;
				t.ID_Group = ID_Group;
				t.ID_Period = temp.ID_Period;
				t.ID_Teacher = temp.ID_Teacher;
				t.Para = temp.Para;
				t.DayWeek = temp.DayWeek;
				Db.Schedule.RemoveScheduleRow(temp);
				Db.Schedule.AddScheduleRow(t);
				Db.AcceptChanges();
			}


			public static void Faculty(FacultyInfo faculty, string newValue)
			{
				var fac = (from a in Db.Faculty
									 where a.ID_Faculty == faculty.ID_Faculty
									 select a).Single();
				fac.Name = newValue;
				Db.AcceptChanges();
			}
			public static void Teacher(TeacherInfo teacher, string newValue)
			{
				var teach = Db.Teachers.Single(a => a.ID_Teacher == teacher.ID_Teacher);
				teach.Name = newValue;
				Db.AcceptChanges();
			}
			public static void Discipline(DisciplineInfo disp, string newValue)
			{
				var d = Db.Disciplines.Single(a => a.ID_Discipline == disp.ID_Discipline);
				d.Name = newValue;
				Db.AcceptChanges();
			}
			public static void Group(GroupInfo groupp, string newValue, EducationInfo eduNew)
			{
				var d = Db.Group.Single(a => a.ID_Group == groupp.ID_Group);
				if (d.Name != newValue)
					d.Name = newValue;
				if (d.ID_Education != eduNew.ID_Education)
					d.ID_Education = eduNew.ID_Education;
				Db.AcceptChanges();
			}
			public static void Location(LocationInfo loc, string newValue)
			{
				var d = Db.Location.Single(a => a.ID_Location == loc.ID_Location);
				d.Name = newValue;
				Db.AcceptChanges();
			}
			public static void Education(EducationInfo edu, string newValue)
			{
				var d = Db.Education.Single(a => a.ID_Education == edu.ID_Education);
				d.Name = newValue;
				Db.AcceptChanges();
			}
			public static void Auditorium(AuditoriumInfo aud, string number, int capacity, int comp,
				string quality, string projector)
			{
				var temp = Db.Auditoriums.Single(a => a.ID_Auditorium == aud.ID_Auditorium);
				temp.Number = number;
				temp.Capacity = capacity;
				temp.NumbComp = comp;
				temp.QualityComp = quality;
				temp.AvailabilityProjector = projector;
				Db.AcceptChanges();
			}
		}

		public static List<string> GetName()
		{
			var list = new List<string>();
			var temp = Db.Group.Select(a => a);
			foreach (var group in temp)
			{
				if (!list.Contains(group.Name.Substring(0, group.Name.Length - 3)))
					list.Add(group.Name.Substring(0, group.Name.Length - 3));
			}
			list.Sort();
			return list;

		}

		public static void SetFaculty(string[] arr)
		{
			var temp = Db.Group.Where(q => q.Name.StartsWith(arr[0]));
			var fac = Db.Faculty.SingleOrDefault(q => q.Name == arr[1]);
			if (fac == null)
			{
				Add.Faculty(arr[1]);
				fac = Db.Faculty.SingleOrDefault(q => q.Name == arr[1]);
				foreach (var queryable in temp)
				{
					queryable.ID_Faculty = fac.ID_Faculty;
				}
			}
			else
				foreach (var queryable in temp)
				{
					queryable.ID_Faculty = fac.ID_Faculty;
				}
			Db.AcceptChanges();
		}
	}
}
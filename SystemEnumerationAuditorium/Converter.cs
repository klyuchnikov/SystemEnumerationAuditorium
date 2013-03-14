using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
            Edu.Items.AddRange(Model.GetAll.Education());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileGroup.ShowDialog() != DialogResult.OK)
                return;
            list.Items.Clear();
            list.Items.AddRange(openFileGroup.SafeFileNames);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Period.SelectedItem == null || Fidelity.Text == "" || list.Items.Count == 0 || Edu.SelectedItem == null)
            {
                MessageBox.Show("Вы что то забыли выбрать", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var count = 0;
            var FacultyStr = File.ReadAllLines(openFileFidelity.FileName, Encoding.Default);
            list.SelectedItem = null;
            list.SelectionMode = SelectionMode.MultiSimple;
            foreach (var name in openFileGroup.FileNames)
            {
                var edu = Period.SelectedIndex == 0 ? -1 : -3;
                list.SelectedIndices.Add(count);
                count++;
                toolStripStatusLabel1.Text = count + " из " + openFileGroup.FileNames.Count();
                Application.DoEvents();
                toolStripProgressBar1.Value = 0;
                var arr = File.ReadAllLines(name, Encoding.Default);
                var ind = 9;
                var temp = arr[ind++];
                var match = Regex.Match(temp, @">[\p{IsCyrillic}\p{P}\d\s]+</P>",
                                                                    RegexOptions.IgnoreCase);
                if (match.Value == "")
                {
                    //    MessageBox.Show("Преобразовать " + temp + " невозможно!");
                    continue;
                }
                temp = match.Value.Substring(1, match.Value.Length - 5).Trim();

                int conv;
                int.TryParse(temp.Substring(temp.Length - 2), out conv);
                if (!int.TryParse(temp.Substring(temp.Length - 2), out conv))
                {
                    //    MessageBox.Show("Преобразовать " + temp + " невозможно!");
                    continue;
                }
                var qw = temp.TakeWhile(q => q.ToString() == q.ToString().ToUpper());
                var faculty = FacultyStr.Select(q => q.Split(';')).SingleOrDefault(a => string.Concat(qw.ToArray()) == a[0]);
                //??
                //         "НЕОПРЕДЕЛЕННЫЕ";

                var group = Model.GetGroupFromString(temp, (EducationInfo)Edu.SelectedItem, faculty == null ? "НЕОПРЕДЕЛЕННЫЕ" : faculty[1]);

                ind = 50;
                for (int dayweek = 0; dayweek < 6; dayweek++)
                {
                    string value, dispStr, au, loc;
                    MatchCollection mAu, mcollection;
                    TeacherInfo teacher;
                    DisciplineInfo disp;
                    LocationInfo location;
                    AuditoriumInfo auditorium;
                    for (var para = 0; para < 8; para++)
                    {
                        ind += 2;
                        toolStripProgressBar1.PerformStep();
                        value = Regex.Match(arr[ind], @"CENTER"">(?<str>.*)</Font", RegexOptions.IgnoreCase).Groups["str"].Value.TrimStart();
                        if (value == "_    ")
                            continue;
                        mAu = Regex.Matches(value, @" а\.\S+");
                        mcollection = Regex.Matches(value, @"( [А-ЯЁ]{3,} [А-Я]( |\.)[А-Я]( |\.)|ПРЕПАДП\d?|АСС. ФИЗИКА \d)");
                        if (mAu.Count != mcollection.Count)
                            mcollection = Regex.Matches(value, @"( [А-ЯЁ]{3,} [А-Я]( |\.)([А-Я]( |\.))?|ПРЕПАДП\d?|АСС. ФИЗИКА \d)");
                        dispStr = value.Substring(0, mcollection[0].Index).Trim();
                        for (var k = 0; k < mcollection.Count; k++)
                        {
                            if (mcollection[k].Value == "" || mAu[k].Value == "")
                                continue;
                            teacher = Model.GetTeacherFromString(mcollection[k].Value.Trim());
                            disp = Model.GetDisciplineFromString(dispStr, teacher);
                            au = mAu[k].Value.Trim();
                            if (au.EndsWith("-"))
                                au = au.Substring(0, au.Length - 1);
                            if (au.Contains("(2") && !au.Contains(")"))
                                au = au.Substring(0, au.Length - 2);
                            else if (au.Contains("(2)") && !au.Contains("СЗ"))
                                au = au.Substring(0, au.Length - 3);
                            if (au.Contains("/3"))
                            {
                                loc = "3уч.к";
                                au = au.Substring(2, au.Length - 4);
                            }
                            else if (au.Contains("а.г"))
                            {
                                loc = "гл.к";
                                au = au.Substring(3, au.Length - 3);
                            }
                            else if (au.Contains("а.сф"))
                            {
                                loc = "сф.к";
                                au = au.Substring(4, au.Length - 4);
                            }
                            else if (au.Contains("а.э"))
                            {
                                loc = "э.к";
                                au = au.Substring(3, au.Length - 3);
                            }
                            else if (au.Contains("/2"))
                            {
                                loc = "2уч.к";
                                au = au.Substring(2, au.Length - 4);
                            }
                            else if (au.Contains("а.в"))
                            {
                                loc = "в";
                                au = au.Substring(3, au.Length - 3);
                            }
                            else if (au.Contains("а.КафИн"))
                            {
                                loc = "гл.к";
                                au = au.Substring(2, au.Length - 2);
                            }
                            else if (au.Contains("а.КафРОН"))
                            {
                                loc = "гл.к";
                                au = au.Substring(2, au.Length - 2);
                            }
                            else
                            {
                                loc = "н/д";
                                au = au.Substring(2, au.Length - 2);
                            }
                            location = Model.GetLocationFromString(loc);
                            auditorium = Model.GetAuditoriumFromString(au, location);
                            Model.Add.Schedule(auditorium.ID_Auditorium, disp.ID_Discipline, group.ID_Group,
                                ind < 164 ? edu : edu - 1, teacher.ID_Teacher, para + 1, dayweek);
                        }
                    }
                    ind += 3;
                    if (ind == 164)
                        dayweek = -1;
                }
            }


            //var t = new StreamReader(openFileFidelity.FileName, Encoding.Default);

            //while (!t.EndOfStream)
            //{
            //  var str = t.ReadLine();
            //  var arr = str.Split(';');
            //  Model.SetFaculty(arr);
            //}

            toolStripStatusLabel1.Text = "Готово";
            toolStripProgressBar1.Value = 0;
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileFidelity.ShowDialog() != DialogResult.OK)
                return;
            Fidelity.Text = openFileFidelity.SafeFileName;
        }
    }
}

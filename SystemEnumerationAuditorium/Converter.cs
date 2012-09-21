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
        var sr = new StreamReader(name, Encoding.Default);
        for (var j = 0; j < 9; j++)
          sr.ReadLine();
        var temp = sr.ReadLine();
        var match = Regex.Match(temp, @">[\p{IsCyrillic}\p{P}\d\s]+</P>",
                                                            RegexOptions.IgnoreCase);
        if (match.Value == "")
        {
          MessageBox.Show("Преобразовать " + temp + " невозможно!");
          continue;
        }
        temp = match.Value.Substring(1, match.Value.Length - 5).Trim();
        var i = 0;
        try
        {
          Convert.ToInt32(temp.Substring(temp.Length - 2));
        }
        catch
        {
          MessageBox.Show("Преобразовать " + temp + " невозможно!");
          continue;
        }
        var f = FacultyStr.Single(a => temp.StartsWith(a.Split(';')[0])).Split(';')[1];

        var group = Model.GetGroupFromString(temp, (EducationInfo)Edu.SelectedItem, f);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
          sr.ReadLine();
          sr.ReadLine();
          for (var j = 0; j < 8; j++)
          {
            sr.ReadLine();
            var str = sr.ReadLine();
            str = str.Substring(str.IndexOf("CENTER"));
            match = Regex.Match(str, @">[\p{IsCyrillic}\p{IsBasicLatin}\p{P}\d\s]+</",
                                                    RegexOptions.IgnoreCase);
            toolStripProgressBar1.PerformStep();
            var value = match.Value.Substring(1, match.Value.Length - 2).TrimStart();
            var mAu = Regex.Matches(value, @" а\.[сфгбАлабцвОбщМузейКафИнРОНСЗ.\p{P}\d]+");
            if (mAu.Count == 0)
              continue;
            var mcollection = Regex.Matches(value, @"([А-Я]+ [А-Я]( |.)[А-Я]( |.)|ПРЕПАДП|АСС. ФИЗИКА \d) ");
            var dispStr = value.Substring(0, mcollection[0].Index).Trim();
            for (var k = 0; k < mcollection.Count; k++)
            {
              if (mcollection[k].Value == "" || mAu[k].Value == "")
                continue;
              var teacher = Model.GetTeacherFromString(mcollection[k].Value);
              var disp = Model.GetDisciplineFromString(dispStr, teacher);
              var au = mAu[k].Value.Trim();
              if (au.EndsWith("-"))
                au = au.Substring(0, au.Length - 1);
              if (au.Contains("(2") && !au.Contains(")"))
                au = au.Substring(0, au.Length - 2);
              else if (au.Contains("(2)") && !au.Contains("СЗ"))
                au = au.Substring(0, au.Length - 3);
              string loc;
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
                continue;
              }
              var location = Model.GetLocationFromString(loc);
              var auditorium = Model.GetAuditoriumFromString(au, location);
              Model.Add.Schedule(auditorium.ID_Auditorium, disp.ID_Discipline, group.ID_Group,
                                 i < 8 ? edu : edu - 1, teacher.ID_Teacher, j + 1, i < 8 ? i - 2 : i - 8);
            }
          }
          sr.ReadLine();
          i++;
          if (i == 14)
            break;
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

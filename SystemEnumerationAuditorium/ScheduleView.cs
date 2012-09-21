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
  public partial class ScheduleView : UserControl
  {
    public ScheduleView()
    {
      InitializeComponent();
    }

    private void label_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < 6; i++)
        for (int j = 0; j < 8; j++)
        {
          var control = Table.GetControlFromPosition(j + 1, i + 1);

        }
    }

    void panel_DoubleClick(object sender, EventArgs e)
    {
      MessageBox.Show("drf");
    }
  }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class Add : Form
	{
		public Add(string str, Type attr, EducationInfo loc)
		{
			InitializeComponent();
			if (attr == typeof(GroupInfo))
				LoadEducation(loc);
			addText.Text = str;
		}
		public EducationInfo Edu;
		ComboBox _com;
		public string strNew;
		private void LoadEducation(EducationInfo loc)
		{
			var label = new Label
			            	{
				Size = new Size(95, 31),
				TabIndex = 1,
				Location = new Point(12, 35),
				Text = "Выберите форму обучения",
			};
			label.Show();
			_com = new ComboBox
			      	{
				Size = new Size(121, 21),
				FormattingEnabled = true,
				Location = new Point(107, 35),
				TabIndex = 2,
				DropDownStyle = ComboBoxStyle.DropDownList,
				SelectedIndex = -1
			};
			_com.Items.AddRange(Model.GetAll.Education());
			if (loc != null)
				_com.SelectedItem = loc;

			Controls.Add(label);
			Controls.Add(_com);
			button1.Location = new Point(10, 69);
			Size = new Size(245, 124);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (addText.Text != "")
			{
				strNew = addText.Text;
				if (_com != null)
					Edu = (EducationInfo)_com.SelectedItem;
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void addText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				button1_Click(button1, EventArgs.Empty);
		}

		private void Add_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
				Close();
		}
	}
}

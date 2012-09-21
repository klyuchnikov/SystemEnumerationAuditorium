using System;
using System.Windows.Forms;

namespace SystemEnumerationAuditorium
{
	public partial class AddAuditorium : Form
	{
		public AddAuditorium(string Number, int Capacity, string AvailabilityProjector,
			int NumbComp, string QualityComp, bool edit)
		{
			InitializeComponent();
			if (edit)
			{
				addText.Text = Number;
				capacity.Value = Capacity;
				comp.Value = NumbComp;
				projector.SelectedItem = AvailabilityProjector;
				if (NumbComp != 0)
				{
					quality.SelectedItem = QualityComp;
					label3.Enabled = true;
					quality.Enabled = true;
				}
			}

		}
	//	public AuditoriumInfo au = null;
		public string number;
		public int Capacity;
		public string AvailabilityProjector;
		public int NumbComp;
		public string QualityComp;


		private void Add_Click(object sender, EventArgs e)
		{
			if (addText.Text == "" || capacity.Value == 0 ||
				(comp.Value != 0 ? quality.SelectedItem == null : false) ||
				projector.SelectedItem == null)
				MessageBox.Show("Не все значения указаны");
			else
			{
				Capacity = (int)capacity.Value;
				AvailabilityProjector = (string)projector.SelectedItem;
				NumbComp = (int)comp.Value;
				QualityComp = comp.Value != 0 ? (string) quality.SelectedItem : "";
				number = addText.Text;
				Add.DialogResult = DialogResult.OK;
				DialogResult = DialogResult.OK;
			}
		}

		private void comp_ValueChanged(object sender, EventArgs e)
		{
			if (comp.Value == 0)
			{
				label3.Enabled = false;
				quality.Enabled = false;
			}
			else
			{
				label3.Enabled = true;
				quality.Enabled = true;
			}
		}

		private void AddAuditorium_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
				Close();
		}
	}
}

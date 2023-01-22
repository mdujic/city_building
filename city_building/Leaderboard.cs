using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace city_building
{
	public partial class Leaderboard : Form
	{
		public MainMenu _m;

		public Leaderboard(MainMenu m)
		{
			InitializeComponent();
			_m = m;
			// open and read file Properties.Resources.Results
			string[] lines = Properties.Resources.Results.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

			// convert to list of ints
			List<int> scores = new List<int>();
			foreach (string line in lines)
			{
				scores.Add(Convert.ToInt32(line));
			}

			// sort scores in ascending order
			scores.Sort();

			for (int i = 1; i <= 10; i++)
			{
				if(i <= scores.Count)
				{
                    int minutes = scores[i - 1] / 60;
                    int seconds = scores[i - 1] % 60;
                    Controls.Find("Name" + i, true)[0].Text = minutes.ToString("00") + ":" + seconds.ToString("00");
                }
				else
				{
					Controls.Find("Name" + i, true)[0].Text = "";
                }
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
            // close this form
            this.Close();
            _m.Show();
        }
    }
}

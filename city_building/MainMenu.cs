using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace city_building
{
	public partial class MainMenu : Form
	{
		public System.Media.SoundPlayer sound;
		string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
		
		public Options o;

		public MainMenu()
		{
			InitializeComponent();
			string soundtrack = projectDirectory + "\\Resources\\Soundtrack_MainMenu.wav";
			sound = new System.Media.SoundPlayer(soundtrack);
			o = new Options(sound);
			
			sound.PlayLooping();
		}

		private void ExitBtn_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void OptionsBtn_Click(object sender, EventArgs e)
		{
			o.ShowDialog();
		}

		
		private void ExitBtn_MouseHover(object sender, EventArgs e)
		{
			// change color to yellow
			ExitBtn.BackColor = Color.Yellow;
		}

		private void ExitBtn_MouseLeave(object sender, EventArgs e)
		{
			// change color back to original light gray
			ExitBtn.BackColor = Color.LightGray;
		}

		private void OptionsBtn_MouseHover(object sender, EventArgs e)
		{
			// change color to yellow
			OptionsBtn.BackColor = Color.Yellow;
		}

		private void OptionsBtn_MouseLeave(object sender, EventArgs e)
		{
			// change color back to original light gray
			OptionsBtn.BackColor = Color.LightGray;
		}

		private void LeaderboardBtn_MouseHover(object sender, EventArgs e)
		{
			// change color to yellow
			LeaderboardBtn.BackColor = Color.Yellow;
		}

		private void LeaderboardBtn_MouseLeave(object sender, EventArgs e)
		{
			// change color back to original light gray
			LeaderboardBtn.BackColor = Color.LightGray;
		}

		private void StartBtn_MouseHover(object sender, EventArgs e)
		{
			// change color to yellow
			StartBtn.BackColor = Color.Yellow;
		}

		private void StartBtn_MouseLeave(object sender, EventArgs e)
		{
			// change color back to original light gray
			StartBtn.BackColor = Color.LightGray;
		}

		private void StartBtn_Click(object sender, EventArgs e)
		{
			// turn off sound
			sound.Stop();

			// hide previous form
			this.Hide();

			Game g = new Game(this);

			// open form g
			g.Show();
		}
	}
}

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
	public partial class Options : Form
	{
		private System.Media.SoundPlayer _sound;
		private int MapSize = 25;

		// function to return SoundBtn text
		public string SoundBtnText()
		{
			return SoundBtn.Text;
		}

		// get map size
		public int GetMapSize()
		{
			return MapSize;
		}

		public Options(System.Media.SoundPlayer sound)
		{
			InitializeComponent();
			SoundBtn.Text = "On";
			_sound = sound;
		}

		private void SoundBtn_Click(object sender, EventArgs e)
		{
			// if sound is on, turn it off
			if (SoundBtn.Text == "On")
			{
				// turn sound off
				SoundBtn.Image = Properties.Resources.sound_off;
				SoundBtn.Text = "Off";

				// stop playing music
				_sound.Stop();
			}
			// if sound is off, turn it on
			else
			{
				// turn sound on
				SoundBtn.Image = Properties.Resources.sound_on;
				SoundBtn.Text = "On";

				// start playing music
				_sound.PlayLooping();
			}
		}


		private void SaveBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SaveBtn_MouseHover(object sender, EventArgs e)
		{
			// change color to yellow
			SaveBtn.BackColor = Color.Yellow;
		}

		private void SaveBtn_MouseLeave(object sender, EventArgs e)
		{
			// change color back to original light gray
			SaveBtn.BackColor = Color.LightGray;
		}

		private void MapSizeNumeric_ValueChanged(object sender, EventArgs e)
		{
			MapSize = (int)MapSizeNumeric.Value;
		}
	}
}

﻿using System;
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
	public partial class Game : Form
	{
		MainMenu _m;
		public int velicina; // veličina mape
		public double[] vrste = { 0.2, 0.1, 0.02 }; // šuma, stijena, željezo
		
		public Game(MainMenu m)
		{
			InitializeComponent();
			_m = m;
			velicina = _m.o.GetMapSize();
			// run initialize drawing
			InitializeDrawing();

		}

		// on destruction show _m

		private void ReturnBtn_Click(object sender, EventArgs e)
		{
			// close this form
			this.Close();
			_m.Show();
			if (_m.o.SoundBtnText() == "On")
			{
				_m.sound.PlayLooping();
			}
		}

		private void ReturnBtn_MouseHover(object sender, EventArgs e)
		{
			// change color to yellow
			ReturnBtn.BackColor = Color.Yellow;
		}

		private void ReturnBtn_MouseLeave(object sender, EventArgs e)
		{
			// change color back to original light gray
			ReturnBtn.BackColor = Color.LightGray;
		}

		public void NacrtajPlocu(int[,] ploca)
		{
			var panel = new TableLayoutPanel();
			panel.RowCount = velicina;
			panel.ColumnCount = velicina;
			//panel.BackColor = Color.Black;

			// postavi jednaku veličinu redova i stupaca
			for (int i = 0; i < velicina; ++i)
			{
				var postotak = 100f / (float)velicina;
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, postotak));
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, postotak));
			}

			// dodaj gumbe
			for (int i = 0; i < velicina; ++i)
			{
				for (int j = 0; j < velicina; ++j)
				{
					var button = new Button();
					switch (ploca[i, j])
					{
						case 0:
							button.BackColor = Color.Green;
							break;
						case 1:
							button.BackColor = Color.DarkGreen;
							break;
						case 2:
							button.BackColor = Color.Gray;
							break;
						case 3:
							button.BackColor = Color.DarkGray;
							break;
					}

					button.Dock = DockStyle.Fill;
					button.FlatStyle = FlatStyle.Flat;
					button.Margin = new Padding(0);

					//button.FlatAppearance.BorderSize = 0;
					// dodaj interaktivnost
					// button.Click += b_Click;

					panel.Controls.Add(button, j, i);
				}
			}
			panel.Dock = DockStyle.Fill;
			this.Controls.Add(panel);
		}

		private void InitializeDrawing()
		{
			// imat ćemo dvodimenzionalno polje intova u kojemu svaki broj predstavlja vrstu polja na tim
			// koordinatama

			// vrste polja i njihovi indeksi:
			// Polje   - 0
			// Šuma    - 1
			// Stijena - 2
			// Željezo - 3

			int[,] ploca = new int[velicina, velicina]; // po defaultu su svi brojevi 0
			Random rnd = new Random();

			for (int vrsta = 0; vrsta < 3; ++vrsta)
			{
				// generiramo broj klastera koji će biti na mapi za zadanu vrstu polja
				double udio = velicina * velicina * vrste[vrsta];
				int brojKlastera = Convert.ToInt32(Math.Ceiling(Math.Sqrt(udio)));

				int[,] lokacije = new int[brojKlastera, 2];

				for (int i = 0; i < brojKlastera; ++i)
				{
					lokacije[i, 0] = rnd.Next(velicina);
					lokacije[i, 1] = rnd.Next(velicina);
				}

				int povrsina = brojKlastera * velicina;

				// za svaku poziciju klastera popuni neko područje oko njega traženom vrstom
				int iskoristenaPovrsina = 0;
				for (int i = 0; i < brojKlastera; ++i)
				{
					int x = lokacije[i, 0], y = lokacije[i, 1];

					// odredi velicinu kvadrata oko lokacije koja zadovoljava povrsinu
					int j;
					for (j = 1; (2 * j + 1) * (2 * j + 1)
						< (povrsina - iskoristenaPovrsina) / brojKlastera; ++j) ;
					iskoristenaPovrsina += (2 * j + 1) * (2 * j + 1);

					// odredi gornji lijevi kut kvadrata
					if (x - j < 0) x = 0;
					else x = x - j;
					if (y - j < 0) y = 0;
					else y = y - j;

					// popuni plocu trazenim poljima
					for (int a = 0; (a < 2 * j + 1) && (a + x < velicina); ++a)
					{

						for (int b = 0; (b < 2 * j + 1) && (b + y < velicina); ++b)
						{
							// ne želimo uništiti ostale šume, stijene ili željezo, pa na to pazimo
							// ovdje
							if (ploca[x + a, y + b] != 0)
							{
								iskoristenaPovrsina -= 1;
							}
							else
								ploca[x + a, y + b] = vrsta;
						}
					}
				}
			}
			// ovdje bismo trebali imati popunjenu ploču, sada na formu dodajemo gumbe s
			// određenim vrstama polja
			NacrtajPlocu(ploca);
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.VisualStyles;

namespace city_building
{
	public partial class Game : Form
	{
		MainMenu _m;
		public int velicina; // veličina mape
        public int time = 0;

        public Game(MainMenu m)

        {
            InitializeComponent();
            _m = m;
            velicina = _m.o.GetMapSize();

            // Generate the map
            GenerateMap();
        }

        void GenerateMap()
        {
			Perlin perlin = new Perlin();

            // height map
            double[,] heightMap = perlin.PerlinNoiseMap(velicina,
				perlin.perlinParameters.heightWaves);

			// heat map
			double[,] heatMap = perlin.PerlinNoiseMap(velicina,
				perlin.perlinParameters.heatWaves);

			// decide the biomes based on the maps
			string[,] biomes = new string[velicina, velicina];

			for(int x = 0; x < velicina; ++x)
			{
				for (int y = 0; y < velicina; ++y)
				{
					biomes[x, y] = perlin.GetBiome(heightMap[x, y], heatMap[x, y]).name;
                }
			}
			AddIronNoise(biomes);
			
			AddMapButtons(biomes);
        }

		void AddIronNoise(string[,] biomes)
		{
            // add some noise for iron ore
            // # iron = 2% of all grassland tiles and 15% of all edge mountains tiles

            var random = new Random();

            for (int x = 0; x < velicina; ++x)
            {
                for (int y = 0; y < velicina; ++y)
                {
                    if (biomes[x, y] == "polje")
                    {
                        if (random.NextDouble() > 0.98) biomes[x, y] = "željezo";
                    }
                    if (biomes[x, y] == "stijena")
                    {
                        bool dobar = false;
                        if (x > 0 && (biomes[x - 1, y] == "šuma" || biomes[x - 1, y] == "polje"))
                            dobar = true;
                        else if (x < velicina - 1 && (biomes[x + 1, y] == "šuma" || biomes[x + 1, y] == "polje"))
                            dobar = true;
                        else if (y < velicina - 1 && (biomes[x, y + 1] == "šuma" || biomes[x, y + 1] == "polje"))
                            dobar = true;
                        else if (y > 0 && (biomes[x, y - 1] == "šuma" || biomes[x, y - 1] == "polje"))
                            dobar = true;
                        if (dobar && random.NextDouble() > 0.85) biomes[x, y] = "željezo";
                    }
                }
            }
        }

        void AddMapButtons(string[,] biomes)
        {
            var panel = new TableLayoutPanel();
            panel.RowCount = velicina;
            panel.ColumnCount = velicina;
            //panel.BackColor = Color.Black;

            // postavi jednaku veličinu redova i stupaca
            for (int i = 0; i < velicina; ++i)
            {
                var postotak = 100d / velicina;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)postotak));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, (float)postotak));
            }

            // add the buttons to the panel
            for (int x = 0; x < velicina; ++x)
            {
                for (int y = 0; y < velicina; ++y)
                {
                    var button = new Button();
                    switch (biomes[x, y])
                    {
                        case "voda":
                            button.BackColor = Color.LightBlue;
                            break;
                        case "polje":
                            button.BackColor = Color.LightGreen;
                            break;
                        case "šuma":
                            button.BackColor = Color.DarkGreen;
                            break;
                        case "stijena":
                            button.BackColor = Color.LightGray;
                            break;
                        case "željezo":
                            button.BackColor = Color.DarkGray;
                            break;
                    }
                    //button.Text = heightMap[x, y].ToString();
                    button.Dock = DockStyle.Fill;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Margin = new Padding(0);

                    //button.FlatAppearance.BorderSize = 0;
                    // dodaj interaktivnost
                    // button.Click += b_Click;

                    panel.Controls.Add(button, y, x);

                }
            }
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);
            OutsidePanel.Controls.Add(panel);
        }

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

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			time++;
			// convert time to minutes and seconds
			int minutes = time / 60;
			int seconds = time % 60;
			// update label
			TimeLabel.Text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
			
		}
	}
}

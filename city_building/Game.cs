﻿using System;
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
		Button lastClicked = null;

		// array of pairs of actions and times to execute after each tick
		public List<Tuple<Action, int>> actions = new List<Tuple<Action, int>>();

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

					// click event for the button
					button.Click += (sender, e) =>
					{
						// remember lastClicked button
						var b = (Button)sender;
						lastClicked = b;
					};

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

			var newActions = new List<Tuple<Action, int>>();
			// iterate through each element in tickActions
			foreach (var action in actions)
			{
				// extract action and time from the tuple
				var a = action.Item1;
				var t = action.Item2;

				if (t == 0)
				{
					// execute the action
					a();
					break;
				}
				else
				{
					newActions.Add(new Tuple<Action, int>(a, t - 1));
				}
			}
			actions = newActions;

		}

		private void Build(Button sender, int resources, int price, int workersNecessary, int seconds)
		{
			// get number of each resource (wood, stone, iron)
			int wood = Convert.ToInt32(WoodCountLbl.Text);
			int stone = Convert.ToInt32(StoneCountLbl.Text);
			int iron = Convert.ToInt32(IronCountLbl.Text);
			int gold = Convert.ToInt32(GoldCountLbl.Text);

			// get number of workers in format available/total
			string[] workers = NoWorkersLbl.Text.Split('/');

			// get number of workers available
			int workersAvailable = Convert.ToInt32(workers[0]);

			// get number of workers total
			int workersTotal = Convert.ToInt32(workers[1]);


			// if there is no lastClicked button, show message
			if (lastClicked == null)
			{
				// check if clicked button is field
				MessageBox.Show("Please select a tile first!");
			}
			else if (lastClicked.BackColor == Color.LightGreen)
			{
				// check if there is enough resources
				if (wood >= resources && stone >= resources && iron >= resources && gold >= price)
				{
					// check if there is enough available workers
					if (workersAvailable >= workersNecessary)
					{
						// subtract resources
						wood -= resources;
						stone -= resources;
						iron -= resources;
						gold -= resources;

						// subtract workers
						workersAvailable -= workersNecessary;

						// update labels
						WoodCountLbl.Text = wood.ToString();
						StoneCountLbl.Text = stone.ToString();
						IronCountLbl.Text = iron.ToString();
						GoldCountLbl.Text = gold.ToString();
						NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

						// change button image to construction
						lastClicked.BackgroundImage = Properties.Resources.construction;
						lastClicked.BackgroundImageLayout = ImageLayout.Zoom;



						// add action to tickActions
						actions.Add(new Tuple<Action, int>(() =>
						{
							workersAvailable += workersNecessary;

							// update labels
							NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

							// change button to image from HouseBtn
							lastClicked.BackgroundImage = sender.BackgroundImage;
							lastClicked.BackgroundImageLayout = ImageLayout.Zoom;
							lastClicked.BackColor = Color.Transparent;
						}, seconds));

					}
					else
					{
						MessageBox.Show("Not enough workers available!");
					}
				}
				else
				{
					MessageBox.Show("Not enough resources!");
				}
			}
			else
			{
				MessageBox.Show("You can't build here!");
			}
		}

		private void HouseBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 10, 0, 10, 5);
		}

		private void BuildingBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 20, 0, 20, 10);
		}

		private void TowerBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 30, 0, 30, 15);
		}

		private void WonderBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 100, 100, 100, 100);
		}

		private void AddSoldierBtn_Click(object sender, EventArgs e)
		{
			// one soldier needs one worker and 10 gold
			// get number of workers in format available/total
			string[] workers = NoWorkersLbl.Text.Split('/');
			// get number of workers available
			int workersAvailable = Convert.ToInt32(workers[0]);
			// get number of workers total
			int workersTotal = Convert.ToInt32(workers[1]);
			// get number of gold
			int gold = Convert.ToInt32(GoldCountLbl.Text);

			// check if there is enough gold
			if (gold >= 10)
			{
				// check if there is enough available workers
				if (workersAvailable >= 1)
				{
					// subtract gold
					gold -= 10;
					// subtract workers
					workersAvailable -= 1;
					workersTotal -= 1;
					// update labels
					GoldCountLbl.Text = gold.ToString();
					NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

					// get number of soldiers in format
					int soldiers = Convert.ToInt32(NoSoldiersLbl.Text);
					
					// add soldier
					soldiers++;
					// update label
					NoSoldiersLbl.Text = soldiers.ToString();
				}
				else
				{
					MessageBox.Show("Not enough workers available to convert!");
				}
			}
			else
			{
				MessageBox.Show("Not enough gold!");
			}
		}
		
		// function to check if we are harvesting/mining from valid place
		// if sender.Tag == "wood", lastClicked.BackColor must be Color.DarkGreen ...
		private bool ValidateHarvestMine(Button sender)
		{
			bool check = sender.Tag == "wood" && lastClicked.BackColor == Color.DarkGreen;
			check = check || sender.Tag == "stone" && lastClicked.BackColor == Color.LightGray;
			check = check || sender.Tag == "iron" && lastClicked.BackColor == Color.DarkGray;

			return check;
		}

		// function which sends workers to gather resources
		private void HarvestMine(Button sender, int seconds)
		{
			// check if there is at least one worker
			if (Convert.ToInt32(NoWorkersLbl.Text.Split('/')[0]) > 0)
			{
				// check if there is no lastClicked button
				if (lastClicked != null)
				{
					// check if clicked button is appropriate to gather resources
					if (lastClicked.BackColor != Color.Transparent && ValidateHarvestMine(sender) )
					{
						// get number of each resource
						int wood = Convert.ToInt32(WoodCountLbl.Text);
						int stone = Convert.ToInt32(StoneCountLbl.Text);
						int iron = Convert.ToInt32(IronCountLbl.Text);
						int gold = Convert.ToInt32(GoldCountLbl.Text);

						// change number of workers
						// get number of workers in format available/total
						string[] workers = NoWorkersLbl.Text.Split('/');
						// get number of workers available
						int workersAvailable = Convert.ToInt32(workers[0]);
						// get number of workers total
						int workersTotal = Convert.ToInt32(workers[1]);

						// set
						workersAvailable--;

						var BackColorBefore = lastClicked.BackColor;
						lastClicked.BackgroundImage = Properties.Resources.worker;
						lastClicked.BackgroundImageLayout = ImageLayout.Zoom;
						
						// update labels
						NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

						actions.Add(new Tuple<Action, int>(() =>
						{
							workersAvailable++;

							// add 10 item of resource from source
							switch (sender.Name)
							{
								case "WoodBtn":
									wood += 10;
									// update label WoodCountLbl
									WoodCountLbl.Text = wood.ToString();
									break;
								case "StoneBtn":
									stone += 10;
									// update label StoneCountLbl
									StoneCountLbl.Text = stone.ToString();
									break;
								case "IronBtn":
									iron += 10;
									// update label IronCountLbl
									IronCountLbl.Text = iron.ToString();
									break;
								case "GoldBtn":
									gold += 10;
									// update label GoldCountLbl
									GoldCountLbl.Text = gold.ToString();
									break;
							}
							

							// update labels
							NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

							// change button color back to before
							lastClicked.BackgroundImage = null;
							lastClicked.BackColor = BackColorBefore;
						}, seconds));
					}
					else
					{
						MessageBox.Show("You can't gather this resource from that tile!");
					}
				}
				else
				{
					MessageBox.Show("Please select tile first!");
				}
			}
			else
			{
				MessageBox.Show("Not enough workers available!");
			}
		}

		private void WoodBtn_Click(object sender, EventArgs e)
		{
			HarvestMine((Button)sender, 5);
		}

		private void StoneBtn_Click(object sender, EventArgs e)
		{
			HarvestMine((Button)sender, 10);
		}

		private void IronBtn_Click(object sender, EventArgs e)
		{
			HarvestMine((Button)sender, 15);
		}
	}
}

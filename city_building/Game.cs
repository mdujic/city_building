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
		Button lastClicked = null;

		// array of pairs of actions and times to execute after each tick
		public List<Tuple<Action, int, int>> actions = new List<Tuple<Action, int, int>>();

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
					

					panel.Controls.Add(button, y, x);

                }
            }

			// choose 2 random buttons from panel.Controls which have color LightGreen
			// set their BackgroundImage to Properties.Resources.house
			// and set BackColor to Color.Transparent
			for (int i = 0; i < 2; ++i)
			{
				var random = new Random();
				var button = (Button)panel.Controls[random.Next(0, panel.Controls.Count)];
				while (button.BackColor != Color.LightGreen)
				{
					button = (Button)panel.Controls[random.Next(0, panel.Controls.Count)];
				}
				button.BackgroundImage = Properties.Resources.house;
				button.BackgroundImageLayout = ImageLayout.Zoom;
				button.BackColor = Color.Transparent;

				// increment NoHousesLbl
				NoHousesLbl.Text = (int.Parse(NoHousesLbl.Text) + 1).ToString();
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

			var newActions = new List<Tuple<Action, int, int>>();
			var workersWorking = 0;
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
				}
				else
				{
					newActions.Add(new Tuple<Action, int, int>(a, t - 1, action.Item3));
					workersWorking += action.Item3;
				}
			}
			actions = newActions;
			
			var workersAvailable = int.Parse(NoWorkersLbl.Text.Split('/')[0]);
			
			// calculate total number of houses from NoHousesLbl
			var NoHouses = int.Parse(NoHousesLbl.Text);
			// calculate number of building from NoBuildingsLbl
			var NoBuildings = int.Parse(NoBuildingsLbl.Text);
			// calculate number of towers from NoTowersLbl
			var NoTowers = int.Parse(NoTowersLbl.Text);
			// calculate number of wonders
			var NoWonders = int.Parse(NoWondersLbl.Text);

			// total number of workers is 5 * number of houses + 20 * number of buildings
			var workersTotal = 5 * NoHouses + 20 * NoBuildings;

			if (seconds % 10 == 0 && workersAvailable < workersTotal - workersWorking)
			{
				workersAvailable++;
			}

			// update NoHousesLbl in format workersAvailable/workersTotal
			NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

			// each tower produces some amount of gold
			if (seconds % 30 == 0)
			{
				GoldCountLbl.Text = (int.Parse(GoldCountLbl.Text) + 5 * NoTowers).ToString();
			}

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


						var b = lastClicked;
						// add action to tickActions
						actions.Add(new Tuple<Action, int, int>(() =>
						{
							// get workersAvailable and workersTotal
							string[] workers = NoWorkersLbl.Text.Split('/');
							int workersAvailable = Convert.ToInt32(workers[0]);
							int workersTotal = Convert.ToInt32(workers[1]);

							workersAvailable += workersNecessary;

							// update labels
							NoWorkersLbl.Text = workersAvailable.ToString() + "/" + workersTotal.ToString();

							// change button to image from sender button
							b.BackgroundImage = sender.BackgroundImage;
							b.BackgroundImageLayout = ImageLayout.Zoom;
							b.BackColor = Color.Transparent;

							// increase number of buildings
							switch (sender.Tag)
							{
								case "House":
									NoHousesLbl.Text = (Convert.ToInt32(NoHousesLbl.Text) + 1).ToString();
									break;
								case "Building":
									NoBuildingsLbl.Text = (Convert.ToInt32(NoBuildingsLbl.Text) + 1).ToString();
									break;
								case "Tower":
									NoTowersLbl.Text = (Convert.ToInt32(NoTowersLbl.Text) + 1).ToString();
									break;
								case "Wonder":
									NoWondersLbl.Text = (Convert.ToInt32(NoWondersLbl.Text) + 1).ToString();
									break;
							}
						}, seconds, workersNecessary));

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
			// get number of iron
			int iron = Convert.ToInt32(IronCountLbl.Text);
			// get number of gold
			int gold = Convert.ToInt32(GoldCountLbl.Text);

			// check if there is enough gold and iron
			if (gold >= 10 && iron >= 10)
			{
				// check if there is enough available workers
				if (workersAvailable >= 1)
				{
					// subtract gold
					gold -= 10;
					// subtract iron
					iron -= 10;
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
				MessageBox.Show("Not enough resources!");
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
						var b = lastClicked;
						actions.Add(new Tuple<Action, int, int>(() =>
						{
							// get workersAvailable and workersTotal
							// get number of workers in format available/total
							string[] workers = NoWorkersLbl.Text.Split('/');
							// get number of workers available
							int workersAvailable = Convert.ToInt32(workers[0]);
							// get number of workers total
							int workersTotal = Convert.ToInt32(workers[1]);
							
							// get number of each resource
							int wood = Convert.ToInt32(WoodCountLbl.Text);
							int stone = Convert.ToInt32(StoneCountLbl.Text);
							int iron = Convert.ToInt32(IronCountLbl.Text);
							int gold = Convert.ToInt32(GoldCountLbl.Text);
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
							b.BackgroundImage = null;
							b.BackColor = BackColorBefore;
						}, seconds, 1));
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

		private void ImmobilizeSoldierBtn_Click(object sender, EventArgs e)
		{
			// return soldier back to workers
			int noSoldiers = Convert.ToInt32(NoSoldiersLbl.Text);
			int workersAvailable = Convert.ToInt32(NoWorkersLbl.Text.Split('/')[0]);
			int workersTotal = Convert.ToInt32(NoWorkersLbl.Text.Split('/')[1]);
			// check if there is at least one soldier
			if (noSoldiers > 0)
			{
				// update labels
				NoSoldiersLbl.Text = (noSoldiers - 1).ToString();
				NoWorkersLbl.Text = (workersAvailable + 1).ToString() + "/" + (workersTotal + 1).ToString();
			}
			else
			{
				MessageBox.Show("You have no soldiers to immobilize!");
			}
		}

		private void GoldBtn_Click(object sender, EventArgs e)
		{
			// dialog box pops out with options to buy/sell resources

			// get number of each resource
			int wood = Convert.ToInt32(WoodCountLbl.Text);
			int stone = Convert.ToInt32(StoneCountLbl.Text);
			int iron = Convert.ToInt32(IronCountLbl.Text);
			int gold = Convert.ToInt32(GoldCountLbl.Text);

			// create dialog box
			Form dialogBox = new Form();
			dialogBox.Text = "Market";
			dialogBox.Size = new Size(300, 600);
			dialogBox.StartPosition = FormStartPosition.CenterScreen;
			dialogBox.FormBorderStyle = FormBorderStyle.FixedDialog;
			dialogBox.MaximizeBox = false;
			dialogBox.MinimizeBox = false;
			dialogBox.ShowIcon = false;
			dialogBox.ShowInTaskbar = false;
			dialogBox.TopMost = true;

			// create labels
			Label woodLbl = new Label();
			woodLbl.Text = "Wood: " + wood.ToString();
			woodLbl.Location = new Point(10, 10);
			woodLbl.Size = new Size(100, 20);
			dialogBox.Controls.Add(woodLbl);

			Label stoneLbl = new Label();
			stoneLbl.Text = "Stone: " + stone.ToString();
			stoneLbl.Location = new Point(10, 40);
			stoneLbl.Size = new Size(100, 20);
			dialogBox.Controls.Add(stoneLbl);

			Label ironLbl = new Label();
			ironLbl.Text = "Iron: " + iron.ToString();
			ironLbl.Location = new Point(10, 70);
			ironLbl.Size = new Size(100, 20);
			dialogBox.Controls.Add(ironLbl);

			Label goldLbl = new Label();
			goldLbl.Text = "Gold: " + gold.ToString();
			goldLbl.Location = new Point(10, 100);
			goldLbl.Size = new Size(100, 20);
			dialogBox.Controls.Add(goldLbl);

			// create buttons
			Button buyWoodBtn = new Button();
			buyWoodBtn.Text = "Buy Wood";
			buyWoodBtn.Location = new Point(10, 130);
			buyWoodBtn.Size = new Size(100, 20);
			buyWoodBtn.Click += (s, e) =>
			{
				// check if there is enough gold
				if (gold >= 10)
				{
					// update labels
					wood += 10;
					gold -= 10;
					woodLbl.Text = "Wood: " + wood.ToString();
					goldLbl.Text = "Gold: " + gold.ToString();
				}
				else
				{
					MessageBox.Show("Not enough gold!");
				}
			};
			dialogBox.Controls.Add(buyWoodBtn);

			Button buyStoneBtn = new Button();
			buyStoneBtn.Text = "Buy Stone";
			buyStoneBtn.Location = new Point(10, 160);
			buyStoneBtn.Size = new Size(100, 20);
			buyStoneBtn.Click += (s, e) =>
			{
				// check if there is enough gold
				if (gold >= 20)
				{
					// update labels
					stone += 10;
					gold -= 20;
					stoneLbl.Text = "Stone: " + stone.ToString();
					goldLbl.Text = "Gold: " + gold.ToString();
				}
				else
				{
					MessageBox.Show("Not enough gold!");
				}
			};

			dialogBox.Controls.Add(buyStoneBtn);

			Button buyIronBtn = new Button();
			buyIronBtn.Text = "Buy Iron";
			buyIronBtn.Location = new Point(10, 190);
			buyIronBtn.Size = new Size(100, 20);

			buyIronBtn.Click += (s, e) =>
			{
				// check if there is enough gold
				if (gold >= 30)
				{
					// update labels
					iron += 10;
					gold -= 30;
					ironLbl.Text = "Iron: " + iron.ToString();
					goldLbl.Text = "Gold: " + gold.ToString();
				}
				else
				{
					MessageBox.Show("Not enough gold!");
				}
			};

			dialogBox.Controls.Add(buyIronBtn);

			Button sellWoodBtn = new Button();
			sellWoodBtn.Text = "Sell Wood";
			sellWoodBtn.Location = new Point(10, 220);
			sellWoodBtn.Size = new Size(100, 20);

			sellWoodBtn.Click += (s, e) =>
			{
				// check if there is enough wood
				if (wood >= 10)
				{
					// update labels
					wood -= 10;
					gold += 10;
					woodLbl.Text = "Wood: " + wood.ToString();
					goldLbl.Text = "Gold: " + gold.ToString();
				}
				else
				{
					MessageBox.Show("Not enough wood!");
				}
			};

			dialogBox.Controls.Add(sellWoodBtn);

			Button sellStoneBtn = new Button();
			sellStoneBtn.Text = "Sell Stone";
			sellStoneBtn.Location = new Point(10, 250);
			sellStoneBtn.Size = new Size(100, 20);

			sellStoneBtn.Click += (s, e) =>
			{
				// check if there is enough stone
				if (stone >= 10)
				{
					// update labels
					stone -= 10;
					gold += 20;
					stoneLbl.Text = "Stone: " + stone.ToString();
					goldLbl.Text = "Gold: " + gold.ToString();
				}
				else
				{
					MessageBox.Show("Not enough stone!");
				}
			};

			dialogBox.Controls.Add(sellStoneBtn);

			Button sellIronBtn = new Button();
			sellIronBtn.Text = "Sell Iron";
			sellIronBtn.Location = new Point(10, 280);
			sellIronBtn.Size = new Size(100, 20);

			sellIronBtn.Click += (s, e) =>
			{
				// check if there is enough iron
				if (iron >= 10)
				{
					// update labels
					iron -= 10;
					gold += 30;
					ironLbl.Text = "Iron: " + iron.ToString();
					goldLbl.Text = "Gold: " + gold.ToString();
				}
				else
				{
					MessageBox.Show("Not enough iron!");
				}
			};

			dialogBox.Controls.Add(sellIronBtn);

			// create close button
			Button closeBtn = new Button();
			closeBtn.Text = "Close";
			closeBtn.Location = new Point(10, 310);
			closeBtn.Size = new Size(100, 20);
			closeBtn.Click += (s, e) =>
			{
				// close dialog box
				dialogBox.Close();
			};
			dialogBox.Controls.Add(closeBtn);

			// show dialog box
			dialogBox.ShowDialog();

		}
	}
}

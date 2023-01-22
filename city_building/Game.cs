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

        public int time = 0;
		public MapInfo map; // MapInfo.cs

        // wolf info
        public int nextWave = 60; // 1 min
        public int waveDifficulty = 0;
		public int waveSize = 3;

        // array of pairs of actions and times to execute after each tick
        public List<Tuple<Action, string, int, int, Button>> actions = new List<Tuple<Action, string, int, int, Button>>();

		public Game(MainMenu m)
        {	
            InitializeComponent();
            _m = m;
            int velicina = _m.o.GetMapSize();
			LoadingScreen.ShowLoadingScreen();
			// Generate the map
			map = new MapInfo(velicina);
			map.GenerateMap(OutsidePanel); // MapInfo.cs
            NoHousesLbl.Text = map.NoHouses.ToString(); // set the starting number of houses to 2
            LoadingScreen.CloseForm();
        }

		private void GameTimer_Tick(object sender, EventArgs e)
		{
            time++;
			// convert time to minutes and seconds
			int minutes = time / 60;
			int seconds = time % 60;
			// update label
			TimeLabel.Text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");

			// check and resolve wolf attack
			ResolveWolves();

			// Action is the action
			// first int is the action type
			// second and third int are action type specific
			// action types: 0 - workers working, 1 - wolves
			var newActions = new List<Tuple<Action, string, int, int, Button>>();

			var actionsQueue = new Queue<Tuple<Action, string, int, int, Button>>(actions);
			int countActions = actionsQueue.Count;
			int i = 0;

			// iterate through each element in tickActions
			while (actionsQueue.Count > 0)
			{
				var action = actionsQueue.Dequeue();

				// extract action and action type from the tuple
				var a = action.Item1;
				var type = action.Item2;
				int time;

                switch (type)
				{
					case "worker": // workers working - Item3 is time, Item4 is required workers
						time = action.Item3;
                        if (time == 0)
                        {
                            // execute the action
                            a();
                        }
                        else
                        {
                            newActions.Add(new Tuple<Action, string, int, int, Button>(a, "worker", time - 1, action.Item4, action.Item5));
                        }
						break;
					case "wolves": // wolves attack resolution - Item3 is time, Item4 is number of wolves
						if(i >= countActions)
						{
                            time = action.Item3;

							if (time == 14) WolvesIncomingLbl.Visible = true;
                            if (time == 0)
                            {
                                WolvesIncomingLbl.Visible = false;
								WolfCountLbl.Text = (waveSize).ToString();

                                int wolves = action.Item4;
                                int count = 0;

                                if (map.workersWorking + map.workersAvailable + map.soldiers * 3 <= wolves) GameLost();

                                if (map.soldiers > 0)
                                {
                                    if (map.soldiers * 3 >= wolves)
                                    {
                                        map.KillSoldiers(wolves / 3);
										count += wolves;
                                    }
                                    else
                                    {
                                        count += map.soldiers * 3;
                                        map.KillSoldiers(map.soldiers);
                                    }
                                }

								if(count < wolves)
								{
                                    var tmp = map.KillWorkers(wolves - count, newActions);

                                    newActions = tmp.Item2;
                                    if (tmp.Item1 > 0)
                                        newActions.Add(new Tuple<Action, string, int, int, Button>(a, "wolves", 5, tmp.Item1, action.Item5));
                                }
                            }
                            else
                            {
								if (time % 2 == 0) WarningLbl.Visible = true;
								else WarningLbl.Visible = false;

                                newActions.Add(new Tuple<Action, string, int, int, Button>(a, "wolves", time - 1, action.Item4, action.Item5));
                            }
                        }
						else
						{
							actionsQueue.Enqueue(action);
						}
						break;
                }
				i++;
			}

			actions = newActions;

            // decide to add additional people to buildings every 10 seconds
            if (seconds % 10 == 0)
				map.AddPeople();

            // update NoHousesLbl in format workersAvailable/workersTotal
            NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();

			// update soldier label
			NoSoldiersLbl.Text = map.soldiers.ToString();

			NoWorkersWorkingLbl.Text = map.workersWorking.ToString();

			// each tower produces some amount of gold
			if (seconds % 5 == 0)
			{
                map.gold += 5 * map.NoTowers;
                GoldCountLbl.Text = map.gold.ToString();
			}
		}
        public void ResolveWolves()
        {
            // check if the nextWave should come
            if (nextWave == 0)
            {
                SendWave();
                nextWave = 59;
                waveDifficulty++;
				waveSize += 3 * waveDifficulty;
            }
            else
            {
                nextWave--;
            }
        }
        public void SendWave()
        {
            // based on waveDifficulty, decide the number of wolves that attack
            // for each pack of 3 wolves, create an action that is then resolved by
            // the GameTimer_Tick function

            // the first int keeps the time until the attack
            // the second int keeps the number of wolves that are still alive in the pack

			actions.Add(new Tuple<Action, string, int, int, Button>(() =>
				{}, "wolves", 14, waveSize, null));
        }

        private void Build(Button sender, int resources, int price, int workersNecessary, int seconds)
		{
			Button lastClicked = map.lastClicked;

			// if there is no lastClicked button, show message
			if (lastClicked == null)
			{
				// check if clicked button is field
				MessageBox.Show("Please select a tile first!");
			}
			else if (lastClicked.BackColor == Color.LightGreen)
			{
				// check if there is enough resources
				if (map.wood >= resources && map.stone >= resources && map.iron >= resources && map.gold >= price)
				{
					// check if there is enough available workers
					if (map.workersAvailable >= workersNecessary)
					{
						// subtract resources
						map.wood -= resources;
						map.stone -= resources;
						map.iron -= resources;
						map.gold -= resources;

						// subtract necessary workers
						map.SubtractWorkersForAction(workersNecessary);

						// update labels
						WoodCountLbl.Text = map.wood.ToString();
						StoneCountLbl.Text = map.stone.ToString();
						IronCountLbl.Text = map.iron.ToString();
						GoldCountLbl.Text = map.gold.ToString();

                        NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();
                        NoWorkersWorkingLbl.Text = map.workersWorking.ToString();

                        // change button image to construction
                        lastClicked.BackgroundImage = Properties.Resources.construction;
						lastClicked.BackgroundImageLayout = ImageLayout.Zoom;

						var b = lastClicked;
						// add action to tickActions
						actions.Add(new Tuple<Action, string, int, int, Button>(() =>
						{
                            // this action triggers when the building is built

							// add workers that are freed
							map.AddWorkersForAction(workersNecessary);

							// update labels
							NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();

							// change button to image from sender button
							b.BackgroundImage = sender.BackgroundImage;
							b.BackgroundImageLayout = ImageLayout.Zoom;
							b.BackColor = Color.Transparent;

							// increase number of buildings
							var panels = OutsidePanel.Controls.OfType<TableLayoutPanel>();
							TableLayoutPanelCellPosition coord = new TableLayoutPanelCellPosition();
							foreach(var panel in panels)
								coord = panel.GetCellPosition(b);

                            switch (sender.Tag)
							{
								case "House":
									map.BuildHouse(coord);
									NoHousesLbl.Text = map.NoHouses.ToString();
									break;

								case "Building":
                                    map.BuildBuilding(coord);
                                    NoBuildingsLbl.Text = map.NoBuildings.ToString();
									break;

								case "Tower":
									map.NoTowers += 1;
									NoTowersLbl.Text = map.NoTowers.ToString();
									break;

								case "Wonder":
									map.NoWonders += 1;
									NoWondersLbl.Text = map.NoWonders.ToString();
									if (NoWondersLbl.Text == "1")
										endOfGame(time);
									break;
							}
                        }, "worker", seconds, workersNecessary, null));

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
			Build((Button)sender, 10, 10, 5, 5);
		}

		private void BuildingBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 20, 20, 10, 10);
		}

		private void TowerBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 30, 30, 15, 15);
		}

		private void WonderBtn_Click(object sender, EventArgs e)
		{
			Build((Button)sender, 0, 0, 0, 0);
		}

		private void AddSoldierBtn_Click(object sender, EventArgs e)
		{
            // one soldier needs one worker and 10 gold

			// check if there is enough gold and iron
			if (map.gold >= 10 && map.iron >= 10)
			{
				// check if there is enough available workers
				if (map.workersAvailable >= 1)
				{
					// subtract gold
					map.gold -= 10;
					// subtract iron
					map.iron -= 10;

					// mobilize the worker
					map.MobilizeSoldier();

					// update labels
					GoldCountLbl.Text = map.gold.ToString();
					NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();

					// update iron label
					IronCountLbl.Text = map.iron.ToString();

					NoSoldiersLbl.Text = map.soldiers.ToString();
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
            Button lastClicked = map.lastClicked;
            bool check = sender.Tag == "wood" && lastClicked.BackColor == Color.DarkGreen;
			check = check || sender.Tag == "stone" && lastClicked.BackColor == Color.LightGray;
			check = check || sender.Tag == "iron" && lastClicked.BackColor == Color.DarkGray;

			return check;
		}

		// function which sends workers to gather resources
		private void HarvestMine(Button sender, int seconds)
		{
            Button lastClicked = map.lastClicked;
            // check if there is at least one worker
            if (map.workersAvailable > 0)
			{
				// check if there is no lastClicked button
				if (lastClicked != null)
				{
					// check if clicked button is appropriate to gather resources
					if (lastClicked.BackgroundImage == null && ValidateHarvestMine(sender) )
					{
                        // subtract the worker from the worker pool
                        map.SubtractWorkersForAction(1);

                        // get the numbers of workers

                        var BackColorBefore = lastClicked.BackColor;
						lastClicked.BackgroundImage = Properties.Resources.worker;
						lastClicked.BackgroundImageLayout = ImageLayout.Zoom;
						
						// update labels
						NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();
                        NoWorkersWorkingLbl.Text = map.workersWorking.ToString();

                        var b = lastClicked;
						actions.Add(new Tuple<Action, string, int, int, Button>(() =>
						{
                            // this function triggers when the worker is done with work

                            // free the worker into the worker pool
                            map.AddWorkersForAction(1);

                            // get the numbers of workers

                            // add 10 item of resource from source
                            switch (sender.Name)
							{
								case "WoodBtn":
									map.wood += 10;
									// update label WoodCountLbl
									WoodCountLbl.Text = map.wood.ToString();
									break;
								case "StoneBtn":
									map.stone += 10;
									// update label StoneCountLbl
									StoneCountLbl.Text = map.stone.ToString();
									break;
								case "IronBtn":
									map.iron += 10;
									// update label IronCountLbl
									IronCountLbl.Text = map.iron.ToString();
									break;
								case "GoldBtn":
									map.gold += 10;
									// update label GoldCountLbl
									GoldCountLbl.Text = map.gold.ToString();
									break;
							}

							// update labels
							NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();

							// change button color back to before
							b.BackgroundImage = null;
						}, "worker", seconds, 1, b));
					}
					else
					{
						MessageBox.Show("You can't gather this resource from that tile!");
					}
				}
				else
				{
					MessageBox.Show("Please select a tile first!");
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

		private void DemobilizeSoldierBtn_Click(object sender, EventArgs e)
		{
			// return soldier back to workers
            
            // check if there is at least one soldier
            if (map.soldiers > 0)
			{
                // demobilize the soldier
                map.DemobilizeSoldier();

                // update labels
                NoSoldiersLbl.Text = map.soldiers.ToString();
				NoWorkersLbl.Text = map.workersAvailable.ToString() + "/" + map.workersTotal.ToString();
			}
			else
			{
				MessageBox.Show("You have no soldiers to immobilize!");
			}
		}

		private void GoldBtn_Click(object sender, EventArgs e)
		{
			// open market dialog box
			Market market = new Market(this);
			market.ShowDialog();
		}

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
		{
			// MessageBox.Show(e.KeyChar.ToString().ToUpper());
			switch (e.KeyChar.ToString().ToUpper())
			{
				case "H":
					Build(HouseBtn, 10, 10, 5, 5);
					break;
				case "B":
					Build(BuildingBtn, 20, 20, 10, 10);
					break;
				case "T":
					Build(TowerBtn, 30, 30, 15, 15);
					break;
				case "J":
					Build(WonderBtn, 100, 100, 50, 100);
					break;
				case "W":
					HarvestMine(WoodBtn, 5);
					break;
				case "S":
					HarvestMine(StoneBtn, 10);
					break;
				case "I":
					HarvestMine(IronBtn, 15);
					break;
			}
		}
        public void set_wood(string wood)
        {
            WoodCountLbl.Text = wood;
        }

        public void set_stone(string stone)
        {
            StoneCountLbl.Text = stone;
        }

        public void set_iron(string iron)
        {
            IronCountLbl.Text = iron;
        }

        public void set_gold(string gold)
        {
            GoldCountLbl.Text = gold;
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

		// this function is called when wonder is built
		private void endOfGame(int time)
		{


			// find path to Properties.Resources.Results
			var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources\\Results.txt");
			// append variable time to the end of file Results
			// open file Results
			StreamWriter sw = new StreamWriter(path, append: true);
			// write time to file
			sw.WriteLine(time);
			// close file
			sw.Close();

			// open leaderboard dialog box
			Leaderboard leaderboard = new Leaderboard(_m);
			int minutes = time / 60;
			int seconds = time % 60;

			for (int i = 1; i <= 10; i++)
			{
				// find label with name "Name" + i
				Control namei = leaderboard.Controls.Find("Name" + i, true)[0];
				
				if (minutes.ToString("00") + ":" + seconds.ToString("00") == namei.Text)
				{
					// change color of label to black
					namei.ForeColor = Color.Black;
					// also change Text of label FeedbackLbl to "You are in top 10!"
					leaderboard.FeedbackLbl.Text = "Congrats! You are in top 10!";
					break;
				}
			}
			if (leaderboard.FeedbackLbl.Text == "")
			{
				leaderboard.FeedbackLbl.Text = "Your result is " + minutes + ":" + seconds;
			}

			var e = new EventArgs();
			// if leaderboard.button1 is clicked, close
			leaderboard.button1.Click += (leaderboard, e ) =>
			{
				this.Close();
			};
			
            leaderboard.ShowDialog();
		}

		private void GameLost() 
		{
			var tmp = new GameLost();
			this.Close();
			tmp.ShowDialog();
        }
	}
}

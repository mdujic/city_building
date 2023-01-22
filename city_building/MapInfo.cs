using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace city_building
{
    public class MapInfo
    {
        // basic info
        public string[,] biomes;
        public int velicina;
        public Button lastClicked;

        // resource info
        public int wood;
        public int stone;
        public int iron;
        public int gold;

        // building info
        public int NoHouses;
        public int NoBuildings;
        public int NoTowers;
        public int NoWonders;

        // update on building a building
        public int maxPeople;           // the maximum possible number of people = NoHouses * 5 + NoBuildings * 20

        // update on beginning or end of action
        public int workersWorking;   // update on death
        public int workersAvailable; // update on birth   

        // update on mobilization, demobilization, or death by wolf
        public int soldiers;            // the current number of soldiers

        // update on mobilization, demobilization, death by wolf, or building a building
        public int workersTotal;        // always equal to maxPeople - soldiers

        // (x, y) -> (typeOfBuilding, existentInhabitants, availableInhabitants)
        // typeOfBuilding: 1 - house, 2 - building
        public Dictionary<Tuple<int, int>, int[]> buildingInfo;
        public static Dictionary<int, int> buildingMax = new Dictionary<int, int>() { { 1, 5}, { 2, 20} };

        public MapInfo(int velicina)
        {
            this.velicina = velicina;
            biomes = new string[velicina, velicina];
            buildingInfo = new Dictionary<Tuple<int, int>, int[]>();
            lastClicked = null;

            NoHouses = 2;
            NoBuildings = 0;
            NoTowers = 0;
            NoWonders = 0;

            workersAvailable = 6;
            workersWorking = 0;
            maxPeople = 10;
            soldiers = 0;
            workersTotal = 10;

            wood = 0;
            gold = 0;
            iron = 0;
            stone = 0;
        }

        public void KillSoldiers(int deaths)
        {
            int count = 0;
            foreach (var building in buildingInfo)
            {
                var val = building.Value;
                int remaining = deaths - count;
                // if house had people outside of it
                if (val[2] < val[1])
                {
                    if (remaining <= val[1] - val[2])
                    {
                        val[1] -= remaining;
                        break;
                    }
                    else
                    {
                        count += val[1] - val[2];
                        val[1] = val[2];
                    }
                }
            }
            soldiers -= deaths;
            workersTotal = maxPeople - soldiers;
        }

        public Tuple<int, List<Tuple<Action, string, int, int, Button>>> KillWorkers(int wolves, List<Tuple<Action, string, int, int, Button>> actions)
        {
            int count = 0;
            int remaining;

            // firstly, kill all available workers from homes
            foreach (var building in buildingInfo)
            {
                var val = building.Value;
                remaining = wolves - count;
                // if house has available workers inside it
                if (val[2] > 0)
                {
                    if (val[2] >= remaining)
                    {
                        val[2] -= remaining;
                        val[1] -= remaining;
                        count += remaining;
                    }
                    else
                    {
                        val[1] -= val[2];
                        count += val[2];
                        val[2] = 0;
                    }
                }
                if (count == wolves) break;
            }

            workersAvailable -= count;

            if (count < wolves)
            {
                List<Tuple<Action, string, int, int, Button>> remainingActions = new List<Tuple<Action, string, int, int, Button>>();

                // secondly, kill #remaining workers currently working on an action
                // all other workings MUST Be working on an action => availableInhabitants = 0 for any building

                int leftover = count; // how many we already killed

                // iterate over all worker actions and kill workers equal
                // to remaining wolves
                foreach (var action in actions)
                {
                    // we will only kill workers that are harvesting - this means that we maybe
                    // will not kill all people this tick, so we must add the action with the
                    // remaining wolves to resolve it
                    if (action.Item2 == "worker" && count < wolves && action.Item4 == 1) 
                    {
                        // kill a worker only if the count < wolves
                        ++count;

                        // we must resolve the destruction of these actions
                        action.Item5.BackgroundImage = null;
                    }
                    else
                    {
                        // all other actions are preserved
                        remainingActions.Add(action);
                    }
                }

                // update the buildingInfo, by killing #(count - leftover) existentInhabitants
                workersWorking -= (count - leftover);

                foreach (var building in buildingInfo)
                {
                    var val = building.Value;
                    remaining = count - leftover;
                    
                    if (val[1] > 0)
                    {
                        if (val[1] >= remaining)
                        {
                            val[1] -= remaining;
                            leftover += remaining;
                        }
                        else
                        {
                            leftover += val[1];
                            val[1] = 0;
                        }
                    }
                    if (count == leftover) break;
                }

                return new Tuple<int, List<Tuple<Action, string, int, int, Button>>>(wolves - count, remainingActions);
            }

            return new Tuple<int, List<Tuple<Action, string, int, int, Button>>>(0, actions);
        }

        public void BuildHouse(TableLayoutPanelCellPosition coord)
        {
            NoHouses++;
            maxPeople += 5;
            workersTotal += 5;

            buildingInfo[new Tuple<int, int>(coord.Row, coord.Column)] = new int[] { 1, 0, 0 };
        }

        public void BuildBuilding(TableLayoutPanelCellPosition coord)
        {
            NoBuildings++;
            maxPeople += 20;
            workersTotal += 20;

            buildingInfo[new Tuple<int, int>(coord.Row, coord.Column)] = new int[] { 2, 0, 0 };
        }

        public void AddPeople()
        {
            // iterate over every building and add a person to each of them
            // that has existentInhabitants < BuildingMax 
            foreach(var building in buildingInfo)
            {
                var val = building.Value;
                if (val[1] < buildingMax[val[0]])
                {
                    val[1]++;
                    val[2]++;
                    workersAvailable++;
                }
            }
        }

        public void MobilizeSoldier()
        {
            soldiers++;
            workersTotal--;
            workersAvailable--;
            // find an available worker and subtract it from a building
            foreach(var building in buildingInfo)
            {
                var val = building.Value;
                if (val[2] > 0)
                {
                    val[2]--;
                    break;
                }
            }
        }

        public void DemobilizeSoldier()
        {
            soldiers--;
            workersTotal++;
            workersAvailable++;
            // find a building with a vacant spot (availableInhabitants < existentInhabitants)
            foreach (var building in buildingInfo)
            {
                var val = building.Value;
                if (val[2] < val[1])
                {
                    val[2]++;
                    break;
                }
            }
        }

        public void SubtractWorkersForAction(int workersNecessary)
        {
            // iterate over buildingInfo and check if availableInhabitants > 0,
            // if so, subtract them until hitting workersNecessary

            int i = 0;
            foreach (var building in buildingInfo)
            {
                var val = building.Value;
                if (val[2] > 0)
                {
                    if (val[2] >= workersNecessary)
                    {
                        val[2] -= workersNecessary;
                        i += workersNecessary;
                    }
                    else
                    {
                        i += val[2];
                        val[2] = 0;
                    }
                    if (i == workersNecessary) break;
                }
            }

            workersWorking += workersNecessary;
            workersAvailable -= workersNecessary;
        }

        public void AddWorkersForAction(int workersFreed)
        {
            // find the buildings whose availableInhabitants < existantInhabitants and add
            // the freed workers
            int i = 0;
            foreach(var building in buildingInfo)
            {
                var val = building.Value;
                if (val[2] < val[1])
                {
                    if (val[2] + workersFreed <= val[1])
                    {
                        i += workersFreed;
                        val[2] += workersFreed;
                    }
                    else
                    {
                        i += val[1] - val[2];
                        val[2] = val[1];
                    }
                    if(i == workersFreed) break;
                }
            }

            workersWorking -= workersFreed;
            workersAvailable += workersFreed;
        }

        public void GenerateMap(Panel OutsidePanel)
        {
            Perlin perlin = new Perlin(); // Perlin.cs

            // height map
            double[,] heightMap = perlin.PerlinNoiseMap(velicina,
                perlin.perlinParameters.heightWaves);

            // heat map
            double[,] heatMap = perlin.PerlinNoiseMap(velicina,
                perlin.perlinParameters.heatWaves);

            // decide the biomes based on the maps
            for (int x = 0; x < velicina; ++x)
            {
                for (int y = 0; y < velicina; ++y)
                {
                    biomes[x, y] = perlin.GetBiome(heightMap[x, y], heatMap[x, y]).name;
                }
            }

            AddIronNoise();

            AddMapButtons(OutsidePanel); // this takes ages
        }

        void AddIronNoise()
        {
            // add some noise for iron ore
            // # iron ~= 2% of all grassland tiles and 15% of all edge mountains tiles

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

        void AddMapButtons(Panel OutsidePanel)
        {
            var panel = new TableLayoutPanel();
            panel.RowCount = velicina;
            panel.ColumnCount = velicina;

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

                    button.Dock = DockStyle.Fill;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
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

                // find the coordinates of the button
                var coord = panel.GetCellPosition(button);
                buildingInfo[new Tuple<int, int>(coord.Row, coord.Column)] = new int[] { 1, 3, 3 };

                button.BackgroundImage = Properties.Resources.house;
                button.BackgroundImageLayout = ImageLayout.Zoom;
                button.BackColor = Color.Transparent;
            }

            panel.Dock = DockStyle.Fill;
            //this.Controls.Add(panel); // i think this is unnecessary
            OutsidePanel.Controls.Add(panel);
        }
    }
}

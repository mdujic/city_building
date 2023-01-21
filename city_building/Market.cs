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
	public partial class Market : Form
	{
		Game g;

		public Market(Game _g)
		{
			g = _g;
			InitializeComponent();

			g.GameTimer.Tick += (sender, e) => { UpdateLabels(); };

			// set all amounts to those from Game
			UpdateLabels();
		}
       
		public void UpdateLabels()
		{
            WoodAmountMarket.Text = g.map.wood.ToString();
            StoneAmountMarket.Text = g.map.stone.ToString();
            IronAmountMarket.Text = g.map.iron.ToString();
            GoldAmountMarket.Text = g.map.gold.ToString();
        }

        private void BuyWoodBtn_Click(object sender, EventArgs e)
		{
            // if player has enough gold
            if (g.map.gold >= 10)
			{
				// subtract 10 gold
				g.map.gold -= 10;

				// add 10 wood
				g.map.wood += 10;

				// update amounts
				WoodAmountMarket.Text = g.map.wood.ToString();
				GoldAmountMarket.Text = g.map.gold.ToString();
				
                g.set_wood(g.map.wood.ToString());
                g.set_gold(g.map.gold.ToString());
            }
		}

		private void BuyStoneBtn_Click(object sender, EventArgs e)
		{
            // if player has enough gold
            if (g.map.gold >= 20)
			{
                // subtract 20 gold
                g.map.gold -= 20;

                // add 10 stone
                g.map.stone += 10;

				// update amounts
				StoneAmountMarket.Text = g.map.stone.ToString();
				GoldAmountMarket.Text = g.map.gold.ToString();

				g.set_stone(g.map.stone.ToString());
				g.set_gold(g.map.gold.ToString());
			}
		}

		private void BuyIronBtn_Click(object sender, EventArgs e)
		{
            // if player has enough gold
            if (g.map.gold >= 30)
			{
                // subtract 30 gold
                g.map.gold -= 30;

                // add 10 iron
                g.map.iron += 10;

				// update amounts
				IronAmountMarket.Text = g.map.iron.ToString();
				GoldAmountMarket.Text = g.map.gold.ToString();

				g.set_iron(g.map.iron.ToString());
				g.set_gold(g.map.gold.ToString());
			}
		}

		private void SellWoodBtn_Click(object sender, EventArgs e)
		{
            // if player has enough wood
            if (g.map.wood >= 10)
			{
				// subtract 10 wood
				g.map.wood -= 10;

				// add 8 gold
				g.map.gold += 8;

				// update amounts
				WoodAmountMarket.Text = g.map.wood.ToString();
				GoldAmountMarket.Text = g.map.gold.ToString();

				g.set_wood(g.map.wood.ToString());
				g.set_gold(g.map.gold.ToString());
			}
		}

		private void SellStoneBtn_Click(object sender, EventArgs e)
		{
            // if player has enough stone
            if (g.map.stone >= 10)
			{
				// subtract 10 stone
				g.map.stone -= 10;

                // add 16 gold
                g.map.gold += 16;

				// update amounts
				StoneAmountMarket.Text = g.map.stone.ToString();
				GoldAmountMarket.Text = g.map.gold.ToString();

				g.set_stone(g.map.stone.ToString());
                g.set_gold(g.map.gold.ToString());
            }
		}

		private void SellIronBtn_Click(object sender, EventArgs e)
		{
            // if player has enough iron
            if (g.map.iron >= 10)
			{
				// subtract 10 iron
				g.map.iron -= 10;

                // add 24 gold	
                g.map.gold += 24;

				// update amounts
				IronAmountMarket.Text = g.map.iron.ToString();
				GoldAmountMarket.Text = g.map.gold.ToString();

				g.set_iron(g.map.iron.ToString());
                g.set_gold(g.map.gold.ToString());
            }
		}
	}
}
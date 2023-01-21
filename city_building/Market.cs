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

			// set all amounts to those from Game
			WoodAmountMarket.Text = g.map.wood.ToString();
			StoneAmountMarket.Text = g.map.stone.ToString();
			IronAmountMarket.Text = g.map.iron.ToString();
			GoldAmountMarket.Text = g.map.gold.ToString();
		}
       
        private void BuyWoodBtn_Click(object sender, EventArgs e)
		{
			int gold = g.map.gold;
            int wood = g.map.wood;

            // if player has enough gold
            if (gold >= 10)
			{
				// subtract 10 gold
				gold -= 10;

				// add 10 wood
				wood += 10;

				// update amounts
				WoodAmountMarket.Text = wood.ToString();
				GoldAmountMarket.Text = gold.ToString();
			}
		}

		private void BuyStoneBtn_Click(object sender, EventArgs e)
		{
			int gold = g.map.gold;
            int stone = g.map.stone;

            // if player has enough gold
            if (gold >= 20)
			{
				// subtract 20 gold
				gold -= 20;

				// add 10 stone
				stone += 10;

				// update amounts
				StoneAmountMarket.Text = stone.ToString();
				GoldAmountMarket.Text = gold.ToString();
			}
		}

		private void BuyIronBtn_Click(object sender, EventArgs e)
		{
			int gold = g.map.gold;
            int iron = g.map.iron;

            // if player has enough gold
            if (gold >= 30)
			{
				// subtract 30 gold
				gold -= 30;

				// add 10 iron
				iron += 10;

				// update amounts
				IronAmountMarket.Text = iron.ToString();
				GoldAmountMarket.Text = gold.ToString();
			}
		}

		private void SellWoodBtn_Click(object sender, EventArgs e)
		{
			int wood = g.map.wood;
            int gold = g.map.gold;

            // if player has enough wood
            if (wood >= 10)
			{
				// subtract 10 wood
				wood -= 10;

				// add 8 gold
				gold += 8;

				// update amounts
				WoodAmountMarket.Text = wood.ToString();
				GoldAmountMarket.Text = gold.ToString();
			}
		}

		private void SellStoneBtn_Click(object sender, EventArgs e)
		{
			int stone = g.map.stone;
            int gold = g.map.gold;

            // if player has enough stone
            if (stone >= 10)
			{
				// subtract 10 stone
				stone -= 10;

				// add 16 gold
				gold += 16;

				// update amounts
				StoneAmountMarket.Text = stone.ToString();
				GoldAmountMarket.Text = gold.ToString();
			}
		}

		private void SellIronBtn_Click(object sender, EventArgs e)
		{
			int iron = g.map.iron;
            int gold = g.map.gold;

            // if player has enough iron
            if (iron >= 10)
			{
				// subtract 10 iron
				iron -= 10;

				// add 24 gold	
				gold += 24;

				// update amounts
				IronAmountMarket.Text = iron.ToString();
				GoldAmountMarket.Text = gold.ToString();
			}
		}
	}
}
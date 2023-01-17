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
			WoodAmountMarket.Text = g.get_wood();
			StoneAmountMarket.Text = g.get_stone();
			IronAmountMarket.Text = g.get_iron();
			GoldAmountMarket.Text = g.get_gold();
		}

		private void BuyWoodBtn_Click(object sender, EventArgs e)
		{
			int gold = Convert.ToInt32(g.get_gold());
			// if player has enough gold
			if (gold >= 10)
			{
				// subtract 10 gold
				g.set_gold((gold - 10).ToString());


				// add 10 wood
				int wood = Convert.ToInt32(g.get_wood());
				g.set_wood((wood + 10).ToString());

				// update amounts
				WoodAmountMarket.Text = g.get_wood();
				GoldAmountMarket.Text = g.get_gold();
			}
		}

		private void BuyStoneBtn_Click(object sender, EventArgs e)
		{
			int gold = Convert.ToInt32(g.get_gold());
			// if player has enough gold
			if (gold >= 20)
			{
				// subtract 10 gold
				g.set_gold((gold - 10).ToString());

				// add 10 stone
				int stone = Convert.ToInt32(g.get_stone());
				g.set_stone((stone + 10).ToString());

				// update amounts
				StoneAmountMarket.Text = g.get_stone();
				GoldAmountMarket.Text = g.get_gold();
			}
		}

		private void BuyIronBtn_Click(object sender, EventArgs e)
		{
			int gold = Convert.ToInt32(g.get_gold());
			// if player has enough gold
			if (gold >= 30)
			{
				// subtract 10 gold
				g.set_gold((gold - 10).ToString());

				// add 10 iron
				int iron = Convert.ToInt32(g.get_iron());
				g.set_iron((iron + 10).ToString());

				// update amounts
				IronAmountMarket.Text = g.get_iron();
				GoldAmountMarket.Text = g.get_gold();
			}
		}

		private void SellWoodBtn_Click(object sender, EventArgs e)
		{
			int wood = Convert.ToInt32(g.get_wood());
			// if player has enough wood
			if (wood >= 10)
			{
				// subtract 10 wood
				g.set_wood((wood - 10).ToString());

				// add 8 gold
				int gold = Convert.ToInt32(g.get_gold());
				g.set_gold((gold + 8).ToString());

				// update amounts
				WoodAmountMarket.Text = g.get_wood();
				GoldAmountMarket.Text = g.get_gold();
			}
		}

		private void SellStoneBtn_Click(object sender, EventArgs e)
		{
			int stone = Convert.ToInt32(g.get_stone());
			// if player has enough stone
			if (stone >= 10)
			{
				// subtract 10 stone
				g.set_stone((stone - 10).ToString());

				// add 16 gold
				int gold = Convert.ToInt32(g.get_gold());
				g.set_gold((gold + 16).ToString());

				// update amounts
				StoneAmountMarket.Text = g.get_stone();
				GoldAmountMarket.Text = g.get_gold();
			}
		}

		private void SellIronBtn_Click(object sender, EventArgs e)
		{
			int iron = Convert.ToInt32(g.get_iron());
			// if player has enough iron
			if (iron >= 10)
			{
				// subtract 10 iron
				g.set_iron((iron - 10).ToString());

				// add 24 gold
				int gold = Convert.ToInt32(g.get_gold());
				g.set_gold((gold + 24).ToString());

				// update amounts
				IronAmountMarket.Text = g.get_iron();
				GoldAmountMarket.Text = g.get_gold();
			}
		}
	}
}
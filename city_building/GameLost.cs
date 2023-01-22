using Accessibility;
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
    public partial class GameLost : Form
    {
        public GameLost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var main = new MainMenu();
            main.Show();
            this.Close();
        }

        private void GameLost_FormClosing(object sender, FormClosingEventArgs e)
        {
            var main = new MainMenu();
            main.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Arkanoid
{
    public partial class HelpScreen : Form
    {
        public HelpScreen()
        {
            InitializeComponent();
        }

        private void BackToMenu(object sender, EventArgs e)
        {
            GameStartMenu gameMenu = new GameStartMenu();
            gameMenu.Show();
            this.Hide();
        }
    }
}

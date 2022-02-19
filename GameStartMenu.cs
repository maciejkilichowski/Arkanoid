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
    public partial class GameStartMenu : Form
    {
        public GameStartMenu()
        {
            InitializeComponent();
        }
        
        private void LoadGame(object sender, EventArgs e)
        {
            GameScreen gameWindow = new GameScreen();
            gameWindow.Show();
            this.Hide();

        }

        private void Settings(object sender, EventArgs e)
        {
            HelpScreen helpWindow = new HelpScreen();
            helpWindow.Show();
            this.Hide();
        }

        private void QuitGame(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

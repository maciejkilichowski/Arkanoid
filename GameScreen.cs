using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Arkanoid
{
    public partial class GameScreen : Form
    {
        bool goLeft;
        bool goRight;
        bool isGameOver;
        
        int score;
        int ballx;
        int bally;
        int playerSpeed;

        Random rnd = new Random();

        PictureBox[] blockArray;
        private void setupGame()
        {
            isGameOver = false;
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            txtWynik.Text = "Wynik: " + score;

            ball.Left = 377;
            ball.Top = 357;

            player.Left = 343;
           

            gameTimer.Start();
            
            
        }
        public GameScreen()
        {
            InitializeComponent();
            PlaceBlocks();
            
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtWynik.Text = "" + score + " " + message; 

        }

        private void PlaceBlocks()
        {
            blockArray = new PictureBox[20];

            int a = 0;

            int top = 50;
            int left = 100;

            int seed = System.DateTime.Now.Millisecond;
            Random x = new Random(seed);
            
            

            for(int i = 0; i < blockArray.Length; i++)
            {
                int rndColor = x.Next(1, 4);
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "bloki";
                
                if(a == 5)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }
                if(a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;   
                    this.Controls.Add(blockArray[i]);
                    left = left + 130;
                }

                if(rndColor == 1)
                {
                    blockArray[i].Image = global::Arkanoid.Properties.Resources.brick;
                }
                else if(rndColor == 2)
                {
                    blockArray[i].Image = global::Arkanoid.Properties.Resources.bluebrick;
                }
                else if(rndColor == 3)
                {
                    blockArray[i].Image = global::Arkanoid.Properties.Resources.greenbrick;
                }
            }
            setupGame(); 
        }
        private void removeBlocks()
        {
             foreach(PictureBox x in blockArray)
            {
                this.Controls.Remove(x);
            }
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
           
            txtWynik.Text =""+score;
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 698)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;

            if (ball.Left < 0 || ball.Left > 779)
            {
                ballx = -ballx;
            }
            if (ball.Top < 0)
            {
                bally = -bally;
            }

                if (ball.Bounds.IntersectsWith(player.Bounds))
                {

                    bally = rnd.Next(5, 12) * -1;

                    if (ballx < 0)
                    {
                        ballx = rnd.Next(5, 12) * -1;
                    }
                    else
                    {
                        ballx = rnd.Next(5, 12);
                    }
                }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "bloki")
                {
                    if(ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        bally = -bally;
                        this.Controls.Remove(x);
                    }
                }
            }

            if(score == 20)
            {
                gameOver("You did it! Press Enter.");
            }
            if(ball.Top > 542)
            {
                gameOver("You lost! Press Enter.");
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeBlocks();
                PlaceBlocks();
            }
        }
        private void onClickmenu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                GameStartMenu menu = new GameStartMenu();
                this.Hide();
                menu.Show();    
            }
        }
        private void onClickMusic(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.M)
            {
                SoundPlayer sndplayr = new SoundPlayer(Arkanoid.Properties.Resources.ArkanoidTheme1);
                sndplayr.Play();
            }
        }
    }
}

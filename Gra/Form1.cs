using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra
{
    public partial class Form1 : Form
    {
        int PlayerSpeed = 7;
        int BallSpeed;

        int Player1Vel;
        int Player2Vel;

        int BSpeedX = 5;
        int BSpeedY = 5;


        bool pause = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(!pause)
            {
                ball.Location = new Point(ball.Location.X + BSpeedX, ball.Location.Y + BSpeedY);
                player1.Location = new Point(player1.Location.X + Player1Vel, player1.Location.Y);
                player2.Location = new Point(player2.Location.X + Player2Vel, player2.Location.Y);
            }
        }

        private void score1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Player1Vel = PlayerSpeed;
            }
            else if(e.KeyCode == Keys.Left)
            {
                Player1Vel = - PlayerSpeed;
            }
            else if(e.KeyCode == Keys.D)
            {
                Player2Vel = PlayerSpeed;
            }
            else if(e.KeyCode == Keys.A)
            {
                Player2Vel = - PlayerSpeed;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Player1Vel = 0;
            }
            else if (e.KeyCode == Keys.Left)
            {
                Player1Vel = 0;
            }
            else if (e.KeyCode == Keys.D)
            {
                Player2Vel = 0;
            }
            else if (e.KeyCode == Keys.A)
            {
                Player2Vel = 0;
            }
        }
    }
}

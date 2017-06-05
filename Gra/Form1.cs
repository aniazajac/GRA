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

        int PlayerSpeed = 6;
    

        int Player1Vel;
        int Player2Vel;

        int BSpeedX = 2;
        int BSpeedY = 2;

        int P1Score;
        int P2Score;


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
            if (ball.Location.Y < 0)
            {
                P2Score++;
                ball.Location = new Point(this.Width / 2, this.Height / 2);
            }

            if(ball.Location.Y > this.Height)
            {
                P1Score++;
                ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            if (ball.Location.X > player2.Location.X && ball.Location.X + ball.Width < player2.Location.X + player2.Width && ball.Location.Y + ball.Height > player2.Location.Y)
            {
                BSpeedY *= -1;
            }
            if (ball.Location.X > player1.Location.X && ball.Location.X + ball.Width < player1.Location.X + player1.Width && ball.Location.Y < player1.Location.Y + player1.Height)
            {
                BSpeedY *= -1;
            }
            if(ball.Location.X - ball.Width < 0)
            {
                BSpeedX *= -1;
            }
            if(ball.Location.X >this.Width - 2*ball.Width)
            {
                BSpeedX *= -1;
            }
            score1.Text = P1Score.ToString();
            score2.Text = P2Score.ToString();
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
            else if(e.KeyCode == Keys.P)
            {
                if (!pause)
                {
                    pause = true;
                }
                else if (pause)
                {
                    pause = false;
                }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Stop();
    
            Form okno = new Form();
            okno.Width = 600;
            okno.Height = 400;
            okno.Text = "Dane graczy";
            okno.BackColor = Color.LightBlue;

            Label etykieta = new Label();
            etykieta.Text = "Wprowadż imię pierwszego gracza ";
            etykieta.Font = new System.Drawing.Font("Arial", 3, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            etykieta.Location = new Point(200, 100);
            etykieta.Width = 200;
            etykieta.Height = 50;

            TextBox pole_tekstowe = new TextBox();
            pole_tekstowe.Width = 200;
            pole_tekstowe.Location = new Point(200, 120);

            Label etykieta2 = new Label();
            etykieta2.Text = "Wprowadż imię drugiego gracza ";
            etykieta2.Font = new System.Drawing.Font("Arial", 3, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            etykieta2.Location = new Point(200, 160);
            etykieta2.Width = 200;
            etykieta2.Height = 50;

            TextBox pole_tekstowe2 = new TextBox();
            pole_tekstowe2.Width = 200;
            pole_tekstowe2.Location = new Point(200, 180);

            Button przycisk = new Button();
            przycisk.Width = 100;
            przycisk.Height = 100;
            przycisk.Location = new Point(250, 250);
            przycisk.Text = "Graj!";
            przycisk.Font = new System.Drawing.Font("Arial", 4, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            przycisk.BackColor = Color.Red;
            przycisk.DialogResult = System.Windows.Forms.DialogResult.OK;


            okno.Controls.Add(pole_tekstowe);
            okno.Controls.Add(etykieta);
            okno.Controls.Add(pole_tekstowe2);
            okno.Controls.Add(etykieta2);
            okno.Controls.Add(przycisk);

            okno.ShowDialog();
            timer.Start();
          

            
        }
        

    }
}


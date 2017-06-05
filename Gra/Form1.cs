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

        int BSpeedX = 3;
        int BSpeedY = 3;

        int P1Score;
        int P2Score;

        TextBox pole_tekstowe = new TextBox();
        TextBox pole_tekstowe2 = new TextBox();

        bool pause = false;

        public Form1()
        {
            InitializeComponent();
            timer.Stop();
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

                pole_tekstowe.Width = 200;
                pole_tekstowe.Location = new Point(200, 120);

                Label etykieta2 = new Label();
                etykieta2.Text = "Wprowadż imię drugiego gracza ";
                etykieta2.Font = new System.Drawing.Font("Arial", 3, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
                etykieta2.Location = new Point(200, 160);
                etykieta2.Width = 200;
                etykieta2.Height = 50;


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



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!pause)
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

            if (ball.Location.Y > this.Height)
            {
                P1Score++;
                ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            if (P1Score == 5 || P2Score == 5)
            {
                Form okno1 = new Form();
                okno1.Width = 400;
                okno1.Height = 400;
                okno1.Text = "Koniec Gry";
                okno1.BackColor = Color.Black;
                okno1.MaximumSize = new System.Drawing.Size(300, 300);
                okno1.MinimumSize = new System.Drawing.Size(300, 300);
                okno1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                timer.Stop();
                Label etykieta3 = new Label();
                etykieta3.Text = "Wygrał gracz:";
                etykieta3.Font = new System.Drawing.Font("Arial", 8, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
                etykieta3.Location = new Point(45, 50);
                etykieta3.Width = 300;
                etykieta3.Height = 40;
                etykieta3.ForeColor = Color.Beige;
                Label etykieta4 = new Label();
                if (P1Score == 5)
                {
                    etykieta4.Text = pole_tekstowe.Text;
                }
                else if (P2Score == 5)
                {
                    etykieta4.Text = pole_tekstowe2.Text;
                }
                etykieta4.Font = new System.Drawing.Font("Arial", 8, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
                etykieta4.Location = new Point(110, 100);
                etykieta4.Width = 300;
                etykieta4.Height = 40;
                etykieta4.ForeColor = Color.Beige;
                okno1.Controls.Add(etykieta3);
                okno1.Controls.Add(etykieta4);
                okno1.ShowDialog();

            }
            if (ball.Location.X > player2.Location.X && ball.Location.X + ball.Width < player2.Location.X + player2.Width && ball.Location.Y + ball.Height > player2.Location.Y)
            {
                BSpeedY *= -1;
            }
            if (ball.Location.X > player1.Location.X && ball.Location.X + ball.Width < player1.Location.X + player1.Width && ball.Location.Y < player1.Location.Y + player1.Height)
            {
                BSpeedY *= -1;
            }
            if (ball.Location.X - ball.Width < 0)
            {
                BSpeedX *= -1;
            }
            if (ball.Location.X > this.Width - 2 * ball.Width)
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
            else if (e.KeyCode == Keys.Left)
            {
                Player1Vel = -PlayerSpeed;
            }
            else if (e.KeyCode == Keys.D)
            {
                Player2Vel = PlayerSpeed;
            }
            else if (e.KeyCode == Keys.A)
            {
                Player2Vel = -PlayerSpeed;
            }
            else if (e.KeyCode == Keys.P)
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

        }



    }
}


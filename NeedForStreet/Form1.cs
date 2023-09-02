using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeedForStreet
{
    public partial class Form1 : Form
    {
        private int _score = 0;

        private int bg_speed = 2;
        private int enemy_speed = 4;
        private int player_speed = 5;
        private int enemies_delay = -100;

        private PictureBox[] enemies_right = new PictureBox[3];
        private PictureBox[] enemies_left = new PictureBox[3];
        private PictureBox[] background_fields = new PictureBox[3];

        private Point _position;
        private bool _dragging;
        private Random _delay;
        public Form1()
        {
            InitializeComponent();

            _delay = new Random();

            label_lose.Visible = false;  
            label_end_score.Visible = false;  
            label_record.Visible = false;

            box_record.Text = "RECORD: 0";

            enemies_left[0] = enemy1;
            enemies_left[1] = enemy2;
            enemies_left[2] = enemy3;

            enemies_right[0] = enemy4;
            enemies_right[1] = enemy5;
            enemies_right[2] = enemy6;

            background_fields[0] = bg1;
            background_fields[1] = bg2;
            background_fields[2] = bg3;

            for(int i = 0; i < 3; i++)
            {
                background_fields[i].MouseDown += MouseClickDown;
                background_fields[i].MouseUp += MouseClickUp;
                background_fields[i].MouseMove += MouseClickMove;
            }
        }

        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if(_dragging)
            {
                Point currPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currPoint.X - _position.X, currPoint.Y -_position.Y);
            }
        }

        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _position.X = e.X;
            _position.Y = e.Y;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            box_score.Text = "SCORE: " + _score + " ";

            for(int i = 0; i < 3; i++)
            {
                background_fields[i].Top += bg_speed;
                if (background_fields[i].Top >= 1110)
                {
                    background_fields[i].Top = -2200;
                }
            }

            for (int i = 0; i < 3; ++i)
            {
                enemies_left[i].Top += enemy_speed;
                enemies_right[i].Top += enemy_speed / 2;
                if (enemies_left[i].Top >= 1110)
                {
                    _score += 1;
                    Game_Speed_Change();
                    enemies_left[i].Top = -50 + _delay.Next(enemies_delay, enemies_delay + 100); 
                }
                if (enemies_right[i].Top >= 1110)
                {
                    _score += 1;
                    Game_Speed_Change();
                    enemies_right[i].Top = -50 + _delay.Next(enemies_delay, enemies_delay + 100);
                }
            }
        }

        private void Game_Speed_Change()
        {
            if (_score % 5 == 0)
            {
                bg_speed++;
                enemy_speed += 1;
            }
            else if (_score % 10 == 0)
            {
                enemies_delay -= 50;
                player_speed++;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && Player.Left > 80)
            {
                Player.Left -= player_speed;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && Player.Right < 700)
            {
                Player.Left += player_speed;
            }
            else if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && Player.Top > 100)
            {
                Player.Top -= player_speed;
            }
            else if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && Player.Bottom < 700)
            {
                Player.Top += player_speed;
            } 
        }
    }
}

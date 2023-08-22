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
        private PictureBox[] enemies_right = new PictureBox[3];
        private PictureBox[] enemies_left = new PictureBox[3];
        private Point _position;
        private bool _dragging;
        private Random _delay;
        public Form1()
        {
            InitializeComponent();

            _delay = new Random();

            enemies_left[0] = enemy1;
            enemies_left[1] = enemy2;
            enemies_left[2] = enemy3;

            enemies_right[0] = enemy4;
            enemies_right[1] = enemy5;
            enemies_right[2] = enemy6;

            bg1.MouseDown += MouseClickDown;
            bg1.MouseUp += MouseClickUp;
            bg1.MouseMove += MouseClickMove;

            bg2.MouseDown += MouseClickDown;
            bg2.MouseUp += MouseClickUp;
            bg2.MouseMove += MouseClickMove;
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


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int bg_speed = 3;
            bg1.Top += bg_speed;
            bg2.Top += bg_speed;

            int enemy_speed = 2;

            for (int i = 0; i < 3; ++i)
            {
                enemies_left[i].Top += enemy_speed;
                enemies_right[i].Top += enemy_speed / 2;
                if (enemies_left[i].Top >= 1100)
                {
                    enemies_left[i].Top = -50 + _delay.Next(-70, 10);
                }
                if (enemies_right[i].Top >= 1100)
                {
                    enemies_right[i].Top = -50 + _delay.Next(-70, 10);
                }
            }
            enemies_left[0].Top += enemy_speed;
            enemies_left[1].Top += enemy_speed;
            enemies_left[2].Top += enemy_speed;

            if (bg1.Top >= 1100)
            {
                bg1.Top = 0;
                bg2.Top = -1100;
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && Player.Left > 80)
            {
                Player.Left -= speed;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && Player.Right < 700)
            {
                Player.Left += speed;
            }
            else if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && Player.Top > 100)
            {
                Player.Top -= speed;
            }
            else if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && Player.Bottom < 740)
            {
                Player.Top += speed;
            } 
        }

        private void enemy2_Click(object sender, EventArgs e)
        {

        }
    }
}

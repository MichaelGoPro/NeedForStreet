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

        private Point _position;
        private bool _dragging;
        public Form1()
        {
            InitializeComponent();

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
            int speed = 3;
            bg1.Top += speed;
            bg2.Top += speed;
            if(bg1.Top >= 1100)
            {
                bg1.Top = 0;
                bg2.Top = -1100;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && Car.Left > 80)
            {
                Car.Left -= speed;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && Car.Right < 700)
            {
                Car.Left += speed;
            }
            else if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && Car.Top > 100)
            {
                Car.Top -= speed;
            }
            else if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && Car.Bottom < 740)
            {
                Car.Top += speed;
            }
        }
    }
}

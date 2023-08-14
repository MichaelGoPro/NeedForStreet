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
        public Form1()
        {
            InitializeComponent();
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
            Road1.Top += speed;
            Road2.Top += speed;
            if(Road1.Top >= 1100)
            {
                Road1.Top = 0;
                Road2.Top = -1100;
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

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeedForStreet
{
    public partial class Form1 : Form
    {
        #region vars and consts
        private const string path = "C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet";
        private const int enemies_delay1 = -300;
        private const int enemies_delay2 = 10;
        private const int _images_amout = 7;
        private const int _enemies_amount = 3;

        private StreamReader _reader;
        private StreamWriter _writer;

        private int _score = 0;
        private int _record;

        private int bg_speed = 2;
        private int enemy_speed = 4;
        private int player_speed = 5;

        private Image[] cars_left_images = new Image[_images_amout];
        private Image[] cars_right_images = new Image[_images_amout];
        private PictureBox[] enemies_right = new PictureBox[_enemies_amount];
        private PictureBox[] enemies_left = new PictureBox[_enemies_amount];
        private PictureBox[] background_fields = new PictureBox[3];

        private Point _position;
        private bool _dragging;
        private Random _delay;
        private Random _car_image;

        #endregion
        public Form1()
        {
            InitializeComponent();

            _delay = new Random();
            _car_image = new Random();

            KeyPreview = true;

            _reader = new StreamReader(path + "\\Record.txt");
            _record = Int32.Parse(_reader.ReadLine());
            box_record.Text = "RECORD: " + _record;

            box_score.Text = "SCORE: " + _score + " ";

            Initialize_Enemies();
            Initialize_Enemies_Images();

            EndGame_Menu_Visible(false);
            
            for (int i = 0; i < 3; i++)
            {
                background_fields[i].MouseDown += MouseClickDown;   
                background_fields[i].MouseUp += MouseClickUp;
                background_fields[i].MouseMove += MouseClickMove;
            }
        }

        #region window dragging;

        //make endgame menu visible and invisible and call update record
        private void EndGame_Menu_Visible(bool visible)
        {
            if(!visible)
            {
                label_lose.Visible = false;
                label_end_score.Visible = false;
                label_record.Visible = false;
                button_play.Visible = false;
            }
            else
            {
                label_lose.Visible = true;
                label_end_score.Visible = true;
                label_end_score.Text = "SCORE: " + _score;
                Record_Update();
                button_play.Visible = true;
            }
        }

        //fill enemies_left and enemies_right
        private void Initialize_Enemies()
        {
            enemies_left[0] = enemy1;
            enemies_left[1] = enemy2;
            enemies_left[2] = enemy3;

            enemies_right[0] = enemy4;
            enemies_right[1] = enemy5;
            enemies_right[2] = enemy6;

            background_fields[0] = bg1;
            background_fields[1] = bg2;
            background_fields[2] = bg3;
        }


        //fill cars_images right and left with images from file
        private void Initialize_Enemies_Images()
        {
            cars_right_images[0] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_3_01.png");
            cars_right_images[1] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_4_01.png");
            cars_right_images[2] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_5_01.png");
            cars_right_images[3] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_6_01.png");
            cars_right_images[4] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_7_01.png");
            cars_right_images[5] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_8_01.png");
            cars_right_images[6] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_9_01.png");

            cars_left_images[0] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_3_02.png");
            cars_left_images[1] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_4_02.png");
            cars_left_images[2] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_5_02.png");
            cars_left_images[3] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_6_02.png");
            cars_left_images[4] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_7_02.png");
            cars_left_images[5] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_8_02.png");
            cars_left_images[6] = System.Drawing.Image.FromFile(path + "\\Images\\Cars\\car_9_02.png");
        }

        //move the window
        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point currPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currPoint.X - _position.X, currPoint.Y - _position.Y);
            }
        }

        //make _dragging = false
        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        //main dragging function change window coordinates
        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _position.X = e.X;
            _position.Y = e.Y;
        }

        //bind Esc KeyChar to close the game window
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        #endregion

        //main ingame function 
        private void timer1_Tick(object sender, EventArgs e)
        {
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
                Game_End(enemies_left[i], enemies_right[i]);
                enemies_left[i].Top += enemy_speed;
                enemies_right[i].Top += enemy_speed / 2;
                if (enemies_left[i].Top >= 1110)
                {
                    Enemy_Spown(enemies_left[i], true);
                }
                if (enemies_right[i].Top >= 1110)
                {
                    Enemy_Spown(enemies_right[i], false);
                }
            }
        }


        //activate endgame menu and update record if need
        private void Game_End(PictureBox enemy_left, PictureBox enemy_right)
        {
            if(Player.Bounds.IntersectsWith(enemy_left.Bounds) ||
                Player.Bounds.IntersectsWith(enemy_right.Bounds))
            {
                main_timer.Enabled = false;
                EndGame_Menu_Visible(true);
            }
        }

        //write new record in file and endgame menu
        private void Record_Update()
        {
            if(_record < _score)
            {
                _reader.Close();
                _writer = new StreamWriter(path + "\\Record.txt");
                _writer.WriteLine(_score); 
                label_record.Visible = true;
                _writer.Close();
            }
        }

        //spown enemies right and left with random images and call Game_Speed_Change
        private void Enemy_Spown(PictureBox enemy, bool rotation)
        {
            if (rotation)
            {
                Image tmp_image = cars_left_images[_car_image.Next(0, 6)];
                enemy.Image = tmp_image;
            }
            else
            {
                Image tmp_image = cars_right_images[_car_image.Next(0, 6)];
                enemy.Image = tmp_image;
            }
            Change_Score();
            Game_Speed_Change();
            enemy.Top = -50 + _delay.Next(enemies_delay1, enemies_delay2);
        }

        //change score and update score_box text
        private void Change_Score()
        {
            _score += 1;
            box_score.Text = "SCORE: " + _score + " ";
        }

        //change game and enemies speed
        private void Game_Speed_Change()
        {
            if (_score % 5 == 0)
            {
                bg_speed++;
                enemy_speed += 1;
            }
            else if (_score % 10 == 0)
            {
                player_speed++;
            }
        }

        // player moving 
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

        private void button_play_Click(object sender, EventArgs e)
        {
            EndGame_Menu_Visible(false);
            Game_Start();
            main_timer.Enabled = true;
        }

        private void Game_Start()
        {
            _score = 0;
            bg_speed = 2;
            enemy_speed = 4;
            player_speed = 5;

            enemy1.Top = -250;
            enemy2.Top = 789;
            enemy3.Top = 245;
            enemy4.Top = 160;
            enemy5.Top = -300;
            enemy6.Top = 667;

            Player.Top = 490;
            Player.Left = 430;
        }
    }
}

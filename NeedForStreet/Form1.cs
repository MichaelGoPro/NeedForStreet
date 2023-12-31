﻿using System;
using Npgsql;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace NeedForStreet
{
    public partial class Form1 : Form
    {
        #region vars and consts
        private const string path = "C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet";
        private const string connectionString = "Server = 127.0.0.1; Port=5432;User=postgres;Password=1234;Database=postgres;";
        private const int enemies_delay1 = -300;
        private const int enemies_delay2 = 10;
        private const int _images_amount = 7;
        private const int _enemies_amount = 3;
        private const int V = 5;
        private StreamReader _reader_record;
        private StreamWriter _writer_record;

        private StreamReader _reader_coins;
        private StreamWriter _writer_coins;

        private int _score = 0;
        private int _coins = 0;
        private int _record;

        private int bg_speed = 2;
        private int enemy_speed = 4;
        private int player_speed = 5;

        private Image[] cars_left_images = new Image[_images_amount];
        private Image[] cars_right_images = new Image[_images_amount];
        private PictureBox[] enemies_right = new PictureBox[_enemies_amount];
        private PictureBox[] enemies_left = new PictureBox[_enemies_amount];
        private PictureBox[] background_fields = new PictureBox[3];

        private Point _position;
        private bool _dragging;
        private bool _lose;
        private Random _delay;
        private Random _car_image;

        #endregion
        public Form1()
        {
            InitializeComponent();
            Inizialize_DB_Connection();

            main_timer.Enabled = false;

            _lose = false;
            _delay = new Random();
            _car_image = new Random();

            KeyPreview = true;

            Initialize_Streams();
            Initialize_Enemies();
            Initialize_Enemies_Images();
            Initialize_Counters();
            Initialize_Moving_Functions();

            UnlockCars();

            EndGame_Menu_Visible(false);

        }

        #region Initializers
        private void Initialize_Moving_Functions()
        {
            for (int i = 0; i < 3; i++)
            {
                background_fields[i].MouseDown += MouseClickDown;
                background_fields[i].MouseUp += MouseClickUp;
                background_fields[i].MouseMove += MouseClickMove;
            }
        }

        private void Initialize_Streams()
        {
            _reader_record = new StreamReader(path + "\\Record.txt");
            _reader_coins = new StreamReader(path + "\\Coins.txt");
        }

        private void Initialize_Counters()
        {
            _coins = Int32.Parse(_reader_coins.ReadLine());
            _record = Int32.Parse(_reader_record.ReadLine());
            box_coins.Text = _coins.ToString();
            box_record.Text = "RECORD: " + _record;
            box_score.Text = "SCORE: " + _score + " ";
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

        #endregion

        //make endgame menu visible and invisible and call update score and update coins
        private void EndGame_Menu_Visible(bool visible)
        {
            if (!visible)
            {
                car_change_button.Visible = false;
                label_lose.Visible = false;
                label_end_score.Visible = false;
                label_record.Visible = false;
                button_play.Visible = false;
            }
            else
            {
                car_change_button.Visible = true;
                label_lose.Visible = true;
                label_end_score.Visible = true;
                label_end_score.Text = "SCORE: " + _score;
                Record_Update();
                Coins_Update();
                button_play.Visible = true;
            }
        }

        #region window dragging;

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
            Bg_Move();

            Coin_Behavior();

            for (int i = 0; i < 3; ++i)
            {
                Game_End(enemies_left[i], enemies_right[i]);
                Enemy_Move(i);
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

        #region Coin functions
        // contains Coin_Move and Coin_Intersects
        private void Coin_Behavior()
        {
            Coin_Move();
            Coin_Intersects();
        }

        //move coin on game field
        private void Coin_Move()
        {
            box_coin.Top += bg_speed;
            if (box_coin.Top >= 1110)
            {
                Coin_Respown();
            }
        }

        //check coin intersects with player
        private void Coin_Intersects()
        {
            if (Player.Bounds.IntersectsWith(box_coin.Bounds))
            {
                _coins++;
                box_coins.Text = _coins.ToString();
                Coin_Respown();
            }
        }

        //respown coins with vertical and horizontal delay
        private void Coin_Respown()
        {
            box_coin.Top = -200 + _delay.Next(-200, -100);
            box_coin.Left = _delay.Next(130, 700);
        }

        //write new coins value in file
        private void Coins_Update()
        {
            _reader_coins.Close();
            _writer_coins = new StreamWriter(path + "\\Coins.txt");
            _writer_coins.WriteLine(_coins);
            _writer_coins.Close();
        }
        #endregion

        //move background fields
        private void Bg_Move()
        {
            for (int i = 0; i < 3; i++)
            {
                background_fields[i].Top += bg_speed;
                if (background_fields[i].Top >= 1110)
                {
                    background_fields[i].Top = -2200;
                }
            }
        }

        //activate endgame menu and update record if need
        private void Game_End(PictureBox enemy_left, PictureBox enemy_right)
        {
            if (Player.Bounds.IntersectsWith(enemy_left.Bounds) ||
                Player.Bounds.IntersectsWith(enemy_right.Bounds))
            {
                _lose = true;
                main_timer.Enabled = false;
                EndGame_Menu_Visible(true);
            }
        }

        //write new record in file and endgame menu
        private void Record_Update()
        {
            if (_record < _score)
            {
                _reader_record.Close();
                _writer_record = new StreamWriter(path + "\\Record.txt");
                _writer_record.WriteLine(_score);
                label_record.Visible = true;
                _writer_record.Close();
            }
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
            if (_lose)
            {
                return;
            }
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && Player.Left > 80)
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

        //make menu invisible and restart timer
        private void button_play_Click(object sender, EventArgs e)
        {
            Play_Click_Action();
        }

        private void Play_Click_Action()
        {
            EndGame_Menu_Visible(false);
            Game_Start();
            box_score.Text = "SCORE: " + _score + " ";
            box_record.Text = "RECORD: " + _record;
            main_timer.Enabled = true;
        }

        //set default position for enemies and player, default settings, open IO streams
        private void Game_Start()
        {
            _lose = false;
            _score = 0;
            bg_speed = 2;
            enemy_speed = 4;
            player_speed = 5;

            Set_Enemies_Default();
            Set_Player_Default();
            Initialize_Streams();
            Initialize_Counters();
        }

        //set Player on default position
        private void Set_Player_Default()
        {
            Player.Top = 490;
            Player.Left = 430;
        }

        #region enemies functions
        //set enemies on default position
        private void Set_Enemies_Default()
        {
            enemy1.Top = -250;
            enemy2.Top = 789;
            enemy3.Top = 245;
            enemy4.Top = 160;
            enemy5.Top = -300;
            enemy6.Top = 667;
        }

        //move enemy_left end enemy_right with index
        private void Enemy_Move(int index)
        {

            enemies_left[index].Top += enemy_speed;
            enemies_right[index].Top += enemy_speed / 2;
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

        #endregion

        #region DB functions

        private void Inizialize_DB_Connection()
        {
            return;
            //NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            //connection.Open();
        }

        private void Update_Score_From_DB()
        {
            return;
        }

        private void Update_Coins_From_DB()
        {
            return;
        }

        #endregion

        #region car select menu

        private void Close_Menu()
        {
            select_car_button_1.Visible = false;
            select_car_button_2.Visible = false;
            select_car_button_3.Visible = false;
            select_car_button_4.Visible = false;
            select_car_button_5.Visible = false;
            select_car_button_6.Visible = false;
            select_car_button_7.Visible = false;
            select_car_button_8.Visible = false;

            car_select_menu_bg.Visible = false;

            selected_car1.Visible = false;
            selected_car2.Visible = false;
            selected_car3.Visible = false;
            selected_car4.Visible = false;
            selected_car5.Visible = false;
            selected_car6.Visible = false;
            selected_car7.Visible = false;
            selected_car8.Visible = false;

            car_Select_box.Visible = false;
        }

        private void Open_Menu()
        {
            select_car_button_1.Visible = true;
            select_car_button_2.Visible = true;
            select_car_button_3.Visible = true;
            select_car_button_4.Visible = true;
            select_car_button_5.Visible = true;
            select_car_button_6.Visible = true;
            select_car_button_7.Visible = true;
            select_car_button_8.Visible = true;

            car_select_menu_bg.Visible = true;

            selected_car1.Visible = true;
            selected_car2.Visible = true;
            selected_car3.Visible = true;
            selected_car4.Visible = true;
            selected_car5.Visible = true;
            selected_car6.Visible = true;
            selected_car7.Visible = true;
            selected_car8.Visible = true;

            car_Select_box.Visible = true;
        }


        //set picture box image == image with the path
        private void Change_Player_Skin(string path)
        {
            Player.Image = System.Drawing.Image.FromFile(path);
        }

        //lock cars if coins < param
        private void UnlockCars()
        {
            if(_coins < 5)
                select_car_button_2.Enabled = false;
            if (_coins < 10)
                select_car_button_3.Enabled = false;
            if (_coins < 20)
                select_car_button_4.Enabled = false;
            if (_coins < 30)
                select_car_button_5.Enabled = false;
            if (_coins < 40)
                select_car_button_6.Enabled = false;
            if (_coins < 50)
                select_car_button_7.Enabled = false;
            if (_coins < 60)
                select_car_button_8.Enabled = false;
        }

        private void select_car_button_1_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_1_01 — копия.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_2_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_2_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_3_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_3_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_4_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_4_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_5_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_5_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_6_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_6_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_7_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_8_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void select_car_button_8_Click(object sender, EventArgs e)
        {
            Change_Player_Skin("C:\\Users\\MikhailS\\source\\repos\\NeedForStreet\\NeedForStreet\\Images\\Cars\\Car_9_01.png");
            Close_Menu();
            Play_Click_Action();
        }

        private void car_change_button_Click(object sender, EventArgs e)
        {
            Open_Menu();
            car_change_button.Visible = false;
        }
        #endregion
    }
}
namespace NeedForStreet
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bg1 = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            this.main_timer = new System.Windows.Forms.Timer(this.components);
            this.bg2 = new System.Windows.Forms.PictureBox();
            this.enemy2 = new System.Windows.Forms.PictureBox();
            this.enemy1 = new System.Windows.Forms.PictureBox();
            this.enemy3 = new System.Windows.Forms.PictureBox();
            this.enemy4 = new System.Windows.Forms.PictureBox();
            this.enemy6 = new System.Windows.Forms.PictureBox();
            this.enemy5 = new System.Windows.Forms.PictureBox();
            this.box_score = new System.Windows.Forms.TextBox();
            this.bg3 = new System.Windows.Forms.PictureBox();
            this.label_lose = new System.Windows.Forms.Label();
            this.label_record = new System.Windows.Forms.Label();
            this.label_end_score = new System.Windows.Forms.Label();
            this.box_record = new System.Windows.Forms.TextBox();
            this.button_play = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg3)).BeginInit();
            this.SuspendLayout();
            // 
            // bg1
            // 
            this.bg1.Image = ((System.Drawing.Image)(resources.GetObject("bg1.Image")));
            this.bg1.Location = new System.Drawing.Point(0, 0);
            this.bg1.Margin = new System.Windows.Forms.Padding(0);
            this.bg1.Name = "bg1";
            this.bg1.Size = new System.Drawing.Size(1030, 1100);
            this.bg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg1.TabIndex = 4;
            this.bg1.TabStop = false;
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(571, 667);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(105, 177);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 5;
            this.Player.TabStop = false;
            // 
            // main_timer
            // 
            this.main_timer.Enabled = true;
            this.main_timer.Interval = 5;
            this.main_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bg2
            // 
            this.bg2.Image = ((System.Drawing.Image)(resources.GetObject("bg2.Image")));
            this.bg2.Location = new System.Drawing.Point(0, -1100);
            this.bg2.Margin = new System.Windows.Forms.Padding(0);
            this.bg2.Name = "bg2";
            this.bg2.Size = new System.Drawing.Size(1030, 1100);
            this.bg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg2.TabIndex = 6;
            this.bg2.TabStop = false;
            // 
            // enemy2
            // 
            this.enemy2.BackColor = System.Drawing.Color.Transparent;
            this.enemy2.Image = ((System.Drawing.Image)(resources.GetObject("enemy2.Image")));
            this.enemy2.Location = new System.Drawing.Point(345, 789);
            this.enemy2.Name = "enemy2";
            this.enemy2.Size = new System.Drawing.Size(105, 177);
            this.enemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy2.TabIndex = 7;
            this.enemy2.TabStop = false;
            // 
            // enemy1
            // 
            this.enemy1.BackColor = System.Drawing.Color.Transparent;
            this.enemy1.Image = ((System.Drawing.Image)(resources.GetObject("enemy1.Image")));
            this.enemy1.Location = new System.Drawing.Point(337, -250);
            this.enemy1.Name = "enemy1";
            this.enemy1.Size = new System.Drawing.Size(105, 177);
            this.enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy1.TabIndex = 8;
            this.enemy1.TabStop = false;
            // 
            // enemy3
            // 
            this.enemy3.BackColor = System.Drawing.Color.Transparent;
            this.enemy3.Image = ((System.Drawing.Image)(resources.GetObject("enemy3.Image")));
            this.enemy3.Location = new System.Drawing.Point(141, 245);
            this.enemy3.Name = "enemy3";
            this.enemy3.Size = new System.Drawing.Size(105, 177);
            this.enemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy3.TabIndex = 9;
            this.enemy3.TabStop = false;
            // 
            // enemy4
            // 
            this.enemy4.BackColor = System.Drawing.Color.Transparent;
            this.enemy4.Image = ((System.Drawing.Image)(resources.GetObject("enemy4.Image")));
            this.enemy4.Location = new System.Drawing.Point(571, 160);
            this.enemy4.Name = "enemy4";
            this.enemy4.Size = new System.Drawing.Size(105, 177);
            this.enemy4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy4.TabIndex = 10;
            this.enemy4.TabStop = false;
            // 
            // enemy6
            // 
            this.enemy6.BackColor = System.Drawing.Color.Transparent;
            this.enemy6.Image = ((System.Drawing.Image)(resources.GetObject("enemy6.Image")));
            this.enemy6.Location = new System.Drawing.Point(786, 667);
            this.enemy6.Name = "enemy6";
            this.enemy6.Size = new System.Drawing.Size(105, 177);
            this.enemy6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy6.TabIndex = 11;
            this.enemy6.TabStop = false;
            // 
            // enemy5
            // 
            this.enemy5.BackColor = System.Drawing.Color.Transparent;
            this.enemy5.Image = ((System.Drawing.Image)(resources.GetObject("enemy5.Image")));
            this.enemy5.Location = new System.Drawing.Point(787, -300);
            this.enemy5.Name = "enemy5";
            this.enemy5.Size = new System.Drawing.Size(105, 177);
            this.enemy5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy5.TabIndex = 12;
            this.enemy5.TabStop = false;
            // 
            // box_score
            // 
            this.box_score.BackColor = System.Drawing.SystemColors.Menu;
            this.box_score.Enabled = false;
            this.box_score.Font = new System.Drawing.Font("Segoe Print", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.box_score.Location = new System.Drawing.Point(804, 822);
            this.box_score.Margin = new System.Windows.Forms.Padding(0);
            this.box_score.Name = "box_score";
            this.box_score.ReadOnly = true;
            this.box_score.Size = new System.Drawing.Size(215, 55);
            this.box_score.TabIndex = 20;
            this.box_score.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bg3
            // 
            this.bg3.Image = ((System.Drawing.Image)(resources.GetObject("bg3.Image")));
            this.bg3.Location = new System.Drawing.Point(0, -2200);
            this.bg3.Margin = new System.Windows.Forms.Padding(0);
            this.bg3.Name = "bg3";
            this.bg3.Size = new System.Drawing.Size(1030, 1100);
            this.bg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg3.TabIndex = 21;
            this.bg3.TabStop = false;
            // 
            // label_lose
            // 
            this.label_lose.AutoSize = true;
            this.label_lose.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_lose.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_lose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_lose.Font = new System.Drawing.Font("Segoe Print", 55F, System.Drawing.FontStyle.Bold);
            this.label_lose.ForeColor = System.Drawing.Color.Red;
            this.label_lose.Location = new System.Drawing.Point(252, 257);
            this.label_lose.Name = "label_lose";
            this.label_lose.Size = new System.Drawing.Size(542, 165);
            this.label_lose.TabIndex = 22;
            this.label_lose.Text = "CRASHED";
            // 
            // label_record
            // 
            this.label_record.AutoSize = true;
            this.label_record.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_record.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_record.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.label_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_record.Font = new System.Drawing.Font("Segoe Print", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_record.ForeColor = System.Drawing.Color.Red;
            this.label_record.Location = new System.Drawing.Point(234, 567);
            this.label_record.Name = "label_record";
            this.label_record.Size = new System.Drawing.Size(590, 125);
            this.label_record.TabIndex = 23;
            this.label_record.Text = "NEW RECORD!";
            // 
            // label_end_score
            // 
            this.label_end_score.AutoSize = true;
            this.label_end_score.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_end_score.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_end_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_end_score.Font = new System.Drawing.Font("Segoe Print", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_end_score.ForeColor = System.Drawing.Color.Red;
            this.label_end_score.Location = new System.Drawing.Point(252, 445);
            this.label_end_score.Name = "label_end_score";
            this.label_end_score.Size = new System.Drawing.Size(237, 86);
            this.label_end_score.TabIndex = 24;
            this.label_end_score.Text = "SCORE: ";
            // 
            // box_record
            // 
            this.box_record.BackColor = System.Drawing.SystemColors.Menu;
            this.box_record.Enabled = false;
            this.box_record.Font = new System.Drawing.Font("Segoe Print", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.box_record.Location = new System.Drawing.Point(9, 822);
            this.box_record.Margin = new System.Windows.Forms.Padding(0);
            this.box_record.Name = "box_record";
            this.box_record.ReadOnly = true;
            this.box_record.Size = new System.Drawing.Size(215, 55);
            this.box_record.TabIndex = 25;
            // 
            // button_play
            // 
            this.button_play.AllowDrop = true;
            this.button_play.BackColor = System.Drawing.Color.LimeGreen;
            this.button_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_play.Font = new System.Drawing.Font("Segoe Print", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_play.Location = new System.Drawing.Point(624, 444);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(209, 87);
            this.button_play.TabIndex = 26;
            this.button_play.Text = "PLAY";
            this.button_play.UseVisualStyleBackColor = false;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 1100);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.box_record);
            this.Controls.Add(this.label_end_score);
            this.Controls.Add(this.label_record);
            this.Controls.Add(this.label_lose);
            this.Controls.Add(this.box_score);
            this.Controls.Add(this.enemy5);
            this.Controls.Add(this.enemy6);
            this.Controls.Add(this.enemy4);
            this.Controls.Add(this.enemy3);
            this.Controls.Add(this.enemy1);
            this.Controls.Add(this.enemy2);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.bg1);
            this.Controls.Add(this.bg2);
            this.Controls.Add(this.bg3);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NeedForStreet";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bg1;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer main_timer;
        private System.Windows.Forms.PictureBox bg2;
        private System.Windows.Forms.PictureBox enemy2;
        private System.Windows.Forms.PictureBox enemy1;
        private System.Windows.Forms.PictureBox enemy3;
        private System.Windows.Forms.PictureBox enemy4;
        private System.Windows.Forms.PictureBox enemy6;
        private System.Windows.Forms.PictureBox enemy5;
        private System.Windows.Forms.TextBox box_score;
        private System.Windows.Forms.PictureBox bg3;
        private System.Windows.Forms.Label label_lose;
        private System.Windows.Forms.Label label_record;
        private System.Windows.Forms.Label label_end_score;
        private System.Windows.Forms.TextBox box_record;
        private System.Windows.Forms.Button button_play;
    }
}


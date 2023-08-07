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
            this.Road1 = new System.Windows.Forms.PictureBox();
            this.Car = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Road2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Road1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Road2)).BeginInit();
            this.SuspendLayout();
            // 
            // Road1
            // 
            this.Road1.Image = ((System.Drawing.Image)(resources.GetObject("Road1.Image")));
            this.Road1.Location = new System.Drawing.Point(0, 0);
            this.Road1.Margin = new System.Windows.Forms.Padding(0);
            this.Road1.Name = "Road1";
            this.Road1.Size = new System.Drawing.Size(1030, 1100);
            this.Road1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Road1.TabIndex = 4;
            this.Road1.TabStop = false;
            // 
            // Car
            // 
            this.Car.BackColor = System.Drawing.Color.Transparent;
            this.Car.Image = ((System.Drawing.Image)(resources.GetObject("Car.Image")));
            this.Car.Location = new System.Drawing.Point(619, 818);
            this.Car.Name = "Car";
            this.Car.Size = new System.Drawing.Size(105, 177);
            this.Car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Car.TabIndex = 5;
            this.Car.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Road2
            // 
            this.Road2.Image = ((System.Drawing.Image)(resources.GetObject("Road2.Image")));
            this.Road2.Location = new System.Drawing.Point(0, -1100);
            this.Road2.Margin = new System.Windows.Forms.Padding(0);
            this.Road2.Name = "Road2";
            this.Road2.Size = new System.Drawing.Size(1030, 1100);
            this.Road2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Road2.TabIndex = 6;
            this.Road2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 1100);
            this.Controls.Add(this.Car);
            this.Controls.Add(this.Road1);
            this.Controls.Add(this.Road2);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NeedForStreet";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Road1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Road2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Road1;
        private System.Windows.Forms.PictureBox Car;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox Road2;
    }
}


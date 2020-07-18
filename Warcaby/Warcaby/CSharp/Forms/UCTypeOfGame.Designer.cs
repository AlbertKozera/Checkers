namespace Warcaby.Forms
{
    partial class UCTypeOfGame
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonComputerVSComputer = new System.Windows.Forms.Button();
            this.buttonPlayerVSComputer = new System.Windows.Forms.Button();
            this.buttonPlayerVSPlayer = new System.Windows.Forms.Button();
            this.button1 = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonComputerVSComputer
            // 
            this.buttonComputerVSComputer.BackColor = System.Drawing.Color.White;
            this.buttonComputerVSComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComputerVSComputer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonComputerVSComputer.Location = new System.Drawing.Point(294, 327);
            this.buttonComputerVSComputer.Name = "buttonComputerVSComputer";
            this.buttonComputerVSComputer.Size = new System.Drawing.Size(180, 65);
            this.buttonComputerVSComputer.TabIndex = 1;
            this.buttonComputerVSComputer.Text = "komputer vs komputer";
            this.buttonComputerVSComputer.UseVisualStyleBackColor = false;
            this.buttonComputerVSComputer.Click += new System.EventHandler(this.ButtonComputerVSComputer_Click);
            // 
            // buttonPlayerVSComputer
            // 
            this.buttonPlayerVSComputer.BackColor = System.Drawing.Color.White;
            this.buttonPlayerVSComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayerVSComputer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlayerVSComputer.Location = new System.Drawing.Point(294, 237);
            this.buttonPlayerVSComputer.Name = "buttonPlayerVSComputer";
            this.buttonPlayerVSComputer.Size = new System.Drawing.Size(180, 65);
            this.buttonPlayerVSComputer.TabIndex = 2;
            this.buttonPlayerVSComputer.Text = "gracz vs komputer";
            this.buttonPlayerVSComputer.UseVisualStyleBackColor = false;
            this.buttonPlayerVSComputer.Click += new System.EventHandler(this.ButtonPlayerVSComputer_Click);
            // 
            // buttonPlayerVSPlayer
            // 
            this.buttonPlayerVSPlayer.BackColor = System.Drawing.Color.White;
            this.buttonPlayerVSPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayerVSPlayer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlayerVSPlayer.Location = new System.Drawing.Point(294, 144);
            this.buttonPlayerVSPlayer.Name = "buttonPlayerVSPlayer";
            this.buttonPlayerVSPlayer.Size = new System.Drawing.Size(180, 65);
            this.buttonPlayerVSPlayer.TabIndex = 3;
            this.buttonPlayerVSPlayer.Text = "gracz vs gracz";
            this.buttonPlayerVSPlayer.UseVisualStyleBackColor = false;
            this.buttonPlayerVSPlayer.Click += new System.EventHandler(this.ButtonPlayerVSPlayer_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft;
            this.button1.IconColor = System.Drawing.Color.Black;
            this.button1.IconSize = 25;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(322, 496);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.button1.Rotation = 0D;
            this.button1.Size = new System.Drawing.Size(110, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Powrót";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.backToMenu);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconSize = 30;
            this.iconPictureBox1.Location = new System.Drawing.Point(480, 166);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBox1.TabIndex = 9;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconSize = 30;
            this.iconPictureBox2.Location = new System.Drawing.Point(260, 166);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBox2.TabIndex = 10;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconPictureBox3.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox3.IconSize = 30;
            this.iconPictureBox3.Location = new System.Drawing.Point(258, 257);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBox3.TabIndex = 11;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.iconPictureBox4.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox4.Location = new System.Drawing.Point(478, 257);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox4.TabIndex = 12;
            this.iconPictureBox4.TabStop = false;
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.iconPictureBox5.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox5.Location = new System.Drawing.Point(258, 348);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox5.TabIndex = 13;
            this.iconPictureBox5.TabStop = false;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.iconPictureBox6.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox6.Location = new System.Drawing.Point(478, 348);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox6.TabIndex = 14;
            this.iconPictureBox6.TabStop = false;
            // 
            // UCTypeOfGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.iconPictureBox6);
            this.Controls.Add(this.iconPictureBox5);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPlayerVSPlayer);
            this.Controls.Add(this.buttonPlayerVSComputer);
            this.Controls.Add(this.buttonComputerVSComputer);
            this.Name = "UCTypeOfGame";
            this.Size = new System.Drawing.Size(762, 600);
            this.Load += new System.EventHandler(this.UCTypeOfGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonComputerVSComputer;
        private System.Windows.Forms.Button buttonPlayerVSComputer;
        private System.Windows.Forms.Button buttonPlayerVSPlayer;
        private FontAwesome.Sharp.IconButton button1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
    }
}

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
            this.SuspendLayout();
            // 
            // buttonComputerVSComputer
            // 
            this.buttonComputerVSComputer.BackColor = System.Drawing.Color.White;
            this.buttonComputerVSComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComputerVSComputer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonComputerVSComputer.Location = new System.Drawing.Point(291, 344);
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
            this.buttonPlayerVSComputer.Location = new System.Drawing.Point(291, 259);
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
            this.buttonPlayerVSPlayer.Location = new System.Drawing.Point(291, 174);
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
            // UCTypeOfGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPlayerVSPlayer);
            this.Controls.Add(this.buttonPlayerVSComputer);
            this.Controls.Add(this.buttonComputerVSComputer);
            this.Name = "UCTypeOfGame";
            this.Size = new System.Drawing.Size(762, 600);
            this.Load += new System.EventHandler(this.UCTypeOfGame_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonComputerVSComputer;
        private System.Windows.Forms.Button buttonPlayerVSComputer;
        private System.Windows.Forms.Button buttonPlayerVSPlayer;
        private FontAwesome.Sharp.IconButton button1;
    }
}

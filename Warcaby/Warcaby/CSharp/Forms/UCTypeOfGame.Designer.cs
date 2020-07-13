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
            this.labelTypeOfGame = new System.Windows.Forms.Label();
            this.buttonComputerVSComputer = new System.Windows.Forms.Button();
            this.buttonPlayerVSComputer = new System.Windows.Forms.Button();
            this.buttonPlayerVSPlayer = new System.Windows.Forms.Button();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTypeOfGame
            // 
            this.labelTypeOfGame.AutoSize = true;
            this.labelTypeOfGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTypeOfGame.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTypeOfGame.Location = new System.Drawing.Point(398, 0);
            this.labelTypeOfGame.Name = "labelTypeOfGame";
            this.labelTypeOfGame.Size = new System.Drawing.Size(221, 50);
            this.labelTypeOfGame.TabIndex = 0;
            this.labelTypeOfGame.Text = "Rodzaj gry";
            // 
            // buttonComputerVSComputer
            // 
            this.buttonComputerVSComputer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonComputerVSComputer.Location = new System.Drawing.Point(423, 136);
            this.buttonComputerVSComputer.Name = "buttonComputerVSComputer";
            this.buttonComputerVSComputer.Size = new System.Drawing.Size(180, 65);
            this.buttonComputerVSComputer.TabIndex = 1;
            this.buttonComputerVSComputer.Text = "komputer vs komputer";
            this.buttonComputerVSComputer.UseVisualStyleBackColor = true;
            this.buttonComputerVSComputer.Click += new System.EventHandler(this.ButtonComputerVSComputer_Click);
            // 
            // buttonPlayerVSComputer
            // 
            this.buttonPlayerVSComputer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlayerVSComputer.Location = new System.Drawing.Point(423, 245);
            this.buttonPlayerVSComputer.Name = "buttonPlayerVSComputer";
            this.buttonPlayerVSComputer.Size = new System.Drawing.Size(180, 65);
            this.buttonPlayerVSComputer.TabIndex = 2;
            this.buttonPlayerVSComputer.Text = "gracz vs komputer";
            this.buttonPlayerVSComputer.UseVisualStyleBackColor = true;
            this.buttonPlayerVSComputer.Click += new System.EventHandler(this.ButtonPlayerVSComputer_Click);
            // 
            // buttonPlayerVSPlayer
            // 
            this.buttonPlayerVSPlayer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlayerVSPlayer.Location = new System.Drawing.Point(423, 354);
            this.buttonPlayerVSPlayer.Name = "buttonPlayerVSPlayer";
            this.buttonPlayerVSPlayer.Size = new System.Drawing.Size(180, 65);
            this.buttonPlayerVSPlayer.TabIndex = 3;
            this.buttonPlayerVSPlayer.Text = "gracz vs gracz";
            this.buttonPlayerVSPlayer.UseVisualStyleBackColor = true;
            this.buttonPlayerVSPlayer.Click += new System.EventHandler(this.ButtonPlayerVSPlayer_Click);
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBackToMenu.Location = new System.Drawing.Point(423, 514);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(180, 65);
            this.buttonBackToMenu.TabIndex = 4;
            this.buttonBackToMenu.Text = "Powrót do menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.ButtonBackToMenu_Click);
            // 
            // UCTypeOfGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.buttonPlayerVSPlayer);
            this.Controls.Add(this.buttonPlayerVSComputer);
            this.Controls.Add(this.buttonComputerVSComputer);
            this.Controls.Add(this.labelTypeOfGame);
            this.Name = "UCTypeOfGame";
            this.Size = new System.Drawing.Size(984, 661);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTypeOfGame;
        private System.Windows.Forms.Button buttonComputerVSComputer;
        private System.Windows.Forms.Button buttonPlayerVSComputer;
        private System.Windows.Forms.Button buttonPlayerVSPlayer;
        private System.Windows.Forms.Button buttonBackToMenu;
    }
}

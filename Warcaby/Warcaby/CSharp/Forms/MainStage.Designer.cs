

namespace Warcaby.CSharp.Forms
{
    partial class MainStage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainStage));
            this.ucOptions = new UCOptions();
            this.ucNewGame = new UCNewGame(0);
            this.ucMainMenu = new UCMainMenu();
            this.ucTypeOfGame = new UCTypeOfGame();
            this.clientStage = new ClientStage();
            this.SuspendLayout();
            // 
            // ucOptions
            // 
            this.ucOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucOptions.Location = new System.Drawing.Point(0, 0);
            this.ucOptions.Name = "ucOptions";
            this.ucOptions.Size = new System.Drawing.Size(762, 600);
            this.ucOptions.TabIndex = 0;
            // 
            // ucNewGame
            // 
            this.ucNewGame.Location = new System.Drawing.Point(0, 0);
            this.ucNewGame.Name = "ucNewGame";
            this.ucNewGame.Size = new System.Drawing.Size(762, 600);
            this.ucNewGame.TabIndex = 1;
            // 
            // ucMainMenu
            // 
            this.ucMainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucMainMenu.BackgroundImage")));
            this.ucMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ucMainMenu.Name = "ucMainMenu";
            this.ucMainMenu.Size = new System.Drawing.Size(762, 600);
            this.ucMainMenu.TabIndex = 2;
            // 
            // ucTypeOfGame
            // 
            this.ucTypeOfGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucTypeOfGame.BackgroundImage")));
            this.ucTypeOfGame.Location = new System.Drawing.Point(0, 0);
            this.ucTypeOfGame.Name = "ucTypeOfGame";
            this.ucTypeOfGame.Size = new System.Drawing.Size(762, 600);
            this.ucTypeOfGame.TabIndex = 3;
            // 
            // ClientStage
            // 
            this.clientStage.Location = new System.Drawing.Point(300, 0);
            this.clientStage.Name = "ClientStage";
            this.clientStage.Size = new System.Drawing.Size(762, 30);
            this.clientStage.TabIndex = 4;
            // 
            // MainStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 600);
            this.Controls.Add(this.ucTypeOfGame);
            this.Controls.Add(this.ucMainMenu);
            this.Controls.Add(this.ucNewGame);
            this.Controls.Add(this.ucOptions);
            this.Controls.Add(this.clientStage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainStage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warcaby";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.Icon = (Properties.Resources.Icon);
        }

        #endregion

        private Forms.UCOptions ucOptions;
        private Forms.UCNewGame ucNewGame;
        private Forms.UCMainMenu ucMainMenu;
        private Forms.UCTypeOfGame ucTypeOfGame;
        private Forms.ClientStage clientStage;
    }
}


namespace Warcaby
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ucOptions = new Warcaby.Forms.UCOptions();
            this.ucNewGame = new Warcaby.Forms.UCNewGame();
            this.ucMainMenu = new Warcaby.Forms.UCMainMenu();
            this.SuspendLayout();
            // 
            // ucOptions
            // 
            this.ucOptions.Location = new System.Drawing.Point(0, 0);
            this.ucOptions.Name = "ucOptions";
            this.ucOptions.Size = new System.Drawing.Size(984, 661);
            this.ucOptions.TabIndex = 0;
            // 
            // ucNewGame
            // 
            this.ucNewGame.Location = new System.Drawing.Point(0, 0);
            this.ucNewGame.Name = "ucNewGame";
            this.ucNewGame.Size = new System.Drawing.Size(984, 661);
            this.ucNewGame.TabIndex = 1;
            // 
            // ucMainMenu
            // 
            this.ucMainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucMainMenu.BackgroundImage")));
            this.ucMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ucMainMenu.Name = "ucMainMenu";
            this.ucMainMenu.Size = new System.Drawing.Size(984, 661);
            this.ucMainMenu.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 657);
            this.Controls.Add(this.ucMainMenu);
            this.Controls.Add(this.ucNewGame);
            this.Controls.Add(this.ucOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warcaby";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.UCOptions ucOptions;
        private Forms.UCNewGame ucNewGame;
        private Forms.UCMainMenu ucMainMenu;
    }
}


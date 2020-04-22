namespace Warcaby.Forms
{
    partial class UCNewGame
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
            this.labelNewGame = new System.Windows.Forms.Label();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNewGame
            // 
            this.labelNewGame.AutoSize = true;
            this.labelNewGame.Location = new System.Drawing.Point(451, 25);
            this.labelNewGame.Name = "labelNewGame";
            this.labelNewGame.Size = new System.Drawing.Size(53, 13);
            this.labelNewGame.TabIndex = 0;
            this.labelNewGame.Text = "Nowa gra";
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Location = new System.Drawing.Point(906, 3);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(75, 23);
            this.buttonBackToMenu.TabIndex = 1;
            this.buttonBackToMenu.Text = "Powrót";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.backToMenu);
            // 
            // usNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.labelNewGame);
            this.Name = "usNewGame";
            this.Size = new System.Drawing.Size(984, 661);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewGame;
        private System.Windows.Forms.Button buttonBackToMenu;
    }
}

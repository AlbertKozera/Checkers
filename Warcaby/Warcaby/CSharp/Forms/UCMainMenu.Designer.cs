

namespace Warcaby.CSharp.Forms
{
    partial class UCMainMenu
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
            this.buttonNewGame = new FontAwesome.Sharp.IconButton();
            this.buttonExit = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.White;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.buttonNewGame.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNewGame.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.buttonNewGame.IconColor = System.Drawing.Color.Black;
            this.buttonNewGame.IconSize = 35;
            this.buttonNewGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewGame.Location = new System.Drawing.Point(301, 215);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Rotation = 0D;
            this.buttonNewGame.Size = new System.Drawing.Size(160, 60);
            this.buttonNewGame.TabIndex = 3;
            this.buttonNewGame.Text = "Nowa gra";
            this.buttonNewGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.TypeOfGameEvent);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.White;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.buttonExit.IconColor = System.Drawing.Color.Black;
            this.buttonExit.IconSize = 35;
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(301, 313);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Rotation = 0D;
            this.buttonExit.Size = new System.Drawing.Size(160, 60);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ExitEvent);
            // 
            // UCMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "UCMainMenu";
            this.Size = new System.Drawing.Size(762, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton buttonNewGame;
        private FontAwesome.Sharp.IconButton buttonExit;
    }
}

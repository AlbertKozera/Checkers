namespace Warcaby.Forms
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
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonOption = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelWarcaby = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNewGame.Location = new System.Drawing.Point(422, 279);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(160, 60);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "Nowa gra";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.newGameEvent);
            // 
            // buttonOption
            // 
            this.buttonOption.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOption.Location = new System.Drawing.Point(422, 367);
            this.buttonOption.Name = "buttonOption";
            this.buttonOption.Size = new System.Drawing.Size(160, 60);
            this.buttonOption.TabIndex = 1;
            this.buttonOption.Text = "Opcje";
            this.buttonOption.UseVisualStyleBackColor = true;
            this.buttonOption.Click += new System.EventHandler(this.optionsEvent);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.Location = new System.Drawing.Point(422, 458);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(160, 60);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.exitEvent);
            // 
            // labelWarcaby
            // 
            this.labelWarcaby.AutoSize = true;
            this.labelWarcaby.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWarcaby.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWarcaby.Location = new System.Drawing.Point(413, 0);
            this.labelWarcaby.Name = "labelWarcaby";
            this.labelWarcaby.Size = new System.Drawing.Size(185, 50);
            this.labelWarcaby.TabIndex = 3;
            this.labelWarcaby.Text = "Warcaby";
            // 
            // usMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.labelWarcaby);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOption);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "usMainMenu";
            this.Size = new System.Drawing.Size(984, 661);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonOption;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelWarcaby;
    }
}

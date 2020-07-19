

namespace Warcaby.CSharp.Forms
{
    partial class UCOptions
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
            this.optionsQuestion = new System.Windows.Forms.Label();
            this.checkBoxThread = new System.Windows.Forms.CheckBox();
            this.optionsLabel2 = new System.Windows.Forms.Label();
            this.checkBoxStartingGame = new System.Windows.Forms.CheckBox();
            this.backToMenuButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // optionsQuestion
            // 
            this.optionsQuestion.AutoSize = true;
            this.optionsQuestion.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.optionsQuestion.Location = new System.Drawing.Point(79, 89);
            this.optionsQuestion.Name = "optionsQuestion";
            this.optionsQuestion.Size = new System.Drawing.Size(593, 31);
            this.optionsQuestion.TabIndex = 2;
            this.optionsQuestion.Text = "Algorytm komputera będzie korzystał z wątków";
            // 
            // checkBoxThread
            // 
            this.checkBoxThread.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxThread.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxThread.Location = new System.Drawing.Point(678, 99);
            this.checkBoxThread.Name = "checkBoxThread";
            this.checkBoxThread.Size = new System.Drawing.Size(20, 20);
            this.checkBoxThread.TabIndex = 3;
            this.checkBoxThread.UseVisualStyleBackColor = true;
            this.checkBoxThread.CheckedChanged += new System.EventHandler(this.checkBoxThreadYes_CheckedChanged);
            this.checkBoxThread.MouseCaptureChanged += new System.EventHandler(this.checkBoxThreadYes_CheckedChanged);
            // 
            // optionsLabel2
            // 
            this.optionsLabel2.AutoSize = true;
            this.optionsLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.optionsLabel2.Location = new System.Drawing.Point(79, 176);
            this.optionsLabel2.Name = "optionsLabel2";
            this.optionsLabel2.Size = new System.Drawing.Size(486, 31);
            this.optionsLabel2.TabIndex = 4;
            this.optionsLabel2.Text = "Komputer zaczyna partię jako pierwszy";
            // 
            // checkBoxStartingGame
            // 
            this.checkBoxStartingGame.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxStartingGame.Location = new System.Drawing.Point(678, 187);
            this.checkBoxStartingGame.Name = "checkBoxStartingGame";
            this.checkBoxStartingGame.Size = new System.Drawing.Size(20, 20);
            this.checkBoxStartingGame.TabIndex = 5;
            this.checkBoxStartingGame.UseVisualStyleBackColor = true;
            this.checkBoxStartingGame.CheckedChanged += new System.EventHandler(this.CheckBoxStartingGame_CheckedChanged);
            this.checkBoxStartingGame.MouseCaptureChanged += new System.EventHandler(this.CheckBoxStartingGame_CheckedChanged);
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.BackColor = System.Drawing.Color.White;
            this.backToMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToMenuButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.backToMenuButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backToMenuButton.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft;
            this.backToMenuButton.IconColor = System.Drawing.Color.Black;
            this.backToMenuButton.IconSize = 25;
            this.backToMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backToMenuButton.Location = new System.Drawing.Point(324, 389);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.backToMenuButton.Rotation = 0D;
            this.backToMenuButton.Size = new System.Drawing.Size(110, 42);
            this.backToMenuButton.TabIndex = 7;
            this.backToMenuButton.Text = "Powrót";
            this.backToMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.backToMenuButton.UseVisualStyleBackColor = false;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenu);
            // 
            // UCOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.backToMenuButton);
            this.Controls.Add(this.checkBoxStartingGame);
            this.Controls.Add(this.optionsLabel2);
            this.Controls.Add(this.checkBoxThread);
            this.Controls.Add(this.optionsQuestion);
            this.Name = "UCOptions";
            this.Size = new System.Drawing.Size(762, 600);
            this.Load += new System.EventHandler(this.UCOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label optionsQuestion;
        private System.Windows.Forms.CheckBox checkBoxThread;
        private System.Windows.Forms.Label optionsLabel2;
        private System.Windows.Forms.CheckBox checkBoxStartingGame;
        private FontAwesome.Sharp.IconButton backToMenuButton;
    }
}

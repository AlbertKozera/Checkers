using System;

namespace Warcaby.Forms
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
            this.button1 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(327, 495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Powrót";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.backToMenu);
            // 
            // UCOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}

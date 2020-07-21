namespace Warcaby.CSharp.Forms
{
    partial class ClientStage
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateGame = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnJoin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxWhiteTurn = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Port";
            // 
            // btnCreateGame
            // 
            this.btnCreateGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateGame.Location = new System.Drawing.Point(233, 88);
            this.btnCreateGame.Name = "btnCreateGame";
            this.btnCreateGame.Size = new System.Drawing.Size(87, 28);
            this.btnCreateGame.TabIndex = 24;
            this.btnCreateGame.Text = "Utwórz grę";
            this.btnCreateGame.UseVisualStyleBackColor = true;
            this.btnCreateGame.Click += new System.EventHandler(this.btnCreateGame_Click);
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.Location = new System.Drawing.Point(51, 45);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 23;
            this.txtPort.Text = "8910";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Host";
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHost.ForeColor = System.Drawing.Color.White;
            this.txtHost.Location = new System.Drawing.Point(51, 11);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 21;
            this.txtHost.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "Gospodarz wybierze stronę            ";
            // 
            // btnJoin
            // 
            this.btnJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnJoin.Location = new System.Drawing.Point(233, 125);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(87, 28);
            this.btnJoin.TabIndex = 31;
            this.btnJoin.Text = "Dołącz";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCreateGame);
            this.panel1.Controls.Add(this.checkBoxWhiteTurn);
            this.panel1.Controls.Add(this.btnJoin);
            this.panel1.Controls.Add(this.txtHost);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(209, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 166);
            this.panel1.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(198, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 28);
            this.label4.TabIndex = 33;
            this.label4.Text = "TCP/IP";
            // 
            // checkBoxWhiteTurn
            // 
            this.checkBoxWhiteTurn.AutoSize = true;
            this.checkBoxWhiteTurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxWhiteTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxWhiteTurn.ForeColor = System.Drawing.Color.White;
            this.checkBoxWhiteTurn.Location = new System.Drawing.Point(12, 91);
            this.checkBoxWhiteTurn.Name = "checkBoxWhiteTurn";
            this.checkBoxWhiteTurn.Size = new System.Drawing.Size(225, 22);
            this.checkBoxWhiteTurn.TabIndex = 32;
            this.checkBoxWhiteTurn.Text = "Rozpocznij grę jako pierwszy ";
            this.checkBoxWhiteTurn.UseVisualStyleBackColor = false;
            // 
            // ClientStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Warcaby.Properties.Resources.background;
            this.Controls.Add(this.panel1);
            this.Name = "ClientStage";
            this.Size = new System.Drawing.Size(762, 600);
            this.Load += new System.EventHandler(this.ClientStage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateGame;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxWhiteTurn;
        private System.Windows.Forms.Label label4;
    }
}

namespace Warcaby
{
    partial class WarcabyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarcabyForm));
            this.MenuControl = new Warcaby.Forms.menuControl();
            this.newGameControl = new Warcaby.NewGameControl();
            this.optionsControl = new Warcaby.OptionsControl();
            this.SuspendLayout();
            // 
            // MenuControl
            // 
            this.MenuControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuControl.BackgroundImage")));
            this.MenuControl.Location = new System.Drawing.Point(0, 2);
            this.MenuControl.Name = "MenuControl";
            this.MenuControl.Size = new System.Drawing.Size(984, 661);
            this.MenuControl.TabIndex = 2;
            // 
            // newGameControl
            // 
            this.newGameControl.Location = new System.Drawing.Point(0, 2);
            this.newGameControl.Name = "newGameControl";
            this.newGameControl.Size = new System.Drawing.Size(984, 661);
            this.newGameControl.TabIndex = 1;
            // 
            // optionsControl
            // 
            this.optionsControl.Location = new System.Drawing.Point(0, 2);
            this.optionsControl.Name = "optionsControl";
            this.optionsControl.Size = new System.Drawing.Size(984, 661);
            this.optionsControl.TabIndex = 0;
            // 
            // WarcabyForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.MenuControl);
            this.Controls.Add(this.newGameControl);
            this.Controls.Add(this.optionsControl);
            this.Name = "WarcabyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnLoadForm);
            this.ResumeLayout(false);

        }

        #endregion

        private NewGameControl newGame1;
        private OptionsControl options1;
        private OptionsControl options2;
        private NewGameControl newGame2;
        private Forms.menuControl menu1;
        private OptionsControl optionsControl;
        private NewGameControl newGameControl;
        private Forms.menuControl MenuControl;
    }
}


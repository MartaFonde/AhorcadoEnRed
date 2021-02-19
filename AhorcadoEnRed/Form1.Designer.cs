
namespace AhorcadoEnRed
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newWordToolStrip = new System.Windows.Forms.ToolStripButton();
            this.recordToolStrip = new System.Windows.Forms.ToolStripButton();
            this.addToolStrip = new System.Windows.Forms.ToolStripButton();
            this.closeToolStrip = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWordMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.recodsMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.showRecordsMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.serverMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.sendNewWordMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeServerMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.galicianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.dibujoAhorcado1 = new Dibujo.DibujoAhorcado();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWordToolStrip,
            this.recordToolStrip,
            this.addToolStrip,
            this.closeToolStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newWordToolStrip
            // 
            this.newWordToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newWordToolStrip.Image = global::ClientAhorcado.Properties.Resources._new;
            this.newWordToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newWordToolStrip.Name = "newWordToolStrip";
            this.newWordToolStrip.Size = new System.Drawing.Size(23, 22);
            this.newWordToolStrip.Text = "New word";
            this.newWordToolStrip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newWordToolStrip.Click += new System.EventHandler(this.getWordMnu_clicl);
            // 
            // recordToolStrip
            // 
            this.recordToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recordToolStrip.Image = global::ClientAhorcado.Properties.Resources.records;
            this.recordToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recordToolStrip.Name = "recordToolStrip";
            this.recordToolStrip.Size = new System.Drawing.Size(23, 22);
            this.recordToolStrip.Text = "Show records";
            this.recordToolStrip.Click += new System.EventHandler(this.showRecordsMnu_click);
            // 
            // addToolStrip
            // 
            this.addToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStrip.Image = global::ClientAhorcado.Properties.Resources.add;
            this.addToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStrip.Name = "addToolStrip";
            this.addToolStrip.Size = new System.Drawing.Size(23, 22);
            this.addToolStrip.Text = "Send word(s) to server";
            this.addToolStrip.Click += new System.EventHandler(this.sendWordMnu_click);
            // 
            // closeToolStrip
            // 
            this.closeToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeToolStrip.Image = global::ClientAhorcado.Properties.Resources.close;
            this.closeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeToolStrip.Name = "closeToolStrip";
            this.closeToolStrip.Size = new System.Drawing.Size(23, 22);
            this.closeToolStrip.Text = "Close server";
            this.closeToolStrip.Click += new System.EventHandler(this.closeServerMnu_click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMnu,
            this.recodsMnu,
            this.serverMnu,
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newMnu
            // 
            this.newMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWordMnu});
            this.newMnu.Name = "newMnu";
            this.newMnu.Size = new System.Drawing.Size(43, 20);
            this.newMnu.Text = "New";
            // 
            // newWordMnu
            // 
            this.newWordMnu.Name = "newWordMnu";
            this.newWordMnu.Size = new System.Drawing.Size(128, 22);
            this.newWordMnu.Text = "New word";
            this.newWordMnu.Click += new System.EventHandler(this.getWordMnu_clicl);
            // 
            // recodsMnu
            // 
            this.recodsMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRecordsMnu});
            this.recodsMnu.Name = "recodsMnu";
            this.recodsMnu.Size = new System.Drawing.Size(61, 20);
            this.recodsMnu.Text = "Records";
            // 
            // showRecordsMnu
            // 
            this.showRecordsMnu.Name = "showRecordsMnu";
            this.showRecordsMnu.Size = new System.Drawing.Size(145, 22);
            this.showRecordsMnu.Text = "Show records";
            this.showRecordsMnu.Click += new System.EventHandler(this.showRecordsMnu_click);
            // 
            // serverMnu
            // 
            this.serverMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendNewWordMnu,
            this.closeServerMnu});
            this.serverMnu.Name = "serverMnu";
            this.serverMnu.Size = new System.Drawing.Size(51, 20);
            this.serverMnu.Text = "Server";
            // 
            // sendNewWordMnu
            // 
            this.sendNewWordMnu.Name = "sendNewWordMnu";
            this.sendNewWordMnu.Size = new System.Drawing.Size(168, 22);
            this.sendNewWordMnu.Text = "Send new word(s)";
            this.sendNewWordMnu.Click += new System.EventHandler(this.sendWordMnu_click);
            // 
            // closeServerMnu
            // 
            this.closeServerMnu.Name = "closeServerMnu";
            this.closeServerMnu.Size = new System.Drawing.Size(168, 22);
            this.closeServerMnu.Text = "Close server";
            this.closeServerMnu.Click += new System.EventHandler(this.closeServerMnu_click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.galicianToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.CheckedChanged += new System.EventHandler(this.englishToolStripMenuItem_CheckedChanged);
            // 
            // galicianToolStripMenuItem
            // 
            this.galicianToolStripMenuItem.CheckOnClick = true;
            this.galicianToolStripMenuItem.Name = "galicianToolStripMenuItem";
            this.galicianToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.galicianToolStripMenuItem.Text = "Galician";
            this.galicianToolStripMenuItem.CheckedChanged += new System.EventHandler(this.galicianToolStripMenuItem_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(40, 59);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(39, 13);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "00:00";
            // 
            // dibujoAhorcado1
            // 
            this.dibujoAhorcado1.Errores = 0;
            this.dibujoAhorcado1.Location = new System.Drawing.Point(296, 194);
            this.dibujoAhorcado1.Name = "dibujoAhorcado1";
            this.dibujoAhorcado1.Size = new System.Drawing.Size(185, 227);
            this.dibujoAhorcado1.TabIndex = 3;
            this.dibujoAhorcado1.Text = "dibujoAhorcado1";
            this.dibujoAhorcado1.Ahorcado += new System.EventHandler(this.dibujoAhorcado1_Ahorcado);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dibujoAhorcado1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Ahorcado en Red";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newMnu;
        private System.Windows.Forms.ToolStripMenuItem newWordMnu;
        private System.Windows.Forms.ToolStripMenuItem recodsMnu;
        private System.Windows.Forms.ToolStripMenuItem showRecordsMnu;
        private System.Windows.Forms.ToolStripMenuItem serverMnu;
        private System.Windows.Forms.ToolStripMenuItem closeServerMnu;
        private System.Windows.Forms.ToolStripButton newWordToolStrip;
        private System.Windows.Forms.ToolStripButton recordToolStrip;
        private System.Windows.Forms.ToolStripMenuItem sendNewWordMnu;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ToolStripButton addToolStrip;
        private System.Windows.Forms.ToolStripButton closeToolStrip;
        private Dibujo.DibujoAhorcado dibujoAhorcado1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem galicianToolStripMenuItem;
    }
}


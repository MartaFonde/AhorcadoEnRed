
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoJuegoMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.récordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarRécordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPalabraMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.nuevoJuegoToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoJuegoToolStrip,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.récordsToolStripMenuItem,
            this.servidorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoJuegoMnu});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.nuevoToolStripMenuItem.Text = "New";
            // 
            // nuevoJuegoMnu
            // 
            this.nuevoJuegoMnu.Name = "nuevoJuegoMnu";
            this.nuevoJuegoMnu.Size = new System.Drawing.Size(180, 22);
            this.nuevoJuegoMnu.Text = "New word";
            this.nuevoJuegoMnu.Click += new System.EventHandler(this.getWordMnu_clicl);
            // 
            // récordsToolStripMenuItem
            // 
            this.récordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarRécordsToolStripMenuItem});
            this.récordsToolStripMenuItem.Name = "récordsToolStripMenuItem";
            this.récordsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.récordsToolStripMenuItem.Text = "Records";
            // 
            // mostrarRécordsToolStripMenuItem
            // 
            this.mostrarRécordsToolStripMenuItem.Name = "mostrarRécordsToolStripMenuItem";
            this.mostrarRécordsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarRécordsToolStripMenuItem.Text = "Show records";
            this.mostrarRécordsToolStripMenuItem.Click += new System.EventHandler(this.showRecordsMnu_click);
            // 
            // servidorToolStripMenuItem
            // 
            this.servidorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPalabraMnu,
            this.cerrarServidorToolStripMenuItem});
            this.servidorToolStripMenuItem.Name = "servidorToolStripMenuItem";
            this.servidorToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.servidorToolStripMenuItem.Text = "Server";
            // 
            // nuevaPalabraMnu
            // 
            this.nuevaPalabraMnu.Name = "nuevaPalabraMnu";
            this.nuevaPalabraMnu.Size = new System.Drawing.Size(180, 22);
            this.nuevaPalabraMnu.Text = "Send new word(s)";
            this.nuevaPalabraMnu.Click += new System.EventHandler(this.sendWordMnu_click);
            // 
            // cerrarServidorToolStripMenuItem
            // 
            this.cerrarServidorToolStripMenuItem.Name = "cerrarServidorToolStripMenuItem";
            this.cerrarServidorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarServidorToolStripMenuItem.Text = "Close server";
            this.cerrarServidorToolStripMenuItem.Click += new System.EventHandler(this.closeServerMnu_click);
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
            // nuevoJuegoToolStrip
            // 
            this.nuevoJuegoToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoJuegoToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("nuevoJuegoToolStrip.Image")));
            this.nuevoJuegoToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoJuegoToolStrip.Name = "nuevoJuegoToolStrip";
            this.nuevoJuegoToolStrip.Size = new System.Drawing.Size(23, 22);
            this.nuevoJuegoToolStrip.Text = "New word";
            this.nuevoJuegoToolStrip.Click += new System.EventHandler(this.getWordMnu_clicl);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Show records";
            this.toolStripButton2.Click += new System.EventHandler(this.showRecordsMnu_click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::AhorcadoEnRed.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Send word(s) to server";
            this.toolStripButton1.Click += new System.EventHandler(this.sendWordMnu_click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::AhorcadoEnRed.Properties.Resources.close;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Close server";
            this.toolStripButton3.Click += new System.EventHandler(this.closeServerMnu_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoJuegoMnu;
        private System.Windows.Forms.ToolStripMenuItem récordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarRécordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarServidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton nuevoJuegoToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem nuevaPalabraMnu;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}


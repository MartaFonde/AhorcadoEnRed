
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
            this.nuevoJuegoToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoJuegoToolStrip,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevoJuegoToolStrip
            // 
            this.nuevoJuegoToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoJuegoToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("nuevoJuegoToolStrip.Image")));
            this.nuevoJuegoToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoJuegoToolStrip.Name = "nuevoJuegoToolStrip";
            this.nuevoJuegoToolStrip.Size = new System.Drawing.Size(23, 22);
            this.nuevoJuegoToolStrip.Text = "toolStripButton1";
            this.nuevoJuegoToolStrip.Click += new System.EventHandler(this.nuevoJuego);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
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
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // nuevoJuegoMnu
            // 
            this.nuevoJuegoMnu.Name = "nuevoJuegoMnu";
            this.nuevoJuegoMnu.Size = new System.Drawing.Size(142, 22);
            this.nuevoJuegoMnu.Text = "Nuevo juego";
            this.nuevoJuegoMnu.Click += new System.EventHandler(this.nuevoJuego);
            // 
            // récordsToolStripMenuItem
            // 
            this.récordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarRécordsToolStripMenuItem});
            this.récordsToolStripMenuItem.Name = "récordsToolStripMenuItem";
            this.récordsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.récordsToolStripMenuItem.Text = "Récords";
            // 
            // mostrarRécordsToolStripMenuItem
            // 
            this.mostrarRécordsToolStripMenuItem.Name = "mostrarRécordsToolStripMenuItem";
            this.mostrarRécordsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.mostrarRécordsToolStripMenuItem.Text = "Mostrar récords";
            // 
            // servidorToolStripMenuItem
            // 
            this.servidorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPalabraMnu,
            this.cerrarServidorToolStripMenuItem});
            this.servidorToolStripMenuItem.Name = "servidorToolStripMenuItem";
            this.servidorToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.servidorToolStripMenuItem.Text = "Servidor";
            // 
            // nuevaPalabraMnu
            // 
            this.nuevaPalabraMnu.Name = "nuevaPalabraMnu";
            this.nuevaPalabraMnu.Size = new System.Drawing.Size(151, 22);
            this.nuevaPalabraMnu.Text = "Nueva palabra";
            this.nuevaPalabraMnu.Click += new System.EventHandler(this.nuevaPalabraMnu_Click);
            // 
            // cerrarServidorToolStripMenuItem
            // 
            this.cerrarServidorToolStripMenuItem.Name = "cerrarServidorToolStripMenuItem";
            this.cerrarServidorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cerrarServidorToolStripMenuItem.Text = "Cerrar servidor";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(40, 59);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(34, 13);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "00:00";
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
            this.Text = "Form1";
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
        private System.Windows.Forms.Label lblTimer;
    }
}


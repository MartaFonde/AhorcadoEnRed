using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dibujo
{
    public partial class DibujoAhorcado : Control
    {
        private int errores;
        public int Errores
        {
            set
            {
                errores = value;
                Refresh();
                if(errores == 6)        //completa dibujo
                {
                    Ahorcado?.Invoke(this, EventArgs.Empty);
                }
            }
            get
            {
                return errores;
            }
        }

        public DibujoAhorcado()
        {
            InitializeComponent();
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Error cambia")]
        public event System.EventHandler CambiaError;

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Error llega a 6")]
        public event System.EventHandler Ahorcado;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int w = this.Width;
            int h = this.Height;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //int grosor = 8;
            Pen pen = new Pen(Color.Black, 5);

            g.DrawLine(pen, new Point(w/8, h), new Point(w/8*5, h));
            g.DrawLine(pen, new Point(w / 8 * 3, 0), new Point(w / 8 * 3, h));
            g.DrawLine(pen, new Point(w / 8 * 3, 0), new Point(w / 8 * 6, 0));
            g.DrawLine(pen, new Point(w / 8 * 6, 0), new Point(w / 8 * 6, h / 8 ));

            pen.Width = 3;

            //g.DrawEllipse(pen, new Rectangle(w/8*5, h/8, w/8*2, h/8*2));    //1
            //g.DrawLine(pen, new Point(w / 8 * 6, h/8 * 3), new Point(w / 8 * 6, h / 8 * 6));        //2
            //g.DrawLine(pen, new Point(w / 8 * 6, h/8 * 4), new Point(w / 8 * 5, h / 8 * 5));    //3
            //g.DrawLine(pen, new Point(w / 8 * 6, h/8 * 4), new Point(w / 8 * 7, h / 8 * 5));    //4
            //g.DrawLine(pen, new Point(w / 8 * 6, h/8 * 6), new Point(w / 8 * 5, h / 8 * 7));    //5
            //g.DrawLine(pen, new Point(w / 8 * 6, h/8 * 6), new Point(w / 8 * 7, h / 8 * 7));    //6

            switch (Errores)
            {
                case 1:
                    g.DrawEllipse(pen, new Rectangle(w / 8 * 5, h / 8, w / 8 * 2, h / 8 * 2));
                    break;
                case 2:                    
                    g.DrawLine(pen, new Point(w / 8 * 6, h / 8 * 3), new Point(w / 8 * 6, h / 8 * 6));
                    goto case 1;
                case 3:                    
                    g.DrawLine(pen, new Point(w / 8 * 6, h / 8 * 4), new Point(w / 8 * 5, h / 8 * 5));
                    goto case 2;
                case 4:                    
                    g.DrawLine(pen, new Point(w / 8 * 6, h / 8 * 4), new Point(w / 8 * 7, h / 8 * 5));
                    goto case 3;
                case 5:                    
                    g.DrawLine(pen, new Point(w / 8 * 6, h / 8 * 6), new Point(w / 8 * 5, h / 8 * 7));
                    goto case 4;
                case 6:                    
                    g.DrawLine(pen, new Point(w / 8 * 6, h / 8 * 6), new Point(w / 8 * 7, h / 8 * 7));
                    goto case 5;
            }
            pen.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    public partial class Form2 : Form
    {
        private Bitmap _bmp = null;
        private int magnifier = 20;
        private double _d = 0;
        private System.Windows.Forms.Timer timer1;
        private Bitmap _bmpBackGround = null;

        double _sinWidthFactor = 1.0;
        double _sinHeightFactor = 5.0;

        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.ClientSize = new System.Drawing.Size(744, 507);
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        }

        private void Plot(double d)
        {
            if (_bmp != null)
            {
                _bmp.Dispose();
                _bmp = null;
            }

            if (this.ClientSize.Width > 0 && this.ClientSize.Height > 0)
            {
                _bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

                //getData
                using (System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    List<PointF> pts = new List<PointF>();

                    for (int x = -_bmp.Width / 2; x <= _bmp.Width / 2 - 1; x++)
                    {
                        pts.Add(new PointF(x, (float)(Math.Sin(((x - d) / _sinWidthFactor) / (double)magnifier) * (double)magnifier * _sinHeightFactor)));
                    }

                    gPath.AddLines(pts.ToArray());

                    DrawGraph(_bmp, gPath);
                }
            }
        }

        private void DrawGraph(Bitmap bmp, System.Drawing.Drawing2D.GraphicsPath gPath)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImageUnscaled(this._bmpBackGround, 0, 0);

                g.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, -1, bmp.Width / 2, bmp.Height / 2);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawPath(Pens.Black, gPath);
            }
        }

        private void DrawGridAndAxis(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, -1, bmp.Width / 2, bmp.Height / 2);

                //magnifier size
                int i = 0;
                while (i < bmp.Width / 2)
                {
                    g.DrawLine(Pens.Gray, new Point(i, -bmp.Height / 2), new Point(i, bmp.Height / 2));
                    i += magnifier;
                }

                i = 0;
                while (i < bmp.Height / 2)
                {
                    g.DrawLine(Pens.Gray, new Point(-bmp.Width / 2, i), new Point(bmp.Width / 2, i));
                    i += magnifier;
                }

                i = magnifier;
                while (i > -bmp.Width / 2)
                {
                    g.DrawLine(Pens.Gray, new Point(i, -bmp.Height / 2), new Point(i, bmp.Height / 2));
                    i -= magnifier;
                }

                i = magnifier;
                while (i > -bmp.Height / 2)
                {
                    g.DrawLine(Pens.Gray, new Point(-bmp.Width / 2, i), new Point(bmp.Width / 2, i));
                    i -= magnifier;
                }

                g.DrawLine(Pens.Red, new Point(0, -bmp.Height / 2), new Point(0, bmp.Height / 2));
                g.DrawLine(Pens.Blue, new Point(-bmp.Width / 2, 0), new Point(bmp.Width / 2, 0));
            }
        }

        private void Form1_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (_bmp != null)
                _bmp.Dispose();

            if (_bmpBackGround != null)
                _bmpBackGround.Dispose();
        }

        private void Form1_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (_bmp != null)
            {
                e.Graphics.DrawImage(_bmp, 0, 0);
            }
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            this.DoubleBuffered = true;
            this.timer1.Start();
        }

        private void timer1_Tick(System.Object sender, System.EventArgs e)
        {
            this.timer1.Stop();
            _d -= 1;
            Plot(_d);
            this.Invalidate();
            this.timer1.Start();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this._bmpBackGround != null)
            {
                this._bmpBackGround.Dispose();
                this._bmpBackGround = null;
            }

            if (this.ClientSize.Width > 0 && this.ClientSize.Height > 0)
            {
                this._bmpBackGround = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                DrawGridAndAxis(this._bmpBackGround);
            }
        }
    }
}

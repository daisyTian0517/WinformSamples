using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    class TwoLinesControl:Control
    {
        public TwoLinesControl()
        {
            this.BackColor = Color.Azure;
            this.Size = new Size(300, 300);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            //平滑绘制，反锯齿
            g.SmoothingMode = SmoothingMode.HighQuality;

            //控件高度和宽度
            int intWidth = this.Width;
            int intHeight = this.Height;
            Rectangle rect = new Rectangle(0, 0, intWidth, intHeight);

            using(Pen pen = new Pen(Color.Red))
            {
                g.DrawLine(pen, 0,0,intWidth, intHeight);
                g.DrawLine(pen, new Point(intWidth, 0), new Point(0, Height));
            }

            using (Brush brush = new SolidBrush(Color.LightBlue))
            {
                rect.Inflate(-20, -20);//往里缩一点
                g.FillRectangle(brush, rect);
            }

            using (Pen pen1 = new Pen(Color.LightPink))
            {
                rect.Inflate(-50, -50);
                g.DrawEllipse(pen1, rect);
            }

            using (Brush brush2 = new SolidBrush(Color.LightYellow))
            {
                rect.Inflate(-80, 80);
                Point[] points =
                {
                    new Point(rect.Left,rect.Top),
                    new Point(rect.Right,rect.Top),
                    new Point(rect.Left+rect.Width/2,rect.Bottom)
                };
                g.FillPolygon(brush2, points);
            }
        }
    }
}

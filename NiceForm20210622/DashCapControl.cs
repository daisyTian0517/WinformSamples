using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    class DashCapControl:Control
    {
        public DashCapControl()
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

            
            //渐变色
            Brush brush = new LinearGradientBrush(
                new Point(rect.Left, rect.Top),
                new Point(rect.Right, rect.Bottom),
                 Color.FromArgb(255, 0, 0),
                 Color.FromArgb(255, 255, 255)
                );

            using (brush)
            {
                g.FillRectangle(brush, rect);
            }


            //虚线
            using (Pen pen = new Pen(Color.Blue))
            {
                pen.Width = 0.2f;
                pen.DashCap = DashCap.Round;
                pen.DashPattern = new float[] { 10, 2, 2, 1 };
                g.DrawLine(pen, 0, 0, intWidth, intHeight);
                g.DrawLine(pen, new Point(intWidth, 0), new Point(0, Height));
            }
        }
    }
}

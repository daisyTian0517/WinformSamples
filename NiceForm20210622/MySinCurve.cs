using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    class MySinCurve:Control
    {
        public int grain = 3;//线条的精细度（粒度）
        public int range = 50;//高度（振幅半径）
        public int period = 100;//X 轴, 每100像素表示一个周期（2PI）

        public MySinCurve()
        {
            this.BackColor = Color.Azure;
            this.Size = new Size(400, 300);

            //设置双缓冲，减少画面闪烁
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);

            //平滑绘制 反锯齿
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using(Pen pen = new Pen(Color.OrangeRed))
            {
                int center = h / 2;
                g.DrawLine(pen, 0, center, w, center);

                //正弦曲线（由多个小段连接而成，近似一条曲线）

                int x1 = 0;
                int y1 = 0;
                for(int i = 0; i < w; i++)
                {
                    int x2 = i;

                    //把横坐标x换算成角度（弧度值）
                    double angle = 2 * Math.PI * x2 / period;

                    //计算得到y坐标
                    int y2 = (int)(range * Math.Sin(angle));

                    g.DrawLine(pen, x1, center + y1, x2, center + y2);

                    x1 = x2;
                    y1 = y2;
                }
            }

        }
    }
}

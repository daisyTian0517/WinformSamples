using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    class MyCalendar:Control
    {
        public MyCalendar()
        {
            this.BackColor = Color.White;
            this.Size = new Size(300, 300);

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

            int x = 0, y = 0;
            int x_size = 40;//单元格宽度
            int y_size = 40;//单元格高度

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //两条横杠
            using(Pen pen = new Pen(Color.DarkCyan))
            {
                g.DrawLine(pen, x, y, x + x_size * 7, y);
                g.DrawLine(pen, x, y+y_size, x + x_size * 7, y+y_size);
            }

            //第一行
            String[] cc = { "一", "二", "三", "四", "五", "六", "日" };
            using(Brush brush = new SolidBrush(Color.Blue))
            {
                for(int i=0; i < 7; i++)
                {
                    Rectangle r1 = new Rectangle(x + i * x_size, y, x_size, y_size);
                    g.DrawString(cc[i], this.Font, brush, r1, sf);
                }
            }

            //计算本月第一天是周几
            DateTime dt = DateTime.Now;
            int theMonth = dt.Month;//当前月份
            int theDay = dt.Day;//当前几号
            dt = dt.AddDays(1 - theDay);//向前推到本月第一天
            DayOfWeek weekday = dt.DayOfWeek;//计算本月第一天是周几
            Debug.WriteLine(" ************* Weekday:" + weekday+"***************");

            //往前推n天
            //calendar里规定sunday=1（周日），Monday=2，
            //如果是周一往前推0天， 如果是周二，推1天，....周日推6天

            int start = weekday - DayOfWeek.Monday;
            if (start < 0) start = 6;
            dt = dt.AddDays(0 - start);//前推，从上月开始显示

            ////绘制6行
            ////每月最多31天，最多显示6行
            x = 0;
            y += y_size;
            for (int i = 0; i < 6; i++)//5行
            {
                for (int j = 0; j < 7; j++)//7列
                {
                    bool isToday = false;
                    Color textColor = Color.Black;
                    //判断月份是否相同
                    if (dt.Month != theMonth)
                    {
                        textColor = Color.Gray;//非本月显示灰色
                    }
                    if (dt.Month == theMonth && dt.Day == theDay)
                    {
                        isToday = true;
                        textColor = Color.OrangeRed;//本月显示高亮
                    }
                    int day = dt.Day;
                    Rectangle r1 = new Rectangle(x + j * x_size, y + y_size * i, x_size, y_size);
                    if (isToday)
                    {
                        //当天高亮显示
                        Rectangle r2 = new Rectangle(r1.X + 3, r1.Y + 3, x_size, y_size);
                        Pen pen = new Pen(textColor, 1.5f);
                        g.DrawEllipse(pen, r2);
                        //pen.Dispose();
                    }

                    using (Brush brush = new SolidBrush(textColor))
                    {
                        g.DrawString(day + " ", this.Font, brush, r1, sf);
                    }

                    //日期+1
                    dt = dt.AddDays(1);
                }
            }

        }
    }
}

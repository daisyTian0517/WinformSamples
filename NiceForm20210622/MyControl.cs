using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    public class MyControl : Control
    {
        public MyControl()
        {
            this.BackColor = Color.White;
            this.Size = new Size(300, 300);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(10, 10, 100, 50);

            //先Fill 再 Draw

            //Brush brush = new SolidBrush(Color.Azure);
            //g.FillRectangle(brush, rectangle);
            //brush.Dispose();

            //or 更好的写法
            using (Brush brush2 = new SolidBrush(Color.Azure))
            {
                g.FillRectangle(brush2, rectangle);
            }

            Pen pen = new Pen(Color.Red, 2.0f);
            g.DrawRectangle(pen, 0, 0, 50, 50);
            pen.Dispose();//Pen 对象中包含非托管资源，需要调用Dispose.
        }
    }
}

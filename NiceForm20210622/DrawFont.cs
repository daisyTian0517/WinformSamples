using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    class DrawFont:Control
    {
        private string content;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Content
        {
            get 
            { 
                return this.content;
            }
            set 
            {
                this.content = value;
                Invalidate();//要求框架重新绘制文本
            }
        }

        public DrawFont()
        {
            this.BackColor = Color.White;
            this.Size = new Size(300, 300);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            //文本框显示在此矩形中

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            rect.Inflate(-1, -1);

            //为了方便演示对照，绘制一个矩形边框
            using(Pen pen = new Pen(Color.LightBlue))
            {
                g.DrawRectangle(pen, rect);
            }



            using (Brush brush = new SolidBrush(Color.Red))
            {
                //字体
                Font font = new Font("宋体", 30, GraphicsUnit.Point);
               
                //格式与对齐
                StringFormat format = new StringFormat();
                //设置文本
                format.Alignment = StringAlignment.Far;//靠右对齐 水平方向 Near 左 Far 右
                format.LineAlignment = StringAlignment.Center;// 向下对齐 竖直方向 Near 上 Far 下

                if (content != null)
                {
                    //g.DrawString(content, font, brush, x, y, format);
                    g.DrawString(content, font, brush,rect, format);
                }

                font.Dispose();
            }
        }
    }
}

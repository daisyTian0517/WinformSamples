using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceForm20210622
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //创建画布
            Graphics g = this.CreateGraphics();
            //设置画笔颜色 画笔宽度
            Pen redPen = new Pen(Color.Red, 3);
            //绘制两个端点 
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(100, 200);
            //用笔和端点绘制直线
            g.DrawLine(redPen, startPoint, endPoint);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen bluePen = new Pen(Color.Blue, 5);
            g.DrawLine(bluePen, 270, 10, 150, 200);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //曲线
            Graphics g = this.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue, 3);
            Point[] points1 ={
                             new Point(20,190),
                             new Point(60,50),
                             new Point(100,180),
                             new Point(140,60),
                             new Point(180,170),
                             new Point(220,70),
                             new Point(260,160)
                             };

            //绘制一条弯度为0.5的开口曲线
            //tension范围为 0.0-1.0f 
            g.DrawCurve(pen1, points1, 0.5f);
            Pen pen2 = new Pen(Color.Red, 3);
            Point[] points2 ={
                             new Point(40,370),
                             new Point(80,230),
                             new Point(120,360),
                             new Point(160,240),
                             new Point(200,350),
                             new Point(240,250),
                             new Point(280,340)
                             };
            //绘制弯曲度为0.9f的封闭曲线
            g.DrawClosedCurve(pen2, points2, 0.9f, FillMode.Winding);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //绘制矩形
            Graphics g = this.CreateGraphics();
            Pen GreenPen = new Pen(Color.Green, 3);
            Rectangle rect = new Rectangle(330, 10, 60, 80);
            g.DrawRectangle(GreenPen, rect);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //椭圆
            Graphics g = this.CreateGraphics();
            Pen purplePen = new Pen(Color.Purple, 3);
            Rectangle rect = new Rectangle(330, 130, 120, 60);
            g.DrawEllipse(purplePen, rect);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //绘制圆弧
            Graphics g = this.CreateGraphics();
            Pen redPen = new Pen(Color.DarkRed, 5);
            Rectangle rect = new Rectangle(430, 30, 220, 110);
            g.DrawArc(redPen, rect, 120, 220);
        }

    }
}

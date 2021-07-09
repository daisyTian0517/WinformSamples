using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NiceForm20210622
{
    public partial class Form3 : Form
    {
        //随机数
        private static int iSeed = 8;
        Random rd = new Random(iSeed);
        //存放数据的数组最大值
        private int sizeMax;
        //存放y轴数据的数组链表
        private List<int> DataL;
        //存放在画布上的数据节点的数组
        private Point[] pArrData;

        private Timer timer1;

        public Form3()
        {
            //初始化
            InitializeComponent();

            //根据画布的宽决定x轴需要多少个数组
            sizeMax = Width / 2;
            //sizeMax = pcbDisplay.Width / 2;
            //数据数组
            DataL = new List<int>();
            pArrData = new Point[sizeMax + 1];
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.timer1 = new System.Windows.Forms.Timer();
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(pcbDisplay_Paint);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataL.Add(rd.Next(20, 180));
            //数据链表是否达到x轴最大容量的数组（动态曲线的来源）
            if (DataL.Count == sizeMax + 2)
            {
                DataL.RemoveAt(0);//移除链表第一个
            }

            //判断数据链表是否为空
            if (DataL.Count != 0)
            {
                pArrData = new Point[DataL.Count];
            }

            //生成新的节点
            for (int i = 0; i < sizeMax + 1; i++)
            {
                if (i >= DataL.Count)
                {
                    break;
                }
                pArrData[i] = new Point(i * 2, DataL[i]);
            }
            //pcbDisplay.Refresh();
            this.Refresh();
        }

        #region 绘制曲线

        //定义画笔
        private Pen greenPen = new Pen(Color.Green, 1);
        private Pen redPen = new Pen(Color.Red, 1);
        private Pen blackPen = new Pen(Color.Black, 1);

        /// <summary>
        /// 绘制曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pcbDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (DataL.Count != 1)
            {
                e.Graphics.DrawCurve(greenPen, pArrData);
            }
        }
        #endregion
    }
}

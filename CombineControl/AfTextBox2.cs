using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombineControl
{
    class AfTextBox2:UserControl
    {
        private System.Windows.Forms.TextBox edit;

        private void InitializeComponent()
        {
            this.edit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // edit
            // 
            this.edit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edit.Location = new System.Drawing.Point(74, 43);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(100, 13);
            this.edit.TabIndex = 0;
            this.edit.Text = " ";
            this.edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_KeyPress);
            // 
            // AfTextBox2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.edit);
            this.Name = "AfTextBox2";
            this.Size = new System.Drawing.Size(285, 114);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public AfTextBox2()
        {
            InitializeComponent();
        }

        protected override void InitLayout()
        {
            base.InitLayout();

            //获取子控件
            if (this.Controls.Count == 0) return;
            Control c = this.Controls[0];

            //父窗体参数
            Padding p = this.Padding;
            int x = 0, y = 0;
            int w = this.Width, h = this.Height;
            w -= (p.Left + p.Right);
            x += p.Left;

            //计算文本框的高度，使其显示在中间
            int h2 = c.PreferredSize.Height;
            if (h2 > h) h2 = h;
            y = (h - h2) / 2;

            c.Location = new Point(x, y);
            c.Size = new Size(w, h2);
        }

        //添加一些属性
        #region  添加一些属性
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return edit.Text;
            } 
            set
            {
                edit.Text = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get
            {
                return edit.Font;
            }
            set
            {
                edit.Font = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor
        {
            get
            {
                return edit.BackColor;
            }
            set
            {
                base.BackColor = value;
                edit.BackColor = value;
            }
        }


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get
            {
                return edit.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                edit.ForeColor = value;
            }
        }
        #endregion

        //添加事件
        #region 添加事件

        public event EventHandler ReturnPressed;
        private void edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '\r')
                ReturnPressed?.Invoke(this, e);

        }
        #endregion

    }
}

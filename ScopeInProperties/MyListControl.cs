using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace ScopeInProperties
{
    public class MyListControl : Control
    {
        private List<Int32> _list = new List<Int32>();
        private Scope _scope = new Scope();

        public MyListControl()
        {
            this.BackColor = Color.White;
        }

        [Browsable(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public List<Int32> Item
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }


        [Browsable(true)]
        [Editor(typeof(ScopeDropDownEditor), typeof(UITypeEditor))]
        //[Editor(typeof(ScopeEditor), typeof(UITypeEditor))]
        public Scope Scope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            //绘制控件的边框

            g.DrawRectangle(Pens.Black, new Rectangle(Point.Empty, new Size(Size.Width - 1, Size.Height - 1)));

            for (Int32 i = 0; i < _list.Count; i++)
            {
                g.DrawString(_list[i].ToString(), Font, Brushes.Black, 1, i * FontHeight);
            }
        }
    }
}

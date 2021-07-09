using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyHorizontalListItem
{
    public partial class UCHorizontalList : UserControl
    {
        public UCHorizontalListItem SelectedItem { get; set; }
        public event EventHandler SelectedItemEvent;
        private int m_startItemIndex = 0;
        private bool isAutoSelectFirst = true;

        public bool IsAutoSelectFirst
        {
            get { return isAutoSelectFirst; }
            set { isAutoSelectFirst = value; }
        }

        private List<KeyValuePair<string, string>> dataSource = null;

        public List<KeyValuePair<string, string>> DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                ReloadSource();
            }
        }

        public UCHorizontalList()
        {
            InitializeComponent();
        }

        public void ReloadSource()
        {
            try
            {
                FreezeControl(this, true);
                this.panList.SuspendLayout();
                this.panList.Controls.Clear();
                this.panList.Width = this.panMain.Width;
                if (DataSource != null)
                {
                    foreach (var item in DataSource)
                    {
                        UCHorizontalListItem uc = new UCHorizontalListItem();
                        uc.DataSource = item;
                        uc.SelectedItem += uc_SelectItem;
                        this.panList.Controls.Add(uc);
                    }
                }
                this.panList.ResumeLayout(true);
                if (this.panList.Controls.Count > 0)
                    this.panList.Width = panMain.Width + this.panList.Controls[0].Location.X * -1;
                this.panList.Location = new Point(0, 0);
                m_startItemIndex = 0;
                if (this.panList.Width > panMain.Width)
                    panRight.Visible = true;
                else
                    panRight.Visible = false;
                panLeft.Visible = false;
                panList.SendToBack();
                panRight.SendToBack();
                if (isAutoSelectFirst && DataSource != null && DataSource.Count > 0)
                {
                    SelectItem((UCHorizontalListItem)this.panList.Controls[0]);
                }
            }
            finally
            {
                FreezeControl(this, false);
            }
        }


        #region 冻结控件
        static Dictionary<Control, bool> m_lstFreezeControl = new Dictionary<Control, bool>();
        /// <summary>
        /// 功能描述:停止更新控件
        /// <param name="control">control</param>
        /// <param name="blnToFreeze">是否停止更新</param>
        public static void FreezeControl(Control control, bool blnToFreeze)
        {
            if (blnToFreeze && control.IsHandleCreated && control.Visible && !control.IsDisposed && (!m_lstFreezeControl.ContainsKey(control) || (m_lstFreezeControl.ContainsKey(control) && m_lstFreezeControl[control] == false)))
            {
                m_lstFreezeControl[control] = true;
                control.Disposed += control_Disposed;
                SendMessage(control.Handle, 11, 0, 0);
            }
            else if (!blnToFreeze && !control.IsDisposed && m_lstFreezeControl.ContainsKey(control) && m_lstFreezeControl[control] == true)
            {
                m_lstFreezeControl.Remove(control);
                SendMessage(control.Handle, 11, 1, 0);
                control.Invalidate(true);
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        [DllImport("user32.dll")]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        /// <summary>
        /// Handles the Disposed event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        static void control_Disposed(object sender, EventArgs e)
        {
            try
            {
                if (m_lstFreezeControl.ContainsKey((Control)sender))
                    m_lstFreezeControl.Remove((Control)sender);
            }
            catch { }
        }
        #endregion

        void uc_SelectItem(object sender, EventArgs e)
        {
            SelectItem(sender as UCHorizontalListItem);
        }

        private void SelectItem(UCHorizontalListItem item)
        {
            if (SelectedItem != null && !SelectedItem.IsDisposed)
                SelectedItem.SetSelect(false);
            SelectedItem = item;
            SelectedItem.SetSelect(true);
            if (SelectedItemEvent != null)
                SelectedItemEvent(item, null);
        }

        private void panLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.panList.Location.X >= 0)
            {
                this.panList.Location = new Point(0, 0);
                return;
            }

            for (int i = m_startItemIndex; i >= 0; i--)
            {
                if (this.panList.Controls[i].Location.X < this.panList.Controls[m_startItemIndex].Location.X - panMain.Width)
                {
                    m_startItemIndex = i + 1;
                    break; ;
                }
                if (i == 0)
                {
                    m_startItemIndex = 0;
                }
            }

            ResetListLocation();
            panRight.Visible = true;
            if (this.panList.Location.X >= 0)
            {
                panLeft.Visible = false;
            }
            else
            {
                panLeft.Visible = true;
            }
            panList.SendToBack();
            panRight.SendToBack();
        }

        private void panRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.panList.Location.X + this.panList.Width <= this.panMain.Width)
                return;
            if (this.panList.Controls.Count <= 0)
                return;
            for (int i = m_startItemIndex; i < this.panList.Controls.Count; i++)
            {
                if (this.panList.Location.X + this.panList.Controls[i].Location.X + this.panList.Controls[i].Width > panMain.Width)
                {
                    m_startItemIndex = i;
                    break;
                }
            }
            ResetListLocation();
            panLeft.Visible = true;
            if (panList.Width + panList.Location.X <= panMain.Width)
                panRight.Visible = false;
            else
                panRight.Visible = true;
            panList.SendToBack();
            panRight.SendToBack();
        }

        private void ResetListLocation()
        {
            if (this.panList.Controls.Count > 0)
            {
                this.panList.Location = new Point(this.panList.Controls[m_startItemIndex].Location.X * -1, 0);
            }
        }

        public void SetSelect(string strKey)
        {
            foreach (UCHorizontalListItem item in this.panList.Controls)
            {
                if (item.DataSource.Key == strKey)
                {
                    SelectItem(item);
                    return;
                }
            }
        }
    }
}

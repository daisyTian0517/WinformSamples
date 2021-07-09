using System;
using System.IO;
using System.Windows.Forms;

namespace SystemControls
{

    public partial class ListViewSample : Form
    {
        private System.Collections.Specialized.StringCollection folderCol;

        //创建列标题，并添加到列表视图控件中
        private void CreateHeadersAndFillListView()
        {
            ColumnHeader colHead;

            //添加“Filename”列标题
            colHead = new ColumnHeader();
            colHead.Text = "Filename";
            ListViewFileAndFloder.Columns.Add(colHead);

            //添加“Size”列标题
            colHead = new ColumnHeader();
            colHead.Text = "Size";
            ListViewFileAndFloder.Columns.Add(colHead);

            //添加“Last accessed”列标题
            colHead = new ColumnHeader();
            colHead.Text = "Last accessed";
            ListViewFileAndFloder.Columns.Add(colHead);
        }

        private void PaintListView(string root)
        {
            try
            {
                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;

                if (string.IsNullOrEmpty(root)) return;

                //当前目录
                DirectoryInfo dir = new DirectoryInfo(root);

                //当前目录的所有子目录，即文件夹
                DirectoryInfo[] dirs = dir.GetDirectories();

                //当前目录下的文件
                FileInfo[] files = dir.GetFiles();

                //清空
                ListViewFileAndFloder.Items.Clear();

                ListViewFileAndFloder.BeginUpdate();

                //遍历所有文件夹
                foreach (DirectoryInfo di in dirs)
                {
                    lvi = new ListViewItem();
                    lvi.Text = di.Name;     //保存文件夹名
                    lvi.ImageIndex = 0;     //索引为0
                    lvi.Tag = di.FullName;  //保存文件夹完全路径

                    //如果是文件夹则忽略文件夹的大小
                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = "";
                    lvi.SubItems.Add(lvsi);

                    //最后访问时间
                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = di.LastAccessTime.ToString();
                    lvi.SubItems.Add(lvsi);

                    //添加到Items集合中
                    ListViewFileAndFloder.Items.Add(lvi);
                }

                foreach (FileInfo fi in files)
                {
                    lvi = new ListViewItem();

                    lvi.Text = fi.Name;    //保存文件名
                    lvi.ImageIndex = 1;    //索引为0
                    lvi.Tag = fi.FullName; //保存文件完全路径

                    //获得文件大小
                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = fi.Length.ToString();
                    lvi.SubItems.Add(lvsi);

                    //最后访问时间
                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = fi.LastAccessTime.ToString();
                    lvi.SubItems.Add(lvsi);

                    //添加到Items集合中
                    ListViewFileAndFloder.Items.Add(lvi);
                }

                ListViewFileAndFloder.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("Error:" + err.Message);
            }

        }

        public ListViewSample()
        {
            InitializeComponent();

            folderCol = new System.Collections.Specialized.StringCollection();

            //为列表视图控件创建列标题
            CreateHeadersAndFillListView();

            //绘制C盘目录下的文件夹和文件
            PaintListView(@"E:\");

            //添加C盘搜索目录
            folderCol.Add(@"E:\");
        }

        //列表视图控件的显示模式切换为大图标模式
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
            {
                ListViewFileAndFloder.View = View.LargeIcon;
            }
        }

        //列表视图控件的显示模式切换为小图标模式
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
            {
                ListViewFileAndFloder.View = View.SmallIcon;
            }
        }

        //列表视图控件的显示模式切换为列表模式
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
            {
                ListViewFileAndFloder.View = View.List;
            }
        }

        //列表视图控件的显示模式切换为详细信息模式
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
            {
                ListViewFileAndFloder.View = View.Details;
            }
        }

        //列表视图控件的显示模式切换为平铺模式
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
            {
                ListViewFileAndFloder.View = View.Tile;
            }
        }

        //点击“back”按钮，返回上级目录
        //其原理是确保folderCol集合中最后一个选项始终为当前目录的完整路径
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (folderCol.Count > 1)
            {
                PaintListView(folderCol[folderCol.Count - 2].ToString());
                folderCol.RemoveAt(folderCol.Count - 1);
            }
            else
            {
                PaintListView(folderCol[0].ToString());
            }

        }

        //双击控件中的每一文件夹或文件继续访问
        private void ListViewFileAndFloder_ItemActivate(object sender, EventArgs e)
        {
            ListView lw = (ListView)sender;
            string filename = lw.SelectedItems[0].Tag.ToString();

            if (lw.SelectedItems[0].ImageIndex != 0)
            {
                try
                {
                    //打开文件
                    System.Diagnostics.Process.Start(filename);
                }
                catch
                {
                    return;
                }
            }
            else
            {
                PaintListView(filename);
                folderCol.Add(filename);
            }
        }
    }
}

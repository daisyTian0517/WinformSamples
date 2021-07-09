using System;
using System.IO;
using System.Windows.Forms;

namespace SystemControls
{
    public partial class SystemDialogs : Form
    {
        public SystemDialogs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C#源码文件|*.cs";
            dlg.InitialDirectory = Path.GetFullPath(".");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                MessageBox.Show(fileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "NewTxt";
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Text Doucment (.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;
                MessageBox.Show("选中了"+fileName);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Path.GetFullPath(".");
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                MessageBox.Show("选中了"+ path);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = button4.ForeColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                button4.ForeColor = cd.Color;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Font = button5.Font;
            fd.Color = button5.ForeColor;
            if(fd.ShowDialog() != DialogResult.Cancel)
            {
                button5.Font = fd.Font;
                button5.ForeColor = fd.Color;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemControls
{
    public partial class OpenPictures : Form
    {
        public OpenPictures()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                this.pathField.Text = path;
                ShowPictureList(path);
            }
        }

        private void ShowPictureList(string path)
        {
            listField.Items.Clear();

            string[] fff = Directory.GetFiles(path);
            foreach(string str in fff)
            {
                if(str.EndsWith(".jpg")|| str.EndsWith(".jpeg")|| str.EndsWith(".png"))
                {
                    PictureListItem item = new PictureListItem();
                    item.filePath = str;
                    item.name = Path.GetFileName(str);

                    listField.Items.Add(item);
                }
            }
        }

        private void listField_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureListItem item = (PictureListItem)listField.SelectedItem;
            if (item == null) return;
            pictureField.Load(item.filePath);
        }
    }

    public class PictureListItem
    {
        public string name;
        public string filePath;
        public override string ToString()
        {
            return name.ToString();
        }
    }
}

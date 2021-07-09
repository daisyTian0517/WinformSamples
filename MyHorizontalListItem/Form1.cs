using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHorizontalListItem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<KeyValuePair<string, string>> lstHL = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 30; i++)
            {
                lstHL.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
            }

            this.ucHorizontalList1.DataSource = lstHL;
        }


    }
}

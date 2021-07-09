using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CustomEditor
{
    public class EditorControl : UserControl
    {
        public EditorControl()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";

            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "名称一",
            "名称二",
            "名称三",
            "名称四"});
            this.comboBox1.Location = new System.Drawing.Point(56, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "EditorControl";
            this.Size = new System.Drawing.Size(210, 64);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label label1;
        private ComboBox comboBox1;

        public string result = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            result = comboBox1.SelectedItem.ToString();
        }
    }
}

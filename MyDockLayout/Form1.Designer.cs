
namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.afDockFlagEditor1 = new Test.AfDockFlagEditor();
            this.SuspendLayout();
            // 
            // afDockFlagEditor1
            // 
            this.afDockFlagEditor1.DockFlags = new int[] {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0};
            this.afDockFlagEditor1.Location = new System.Drawing.Point(220, 103);
            this.afDockFlagEditor1.Name = "afDockFlagEditor1";
            this.afDockFlagEditor1.Size = new System.Drawing.Size(200, 100);
            this.afDockFlagEditor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.afDockFlagEditor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private AfDockFlagEditor afDockFlagEditor1;
    }
}


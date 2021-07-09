
namespace CombineControl
{
    partial class AfTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
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
            // 
            // AfTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.edit);
            this.Name = "AfTextBox";
            this.Size = new System.Drawing.Size(285, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edit;
    }
}

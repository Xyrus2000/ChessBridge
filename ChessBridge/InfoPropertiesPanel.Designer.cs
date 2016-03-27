/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChessBridge
{
    partial class InfoPropertiesPanel
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.shortTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bioTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.longTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Short Style Descritpion";
            // 
            // shortTextbox
            // 
            this.shortTextbox.Location = new System.Drawing.Point(4, 23);
            this.shortTextbox.MaxLength = 100;
            this.shortTextbox.Name = "shortTextbox";
            this.shortTextbox.Size = new System.Drawing.Size(423, 20);
            this.shortTextbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Biography";
            // 
            // bioTextBox
            // 
            this.bioTextBox.Location = new System.Drawing.Point(4, 70);
            this.bioTextBox.MaxLength = 1000;
            this.bioTextBox.Multiline = true;
            this.bioTextBox.Name = "bioTextBox";
            this.bioTextBox.Size = new System.Drawing.Size(423, 88);
            this.bioTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Long Style Description";
            // 
            // longTextbox
            // 
            this.longTextbox.Location = new System.Drawing.Point(4, 181);
            this.longTextbox.MaxLength = 1000;
            this.longTextbox.Multiline = true;
            this.longTextbox.Name = "longTextbox";
            this.longTextbox.Size = new System.Drawing.Size(423, 253);
            this.longTextbox.TabIndex = 5;
            // 
            // InfoPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.longTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bioTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortTextbox);
            this.Controls.Add(this.label1);
            this.Name = "InfoPropertiesPanel";
            this.Size = new System.Drawing.Size(430, 451);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.TextBox longTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bioTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shortTextbox;
        private System.Windows.Forms.Label label1;
    }
}

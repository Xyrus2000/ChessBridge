/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 7:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChessBridge
{
    partial class PositionalPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cocSlider = new System.Windows.Forms.TrackBar();
            this.cocSpinner = new System.Windows.Forms.NumericUpDown();
            this.oppPWSlider = new System.Windows.Forms.TrackBar();
            this.pwSlider = new System.Windows.Forms.TrackBar();
            this.oppPPSlider = new System.Windows.Forms.TrackBar();
            this.ppSlider = new System.Windows.Forms.TrackBar();
            this.oppKSSlider = new System.Windows.Forms.TrackBar();
            this.ksSlider = new System.Windows.Forms.TrackBar();
            this.oppMobSlider = new System.Windows.Forms.TrackBar();
            this.mobSlider = new System.Windows.Forms.TrackBar();
            this.oppCocSlider = new System.Windows.Forms.TrackBar();
            this.oppPWSpinner = new System.Windows.Forms.NumericUpDown();
            this.pwSpinner = new System.Windows.Forms.NumericUpDown();
            this.oppPPSpinner = new System.Windows.Forms.NumericUpDown();
            this.ppSpinner = new System.Windows.Forms.NumericUpDown();
            this.oppKSSpinner = new System.Windows.Forms.NumericUpDown();
            this.ksSpinner = new System.Windows.Forms.NumericUpDown();
            this.oppMobSpinner = new System.Windows.Forms.NumericUpDown();
            this.mobSpinner = new System.Windows.Forms.NumericUpDown();
            this.oppCocSpinner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cocSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPWSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPPSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppKSSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppMobSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppCocSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPWSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPPSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppKSSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppMobSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppCocSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Own Control of Center";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opp Control of Center";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Own Mobility";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Opp Mobility";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Own Passed Pawns";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Opp Pawn Weakness";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Opp Passed Pawns";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Own Pawn Weakness";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Opp King Safety";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(4, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Own King Safety";
            // 
            // cocSlider
            // 
            this.cocSlider.Location = new System.Drawing.Point(126, 3);
            this.cocSlider.Maximum = 200;
            this.cocSlider.Name = "cocSlider";
            this.cocSlider.Size = new System.Drawing.Size(218, 45);
            this.cocSlider.TabIndex = 10;
            this.cocSlider.TickFrequency = 10;
            this.cocSlider.Scroll += new System.EventHandler(this.CocSliderScroll);
            // 
            // cocSpinner
            // 
            this.cocSpinner.Location = new System.Drawing.Point(350, 4);
            this.cocSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.cocSpinner.Name = "cocSpinner";
            this.cocSpinner.Size = new System.Drawing.Size(63, 20);
            this.cocSpinner.TabIndex = 11;
            this.cocSpinner.ValueChanged += new System.EventHandler(this.CocSpinnerValueChanged);
            // 
            // oppPWSlider
            // 
            this.oppPWSlider.Location = new System.Drawing.Point(126, 375);
            this.oppPWSlider.Maximum = 200;
            this.oppPWSlider.Name = "oppPWSlider";
            this.oppPWSlider.Size = new System.Drawing.Size(218, 45);
            this.oppPWSlider.TabIndex = 28;
            this.oppPWSlider.TickFrequency = 10;
            this.oppPWSlider.Scroll += new System.EventHandler(this.OppPWSliderScroll);
            // 
            // pwSlider
            // 
            this.pwSlider.Location = new System.Drawing.Point(126, 333);
            this.pwSlider.Maximum = 200;
            this.pwSlider.Name = "pwSlider";
            this.pwSlider.Size = new System.Drawing.Size(218, 45);
            this.pwSlider.TabIndex = 26;
            this.pwSlider.TickFrequency = 10;
            this.pwSlider.Scroll += new System.EventHandler(this.PwSliderScroll);
            // 
            // oppPPSlider
            // 
            this.oppPPSlider.Location = new System.Drawing.Point(126, 293);
            this.oppPPSlider.Maximum = 200;
            this.oppPPSlider.Name = "oppPPSlider";
            this.oppPPSlider.Size = new System.Drawing.Size(218, 45);
            this.oppPPSlider.TabIndex = 24;
            this.oppPPSlider.TickFrequency = 10;
            this.oppPPSlider.Scroll += new System.EventHandler(this.OppPPSliderScroll);
            // 
            // ppSlider
            // 
            this.ppSlider.Location = new System.Drawing.Point(126, 251);
            this.ppSlider.Maximum = 200;
            this.ppSlider.Name = "ppSlider";
            this.ppSlider.Size = new System.Drawing.Size(218, 45);
            this.ppSlider.TabIndex = 22;
            this.ppSlider.TickFrequency = 10;
            this.ppSlider.Scroll += new System.EventHandler(this.PpSliderScroll);
            // 
            // oppKSSlider
            // 
            this.oppKSSlider.Location = new System.Drawing.Point(126, 210);
            this.oppKSSlider.Maximum = 200;
            this.oppKSSlider.Name = "oppKSSlider";
            this.oppKSSlider.Size = new System.Drawing.Size(218, 45);
            this.oppKSSlider.TabIndex = 20;
            this.oppKSSlider.TickFrequency = 10;
            this.oppKSSlider.Scroll += new System.EventHandler(this.OppKSSliderScroll);
            // 
            // ksSlider
            // 
            this.ksSlider.Location = new System.Drawing.Point(126, 168);
            this.ksSlider.Maximum = 200;
            this.ksSlider.Name = "ksSlider";
            this.ksSlider.Size = new System.Drawing.Size(218, 45);
            this.ksSlider.TabIndex = 18;
            this.ksSlider.TickFrequency = 10;
            this.ksSlider.Scroll += new System.EventHandler(this.KsSliderScroll);
            // 
            // oppMobSlider
            // 
            this.oppMobSlider.Location = new System.Drawing.Point(126, 127);
            this.oppMobSlider.Maximum = 200;
            this.oppMobSlider.Name = "oppMobSlider";
            this.oppMobSlider.Size = new System.Drawing.Size(218, 45);
            this.oppMobSlider.TabIndex = 16;
            this.oppMobSlider.TickFrequency = 10;
            this.oppMobSlider.Scroll += new System.EventHandler(this.OppMobSliderScroll);
            // 
            // mobSlider
            // 
            this.mobSlider.Location = new System.Drawing.Point(126, 87);
            this.mobSlider.Maximum = 200;
            this.mobSlider.Name = "mobSlider";
            this.mobSlider.Size = new System.Drawing.Size(218, 45);
            this.mobSlider.TabIndex = 14;
            this.mobSlider.TickFrequency = 10;
            this.mobSlider.Scroll += new System.EventHandler(this.MobSliderScroll);
            // 
            // oppCocSlider
            // 
            this.oppCocSlider.Location = new System.Drawing.Point(126, 45);
            this.oppCocSlider.Maximum = 200;
            this.oppCocSlider.Name = "oppCocSlider";
            this.oppCocSlider.Size = new System.Drawing.Size(218, 45);
            this.oppCocSlider.TabIndex = 12;
            this.oppCocSlider.TickFrequency = 10;
            this.oppCocSlider.Scroll += new System.EventHandler(this.OppCocSliderScroll);
            // 
            // oppPWSpinner
            // 
            this.oppPWSpinner.Location = new System.Drawing.Point(350, 375);
            this.oppPWSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.oppPWSpinner.Name = "oppPWSpinner";
            this.oppPWSpinner.Size = new System.Drawing.Size(63, 20);
            this.oppPWSpinner.TabIndex = 29;
            this.oppPWSpinner.ValueChanged += new System.EventHandler(this.OppPWSpinnerValueChanged);
            // 
            // pwSpinner
            // 
            this.pwSpinner.Location = new System.Drawing.Point(350, 333);
            this.pwSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.pwSpinner.Name = "pwSpinner";
            this.pwSpinner.Size = new System.Drawing.Size(63, 20);
            this.pwSpinner.TabIndex = 27;
            this.pwSpinner.ValueChanged += new System.EventHandler(this.PwSpinnerValueChanged);
            // 
            // oppPPSpinner
            // 
            this.oppPPSpinner.Location = new System.Drawing.Point(350, 293);
            this.oppPPSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.oppPPSpinner.Name = "oppPPSpinner";
            this.oppPPSpinner.Size = new System.Drawing.Size(63, 20);
            this.oppPPSpinner.TabIndex = 25;
            this.oppPPSpinner.ValueChanged += new System.EventHandler(this.OppPPSpinnerValueChanged);
            // 
            // ppSpinner
            // 
            this.ppSpinner.Location = new System.Drawing.Point(350, 251);
            this.ppSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.ppSpinner.Name = "ppSpinner";
            this.ppSpinner.Size = new System.Drawing.Size(63, 20);
            this.ppSpinner.TabIndex = 23;
            this.ppSpinner.ValueChanged += new System.EventHandler(this.PpSpinnerValueChanged);
            // 
            // oppKSSpinner
            // 
            this.oppKSSpinner.Location = new System.Drawing.Point(350, 210);
            this.oppKSSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.oppKSSpinner.Name = "oppKSSpinner";
            this.oppKSSpinner.Size = new System.Drawing.Size(63, 20);
            this.oppKSSpinner.TabIndex = 21;
            this.oppKSSpinner.ValueChanged += new System.EventHandler(this.OppKSSpinnerValueChanged);
            // 
            // ksSpinner
            // 
            this.ksSpinner.Location = new System.Drawing.Point(350, 168);
            this.ksSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.ksSpinner.Name = "ksSpinner";
            this.ksSpinner.Size = new System.Drawing.Size(63, 20);
            this.ksSpinner.TabIndex = 19;
            this.ksSpinner.ValueChanged += new System.EventHandler(this.KsSpinnerValueChanged);
            // 
            // oppMobSpinner
            // 
            this.oppMobSpinner.Location = new System.Drawing.Point(350, 127);
            this.oppMobSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.oppMobSpinner.Name = "oppMobSpinner";
            this.oppMobSpinner.Size = new System.Drawing.Size(63, 20);
            this.oppMobSpinner.TabIndex = 17;
            this.oppMobSpinner.ValueChanged += new System.EventHandler(this.OppMobSpinnerValueChanged);
            // 
            // mobSpinner
            // 
            this.mobSpinner.Location = new System.Drawing.Point(350, 87);
            this.mobSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.mobSpinner.Name = "mobSpinner";
            this.mobSpinner.Size = new System.Drawing.Size(63, 20);
            this.mobSpinner.TabIndex = 15;
            this.mobSpinner.ValueChanged += new System.EventHandler(this.MobSpinnerValueChanged);
            // 
            // oppCocSpinner
            // 
            this.oppCocSpinner.Location = new System.Drawing.Point(350, 45);
            this.oppCocSpinner.Maximum = new decimal(new int[] {
                                    200,
                                    0,
                                    0,
                                    0});
            this.oppCocSpinner.Name = "oppCocSpinner";
            this.oppCocSpinner.Size = new System.Drawing.Size(63, 20);
            this.oppCocSpinner.TabIndex = 13;
            this.oppCocSpinner.ValueChanged += new System.EventHandler(this.OppCocSpinnerValueChanged);
            // 
            // PositionalPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oppCocSpinner);
            this.Controls.Add(this.mobSpinner);
            this.Controls.Add(this.oppMobSpinner);
            this.Controls.Add(this.ksSpinner);
            this.Controls.Add(this.oppKSSpinner);
            this.Controls.Add(this.ppSpinner);
            this.Controls.Add(this.oppPPSpinner);
            this.Controls.Add(this.pwSpinner);
            this.Controls.Add(this.oppPWSpinner);
            this.Controls.Add(this.oppCocSlider);
            this.Controls.Add(this.mobSlider);
            this.Controls.Add(this.oppMobSlider);
            this.Controls.Add(this.ksSlider);
            this.Controls.Add(this.oppKSSlider);
            this.Controls.Add(this.ppSlider);
            this.Controls.Add(this.oppPPSlider);
            this.Controls.Add(this.pwSlider);
            this.Controls.Add(this.oppPWSlider);
            this.Controls.Add(this.cocSpinner);
            this.Controls.Add(this.cocSlider);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PositionalPanel";
            this.Size = new System.Drawing.Size(430, 451);
            ((System.ComponentModel.ISupportInitialize)(this.cocSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPWSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPPSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppKSSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppMobSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppCocSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPWSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppPPSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppKSSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppMobSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oppCocSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.NumericUpDown oppCocSpinner;
        private System.Windows.Forms.NumericUpDown mobSpinner;
        private System.Windows.Forms.NumericUpDown oppMobSpinner;
        private System.Windows.Forms.NumericUpDown ksSpinner;
        private System.Windows.Forms.NumericUpDown oppKSSpinner;
        private System.Windows.Forms.NumericUpDown ppSpinner;
        private System.Windows.Forms.NumericUpDown oppPPSpinner;
        private System.Windows.Forms.NumericUpDown pwSpinner;
        private System.Windows.Forms.NumericUpDown oppPWSpinner;
        private System.Windows.Forms.TrackBar oppCocSlider;
        private System.Windows.Forms.TrackBar mobSlider;
        private System.Windows.Forms.TrackBar oppMobSlider;
        private System.Windows.Forms.TrackBar ksSlider;
        private System.Windows.Forms.TrackBar oppKSSlider;
        private System.Windows.Forms.TrackBar ppSlider;
        private System.Windows.Forms.TrackBar oppPPSlider;
        private System.Windows.Forms.TrackBar pwSlider;
        private System.Windows.Forms.TrackBar oppPWSlider;
        private System.Windows.Forms.NumericUpDown cocSpinner;
        private System.Windows.Forms.TrackBar cocSlider;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

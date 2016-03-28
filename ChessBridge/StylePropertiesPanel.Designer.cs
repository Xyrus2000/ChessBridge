/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 4:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChessBridge
{
    partial class StylePropertiesPanel
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
            this.adLabel = new System.Windows.Forms.Label();
            this.attackDefendSpinner = new System.Windows.Forms.NumericUpDown();
            this.sopLabel = new System.Windows.Forms.Label();
            this.attackDefendSlider = new System.Windows.Forms.TrackBar();
            this.sopSlider = new System.Windows.Forms.TrackBar();
            this.sopSpinner = new System.Windows.Forms.NumericUpDown();
            this.matPosLabel = new System.Windows.Forms.Label();
            this.matPosSlider = new System.Windows.Forms.TrackBar();
            this.matPosSpinner = new System.Windows.Forms.NumericUpDown();
            this.randLabel = new System.Windows.Forms.Label();
            this.maxDepthLabel = new System.Windows.Forms.Label();
            this.selSearchLabel = new System.Windows.Forms.Label();
            this.codLabel = new System.Windows.Forms.Label();
            this.ttLabel = new System.Windows.Forms.Label();
            this.ponderCheckbox = new System.Windows.Forms.CheckBox();
            this.egtCheckbox = new System.Windows.Forms.CheckBox();
            this.randomSlider = new System.Windows.Forms.TrackBar();
            this.maxDepthSlider = new System.Windows.Forms.TrackBar();
            this.selSearchSlider = new System.Windows.Forms.TrackBar();
            this.codSlider = new System.Windows.Forms.TrackBar();
            this.randSpinner = new System.Windows.Forms.NumericUpDown();
            this.maxDepthSpinner = new System.Windows.Forms.NumericUpDown();
            this.selSearchSpinner = new System.Windows.Forms.NumericUpDown();
            this.codSpinner = new System.Windows.Forms.NumericUpDown();
            this.ttSizeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.attackDefendSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackDefendSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sopSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sopSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matPosSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matPosSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selSearchSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selSearchSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // adLabel
            // 
            this.adLabel.Location = new System.Drawing.Point(3, 7);
            this.adLabel.Name = "adLabel";
            this.adLabel.Size = new System.Drawing.Size(112, 16);
            this.adLabel.TabIndex = 1;
            this.adLabel.Text = "Attack/Defense";
            // 
            // attackDefendSpinner
            // 
            this.attackDefendSpinner.Location = new System.Drawing.Point(367, 3);
            this.attackDefendSpinner.Minimum = new decimal(new int[] {
                                    100,
                                    0,
                                    0,
                                    -2147483648});
            this.attackDefendSpinner.Name = "attackDefendSpinner";
            this.attackDefendSpinner.Size = new System.Drawing.Size(55, 20);
            this.attackDefendSpinner.TabIndex = 2;
            this.attackDefendSpinner.ValueChanged += new System.EventHandler(this.AttackDefendSpinnerValueChanged);
            // 
            // sopLabel
            // 
            this.sopLabel.Location = new System.Drawing.Point(3, 57);
            this.sopLabel.Name = "sopLabel";
            this.sopLabel.Size = new System.Drawing.Size(112, 16);
            this.sopLabel.TabIndex = 3;
            this.sopLabel.Text = "Strength of Play";
            // 
            // attackDefendSlider
            // 
            this.attackDefendSlider.Location = new System.Drawing.Point(121, 4);
            this.attackDefendSlider.Maximum = 100;
            this.attackDefendSlider.Minimum = -100;
            this.attackDefendSlider.Name = "attackDefendSlider";
            this.attackDefendSlider.Size = new System.Drawing.Size(240, 45);
            this.attackDefendSlider.TabIndex = 0;
            this.attackDefendSlider.TickFrequency = 10;
            this.attackDefendSlider.Scroll += new System.EventHandler(this.AttackDefendSliderScroll);
            // 
            // sopSlider
            // 
            this.sopSlider.Location = new System.Drawing.Point(121, 55);
            this.sopSlider.Maximum = 100;
            this.sopSlider.Name = "sopSlider";
            this.sopSlider.Size = new System.Drawing.Size(240, 45);
            this.sopSlider.TabIndex = 4;
            this.sopSlider.TickFrequency = 10;
            this.sopSlider.Scroll += new System.EventHandler(this.SopSliderScroll);
            // 
            // sopSpinner
            // 
            this.sopSpinner.Location = new System.Drawing.Point(367, 55);
            this.sopSpinner.Name = "sopSpinner";
            this.sopSpinner.Size = new System.Drawing.Size(55, 20);
            this.sopSpinner.TabIndex = 5;
            this.sopSpinner.ValueChanged += new System.EventHandler(this.SopSpinnerValueChanged);
            // 
            // matPosLabel
            // 
            this.matPosLabel.Location = new System.Drawing.Point(3, 110);
            this.matPosLabel.Name = "matPosLabel";
            this.matPosLabel.Size = new System.Drawing.Size(112, 16);
            this.matPosLabel.TabIndex = 6;
            this.matPosLabel.Text = "Material/Positional";
            // 
            // matPosSlider
            // 
            this.matPosSlider.Location = new System.Drawing.Point(121, 106);
            this.matPosSlider.Maximum = 100;
            this.matPosSlider.Minimum = -100;
            this.matPosSlider.Name = "matPosSlider";
            this.matPosSlider.Size = new System.Drawing.Size(240, 45);
            this.matPosSlider.TabIndex = 7;
            this.matPosSlider.TickFrequency = 10;
            this.matPosSlider.Scroll += new System.EventHandler(this.MatPosSliderScroll);
            // 
            // matPosSpinner
            // 
            this.matPosSpinner.Location = new System.Drawing.Point(367, 106);
            this.matPosSpinner.Minimum = new decimal(new int[] {
                                    100,
                                    0,
                                    0,
                                    -2147483648});
            this.matPosSpinner.Name = "matPosSpinner";
            this.matPosSpinner.Size = new System.Drawing.Size(55, 20);
            this.matPosSpinner.TabIndex = 8;
            this.matPosSpinner.ValueChanged += new System.EventHandler(this.MatPosSpinnerValueChanged);
            // 
            // randLabel
            // 
            this.randLabel.Location = new System.Drawing.Point(3, 157);
            this.randLabel.Name = "randLabel";
            this.randLabel.Size = new System.Drawing.Size(112, 16);
            this.randLabel.TabIndex = 9;
            this.randLabel.Text = "Randomness";
            // 
            // maxDepthLabel
            // 
            this.maxDepthLabel.Location = new System.Drawing.Point(3, 208);
            this.maxDepthLabel.Name = "maxDepthLabel";
            this.maxDepthLabel.Size = new System.Drawing.Size(112, 16);
            this.maxDepthLabel.TabIndex = 10;
            this.maxDepthLabel.Text = "Max Search Depth";
            // 
            // selSearchLabel
            // 
            this.selSearchLabel.Location = new System.Drawing.Point(3, 259);
            this.selSearchLabel.Name = "selSearchLabel";
            this.selSearchLabel.Size = new System.Drawing.Size(112, 16);
            this.selSearchLabel.TabIndex = 11;
            this.selSearchLabel.Text = "Selective Search";
            // 
            // codLabel
            // 
            this.codLabel.Location = new System.Drawing.Point(0, 313);
            this.codLabel.Name = "codLabel";
            this.codLabel.Size = new System.Drawing.Size(112, 16);
            this.codLabel.TabIndex = 12;
            this.codLabel.Text = "Contempt of Draw";
            // 
            // ttLabel
            // 
            this.ttLabel.Location = new System.Drawing.Point(3, 366);
            this.ttLabel.Name = "ttLabel";
            this.ttLabel.Size = new System.Drawing.Size(112, 16);
            this.ttLabel.TabIndex = 13;
            this.ttLabel.Text = "Transposition Table";
            // 
            // ponderCheckbox
            // 
            this.ponderCheckbox.Location = new System.Drawing.Point(118, 412);
            this.ponderCheckbox.Name = "ponderCheckbox";
            this.ponderCheckbox.Size = new System.Drawing.Size(104, 24);
            this.ponderCheckbox.TabIndex = 14;
            this.ponderCheckbox.Text = "Pondering";
            this.ponderCheckbox.UseVisualStyleBackColor = true;
            
            // 
            // egtCheckbox
            // 
            this.egtCheckbox.Location = new System.Drawing.Point(254, 412);
            this.egtCheckbox.Name = "egtCheckbox";
            this.egtCheckbox.Size = new System.Drawing.Size(142, 24);
            this.egtCheckbox.TabIndex = 15;
            this.egtCheckbox.Text = "Use End Game Tables";
            this.egtCheckbox.UseVisualStyleBackColor = true;
            
            // 
            // randomSlider
            // 
            this.randomSlider.Location = new System.Drawing.Point(121, 157);
            this.randomSlider.Maximum = 100;
            this.randomSlider.Name = "randomSlider";
            this.randomSlider.Size = new System.Drawing.Size(240, 45);
            this.randomSlider.TabIndex = 16;
            this.randomSlider.TickFrequency = 10;
            this.randomSlider.Scroll += new System.EventHandler(this.RandomSliderScroll);
            // 
            // maxDepthSlider
            // 
            this.maxDepthSlider.Location = new System.Drawing.Point(121, 208);
            this.maxDepthSlider.Maximum = 99;
            this.maxDepthSlider.Minimum = 1;
            this.maxDepthSlider.Name = "maxDepthSlider";
            this.maxDepthSlider.Size = new System.Drawing.Size(240, 45);
            this.maxDepthSlider.TabIndex = 17;
            this.maxDepthSlider.TickFrequency = 10;
            this.maxDepthSlider.Value = 1;
            this.maxDepthSlider.Scroll += new System.EventHandler(this.MaxDepthSliderScroll);
            // 
            // selSearchSlider
            // 
            this.selSearchSlider.Location = new System.Drawing.Point(121, 259);
            this.selSearchSlider.Maximum = 16;
            this.selSearchSlider.Name = "selSearchSlider";
            this.selSearchSlider.Size = new System.Drawing.Size(240, 45);
            this.selSearchSlider.TabIndex = 18;
            this.selSearchSlider.Scroll += new System.EventHandler(this.SelSearchSliderScroll);
            // 
            // codSlider
            // 
            this.codSlider.Location = new System.Drawing.Point(121, 310);
            this.codSlider.Maximum = 500;
            this.codSlider.Minimum = -500;
            this.codSlider.Name = "codSlider";
            this.codSlider.Size = new System.Drawing.Size(240, 45);
            this.codSlider.TabIndex = 19;
            this.codSlider.TickFrequency = 25;
            this.codSlider.Scroll += new System.EventHandler(this.CodSliderScroll);
            // 
            // randSpinner
            // 
            this.randSpinner.Location = new System.Drawing.Point(367, 157);
            this.randSpinner.Name = "randSpinner";
            this.randSpinner.Size = new System.Drawing.Size(55, 20);
            this.randSpinner.TabIndex = 21;
            this.randSpinner.ValueChanged += new System.EventHandler(this.RandSpinnerValueChanged);
            // 
            // maxDepthSpinner
            // 
            this.maxDepthSpinner.Location = new System.Drawing.Point(367, 208);
            this.maxDepthSpinner.Maximum = new decimal(new int[] {
                                    99,
                                    0,
                                    0,
                                    0});
            this.maxDepthSpinner.Minimum = new decimal(new int[] {
                                    1,
                                    0,
                                    0,
                                    0});
            this.maxDepthSpinner.Name = "maxDepthSpinner";
            this.maxDepthSpinner.Size = new System.Drawing.Size(55, 20);
            this.maxDepthSpinner.TabIndex = 22;
            this.maxDepthSpinner.Value = new decimal(new int[] {
                                    1,
                                    0,
                                    0,
                                    0});
            this.maxDepthSpinner.ValueChanged += new System.EventHandler(this.MaxDepthSpinnerValueChanged);
            // 
            // selSearchSpinner
            // 
            this.selSearchSpinner.Location = new System.Drawing.Point(367, 259);
            this.selSearchSpinner.Minimum = new decimal(new int[] {
                                    100,
                                    0,
                                    0,
                                    -2147483648});
            this.selSearchSpinner.Name = "selSearchSpinner";
            this.selSearchSpinner.Size = new System.Drawing.Size(55, 20);
            this.selSearchSpinner.TabIndex = 23;
            this.selSearchSpinner.ValueChanged += new System.EventHandler(this.SelSearchSpinnerValueChanged);
            // 
            // codSpinner
            // 
            this.codSpinner.Location = new System.Drawing.Point(367, 309);
            this.codSpinner.Maximum = new decimal(new int[] {
                                    500,
                                    0,
                                    0,
                                    0});
            this.codSpinner.Minimum = new decimal(new int[] {
                                    500,
                                    0,
                                    0,
                                    -2147483648});
            this.codSpinner.Name = "codSpinner";
            this.codSpinner.Size = new System.Drawing.Size(55, 20);
            this.codSpinner.TabIndex = 24;
            this.codSpinner.ValueChanged += new System.EventHandler(this.CodSpinnerValueChanged);
            // 
            // ttSizeComboBox
            // 
            this.ttSizeComboBox.FormattingEnabled = true;
            this.ttSizeComboBox.Items.AddRange(new object[] {
                                    "None",
                                    "512 KB",
                                    "1 MB",
                                    "2 MB",
                                    "4 MB",
                                    "8 MB",
                                    "16 MB",
                                    "32 MB",
                                    "64 MB",
                                    "128 MB",
                                    "256 MB"});
            this.ttSizeComboBox.Location = new System.Drawing.Point(121, 361);
            this.ttSizeComboBox.Name = "ttSizeComboBox";
            this.ttSizeComboBox.Size = new System.Drawing.Size(240, 21);
            this.ttSizeComboBox.TabIndex = 25;
            
            // 
            // StylePropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ttSizeComboBox);
            this.Controls.Add(this.codSpinner);
            this.Controls.Add(this.selSearchSpinner);
            this.Controls.Add(this.maxDepthSpinner);
            this.Controls.Add(this.randSpinner);
            this.Controls.Add(this.codSlider);
            this.Controls.Add(this.selSearchSlider);
            this.Controls.Add(this.maxDepthSlider);
            this.Controls.Add(this.randomSlider);
            this.Controls.Add(this.egtCheckbox);
            this.Controls.Add(this.ponderCheckbox);
            this.Controls.Add(this.ttLabel);
            this.Controls.Add(this.codLabel);
            this.Controls.Add(this.selSearchLabel);
            this.Controls.Add(this.maxDepthLabel);
            this.Controls.Add(this.randLabel);
            this.Controls.Add(this.matPosSpinner);
            this.Controls.Add(this.matPosSlider);
            this.Controls.Add(this.matPosLabel);
            this.Controls.Add(this.sopSpinner);
            this.Controls.Add(this.sopSlider);
            this.Controls.Add(this.sopLabel);
            this.Controls.Add(this.attackDefendSpinner);
            this.Controls.Add(this.adLabel);
            this.Controls.Add(this.attackDefendSlider);
            this.Name = "StylePropertiesPanel";
            this.Size = new System.Drawing.Size(430, 451);
            ((System.ComponentModel.ISupportInitialize)(this.attackDefendSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackDefendSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sopSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sopSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matPosSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matPosSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selSearchSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selSearchSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox ttSizeComboBox;
        private System.Windows.Forms.NumericUpDown codSpinner;
        private System.Windows.Forms.NumericUpDown selSearchSpinner;
        private System.Windows.Forms.NumericUpDown maxDepthSpinner;
        private System.Windows.Forms.NumericUpDown randSpinner;
        private System.Windows.Forms.TrackBar codSlider;
        private System.Windows.Forms.TrackBar selSearchSlider;
        private System.Windows.Forms.TrackBar maxDepthSlider;
        private System.Windows.Forms.TrackBar randomSlider;
        private System.Windows.Forms.CheckBox egtCheckbox;
        private System.Windows.Forms.CheckBox ponderCheckbox;
        private System.Windows.Forms.Label ttLabel;
        private System.Windows.Forms.Label codLabel;
        private System.Windows.Forms.Label selSearchLabel;
        private System.Windows.Forms.Label maxDepthLabel;
        private System.Windows.Forms.Label randLabel;
        private System.Windows.Forms.NumericUpDown matPosSpinner;
        private System.Windows.Forms.TrackBar matPosSlider;
        private System.Windows.Forms.Label matPosLabel;
        private System.Windows.Forms.NumericUpDown sopSpinner;
        private System.Windows.Forms.TrackBar sopSlider;
        private System.Windows.Forms.Label sopLabel;
        private System.Windows.Forms.NumericUpDown attackDefendSpinner;
        private System.Windows.Forms.Label adLabel;
        private System.Windows.Forms.TrackBar attackDefendSlider;
        
        void AttackDefendSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.attackDefendSlider.Value;
            int spinner = (int)this.attackDefendSpinner.Value;
            if (slider != spinner)
            {
                this.attackDefendSpinner.Value = this.attackDefendSlider.Value;
            }
        }
        
        void AttackDefendSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.attackDefendSlider.Value;
            int spinner = (int)this.attackDefendSpinner.Value;
            if (slider != spinner)
            {
                this.attackDefendSlider.Value = (int)this.attackDefendSpinner.Value;
            }
        }
        
        void SopSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.sopSlider.Value;
            int spinner = (int)this.sopSpinner.Value;
            if (slider != spinner)
            {
                this.sopSpinner.Value = this.sopSlider.Value;
            }
        }
        
        void SopSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.sopSlider.Value;
            int spinner = (int)this.sopSpinner.Value;
            if (slider != spinner)
            {
                this.sopSlider.Value = (int)this.sopSpinner.Value ;
            }
        }
        
        void MatPosSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.matPosSlider.Value;
            int spinner = (int)this.matPosSpinner.Value;
            if (slider != spinner)
            {
                this.matPosSpinner.Value = this.matPosSlider.Value;
            }
        }
        
        void MatPosSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.matPosSlider.Value;
            int spinner = (int)this.matPosSpinner.Value;
            if (slider != spinner)
            {
                this.matPosSlider.Value = (int)this.matPosSpinner.Value ;
            }
        }
        
        void RandomSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.randomSlider.Value;
            int spinner = (int)this.randSpinner.Value;
            if (slider != spinner)
            {
                this.randSpinner.Value = this.randomSlider.Value;
            }
        }
        
        void RandSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.randomSlider.Value;
            int spinner = (int)this.randSpinner.Value;
            if (slider != spinner)
            {
                this.randomSlider.Value = (int)this.randSpinner.Value ;
            }
        }
        
        void MaxDepthSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.maxDepthSlider.Value;
            int spinner = (int)this.maxDepthSpinner.Value;
            if (slider != spinner)
            {
                this.maxDepthSpinner.Value = this.maxDepthSlider.Value;
            }
        }
        
        void MaxDepthSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.maxDepthSlider.Value;
            int spinner = (int)this.maxDepthSpinner.Value;
            if (slider != spinner)
            {
                this.maxDepthSlider.Value = (int)this.maxDepthSpinner.Value ;
            }
        }
        
        void SelSearchSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.selSearchSlider.Value;
            int spinner = (int)this.selSearchSpinner.Value;
            if (slider != spinner)
            {
                this.selSearchSpinner.Value = this.selSearchSlider.Value;
            }
        }
        
        void SelSearchSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.selSearchSlider.Value;
            int spinner = (int)this.selSearchSpinner.Value;
            if (slider != spinner)
            {
                this.selSearchSlider.Value = (int)this.selSearchSpinner.Value ;
            }
        }
        
        void CodSliderScroll(object sender, System.EventArgs e)
        {
            int slider = this.codSlider.Value;
            int spinner = (int)this.codSpinner.Value;
            if (slider != spinner)
            {
                this.codSpinner.Value = this.codSlider.Value;
            }
        }
        
        void CodSpinnerValueChanged(object sender, System.EventArgs e)
        {
            int slider = this.codSlider.Value;
            int spinner = (int)this.codSpinner.Value;
            if (slider != spinner)
            {
                this.codSlider.Value = (int)this.codSpinner.Value ;
            }
        }
        
    }
}

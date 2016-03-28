/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 4:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChessBridge
{
    partial class PersonalityGUI
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Personality personality = new Personality();
        
        public Personality Personality {
            get { return personality; }
        }
        
        
        public PersonalityGUI(Personality personality)
        {
            this.personality = personality;
        }
        
        /// <summary>
        /// Disposes resources used by the form.
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
            this.propertyTabs = new System.Windows.Forms.TabControl();
            this.styleTab = new System.Windows.Forms.TabPage();
            this.stylePropertiesPanel = new ChessBridge.StylePropertiesPanel();
            this.positionalTab = new System.Windows.Forms.TabPage();
            this.positionalPropertiesPanel = new ChessBridge.PositionalPanel();
            this.materialTab = new System.Windows.Forms.TabPage();
            this.materialPropertiesPanel = new ChessBridge.MaterialPropertiesPanel();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.infoPropertiesPanel = new ChessBridge.InfoPropertiesPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openPersonalityButton = new System.Windows.Forms.Button();
            this.openPersonalityFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.savePersonalityFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.propertyTabs.SuspendLayout();
            this.styleTab.SuspendLayout();
            this.positionalTab.SuspendLayout();
            this.materialTab.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyTabs
            // 
            this.propertyTabs.Controls.Add(this.styleTab);
            this.propertyTabs.Controls.Add(this.positionalTab);
            this.propertyTabs.Controls.Add(this.materialTab);
            this.propertyTabs.Controls.Add(this.infoTab);
            this.propertyTabs.Location = new System.Drawing.Point(12, 12);
            this.propertyTabs.Name = "propertyTabs";
            this.propertyTabs.SelectedIndex = 0;
            this.propertyTabs.Size = new System.Drawing.Size(439, 459);
            this.propertyTabs.TabIndex = 0;
            // 
            // styleTab
            // 
            this.styleTab.Controls.Add(this.stylePropertiesPanel);
            this.styleTab.Location = new System.Drawing.Point(4, 22);
            this.styleTab.Name = "styleTab";
            this.styleTab.Padding = new System.Windows.Forms.Padding(3);
            this.styleTab.Size = new System.Drawing.Size(431, 433);
            this.styleTab.TabIndex = 0;
            this.styleTab.Text = "Style";
            this.styleTab.UseVisualStyleBackColor = true;
            // 
            // stylePropertiesPanel
            // 
            this.stylePropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.stylePropertiesPanel.Name = "stylePropertiesPanel";
            this.stylePropertiesPanel.Size = new System.Drawing.Size(430, 451);
            this.stylePropertiesPanel.TabIndex = 0;
            // 
            // positionalTab
            // 
            this.positionalTab.Controls.Add(this.positionalPropertiesPanel);
            this.positionalTab.Location = new System.Drawing.Point(4, 22);
            this.positionalTab.Name = "positionalTab";
            this.positionalTab.Padding = new System.Windows.Forms.Padding(3);
            this.positionalTab.Size = new System.Drawing.Size(431, 433);
            this.positionalTab.TabIndex = 1;
            this.positionalTab.Text = "Positional";
            this.positionalTab.UseVisualStyleBackColor = true;
            // 
            // positionalPropertiesPanel
            // 
            this.positionalPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.positionalPropertiesPanel.Name = "positionalPropertiesPanel";
            this.positionalPropertiesPanel.Size = new System.Drawing.Size(435, 433);
            this.positionalPropertiesPanel.TabIndex = 0;
            // 
            // materialTab
            // 
            this.materialTab.Controls.Add(this.materialPropertiesPanel);
            this.materialTab.Location = new System.Drawing.Point(4, 22);
            this.materialTab.Name = "materialTab";
            this.materialTab.Size = new System.Drawing.Size(431, 433);
            this.materialTab.TabIndex = 2;
            this.materialTab.Text = "Material";
            this.materialTab.UseVisualStyleBackColor = true;
            // 
            // materialPropertiesPanel
            // 
            this.materialPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.materialPropertiesPanel.Name = "materialPropertiesPanel";
            this.materialPropertiesPanel.Size = new System.Drawing.Size(435, 433);
            this.materialPropertiesPanel.TabIndex = 0;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.infoPropertiesPanel);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(431, 433);
            this.infoTab.TabIndex = 3;
            this.infoTab.Text = "Info";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // infoPropertiesPanel
            // 
            this.infoPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPropertiesPanel.Name = "infoPropertiesPanel";
            this.infoPropertiesPanel.Size = new System.Drawing.Size(430, 433);
            this.infoPropertiesPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(479, 409);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(62, 26);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cancelButton.Location = new System.Drawing.Point(479, 441);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(62, 26);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // openPersonalityButton
            // 
            this.openPersonalityButton.Location = new System.Drawing.Point(466, 34);
            this.openPersonalityButton.Name = "openPersonalityButton";
            this.openPersonalityButton.Size = new System.Drawing.Size(75, 23);
            this.openPersonalityButton.TabIndex = 3;
            this.openPersonalityButton.Text = "Open";
            this.openPersonalityButton.UseVisualStyleBackColor = true;
            this.openPersonalityButton.Click += new System.EventHandler(this.OpenPersonalityButtonClick);
            // 
            // openPersonalityFileDialog
            // 
            this.openPersonalityFileDialog.Filter = "Chessmaster files (*.cmp)|*.cmp";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(466, 64);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // savePersonalityFileDialog
            // 
            this.savePersonalityFileDialog.Filter = "Chessmaster files (*.cmp)|*.cmp";
            // 
            // PersonalityGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 479);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openPersonalityButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.propertyTabs);
            this.Name = "PersonalityGUI";
            this.Text = "Chessmaster Personality Modifier";
            this.propertyTabs.ResumeLayout(false);
            this.styleTab.ResumeLayout(false);
            this.positionalTab.ResumeLayout(false);
            this.materialTab.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.SaveFileDialog savePersonalityFileDialog;
        private System.Windows.Forms.Button saveButton;
        private ChessBridge.InfoPropertiesPanel infoPropertiesPanel;
        private ChessBridge.MaterialPropertiesPanel materialPropertiesPanel;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.TabPage materialTab;
        private ChessBridge.PositionalPanel positionalPropertiesPanel;
        private System.Windows.Forms.OpenFileDialog openPersonalityFileDialog;
        private System.Windows.Forms.Button openPersonalityButton;
        private ChessBridge.StylePropertiesPanel stylePropertiesPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabPage positionalTab;
        private System.Windows.Forms.TabPage styleTab;
        private System.Windows.Forms.TabControl propertyTabs;
        
        void OkButtonClick(object sender, System.EventArgs e)
        {
            //gather all info and write it to the personality
            //build personality from settings
            this.stylePropertiesPanel.saveToPersonality(personality);
            this.positionalPropertiesPanel.saveToPersonality(personality);
            this.materialPropertiesPanel.saveToPersonality(personality);
            this.infoPropertiesPanel.saveToPersonality(personality);
            
            this.Close();
        }
    }
}

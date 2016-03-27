/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 4:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace ChessBridge
{
    /// <summary>
    /// Description of PersonalityGUI.
    /// </summary>
    public partial class PersonalityGUI : Form
    { 
        public PersonalityGUI()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        public void setPersonality(Personality personality)
        {
            this.stylePropertiesPanel.setPersonality(personality);
            this.materialPropertiesPanel.setPersonality(personality);
            this.positionalPropertiesPanel.setPersonality(personality);
            this.infoPropertiesPanel.setPersonality(personality);
        }
        
        void OpenPersonalityButtonClick(object sender, EventArgs e)
        {
            DialogResult result = this.openPersonalityFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = this.openPersonalityFileDialog.FileName;
                personality.parsePersonality(path);
                this.setPersonality(personality);
            }
        }
        
        void SaveButtonClick(object sender, EventArgs e)
        {
            DialogResult result = this.savePersonalityFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //build personality from settings
                this.stylePropertiesPanel.saveToPersonality(personality);
                this.positionalPropertiesPanel.saveToPersonality(personality);
                this.materialPropertiesPanel.saveToPersonality(personality);
                this.infoPropertiesPanel.saveToPersonality(personality);
                
                personality.savePersonalityToFile(this.savePersonalityFileDialog.FileName);
            }
        }
        
        void CancelButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

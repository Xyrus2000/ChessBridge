/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChessBridge
{
    /// <summary>
    /// Description of InfoPropertiesPanel.
    /// </summary>
    public partial class InfoPropertiesPanel : UserControl
    {
        public InfoPropertiesPanel()
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
            this.shortTextbox.Text = personality.ShortPlayingStyle;
            this.bioTextBox.Text = personality.Biography;
            this.longTextbox.Text = personality.LongPlayingStyle;
        }
        
        /**
         * Writes current values to the specified personality.
         */ 
        public void saveToPersonality(Personality personality)
        {
            personality.ShortPlayingStyle = this.shortTextbox.Text;
            personality.Biography = this.bioTextBox.Text;
            personality.LongPlayingStyle = this.longTextbox.Text;
        }
    }
}

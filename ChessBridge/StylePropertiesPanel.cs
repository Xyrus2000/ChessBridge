/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 4:12 PM
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
    /// Description of BasicPropertyPanel.
    /// </summary>
    public partial class StylePropertiesPanel : UserControl
    {
        public StylePropertiesPanel()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            
        }
        
        public void setPersonality(Personality personality)
        {
            //init control values
            this.attackDefendSlider.Value = personality.AttackDefense;
            this.attackDefendSpinner.Value = personality.AttackDefense;
            
            this.sopSlider.Value = personality.Sop;
            this.sopSpinner.Value = personality.Sop;
            
            this.matPosSlider.Value = personality.MatPos;
            this.matPosSpinner.Value = personality.MatPos;
            
            this.randomSlider.Value = personality.Rand;
            this.randSpinner.Value = personality.Rand;
            
            this.maxDepthSlider.Value = personality.MaxDepth;
            this.maxDepthSpinner.Value = personality.MaxDepth;
            
            this.selSearchSlider.Value = personality.SelSearch;
            this.selSearchSpinner.Value = personality.SelSearch;
            
            this.codSlider.Value = personality.Contempt;
            this.codSpinner.Value = personality.Contempt;
            
            this.ttSizeComboBox.SelectedIndex = personality.TtSize;
            
            if (personality.Ponder != 0)
            {
                this.ponderCheckbox.CheckState = CheckState.Checked;
            }
            
            if (personality.UseEGT != 0)
            {
                this.egtCheckbox.CheckState =  CheckState.Checked;
            }
        }
        
        /**
         * Writes current values to the specified personality.
         */ 
        public void saveToPersonality(Personality personality)
        {
            //init control values
            personality.AttackDefense = this.attackDefendSlider.Value;
            personality.AttackDefense = (int)this.attackDefendSpinner.Value;
            
            personality.Sop = this.sopSlider.Value;
            personality.Sop = (int)this.sopSpinner.Value;
            
            personality.MatPos = this.matPosSlider.Value;
            personality.MatPos = (int)this.matPosSpinner.Value;
            
            personality.Rand = this.randomSlider.Value;
            personality.Rand = (int)this.randSpinner.Value;
            
            personality.MaxDepth = this.maxDepthSlider.Value;
            personality.MaxDepth = (int)this.maxDepthSpinner.Value;
            
            personality.SelSearch = this.selSearchSlider.Value;
            personality.SelSearch = (int)this.selSearchSpinner.Value;
            
            personality.Contempt = this.codSlider.Value;
            personality.Contempt = (int)this.codSpinner.Value;
            
            personality.TtSize = this.ttSizeComboBox.SelectedIndex;
            
            if (this.ponderCheckbox.CheckState == CheckState.Checked)
            {
                 personality.Ponder = 1;
            }
            else
            {
                personality.Ponder = 0;
            }
            
            if (this.egtCheckbox.CheckState == CheckState.Checked)
            {
                 personality.UseEGT = 1;
            }
            else
            {
                personality.UseEGT = 0;
            }
        }
    }
}

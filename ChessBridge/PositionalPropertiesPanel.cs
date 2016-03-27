/*
 * Created by SharpDevelop.
 * User: Xyrus
 * Date: 3/26/2016
 * Time: 7:07 PM
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
    /// Description of PositionalPanel.
    /// </summary>
    public partial class PositionalPanel : UserControl
    {
        public PositionalPanel()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        /**
         * Extracts necessary properties from the supplied perso0nality for display.
         */
        public void setPersonality(Personality personality)
        {
            //init control values
            this.cocSlider.Value = personality.OwnCoC;
            this.cocSpinner.Value = personality.OwnCoC;
            
            this.oppCocSlider.Value = personality.OppCoC;
            this.oppCocSpinner.Value = personality.OppCoC;
            
            this.mobSlider.Value = personality.OwnMob;
            this.mobSpinner.Value = personality.OwnMob;
            
            this.oppMobSlider.Value = personality.OppMob;
            this.oppMobSpinner.Value = personality.OppMob;
            
            this.ksSlider.Value = personality.OwnKS;
            this.ksSpinner.Value = personality.OwnKS;
            
            this.oppKSSlider.Value = personality.OppKS;
            this.oppKSSpinner.Value = personality.OppKS;
            
            this.ppSlider.Value = personality.OwnPP;
            this.ppSpinner.Value = personality.OwnPP;
            
            this.oppPPSlider.Value = personality.OppPP;
            this.oppPPSpinner.Value = personality.OppPP;
            
            this.pwSlider.Value = personality.OwnPW;
            this.pwSpinner.Value = personality.OwnPW;
            
            this.oppPWSlider.Value = personality.OppPW;
            this.oppPWSpinner.Value = personality.OppPW;
        }
        
         /**
         * Writes current values to the specified personality.
         */ 
        public void saveToPersonality(Personality personality)
        {
            personality.OwnCoC = this.cocSlider.Value;
            personality.OwnCoC = (int)this.cocSpinner.Value;
            
            personality.OppCoC = this.oppCocSlider.Value;
            personality.OppCoC = (int)this.oppCocSpinner.Value;
            
            personality.OwnMob = this.mobSlider.Value;
            personality.OwnMob = (int)this.mobSpinner.Value;
            
            personality.OppMob = this.oppMobSlider.Value;
            personality.OppMob = (int)this.oppMobSpinner.Value;
            
            personality.OwnKS = this.ksSlider.Value;
            personality.OwnKS = (int)this.ksSpinner.Value;
            
            personality.OppKS = this.oppKSSlider.Value;
            personality.OppKS = (int)this.oppKSSpinner.Value;
            
            personality.OwnPP = this.ppSlider.Value;
            personality.OwnPP = (int)this.ppSpinner.Value;
            
            personality.OppPP = this.oppPPSlider.Value;
            personality.OppPP = (int)this.oppPPSpinner.Value;
            
            personality.OwnPW = this.pwSlider.Value;
            personality.OwnPW = (int)this.pwSpinner.Value;
            
            personality.OppPW = this.oppPWSlider.Value;
            personality.OppPW = (int)this.oppPWSpinner.Value;
        }
        
        void CocSliderScroll(object sender, EventArgs e)
        {
            int slider = this.cocSlider.Value;
            int spinner = (int)this.cocSpinner.Value;
            if (slider != spinner)
            {
                this.cocSpinner.Value = this.cocSlider.Value;
            }
        }
        
        void CocSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.cocSlider.Value;
            int spinner = (int)this.cocSpinner.Value;
            if (slider != spinner)
            {
                this.cocSlider.Value = (int)this.cocSpinner.Value;
            }
        }
        
        void OppCocSliderScroll(object sender, EventArgs e)
        {
            int slider = this.oppCocSlider.Value;
            int spinner = (int)this.oppCocSpinner.Value;
            if (slider != spinner)
            {
                this.oppCocSpinner.Value = this.oppCocSlider.Value;
            }
        }
        
        void OppCocSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.oppCocSlider.Value;
            int spinner = (int)this.oppCocSpinner.Value;
            if (slider != spinner)
            {
                this.oppCocSlider.Value = (int)this.oppCocSpinner.Value;
            }
        }
        
        void MobSliderScroll(object sender, EventArgs e)
        {
            int slider = this.mobSlider.Value;
            int spinner = (int)this.mobSpinner.Value;
            if (slider != spinner)
            {
                this.mobSpinner.Value = this.mobSlider.Value;
            }
        }
        
        void MobSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.mobSlider.Value;
            int spinner = (int)this.mobSpinner.Value;
            if (slider != spinner)
            {
                this.mobSlider.Value = (int)this.mobSpinner.Value;
            }
        }
        
        void OppMobSliderScroll(object sender, EventArgs e)
        {
            int slider = this.oppMobSlider.Value;
            int spinner = (int)this.oppMobSpinner.Value;
            if (slider != spinner)
            {
                this.oppMobSpinner.Value = this.oppMobSlider.Value;
            }
        }
        
        void OppMobSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.oppMobSlider.Value;
            int spinner = (int)this.oppMobSpinner.Value;
            if (slider != spinner)
            {
                this.oppMobSlider.Value = (int)this.oppMobSpinner.Value;
            }
        }
        
        void KsSliderScroll(object sender, EventArgs e)
        {
            int slider = this.ksSlider.Value;
            int spinner = (int)this.ksSpinner.Value;
            if (slider != spinner)
            {
                this.ksSpinner.Value = this.ksSlider.Value;
            }
        }
        
        void KsSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.ksSlider.Value;
            int spinner = (int)this.ksSpinner.Value;
            if (slider != spinner)
            {
                this.ksSlider.Value = (int)this.ksSpinner.Value;
            }
        }
        
        void OppKSSliderScroll(object sender, EventArgs e)
        {
            int slider = this.oppKSSlider.Value;
            int spinner = (int)this.oppKSSpinner.Value;
            if (slider != spinner)
            {
                this.oppKSSpinner.Value = this.oppKSSlider.Value;
            }
        }
        
        void PpSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.ppSlider.Value;
            int spinner = (int)this.ppSpinner.Value;
            if (slider != spinner)
            {
                this.ppSlider.Value = (int)this.ppSpinner.Value;
            }
        }
        
        void PpSliderScroll(object sender, EventArgs e)
        {
            int slider = this.ppSlider.Value;
            int spinner = (int)this.ppSpinner.Value;
            if (slider != spinner)
            {
                this.ppSpinner.Value = this.ppSlider.Value;
            }
        }
        
        void OppPPSliderScroll(object sender, EventArgs e)
        {
            int slider = this.oppPPSlider.Value;
            int spinner = (int)this.oppPPSpinner.Value;
            if (slider != spinner)
            {
                this.oppPPSpinner.Value = this.oppPPSlider.Value;
            }
        }
        
        void OppPPSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.oppPPSlider.Value;
            int spinner = (int)this.oppPPSpinner.Value;
            if (slider != spinner)
            {
                this.oppPPSlider.Value = (int)this.oppPPSpinner.Value;
            }
        }
        
        void PwSliderScroll(object sender, EventArgs e)
        {
            int slider = this.pwSlider.Value;
            int spinner = (int)this.pwSpinner.Value;
            if (slider != spinner)
            {
                this.pwSpinner.Value = this.pwSlider.Value;
            }
        }
        
        void PwSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.pwSlider.Value;
            int spinner = (int)this.pwSpinner.Value;
            if (slider != spinner)
            {
                this.pwSlider.Value = (int)this.pwSpinner.Value;
            }
        }
        
        void OppPWSliderScroll(object sender, EventArgs e)
        {
            int slider = this.oppPWSlider.Value;
            int spinner = (int)this.oppPWSpinner.Value;
            if (slider != spinner)
            {
                this.oppPWSpinner.Value = this.oppPWSlider.Value;
            }
        }
        
        void OppPWSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.oppPWSlider.Value;
            int spinner = (int)this.oppPWSpinner.Value;
            if (slider != spinner)
            {
                this.oppPWSlider.Value = (int)this.oppPWSpinner.Value;
            }
        }
        
        void OppKSSpinnerValueChanged(object sender, EventArgs e)
        {
            int slider = this.oppKSSlider.Value;
            int spinner = (int)this.oppKSSpinner.Value;
            if (slider != spinner)
            {
                this.oppKSSlider.Value = (int)this.oppKSSpinner.Value;
            }
        }
    }
}

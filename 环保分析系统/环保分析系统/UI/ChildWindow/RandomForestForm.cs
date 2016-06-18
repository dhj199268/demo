using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 环保分析系统.UI.ChildWindow
{
    public partial class RandomForestForm : 环保分析系统.UI.ChildWindow.baseWindow.baseForm
    {
        public RandomForestForm()
        {
            InitializeComponent();
        }

        private void RandomForestForm_Load(object sender, EventArgs e)
        {

        }

        protected override void setAdvancedControlEnabled(bool state)
        {
                this.treenumBar.Enabled = state;
                this.treenumText.Enabled = state;
                this.depthTextBox.Enabled = state;
                this.treedepthBar.Enabled = state;
                this.isPrun.Enabled = state;
        }

        private void treenumBar_Scroll(object sender, EventArgs e)
        {
            this.treenumText.Text = Convert.ToString(this.treenumBar.Value);
        }

        private void depthtrackBar_Scroll(object sender, EventArgs e)
        {
            this.depthTextBox.Text = Convert.ToString(this.treedepthBar.Value);
        }
        public int GetTreeDepth()
        {
            return int.Parse(this.treedepth.Text);
        }
        public int GetTreeNum()
        {
            return int.Parse(this.treenumText.Text);
        }
        public bool IsPrun()
        {
            return this.isPrun.Checked; 
        }
    }
}

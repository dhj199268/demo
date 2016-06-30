using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 环保分析系统.UI.ChildWindow
{
    public partial class WaveANNForm : 环保分析系统.UI.ChildWindow.baseWindow.baseForm
    {
        public WaveANNForm()
        {
            InitializeComponent();
        }
        public WaveANNForm(string[] features,int limit=1):base(features,limit)
        {
            InitializeComponent();
            
        }

        private void itertrackBar_Scroll(object sender, EventArgs e)
        {
            this.itertextBox.Text = Convert.ToString(this.itertrackBar.Value);
        }

        private void hidelayertrackBar_Scroll(object sender, EventArgs e)
        {
            this.hidelayertextBox.Text = Convert.ToString(this.hidelayertrackBar.Value);
        }
        protected override void setAdvancedControlEnabled(bool state)
        {
            this.hidelayertextBox.Enabled = state;
            this.hidelayertrackBar.Enabled = state;
            this.itertrackBar.Enabled = state;
            this.itertextBox.Enabled = state;
        }
    }
}

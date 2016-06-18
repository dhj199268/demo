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

        private void itertrackBar_Scroll(object sender, EventArgs e)
        {
            this.itertextBox.Text = Convert.ToString(this.itertrackBar.Value);
        }
    }
}

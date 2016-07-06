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
        public int GetHideLayer()
        {
            return this.hidelayer;
        }

        public int GetIter()
        {
            return this.iter;
        }

        protected override void setParm(string method)
        {
            //  "快   速",
            //"标   准",
            //"精   确"
            switch (method)
            {
                case "快   速": this.hidelayer = this.GetTimeLen()+4; this.iter=100; break;
                case "标   准": this.hidelayer = this.GetTimeLen() + 10; this.iter = 500; break;
                case "精   确": this.hidelayer = this.GetTimeLen() + 15; this.iter = 1000; break;

            }
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

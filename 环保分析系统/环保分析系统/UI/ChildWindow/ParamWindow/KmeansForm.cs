using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 环保分析系统.UI.ChildWindow
{
    public partial class KmeansForm : 环保分析系统.UI.ChildWindow.baseWindow.baseForm
    {
        public KmeansForm()
        {
            InitializeComponent();
        }
        public KmeansForm(string[] features,int rows,int limit=2):base(features,limit,rows)
        {
            InitializeComponent();
        }
        public int GetIter()
        {
           return int.Parse(this.itertextBox.Text);
        }
        public int GetClassNum()
        {
            return int.Parse(this.classtextBox.Text);
        }

        private void classtrackBar_Scroll(object sender, EventArgs e)
        {
            this.classtextBox.Text = Convert.ToString(this.classtrackBar.Value);
        }

        private void itertrackBar_Scroll(object sender, EventArgs e)
        {
            this.itertextBox.Text = Convert.ToString(this.itertrackBar.Value);
        }
        protected override void setAdvancedControlEnabled(bool state)
        {
            this.itertrackBar.Enabled = state;
            this.itertextBox.Enabled = state;
            this.classtextBox.Enabled = state;
            this.classtrackBar.Enabled = state;
        }
        protected override void SetParm(string method)
        {
            switch (method)
            {
                case "快   速": this.itertextBox.Text = "6"; this.classtextBox.Text="2"; break;
                case "标   准": this.itertextBox.Text = "15"; this.classtextBox.Text = "2"; break;
                case "精   确": this.itertextBox.Text = "20"; this.classtextBox.Text = "2"; break;

            }
        }
        protected override void SetTrainRow(int rows)
        {
            string str;
            str = "1" + "-" + rows;
            this.trainrownum.Text = str;
            this.predictrownum.Text = str;

        }
    }
}

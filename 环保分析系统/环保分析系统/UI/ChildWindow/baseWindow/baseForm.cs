using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 环保分析系统.UI.ChildWindow.baseWindow
{
    public partial class baseForm : Form
    {
        public baseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2Collapsed == false)
            {
                this.Height = this.smallhight;
                this.splitContainer1.Panel2Collapsed = true;
                //this.splitContainer1.Panel2.Hide();
                
            }
            else
            {
               // this.splitContainer1.Panel2.Show();
                this.splitContainer1.Panel2Collapsed = false;
                this.Height = this.bighight;
            }
           
        }

        private void baseForm_Load(object sender, EventArgs e)
        {
            this.bighight = this.Height;
            this.smallhight = this.splitContainer1.Panel1.Height+50;
            this.Height = this.smallhight;
            this.splitContainer1.Panel2Collapsed = true;
            //this.splitContainer1.Panel2.Hide();

            this.comboBox1.Items.Add("快   速");
            this.comboBox1.Items.Add("标   准");
            this.comboBox1.Items.Add("精   确");
            this.comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 环保分析系统.UI.ChildWindow
{
    public partial class HMMForm : 环保分析系统.UI.ChildWindow.baseWindow.baseForm
    {
        public HMMForm()
        {
            InitializeComponent();
        }

        private void leve1textBox_TextChanged(object sender, EventArgs e)
        {
            this.textBox7.Text = this.leve1textBox.Text;
        }

        private void leve2textBox_TextChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = this.leve2textBox.Text;
        }

        private void level3textBox_TextChanged(object sender, EventArgs e)
        {
            level4textBox.Text = this.level3textBox.Text;
        }
    }
}

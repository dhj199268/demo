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
        public HMMForm(string[] features,int limit=1):base(features,limit)
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
            level4textBox.Text = this.leve3textBox.Text;
        }
        public int[] GetLevel()
        {
            int[] level = new int[3];
            level[0] = int.Parse(this.leve1textBox.Text);
            level[1] = int.Parse(this.leve2textBox.Text);
            level[2] = int.Parse(this.leve3textBox.Text);
            return level;
        
        }
        protected override void setAdvancedControlEnabled(bool state)
        {
            this.leve1textBox.Enabled = state;
            this.leve2textBox.Enabled = state;
            this.leve3textBox.Enabled = state;
        }

        private void leve1textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    MessageBox.Show("非法输入,请输入数字");   //处理非法字符
                    e.KeyChar = (char)0;
                }
            }
        }

        private void leve2textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    MessageBox.Show("非法输入,请输入数字");   //处理非法字符
                    e.KeyChar = (char)0;
                }
            }
        }

        private void leve3textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    MessageBox.Show("非法输入,请输入数字");   //处理非法字符
                    e.KeyChar = (char)0;
                }
            }
        }
    }
}

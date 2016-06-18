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
            if (this.splitContainer.Panel2Collapsed == false)
            {
                this.Height = this.smallhight;
                this.splitContainer.Panel2Collapsed = true;
                //this.splitContainer1.Panel2.Hide();
                
            }
            else
            {
               // this.splitContainer1.Panel2.Show();
                this.splitContainer.Panel2Collapsed = false;
                this.Height = this.bighight;
            }
           
        }

        public void baseForm_Load(object sender, EventArgs e)
        {
            this.bighight = this.Height;
            this.smallhight = this.splitContainer.Panel1.Height+50;
            this.Height = this.smallhight;
            this.splitContainer.Panel2Collapsed = true;
            //this.splitContainer1.Panel2.Hide();
        }


        //用于获取行号
        public int[] getRowNum()
        {
            string strtmp= this.trainrownum.Text;
            string[] strlist = strtmp.Split('-');
            if (strlist.Length!=2)
            {
                throw new Exception("error input");
            }

            int[] tmp = new int[strlist.Length];
            for (int i = 0; i < strlist.Length; ++i)
            {
                tmp[i] = int.Parse(strlist[i]);
            }
            return tmp;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.devarList.ClearSelected();
            this.indevarList.ClearSelected();
        }

        private void isAdvence_CheckedChanged(object sender, EventArgs e)
        {
            setAdvancedControlEnabled(this.isAdvence.Checked);
        }

    
        protected void onlyInputNum(object sender, KeyPressEventArgs e)
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
        //state 表示checkbox 是否按下的bool值
        protected virtual void setAdvancedControlEnabled(bool state)
        {

            if (state == false)
            {
                MessageBox.Show("未选中");
            }
            else
            {
                MessageBox.Show("选中");
            }
        
        }

        private void timeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyInputNum( sender,  e);
        }
    }
}

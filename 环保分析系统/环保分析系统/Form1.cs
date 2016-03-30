using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;


namespace 环保分析系统
{
    public partial class FormLogin : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        public FormLogin()
        {   
            logger.Info("进行认证");
            InitializeComponent();
        }
        //重置事件
        private void btnDesc_Click(object sender, EventArgs e)
        {
            txtLoginName.Clear();
            txtPassword.Clear();
            txtLoginName.Focus();
        }
        //登录事件
        private void btnDengLu_Click(object sender, EventArgs e)
        {
            DengLu();
        }
        #region 登录
        private void DengLu()
        {
            if (txtLoginName.Text == "")
            {
                MessageBox.Show("请输入用户名！");
            }

            else if (txtLoginName.Text == "123456")
            {
                if (txtPassword.Text == "admin")
                {
                    logger.Info("认证成功");
                    mainForm main = new mainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            else
            {
                MessageBox.Show("用户名错误");
            }
        }
        #endregion

        //private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    DengLu();

        //    if (e.KeyChar == 13)
        //    {
        //        mainForm main = new mainForm();
        //        main.Show();
        //        this.Hide();
        //    }
        //}

    }
}

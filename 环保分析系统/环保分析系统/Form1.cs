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
            logger.Info("login surface init");
            InitializeComponent();
        }

        //重置事件
        private void btnDesc_Click(object sender, EventArgs e)
        {
            //清除密码和用户名
            clear();
        }
        //==================================================================
        //函数名：  clear
        //作者：    dhj
        //日期：    2016-03-30
        //功能：    清除TEXTBOX的密码和用户名
        //输入参数：
        //返回值：  类型（void)
        //修改记录：
        //==================================================================
        private void clear()
        {
            logger.Info("Clear password and username");
            this.txtLoginName.Clear();
            this.txtPassword.Clear();
            this.txtLoginName.Focus();
        }
        //登录事件
        private void btnDengLu_Click(object sender, EventArgs e)
        {
            string username = this.txtLoginName.Text;
            string password = this.txtPassword.Text;

            //进行密码认证
            bool isloginsuccess = loginService(ref username, ref password);

            //认证成功 打开EPS 窗口
            if (true == isloginsuccess)
            {
                mainForm main = new mainForm();
                main.Show();
                this.Hide();
            }

        }

        #region 登录
        //==================================================================
        //函数名：  LoginService
        //作者：    rui
        //日期：    2016-03-30
        //功能：    检查用户名和密码
        //输入参数：
        //返回值：  类型（bool)
        //          认证成功返回ture，否则返回false            
        //修改记录：
        //==================================================================
        private bool loginService(ref string username, ref string password)
        {
            const string _username = "123456";
            const string _password = "admin";

            //判断用户名是否为空
            if ("" == username)
            {
                MessageBox.Show("请输入用户名！");
                return false;
            }
            else if (_username == username && _password == password)
            {       //判断用户名和密码是否正确
                logger.Info("认证成功");
                return true;
            }
            else
            {   //用户名和密码错误处理
                if (logger.IsDebugEnabled)
                {
                    logger.Debug("your input username:" + username + "password:" + password);
                }
                MessageBox.Show("用户名或密码错误");
                clear();
                return false;
            }
        }
        #endregion

        //private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        mainForm main = new mainForm();
        //        main.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

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
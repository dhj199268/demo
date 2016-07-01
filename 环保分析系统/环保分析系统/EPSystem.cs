using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using 环保分析系统.Entity;
using 环保分析系统.UI.ChildWindow;

//用于初始化log 配置文件，必须加入
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace 环保分析系统
{
    public partial class mainForm : Form
    {
        //声明一logger 变量 ，用于这个类的logger 分布，typeof()中用这个类的类命
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(mainForm));
        public mainForm()
        {
            InitializeComponent();
        }

        private void 计算器ToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            //部署logger
            logger.Info("响应计算器按钮");
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = "calc.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        int i = 0;
        SaveShowDataMethod model = new SaveShowDataMethod();
        private void openAimFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls|Excel文件|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    model.SaveDataInDataSet(open.FileName);
                    txtName.Text = model.MyDataSet.Tables[0].TableName;
                    dataGridViewOne.DataSource = model.MyDataSet.Tables[0];
                }
               catch
                {
                    MessageBox.Show("检查文件格式是否正确！");
                }
            }
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)//显示北京时间
        {
            labTime.Text = System.DateTime.Now.ToString();
        }
        private void SaveAimFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogOne = new SaveFileDialog();
            saveFileDialogOne.Title = "保存的excel文件";
            saveFileDialogOne.InitialDirectory = "c:\\";
            saveFileDialogOne.Filter = "Excel文件(*.xls)|*.xls|Excel文件|*.xlsx";
            saveFileDialogOne.ShowDialog();
            if (saveFileDialogOne.FileName == null)
            {
                MessageBox.Show("文件名不能为空!");

            }
            string path = saveFileDialogOne.FileName;
            DataTable dt = model.GetDataSetFromDataGridView(dataGridViewOne);
            model.ExportExcel(dt, path);
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnRight.Enabled = true;
            try
            {
                if (i > 0)
                {
                    i--;
                    txtName.Text = model.MyDataSet.Tables[i].TableName;
                    dataGridViewOne.DataSource = model.MyDataSet.Tables[i];
                }
                else
                {
                    btnLeft.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("请选择一张表！");
            }
            
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true;
            try
            {
                if (i < model.MyDataSet.Tables.Count - 1)
                {
                    i++;
                    txtName.Text = model.MyDataSet.Tables[i].TableName;
                    dataGridViewOne.DataSource = model.MyDataSet.Tables[i];
                }
                else
                {
                    btnRight.Enabled = false;
                }      
            }
            catch 
            {
               MessageBox.Show("请选择一张表！");
            }    
        }
        //增加行号
        private void dataGridViewOne_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridViewOne.RowHeadersWidth, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGridViewOne.RowHeadersDefaultCellStyle.Font, rectangle, dataGridViewOne.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //double[] data = model.GetDataText(dataGridViewOne, "企业名称", 4, 9);
            //double[] X1 = { 69.23, 114.95, 24.58, 35.68, 56.34, 32.57, 45.68, 67.89, 48.67, 34.45 };
            //double[] X2 = { 1, 0, 0, 1, 0 };
            //DrawDisperse formOne = new DrawDisperse(X1, X2);
            //formOne.Show();
            float[] X1 = new float[]{ 69.23F, 114.95F, 24.58f, 35.68F, 56.34f, 32.57F, 45.68f, 67.89f, 48.67f, 34.45F };
            float[] X2 = { 49.23f, 74.95f, 14.58f, 15.68f, 36.34f, 15.57f, 35.68f, 57.89f, 38.67f, 14.45f };
            DrawLine formTwo = new DrawLine(X1, X2);
            formTwo.Show();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.IO;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using excelApp = Microsoft.Office.Interop.Excel;
using System.Threading;
using 环保分析系统.Entity;

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
        private void openAimFile_Click(object sender, EventArgs e)
        {
            //点击弹出对话框
            OpenFileDialog ofd = new OpenFileDialog();
            //设置对话框的标题
            ofd.Title = "打开";
            //设置对话框可以多选
            //ofd.Multiselect = true;
            //设置对话框的初始目录
            ofd.InitialDirectory = @"C:\Users\rainn\Desktop";
            //设置对话框的文件类型
            ofd.Filter = "Excel文件|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //打开excel文件
                System.Diagnostics.Process.Start(ofd.FileName);
            }
        }//打开本地的excel文件查看
        private void dataView_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls";

            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                //根据路径打开一个Excel文件并将数据填充到DataSet中
                string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
                OleDbConnection myConn = new OleDbConnection(strCon);
                try
                {
                    string tableName = comboBoxOne.SelectedItem.ToString();
                   // tableName = tableName.Replace("_", "");
                    string strCom = "SELECT * FROM [" + tableName + "$]";
                    myConn.Open();
                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strCom, myConn);
                    DataSet myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "[" + tableName + "$]");
                    myConn.Close();
                    OleDbCommandBuilder odcb = new OleDbCommandBuilder(myDataAdapter);
                    //odcb.QuotePrefix = "["; //用于解决INSERT INTO 语句的语法错误
                    //odcb.QuoteSuffix = "]";
                    //myDataAdapter.Update(myDataSet, "[" + tableName + "$]"); //更新数据集对应的表
                    dataGridViewOne.DataSource = myDataSet.Tables[0].DefaultView; //显示到datagridview
                }
                catch
                {
                    MessageBox.Show("错误提示：请选择一张表！");
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
            saveFileDialogOne.Title = "保存的excel文件";
            saveFileDialogOne.InitialDirectory = "c:\\";
            saveFileDialogOne.Filter = "Excel97-2003 (*.xls)|*.xls|All Files (*.*)|*.*";
            saveFileDialogOne.ShowDialog();
            if (saveFileDialogOne.FileName == "" || saveFileDialogOne.FileName == null)
            {
                MessageBox.Show("文件名不能为空!");
                return;
            }
            string path = saveFileDialogOne.FileName;
            DataSet ds = GetDataSetFromDataGridView(dataGridViewOne);
            ExportExcel(ds, path);
        }
        public static DataSet GetDataSetFromDataGridView(DataGridView ucgrd)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            for (int j = 0; j < ucgrd.Columns.Count; j++)
            {
                dt.Columns.Add(ucgrd.Columns[j].HeaderCell.Value.ToString());
            }

            for (int j = 0; j < ucgrd.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < ucgrd.Columns.Count; i++)
                {
                    if (ucgrd.Rows[j].Cells[i].Value != null)
                    {
                        dr[i] = ucgrd.Rows[j].Cells[i].Value.ToString();
                    }
                    else
                    {
                        dr[i] = "";
                    }
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);

            return ds;
        }//将datagridview中的数据导入到临时数据库dataset中
        public void ExportExcel(DataSet ds, string path)  //以DataSet- 导出Excel文件   
        {
            try
            {
                long totalCount = ds.Tables[0].Rows.Count;
                lblTip.Text = "共有" + totalCount + "条数据。";
                Thread.Sleep(1000);
                long rowRead = 0;
                float percent = 0;

                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                {
                    sb.Append(ds.Tables[0].Columns[k].ColumnName.ToString() + "\t");
                }
                sb.Append(Environment.NewLine);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                    Pbar.Maximum = (int)totalCount;
                    Pbar.Value = (int)rowRead;
                    lblTip.Text = "正在写入[" + percent.ToString("0.00") + "%]...的数据";
                    System.Windows.Forms.Application.DoEvents();

                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        sb.Append(ds.Tables[0].Rows[i][j].ToString() + "\t");
                    }
                    sb.Append(Environment.NewLine);
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                MessageBox.Show("已经生成指定Excel文件!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string[] GetSheetsName(string pExcelAddress)
        {
            try
            {
                string[] vSheetsName;
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=\"Excel 12.0\";Data Source=" + pExcelAddress))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    vSheetsName = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vSheetsName[i] = dt.Rows[i][2].ToString().Replace("$", "");
                    }
                    return vSheetsName;
                }
            }
            catch 
            {
                return null;
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            comboBoxOne.Items.Clear();
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                string[] comboBoxSelect = GetSheetsName(fileName);
                if (comboBoxSelect != null)
                {
                    comboBoxOne.Items.AddRange(comboBoxSelect);
                }
                else
                {
                    MessageBox.Show("文件被加密，无法读取！");
                }
            }
        }//选择工作表         
    }
}

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
            SaveShowDataMethod model = new SaveShowDataMethod();
            model.OpenExcelMethod();
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
        //选择excel文件
        int i = 0;
        SaveShowDataMethod model = new SaveShowDataMethod();
        private void btnSelectExcel_Click(object sender, EventArgs e)
        {
            string fileName = model.OpenExcelShowDGVMethod();
            IsClickShowData(fileName, 0);
        }
        private void IsClickShowData(string fileName, int i)
        {
            string[] sheetsName = model.GetSheetsName(fileName);
            string tableName = sheetsName[i];
            txtName.Text = tableName;
            string strCom = "SELECT * FROM [" + tableName + "$]";
            dataGridViewOne.DataSource = model.ShowDataMethod(fileName,strCom); //显示到datagridview
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnRight.Enabled = true;
            if (i > 0)
            {
                i--;
                string fileName = model.fileName;
                IsClickShowData(fileName, i);
            }
            else
            {
                btnLeft.Enabled = false;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true;
            if (i < model.GetSheetsName(model.fileName).Length - 1)
            {
                i++;
                string fileName = model.fileName;
                IsClickShowData(fileName, i);
            }
            else
            {
                btnRight.Enabled = false;
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
    }
}

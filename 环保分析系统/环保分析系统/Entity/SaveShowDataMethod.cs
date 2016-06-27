using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 环保分析系统.Entity
{
    public interface ISaveShowData
    {
        void OpenExcelMethod();
        string OpenExcelShowDGVMethod();
        DataSet ShowDataMethod(string fileName, string strCom);
        string[] GetSheetsName(string fileName);
        //void SaveDataMethod();
    };
    public class SaveShowDataMethod
    {
        //声明一个属性用来保存打开excel文件的名称
        public string fileName
        {
            get;
            set;
        }
        //打开本地的excel文件查看
        public void OpenExcelMethod()
        {
            //点击弹出对话框
            OpenFileDialog open = new OpenFileDialog();
            //设置对话框的标题
            open.Title = "打开";
            //设置对话框可以多选
            //ofd.Multiselect = true;
            //设置对话框的初始目录
            open.InitialDirectory = @"C:\Users\rainn\Desktop";
            //设置对话框的文件类型
            open.Filter = "Excel文件|*.xls|Excel文件|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //打开excel文件
                System.Diagnostics.Process.Start(open.FileName);
                fileName = open.FileName;
            }
        }
        //打开excel文件在控件datagridview显示
        public string OpenExcelShowDGVMethod()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls|Excel文件|*.xlsx";

            if (open.ShowDialog() == DialogResult.OK)
            {
                this.fileName = open.FileName;
            }
            return this.fileName;
        }
        public DataTable ShowDataMethod(string fileName, string strCom)
        {
            DataTable myDataTable = new DataTable();
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + @fileName + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
            using (OleDbConnection myConn = new OleDbConnection(constr))
            {
                try
                {
                    myConn.Open();
                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strCom, myConn);
                    myDataAdapter.Fill(myDataTable);
                    return myDataTable;
                }
                catch (Exception err)
                {
                    MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
        }
        //获取excel的工作表名
        public string[] GetSheetsName(string fileName)
        {
            try
            {
                string[] sheetsName;
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=\"Excel 12.0\";Data Source=" + fileName))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetsName = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sheetsName[i] = dt.Rows[i][2].ToString().Replace("$", "");
                    }
                   // 读取的数据不是顺序排列，这里将字符串重新排列
                    for (int i = 0; i < sheetsName.Length; i++)
                    {
                        for (int j = i + 1; j < sheetsName.Length; j++)
                        {
                            if (sheetsName[i].Length > sheetsName[j].Length)
                            {
                                string temp = sheetsName[i];
                                sheetsName[i] = sheetsName[j];
                                sheetsName[j] = temp;
                            }
                        }
                    }
                    return sheetsName;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}

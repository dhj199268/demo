using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 环保分析系统.Entity
{
    public interface ISaveShowData
    {
        void SaveDataInDataSet(string fileName);
        void GetDataName(DataGridView dgv);
        void ShowDataMethod(string fileName);
        DataTable GetDataSetFromDataGridView(DataGridView ucgrd);
        void ExportExcel(DataTable dt, string path);
    };
    public class SaveShowDataMethod
    {
        //声明一个属性用来保存打开excel文件的名称
        public DataSet MyDataSet
        {
            get;
            set;
        }
        public void SaveDataInDataSet(string fileName)
        {
            if (fileName != null)
            {
                MyDataSet = new DataSet();
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + @fileName + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
                try
                {
                    string[] sheetsName;
                    using (OleDbConnection conn = new OleDbConnection(constr))
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
                        for (int j = 0; j < sheetsName.Length; j++)
                        {
                            DataTable myDataTable = new DataTable();
                            string tableName = sheetsName[j];
                            string strCom = "SELECT * FROM [" + tableName + "$]";
                            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strCom, conn);
                            myDataAdapter.Fill(myDataTable);
                            MyDataSet.Tables.Add(myDataTable);
                            this.MyDataSet = MyDataSet;
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public string[] GetDataName(DataGridView dgv)
        {
            string[] dataName = new string[dgv.Rows[0].Cells.Count];
            for (int i = 0; i < dgv.Rows[0].Cells.Count; i++)
            {
                dataName[i] = dgv.Columns[i].HeaderText;
            }
            return dataName;
        }
        public double[] GetDataText(DataGridView dgv, string comulnName, int startRow, int endRow)
        {
            try
            {
                double[] dataText = new double[endRow - startRow + 1];
                for (int i = startRow, j = 0; i <= endRow; i++, j++)
                {
                    dataText[j] = Convert.ToDouble(dgv.Rows[i - 1].Cells[comulnName].Value.ToString());
                }
                return dataText;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示信息",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
        //将datagridview中的数据导入到临时数据库dataTable中
        public DataTable GetDataSetFromDataGridView(DataGridView ucgrd)
        {
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
            return dt;
        }
        public void ExportExcel(DataTable dt, string path)  //以DataSet- 导出Excel文件   
        {
            try
            {
                long totalCount = dt.Rows.Count;
                Thread.Sleep(1000);
                long rowRead = 0;
                float percent = 0;

                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    sb.Append(dt.Columns[k].ColumnName.ToString() + "\t");
                }
                sb.Append(Environment.NewLine);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                    // LblTip = "正在写入[" + percent.ToString("0.00") + "%]...的数据";
                    System.Windows.Forms.Application.DoEvents();

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sb.Append(dt.Rows[i][j].ToString() + "\t");
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
        }
}

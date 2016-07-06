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
using 环保分析系统.except;

namespace 环保分析系统.Entity
{
    public interface ISaveShowData
    {
        void SaveDataInDataSet(string fileName);
        void GetDataName(DataGridView dgv);
        void ShowDataMethod(string fileName);
        DataTable GetDataSetFromDataGridView(DataGridView ucgrd);
        void ExportExcel(DataTable dt, string path);
        int GetRowNumber(DataGridView dgv);
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
        public int GetRowNumber(DataGridView dgv)
        {
            int num = 0;
            num = dgv.RowCount;
            return num;
        }
        public float[] GetDataOneText(DataGridView dgv, int startRow, int endRow, params string[] comulnName)
        {
            if (comulnName.Length == 1)
            {
                float[] dataText = new float[endRow - startRow + 1];
                for (int i = startRow, j = 0; i <= endRow; i++, j++)
                {
                    dataText[j] = (float)Convert.ToDouble(dgv.Rows[i - 1].Cells[comulnName[0]].Value.ToString());
                }
                return dataText;
            }
            else
            {
                float[] dataText = new float[2 * (endRow - startRow + 1)];
                for (int i = startRow, j = 0; i <= endRow; i++, j++)
                {
                    dataText[j] = (float)Convert.ToDouble(dgv.Rows[i - 1].Cells[comulnName[0]].Value.ToString());
                }
                for (int i = startRow, j = endRow - startRow + 1; i <= endRow; i++, j++)
                {
                    dataText[j] = (float)Convert.ToDouble(dgv.Rows[i - 1].Cells[comulnName[1]].Value.ToString());
                }
                return dataText;
            }
        }
        //将datagridview中的数据导入到临时数据库dataTable中
        /*  public DataTable GetDataSetFromDataGridView(DataGridView ucgrd)
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
          }*/
        public void ExportExcel(DataTable dt, string strFileName)  //以DataSet- 导出Excel文件   
        {
            int rowNum = dt.Rows.Count;
            int columnNum = dt.Columns.Count;
            int rowIndex = 0;
            int columnIndex = 0;

            if (dt == null || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        xlApp.Cells[rowIndex, columnIndex] = dt.Rows[i][j].ToString();
                    }
                }
                xlBook.SaveCopyAs(strFileName);
                xlApp = null;
                xlBook = null;
            }
        }
    }
}


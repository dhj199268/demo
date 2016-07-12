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
        public void ExportExcel(DataTable dt, string strFileName)  //以DataSet- 导出Excel文件   
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            if (app == null)
            {
                throw new Exception("new Microsoft.Office.Interop.Excel.Application() returns null");
            }
            else
            {
               Microsoft.Office.Interop.Excel.Workbooks xlBooks = app.Workbooks;
               Microsoft.Office.Interop.Excel.Workbook xlBook = xlBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
               Microsoft.Office.Interop.Excel.Worksheet xlSheet = xlBook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;
                int n = 1;
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    xlSheet.Cells[1, n++] = col.ColumnName;
                }
                // int row = 2;
                int row = 0;
                object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

                foreach (System.Data.DataRow r in dt.Rows)
                {
                    //int column = 1;
                    int column = 0;
                    foreach (System.Data.DataColumn col in dt.Columns)
                    {
                        //xlSheet.Cells[row, column] = data.Rows[row-2].ItemArray[column - 1];
                        arr[row, column] = dt.Rows[row][column];
                        column++;
                    }
                    row++;
                }
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[2, 1];
                range = range.get_Resize(dt.Rows.Count, dt.Columns.Count);
                range.Value2 = arr;
                object missing = System.Reflection.Missing.Value;
                xlSheet.SaveAs(strFileName, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing);
            }
        }
    }
}

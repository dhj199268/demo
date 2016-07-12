using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 环保分析系统.UI.ChildWindow
{
    public partial class RankDrawLine : Form
    {
        float[] Y1;
        float[] Y2;
        public RankDrawLine(float[] X1, float[] X2)
        {
            InitializeComponent();
            Y1 = X1;
            Y2 = X2;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogOne = new SaveFileDialog();
            saveFileDialogOne.Title = "保存的图片文件";
            saveFileDialogOne.InitialDirectory = "c:\\";
            saveFileDialogOne.Filter = "图片|*.jpg";
            saveFileDialogOne.ShowDialog();
            try
            {
                if (saveFileDialogOne.FileName == null)
                {
                    MessageBox.Show("路径不能为空!");
                }
                else
                {
                    this.chartTwo.SaveImage(saveFileDialogOne.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示信息",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DrawLine_Load_1(object sender, EventArgs e)
        {
            this.chartTwo.Series[0].ChartType = SeriesChartType.Line;
            this.chartTwo.Series[1].ChartType = SeriesChartType.Line;
            this.chartTwo.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
           // this.chartTwo.ChartAreas[0].AxisY.Interval = 1;
            this.chartTwo.Series[0].Points.DataBindY(Y1);
            this.chartTwo.Series[0].Color = System.Drawing.Color.Red;
            this.chartTwo.Series[1].Points.DataBindY(Y2);
            this.chartTwo.Series[1].Color = System.Drawing.Color.Blue;
        }
    }
} 

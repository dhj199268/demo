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

namespace 环保分析系统.UI
{
    public partial class PMDrawLine : Form
    {
        float[] Y1;
        float[] Y2;
        public PMDrawLine(float[] X1, float[] X2,string Name)
        {
            InitializeComponent();
            Y1 = X1;
            Y2 = X2;
            this.chartFour.Titles.Add(Name);
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                    this.chartFour.SaveImage(saveFileDialogOne.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示信息",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PMDrawLine_Load(object sender, EventArgs e)
        {
            this.chartFour.Series[0].ChartType = SeriesChartType.Line;
            this.chartFour.Series[1].ChartType = SeriesChartType.Line;
            this.chartFour.ChartAreas[0].AxisY.LabelStyle.Format = "N2";
            this.chartFour.ChartAreas[0].AxisX.Title = "点数";
            this.chartFour.ChartAreas[0].AxisY.Title = "浓度";
            // this.chartFour.Series[1].ToolTip = "#VAL\r\n采集时间:#AXISLABEL";
            this.chartFour.Series[0].ToolTip = "#VALY";
            this.chartFour.Series[1].ToolTip = "#VALY";

            this.chartFour.Series[0].Points.DataBindY(Y1);
            this.chartFour.Series[0].Color = System.Drawing.Color.Red;
            this.chartFour.Series[1].Points.DataBindY(Y2);
            this.chartFour.Series[1].Color = System.Drawing.Color.Blue;


            this.chartFour.ChartAreas[0].CursorX.IsUserEnabled = true;
            this.chartFour.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            this.chartFour.ChartAreas[0].CursorX.Interval = 0;
            this.chartFour.ChartAreas[0].CursorX.IntervalOffset = 0;
            this.chartFour.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Minutes;
            this.chartFour.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            this.chartFour.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

        }
    }
}

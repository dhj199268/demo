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
    public partial class DrawDisperse : Form
    {
        float[] Y1;
        float[] Y2;
        public DrawDisperse(float[] X1, float[] X2)
        {
            InitializeComponent();
            Y1 = X1;
            Y2 = X2;
        }

        private void DrawDisperse_Load(object sender, EventArgs e)
        {
            this.chartOne.Series[0].ChartType = SeriesChartType.Point;
            this.chartOne.Series[1].ChartType = SeriesChartType.Point;
            this.chartOne.ChartAreas[0].AxisX.LabelStyle.Format = "N2";
            this.chartOne.ChartAreas[0].AxisY.LabelStyle.Format = "N2";
            for (int i = 0; i < Y2.Length; i++)
            {
                if (Y2[i] == 0)
                {
                    this.chartOne.Series[0].Points.AddXY(Y1[i], Y1[i+Y2.Length]);
                    this.chartOne.Series[0].MarkerColor = System.Drawing.Color.Red; 
                }
                else
                {
                    this.chartOne.Series[1].Points.AddXY(Y1[i], Y1[i + Y2.Length]);
                    this.chartOne.Series[1].MarkerColor = System.Drawing.Color.Blue;
                }
            }
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
                    this.chartOne.SaveImage(saveFileDialogOne.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示信息",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

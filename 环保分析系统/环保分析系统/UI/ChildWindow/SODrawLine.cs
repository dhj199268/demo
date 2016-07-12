using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 环保分析系统.UI
{
    public partial class SODrawLine : Form
    {
        public SODrawLine()
        {
            InitializeComponent();
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
                    this.chartThree.SaveImage(saveFileDialogOne.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
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

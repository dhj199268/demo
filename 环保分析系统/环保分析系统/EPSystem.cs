using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Data.OleDb;
using 环保分析系统.Entity;
using 环保分析系统.UI.ChildWindow;
using 环保分析系统.core.ML;
using 环保分析系统.core.Until;
using 环保分析系统.except;

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
        int i = 0;

        private void openAimFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls|Excel文件|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    model = new SaveShowDataMethod();
                    model.SaveDataInDataSet(open.FileName);
                    if (model.MyDataSet.Tables.Count != 0)
                    {
                        txtName.Text = model.MyDataSet.Tables[0].TableName;
                        dataGridViewOne.DataSource = model.MyDataSet.Tables[0];
                    }
                }
                catch
                {
                    MessageBox.Show("文件被加密,或工作表命名不符合规范！");
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
            SaveFileDialog saveFileDialogOne = new SaveFileDialog();
            saveFileDialogOne.Title = "保存的excel文件";
            saveFileDialogOne.InitialDirectory = "c:\\";
            saveFileDialogOne.Filter = "Excel文件(*.xls)|*.xls|Excel文件|*.xlsx";
            saveFileDialogOne.ShowDialog();
            string path = saveFileDialogOne.FileName;
            if (path != null)
            {
                try
                {
                    DataTable dt = model.MyDataSet.Tables[0];
                    model.ExportExcel(dt,path);
                    MessageBox.Show("已经生成指定Excel文件!");
                }
                catch
                {
                    MessageBox.Show("请导入Excel文件！");
                } 
            }
           
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnRight.Enabled = true;
            try
            {
                if (i > 0)
                {
                    i--;
                    txtName.Text = model.MyDataSet.Tables[i].TableName;
                    dataGridViewOne.DataSource = model.MyDataSet.Tables[i];
                }
                else
                {
                    btnLeft.Enabled = false;
                }
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("请选择一张表");
            }

        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true;
            try
            {
                if (i < model.MyDataSet.Tables.Count - 1)
                {
                    i++;
                    txtName.Text = model.MyDataSet.Tables[i].TableName;
                    dataGridViewOne.DataSource = model.MyDataSet.Tables[i];
                }
                else
                {
                    btnRight.Enabled = false;
                }
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("请选择一张表");
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

        private void pM25预测ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string[] varstr = this.model.GetDataName(dataGridViewOne);
                RandomForestForm rff = new RandomForestForm(varstr);
                rff.ShowDialog();

                if (rff.DialogResult == DialogResult.OK)
                {
                    logger.Info("Get Parm");
                    int[] train_rows = rff.GetTrainRowNum();
                    string[] col = rff.GetIndvFeature();
                    float[] traindata = model.GetDataOneText(dataGridViewOne, train_rows[0], train_rows[1], col);

                    int ntree = rff.GetTreeNum();
                    int max_depth = rff.GetTreeDepth();
                    bool isproun = rff.IsPrun();
                    int segtime = rff.GetTimeLen();
                    int[] predice_rows = rff.GetPredictRowNum();
                    int start = predice_rows[0] - segtime + 1;

                    if (start < 1)
                    {
                        throw new OutOfRangeException("预测行号设置错误");
                    }

                    RandomForest rfmodel = new RandomForest(ntree, segtime, max_depth, max_depth, isproun);
                    rfmodel.Train(ref traindata);
                    float[] showdata = model.GetDataOneText(dataGridViewOne, predice_rows[0], predice_rows[1], col);
                    float[] predictdata = model.GetDataOneText(dataGridViewOne, start, predice_rows[1], col);
                    logger.Debug(loggerUntil.printMatToLogger("predcit data :", ref showdata));
                    float[] result = rfmodel.Predict(ref predictdata);
                    logger.Debug(loggerUntil.printMatToLogger("reuslt data :", ref result));

                    logger.Info("Show Image");
                    DrawLine resultform = new DrawLine(showdata, result);
                    resultform.Show();
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("请导入excel表");
            }
            catch (OutOfRangeException ooe)
            {
                MessageBox.Show(ooe.Message);
            }
        }

        private void sO2预测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] varstr = this.model.GetDataName(dataGridViewOne);
                WaveANNForm waf = new WaveANNForm(varstr);
                waf.ShowDialog();

                if (waf.DialogResult == DialogResult.OK)
                {
                    logger.Info("Get Parm");
                    int[] train_rows = waf.GetTrainRowNum();
                    string[] col = waf.GetIndvFeature();
                    float[] traindata = model.GetDataOneText(dataGridViewOne, train_rows[0], train_rows[1], col);

                    int hidelayer = waf.GetHideLayer();
                    int iter = waf.GetIter();
                    int segtime = waf.GetTimeLen();
                    int[] predice_rows = waf.GetPredictRowNum();

                    int start = predice_rows[0] - segtime + 1;
                    if (start < 1)
                    {
                        throw new OutOfRangeException("预测行号设置错误"); ;
                    }


                    WavesANN wafmodel = new WavesANN(hidelayer, segtime, iter);
                    wafmodel.Train(ref traindata);
                    float[] showdata = model.GetDataOneText(dataGridViewOne, predice_rows[0], predice_rows[1], col);
                    float[] predictdata = model.GetDataOneText(dataGridViewOne, start, predice_rows[1], col);
                    logger.Debug(loggerUntil.printMatToLogger("predcit data :", ref showdata));
                    float[] result = wafmodel.Predict(ref predictdata);
                    logger.Debug(loggerUntil.printMatToLogger("reuslt data :", ref result));

                    logger.Info("Show Image");
                    DrawLine resultform = new DrawLine(showdata, result);
                    resultform.Show();

                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("请导入excel表");
            }
            catch (OutOfRangeException ooe)
            {
                MessageBox.Show(ooe.Message);
            }
        }

        private void 异常分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] varstr = this.model.GetDataName(dataGridViewOne);
                KmeansForm kmf = new KmeansForm(varstr);
                kmf.ShowDialog();

                if (kmf.DialogResult == DialogResult.OK)
                {
                    logger.Info("Get Parm");
                    int[] train_rows = kmf.GetTrainRowNum();
                    string[] col = kmf.GetIndvFeature();
                    float[] traindata = model.GetDataOneText(dataGridViewOne, train_rows[0], train_rows[1], col);

                    int classnum = kmf.GetClassNum();
                    int iter = kmf.GetIter();
                    int segtime = col.Length;
                    Kmeans kmodel = new Kmeans(classnum, iter, segtime);
                    kmodel.Train(ref traindata);

                    int[] predice_rows = kmf.GetPredictRowNum();
                    //float[] showdata = model.GetDataOneText(dataGridViewOne, predice_rows[0], predice_rows[1], col);
                    float[] predictdata = model.GetDataOneText(dataGridViewOne, predice_rows[0], predice_rows[1], col);
                    logger.Debug(loggerUntil.printMatToLogger("predcit data :", ref predictdata));
                    float[] result = kmodel.Predict(ref predictdata);
                    logger.Debug(loggerUntil.printMatToLogger("reuslt data :", ref result));

                    logger.Info("Show Image");
                    DrawDisperse resultform = new DrawDisperse(predictdata, result);
                    resultform.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("请导入excel表");
            }
        }

        private void 等级预测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] varstr = this.model.GetDataName(dataGridViewOne);
                HMMForm hmmf = new HMMForm(varstr);
                hmmf.ShowDialog();

                if (hmmf.DialogResult == DialogResult.OK)
                {
                    logger.Info("Get Parm");
                    int[] train_rows = hmmf.GetTrainRowNum();
                    string[] col = hmmf.GetIndvFeature();


                    int segtime = hmmf.GetTimeLen();
                    int[] predice_rows = hmmf.GetPredictRowNum();

                    int start = predice_rows[0] - segtime + 1;
                    if (start < 1)
                    {
                        throw new OutOfRangeException("预测行号设置错误"); ;
                    }


                    HMM hmmmodel = new HMM();
                    float[] train_data = model.GetDataOneText(dataGridViewOne, train_rows[0], train_rows[1], col);
                    float[] traindata;
                    hmmf.SetLevel(ref train_data, out traindata);

                    hmmmodel.Train(ref traindata);

                    float[] show_data = model.GetDataOneText(dataGridViewOne, predice_rows[0], predice_rows[1], col);
                    float[] showdata;
                    hmmf.SetLevel(ref show_data, out showdata);
                    for (int i = 0; i < showdata.Length; i++)
                    {
                        showdata[i] += 1;
                    }
                    float[] predict_data = model.GetDataOneText(dataGridViewOne, start, predice_rows[1], col);
                    float[] predictdata;
                    hmmf.SetLevel(ref predict_data, out predictdata);

                    logger.Debug(loggerUntil.printMatToLogger("predcit data :", ref showdata));
                    float[] result = hmmmodel.Predict(ref predictdata);
                    logger.Debug(loggerUntil.printMatToLogger("reuslt data :", ref result));

                    logger.Info("Show Image");
                    DrawLine resultform = new DrawLine(showdata, result);
                    resultform.Show();
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("请导入excel表");
            }
            catch (OutOfRangeException ooe)
            {
                MessageBox.Show(ooe.Message);
            }
        }

    }
}

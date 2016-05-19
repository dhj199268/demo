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
using 环保分析系统.core.ML;
using 环保分析系统.core.ML.Impl;
using log4net;

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

        private void 随机深林ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomForest test = new RandomForest(1000,6);
            
            //test.SegTime = 5;
           float[] data ={1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,1,2,3,4,5,4,6,6
                       };
            //float[] data = { 1,2,3,4,5,6,1,3};
            test.Train(data);
            //Console.ReadLine();
            float[] testdata = { 1, 2, 3, 4, 5, 4 };
            float[] result;
            result = test.Predict(testdata);
            logger.Info("result:" + result[0]);
            test.Clear(); 
        }

        private void 小波神经网络ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] data ={1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,
                       1,2,3,4,5,4,6,6,1,2,3,4,5,4,6,6
                       };

            WavesANN test = new WavesANN(15, 6);
            test.Train(data);
            float[] testdata = { 1, 2, 3, 4, 5 ,4};
            float[] result;
            result = test.Predict(testdata);
            logger.Info("result:" + result[0]);
            test.Clear(); 

        }
    }
}

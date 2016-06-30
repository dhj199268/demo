using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.MlEnum;
using System.Drawing;
using 环保分析系统.core.Until;

namespace 环保分析系统.core.ML
{
    class HMM : AbstractMLAlg
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HMM));

        private int numstats;
        private Matrix<float> transferMat;

        public HMM(int stats=4)
            :base(stats,false)
        {
            if (stats==2)
            {
                throw new Exception("num of stats can not set one");
            }
            this.numstats = stats;
        }
        public override void Clear()
        {
            this.transferMat.Dispose();
            this.traindata.Dispose();
        }
    
        protected override void beforeTrain()
        {
            if (logger.IsDebugEnabled)
            {
                string tmp;
                tmp = loggerUntil.printMatToLogger("prinf count mat :", ref traindata);
                logger.Debug(tmp);
            }
        }

        public override bool Train(ref float[] data, int flags = 0)
        {
            logger.Info("train processing");
            int row;
            int col;
            traindata = new Matrix<float>(numstats, numstats);

            for (int i = 0; i < data.Length-1; ++i)
            {
                row = (int)data[i];
                col = (int)data[i + 1];
                traindata[row, col] += 1;
            }

            beforeTrain();
            train();

            return true;

        }
        protected override void beforePredict(ref Matrix<float> data)
        {
            if (logger.IsDebugEnabled)
            {
                string tmp;
                tmp=loggerUntil.printMatToLogger("prinf predict data  mat :", ref data);
                logger.Debug(tmp);
            }
        }
      
        protected override void train()
        {
            Matrix<float> tmprow;
            float tmpsum;
            transferMat = new Matrix<float>(numstats, numstats);

            for (int i = 0; i < traindata.Height; i++)
            {
                tmprow = traindata.GetRow(i);
                tmpsum = (float)tmprow.Sum;

                for (int j = 0; j < traindata.Width; j++)
                {

                    transferMat[i, j] = traindata[i, j] / tmpsum;
                }
                
            }

        }
        protected override void predict(ref Matrix<float> data, out float[] result)
        {
            Matrix<float> probmat;
            Matrix<float>[] matlist = new Matrix<float>[data.Height];
            int probindex;
            result = new float[data.Height];
            probmat = this.transferMat.Clone();


            //cal sum prob
            for (int col = data.Width - 1; col >= 0; --col)
            {
               

                for (int row = 0; row < data.Height; row++)
                {
                    probindex = (int)data[row, col];

                    if (col==data.Width-1)
                    {
                        matlist[row] = probmat.GetRow(probindex);
                    }
                    else
                    {
                        matlist[row] += probmat.GetRow(probindex);
                    }
                    
                }

                //get prob map(n)
                if (0!=col)
                {
                    probmat *= this.transferMat;

                    if (logger.IsDebugEnabled)
                    {
                        string tmp;
                        tmp = loggerUntil.printMatToLogger("prinf transfer prob mat :", ref probmat);
                        logger.Debug(tmp);

                    }
                }
                
            }

            Point maxlocal;
            Point minlocal;
            double minv = 0;
            double maxv = 0;
            for (int i = 0; i < data.Height; i++)
            {
                matlist[i].MinMax(out minv, out maxv, out minlocal, out maxlocal);
                result[i] = maxlocal.X;

            }
        }

      /*  protected override void beforePredict(ref Matrix<float> data)
        {
            float[,] data2 ={
                           { 0.8936f,0.0993f,0.0071f,0},{0.2895f,0.4474f,0.1842f,0.0789f},
                           {0.1667f,0.2500f,0.2917f,0.2917f},{ 0,0.0313f,0.2813f,0.6875f}
                       };
            this.transferMat = new Matrix<float>(data2);
        }*/
    }
}

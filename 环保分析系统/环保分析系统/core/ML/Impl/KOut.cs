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
using 环保分析系统.core.Until;
using System.Drawing;

namespace 环保分析系统.core.ML
{
    class KOut : Kmeans
    {
        private int threshold;
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(KOut));
        public KOut(int numClass = 2,int threshold=10)
            : base(numClass, 100, 2, 0.001f)
        { 
            this.threshold=threshold;
        }

        protected override void train()
        {
           Matrix<float> tmp;
           float sum;
           int ncol = this.traindata.Width;
           int nrow = this.traindata.Height;
           this.center = new Matrix<float>(1, ncol);
           for (int i = 0; i < ncol; i++)
           {
               tmp = this.traindata.GetCol(i);
               sum = (float)tmp.Sum / nrow;
               this.center[0, i] = sum;

           }
           if (logger.IsDebugEnabled)
           {
               string tmpstr;
               tmpstr = loggerUntil.printMatToLogger("center mat : ", ref this.center);
               logger.Debug(tmpstr);
           }
        }

        protected override void predict(ref Matrix<float> data, out float[] result)
        {
            int ncol = this.center.Width;
            int nrow = data.Height;
            result = new float[nrow];
            Matrix<float> tmp = new Matrix<float>(nrow, 1);
            Matrix<float> distance = new Matrix<float>(nrow, 1);
            
            for (int i = 0; i < ncol; i++)
            {
                
                tmp = this.center[0, i] - data.GetCol(i);
                CvInvoke.Pow(tmp, 2, tmp);
                distance += tmp;
            }


            Point maxlocal;
            Point minlocal;
            double minv = 0;
            double maxv = 0;

            for (int i = 0; i < this.threshold; i++)
            {
                distance.MinMax(out minv, out maxv, out minlocal, out maxlocal);
                int n =maxlocal.Y;
                distance[n, 0] = -1;
                result[n] = 1;
            }

        }
    }
}

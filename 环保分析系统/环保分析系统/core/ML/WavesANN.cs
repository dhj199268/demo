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
    class WavesANN:AbstractMLAlg
    {    
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(WavesANN));

        private static int ZERO = 0;
        //输入层个数,即segTime的个数
        private int outlayer = 1;//输出层结点个数
        private int hidelayer;//隐藏层结点个数

        private float lr1   = 0.01f;//权值
        private float lr2   = 0.001f;//学习率
        private int maxiter = 100;//对大迭代次数
        private double maxv;
        private double minv;

        private Matrix<float> Wij;
        private Matrix<float> Wjk;
        private Matrix<float> b;
        private Matrix<float> a;
       
        protected float morlet(double data) 
        {
            return (float)(Math.Exp(data * data / 2.0 * (-1)) * Math.Cos(1.75 * data));
        }
        protected float d_morlet(double data)
        {
            double exptemp = Math.Exp(data * data / 2.0 * (-1));
            double temp    =1.75*data;

            return (float)(Math.Sin(temp) * exptemp * (-1.75) - data * Math.Cos(temp) * exptemp);
        }

        //==================================================================
        //函数名：  train
        //作者：    dhj
        //日期：    2016-05-17
        //功能：    训练wave ann 
        //输入参数：
        //返回值：  类型（void) 
        //修改记录：
        //==================================================================
        private void train(ref Matrix<float> traindata, ref Matrix<float> label)
        {   
            logger.Info("WavesANN train processing");
            if (traindata.Height != label.Height || traindata.Width != segTime)
            {
                throw new Exception("train data or label data dim  out of range");
            }

            logger.Info("new init");
            MCvScalar mean = new MCvScalar(0);
            MCvScalar std = new MCvScalar(1);

            //net weight init
            Wij = new Matrix<float>(outlayer, hidelayer);  //hide to out
            Wjk = new Matrix<float>(hidelayer, segTime);//input to hide
            a = new Matrix<float>(outlayer, hidelayer);
            b = new Matrix<float>(outlayer, hidelayer);

            //rand init
            Wjk.SetRandNormal(mean, std);
            Wij.SetRandNormal(mean, std);
            a.SetRandNormal(mean, std);
            b.SetRandNormal(mean, std);

            //study weight init
            Matrix<float> d_Wjk = new Matrix<float>(hidelayer, segTime);
            Matrix<float> d_Wij = new Matrix<float>(outlayer, hidelayer);
            Matrix<float> d_a = new Matrix<float>(outlayer, hidelayer);
            Matrix<float> d_b = new Matrix<float>(outlayer, hidelayer);


            //init net
            Matrix<float> net = new Matrix<float>(outlayer, hidelayer);
            Matrix<float> net_ab = new Matrix<float>(outlayer, hidelayer);
            /*Matrix<float>  net;
            Matrix<float> net_ab;*/
            float y = 0;
            
            //init error record
            /*Matrix<float> error = new Matrix<float>(1, maxiter);*/

            //init temp data
            Matrix<float> x;
            float yqw;

            //iter train
            logger.Info("iter train");
            for (int i = 0; i < maxiter; ++i)
            {

                if(logger.IsDebugEnabled)
                {
                    logger.Debug("iter time :"+(i+1));
                }
                
                //train net
                for (int k = 0; k < traindata.Height; ++k)
                {
                        x = traindata.GetRow(k);
                        yqw = label[k, ZERO];
                        y = y + trainPredictOut(ref x, ref yqw,ref  b, ref a,ref net, ref net_ab);
                        x.Dispose();

                       
                        // updata weight
                        float error = yqw-y;
                        float temp;
                        for (int j = 0; j < hidelayer;++j )
                        {

                            //cal d_Wij
                            temp = morlet(net_ab[outlayer, j]);
                            d_Wij[outlayer, j] = d_Wij[outlayer, j] - error * temp;

                            //cal d_Wjk
                            temp = d_morlet(net_ab[ZERO, j]);
                            for (int z = 0; z < segTime; ++z)
                            {
                                d_Wjk[j, z] = d_Wjk[j, z] + error * Wij[outlayer, j];
                                d_Wjk[j, z] = -1 * d_Wjk[j, z] * temp * x[k, ZERO] / a[ZERO, j];
                            }

                            //cal d_b
                            d_b[outlayer, j] += error * Wij[outlayer, j];
                            d_b[outlayer, j] *= temp / a[ZERO, j];

                            //cal d_a
                            d_a[outlayer, j] += error * Wij[outlayer, j];
                            d_a[outlayer, j] *= temp * (net[ZERO, j] - b[ZERO, j]) / b[ZERO, j] / a[ZERO, j];
                        }

                       //updata wight params
                        Wij -= lr1 * d_Wij;
                        Wjk -= lr2 * d_Wjk;
                        b -= lr2 * d_b;
                        a -= lr2 * d_a;

                        //zeros params
                        d_Wjk.SetZero();
                        d_Wij.SetZero();
                        d_a.SetZero();
                        d_b.SetZero();
                        net.SetZero();
                        net_ab.SetZero();
                        y = 0;
                }
              
            
            }

        }
        private float trainPredictOut(ref Matrix<float> x, ref float yqw, ref Matrix<float> b,ref Matrix<float> a, ref Matrix<float> net, ref Matrix<float> net_ab)
        {
            logger.Info("train preidct out net");

            
            float temp;
            float y=0.0f;

            for (int j = 0; j < hidelayer; ++j)
            { 
                for(int k=0;k<segTime;++k)
                {
                    net[0, j] = net[0, j] + Wjk[j, k] * x[k, 0];
                    net_ab[0, j] = (net[0, j] - b[1, j]) / a[0, j];

                }
                temp = morlet(net_ab[1, j]);
                for (int k = 0; k < outlayer; ++k)
                {
                    y = y + Wij[k, j] * temp;
                }
            }
            return y;
        }

        private float predict(ref Matrix<float> predictdata)
        {
            logger.Info("predict processing");
            if (predictdata.Width != segTime || predictdata.Height!=1)
            {
                throw new Exception("error dim about predictdata");
            }

            //init net
            Matrix<float> net = new Matrix<float>(outlayer, hidelayer);
            Matrix<float> net_ab = new Matrix<float>(outlayer, hidelayer);
            
            float y=0.0f;
            float temp;
            //predict
            for (int j = 0; j < hidelayer; ++j)
            {
                for (int k = 0; k < segTime; ++k)
                {
                    net[ZERO, j]+=Wjk[j,k] * predictdata[0,k];
                    net_ab[ZERO, j]+=(net[ZERO, j]-b[ZERO,j])/a[ZERO,j];
                }
                temp = morlet(net_ab[ZERO, j]);

                y += Wij[ZERO, j] * temp;
            
            }
            return y;
        
        }
        public void clear()
        {
            Wjk.Dispose();
            Wij.Dispose();
            a.Dispose();
            b.Dispose();
        }
    }
}

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

        private static int OUTLAYER = 0;
        //输入层个数,即segTime的个数
        private int outlayer = 1;//输出层结点个数
        private int hidelayer;//隐藏层结点个数

        private float lr1   = 0.01f;//权值
        private float lr2   = 0.001f;//学习率
        private int maxiter = 100;//对大迭代次数
        private double intputmaxv;
        private double intputminv;
        private double outputmaxv;
        private double outputrminv;
        //private int segTime;
        private Matrix<float> Wij;
        private Matrix<float> Wjk;
        private Matrix<float> b;
        private Matrix<float> a;


        private WavesANN() { }

        public WavesANN(int hidelayer,int segTime, int iter = 100, float lr1=0.01f, float lr2 = 0.001f)
        {
            this.hidelayer = hidelayer;
            this.segTime = segTime;
            this.maxiter = iter;
            this.lr1 = lr1;
            this.lr2 = lr2;
        
        }
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

            //tmp data
            //Matrix<float> tmp1_Wjk, tmp2_Wjk, tmp1_Wij, tmp2_Wij, tmp1_a, tmp2_a, tmp1_b, tmp2_b;
            //rand init
            Wjk.SetRandNormal(mean, std);
            Wij.SetRandNormal(mean, std);
            a.SetRandNormal(mean, std);
            b.SetRandNormal(mean, std);

            //init tmp
           /* tmp1_Wjk = Wij.Clone(); tmp2_Wjk = tmp1_Wjk.Clone();
            tmp1_Wij = Wij.Clone(); tmp2_Wij = tmp1_Wij.Clone();
            tmp1_a = a.Clone(); tmp2_a = tmp1_a.Clone();
            tmp1_b = b.Clone(); tmp2_b = tmp1_b.Clone();*/

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
                        logger.Debug("train net time :" + (k + 1));
                        x = traindata.GetRow(k);
                        yqw = label[k, OUTLAYER];
                        y =  trainPredictOut(ref x,ref net, ref net_ab);
                        //x.Dispose();

                       
                        // updata weight
                        float error = yqw-y;
                        float temp;
                        logger.Debug("updata weight");
                        for (int j = 0; j < hidelayer;++j )
                        {

                            //cal d_Wij
                            logger.Debug("cal d_Wij");
                            temp = morlet(net_ab[OUTLAYER, j]);
                            d_Wij[OUTLAYER, j] = d_Wij[OUTLAYER, j] - error * temp;

                            //cal d_Wjk
                            logger.Debug("cal d_Wjk");
                            temp = d_morlet(net_ab[OUTLAYER, j]);
                            for (int z = 0; z < segTime; ++z)
                            {
                                d_Wjk[j, z] = d_Wjk[j, z] + error * Wij[OUTLAYER, j];
                                d_Wjk[j, z] = -1 * d_Wjk[j, z] * temp * x[OUTLAYER,z] / a[OUTLAYER, j];
                            }

                            //cal d_b
                            logger.Debug("cal d_b");
                            d_b[OUTLAYER, j] += error * Wij[OUTLAYER, j];
                            d_b[OUTLAYER, j] *= temp / a[OUTLAYER, j];

                            //cal d_a
                            logger.Debug("cal d_a");
                            d_a[OUTLAYER, j] += error * Wij[OUTLAYER, j];
                            d_a[OUTLAYER, j] *= temp * (net[OUTLAYER, j] - b[OUTLAYER, j]) / b[OUTLAYER, j] / a[OUTLAYER, j];
                        }

                       //updata wight params
                        logger.Debug("updata wight params");
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
        private float trainPredictOut(ref Matrix<float> x, ref Matrix<float> net, ref Matrix<float> net_ab)
        {
            logger.Debug("train preidct out net");

            
            float temp;
            float y=0.0f;

            for (int j = 0; j < hidelayer; ++j)
            { 
                for(int k=0;k< segTime;++k)
                {
                    net[OUTLAYER, j] = net[OUTLAYER, j] + Wjk[j, k] * x[OUTLAYER, k];
                    net_ab[OUTLAYER, j] = (net[OUTLAYER, j] - b[OUTLAYER, j]) / a[OUTLAYER, j];

                }
                temp = morlet(net_ab[OUTLAYER, j]);
                for (int k = 0; k < outlayer; ++k)
                {
                    y = y + Wij[k, j] * temp;
                }
            }

            logger.Debug("train preidct out over");
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

            /*float temp;
            //predict
            for (int j = 0; j < hidelayer; ++j)
            {
                for (int k = 0; k < segTime; ++k)
                {
                    net[OUTLAYER, j] += Wjk[j, k] * predictdata[0, k];
                    net_ab[OUTLAYER, j] += (net[OUTLAYER, j] - b[OUTLAYER, j]) / a[OUTLAYER, j];
                }
                temp = morlet(net_ab[OUTLAYER, j]);

                y += Wij[OUTLAYER, j] * temp;
            
            }*/

            y=trainPredictOut(ref predictdata, ref net, ref net_ab);
            return y;
        
        }

        public override void Clear()
        {
            Wjk.Dispose();
            Wij.Dispose();
            a.Dispose();
            b.Dispose();
        }

        
        public override bool Train(float[] data, int flags = 0) 
        {
            logger.Info("WavesANN train");

            //mergr trian data and label
            if (data == null)
            {
                logger.Debug("train data is null,program can not run");
                return false;
            }

            //merge data
            Matrix<float> traindata = null;
            Matrix<float> label = null;
            bool isSuccess = false;
            isSuccess = doMergeTrainData(ref data, out traindata, out label);
            if (!isSuccess || traindata == null || label == null)
            {
                throw new Exception("megre train data flase");
            }

           //nomal data
            MatrixUntil.maxminnomal(ref traindata,out intputmaxv, out intputminv);
            MatrixUntil.maxminnomal(ref label, out outputmaxv, out outputrminv);


            //training
            try
            {
                train(ref traindata,ref label);
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                logger.Info("train flase");
                return false;
            }

            logger.Info("train success");
            return true;
        }
        public override float[] Predict(float[] data)
        {
            logger.Info("Predict data");


            //merge predict data
            float[] result = new float[1];
            Matrix<float> predictdata = null;
            bool isSuccess = false;


            isSuccess = doMergePredictData(ref data, out predictdata);
            if (!isSuccess || predictdata == null)
            {
                throw new Exception("megre predict data flase");
            }
            //nomaldata
            MatrixUntil.maxminnomal(ref predictdata,  intputmaxv,  intputminv);

            //predict processing
            try
            {
                result[0] = predict(ref predictdata);
                MatrixUntil.reversemaxminnomal(ref result, outputmaxv,outputrminv);
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                return null;
            }

            //deal result to list

            return result;

        }
    }
}

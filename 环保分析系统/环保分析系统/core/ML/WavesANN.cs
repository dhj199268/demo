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
        protected override void train()
        {   
            logger.Info("WavesANN train processing");
            if (traindata.Height != label.Height && traindata.Width != segTime)
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
                    logger.Debug("iter time :"+(i+1));
                //train net
                for (int k = 0; k < traindata.Height; ++k)
                {
                        x = traindata.GetRow(k);
                        yqw = label[k, OUTLAYER];
                        y = _predict(ref x, ref net, ref net_ab);
                        //x.Dispose();

                       
                        // updata weight
                        float error = yqw-y;
                        float temp;
                        logger.Debug("updata weight");
                        for (int j = 0; j < hidelayer;++j )
                        {

                            //cal d_Wij
                            temp = morlet(net_ab[OUTLAYER, j]);
                            d_Wij[OUTLAYER, j] = d_Wij[OUTLAYER, j] - error * temp;

                            //cal d_Wjk
                            temp = d_morlet(net_ab[OUTLAYER, j]);
                            for (int z = 0; z < segTime; ++z)
                            {
                                d_Wjk[j, z] = d_Wjk[j, z] + error * Wij[OUTLAYER, j];
                                d_Wjk[j, z] = -1 * d_Wjk[j, z] * temp * x[OUTLAYER,z] / a[OUTLAYER, j];
                            }

                            //cal d_b
                            d_b[OUTLAYER, j] += error * Wij[OUTLAYER, j];
                            d_b[OUTLAYER, j] *= temp / a[OUTLAYER, j];

                            //cal d_a
                            d_a[OUTLAYER, j] += error * Wij[OUTLAYER, j];
                            d_a[OUTLAYER, j] *= temp * (net[OUTLAYER, j] - b[OUTLAYER, j]) / b[OUTLAYER, j] / a[OUTLAYER, j];
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
        private float _predict(ref Matrix<float> x, ref Matrix<float> net, ref Matrix<float> net_ab)
        {
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
            return y;
        }

        protected override void predict(ref Matrix<float> predictdata,out float[] y)
        {
            logger.Info("predict processing");
            if (predictdata.Width != segTime)
            {
                throw new Exception("error dim about predictdata");
            }

            //init net
            Matrix<float> net = new Matrix<float>(outlayer, hidelayer);
            Matrix<float> net_ab = new Matrix<float>(outlayer, hidelayer);
            Matrix<float> tmp;
            y = new float [predictdata.Height];

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
            for(int i =0;i<y.Length;++i)
            {
                tmp = predictdata.GetRow(i);
                y[i] = _predict(ref tmp, ref net, ref net_ab);

                net.SetZero();
                net_ab.SetZero();
            }
            
        
        }

        public override void Clear()
        {
            Wjk.Dispose();
            Wij.Dispose();
            a.Dispose();
            b.Dispose();
            traindata.Dispose();
            label.Dispose();
        }

        protected override void beforeTrain()
        {
            MatrixUntil.maxminnomal(ref traindata, out intputmaxv, out intputminv);
            MatrixUntil.maxminnomal(ref label, out outputmaxv, out outputrminv);
        }

        protected override void beforePredict(ref Matrix<float> predictdata)
        {
            MatrixUntil.maxminnomal(ref predictdata, intputmaxv, intputminv);
        }
        protected override void afterPredict(ref float[] data)
        {
            MatrixUntil.reversemaxminnomal(ref data, outputmaxv, outputrminv);
        }

      /*  public override bool Train(ref float[] data, int flags = 0) 
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
            isSuccess = doMergeData(ref data, out traindata, out label);
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
        public override float[] Predict(ref float[] data)
        {
            logger.Info("Predict data");


            //merge predict data
            float[] result ;
            Matrix<float> predictdata = null;
            bool isSuccess = false;


            isSuccess = doMergeData(ref data, out predictdata);
            if (!isSuccess || predictdata == null)
            {
                throw new Exception("megre predict data flase");
            }
            //nomaldata
            MatrixUntil.maxminnomal(ref predictdata,  intputmaxv,  intputminv);

            //predict processing
            try
            {
                predict(ref predictdata,out result);
                MatrixUntil.reversemaxminnomal(ref result, outputmaxv, outputrminv);
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                throw e;
            }

            //deal result to list
            return result;

        }*/
    }
}

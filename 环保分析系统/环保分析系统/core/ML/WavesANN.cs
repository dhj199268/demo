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

        private static  int OUTLAYER = 0;
        //输入层个数,即segTime的个数
        private const int outlayer = 1;//输出层结点个数
        private int hidelayer;//隐藏层结点个数

        private float lr1   = 0.01f;//权值
        private float lr2   = 0.001f;//学习率
        private int maxiter = 100;//对大迭代次数
        private float[] intputmaxv;
        private float[] intputminv;
        private float[] outputmaxv;
        private float[] outputrminv;
        //private int segTime;
        private Matrix<float> Wij;
        private Matrix<float> Wjk;
        private Matrix<float> b;
        private Matrix<float> a;


        private WavesANN() { }

        public WavesANN(int hidelayer, int segTime, int iter = 100, float lr1 = 0.01f, float lr2 = 0.001f, float accurate=0.001f)
        {
            this.hidelayer = hidelayer;
            this.segTime = segTime;
            this.maxiter = iter;
            this.lr1 = lr1;
            this.lr2 = lr2;
            this.accurate = accurate;
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
            /*float[,] dateWjk = new float[,]{
            {-1.603095E-09f , 0.1581351f  ,-0.700928f,  -0.428596f , 1.238742f,  -0.2780082f},
            {-0.6483988f , 0.3051633f , 0.5150146f , -1.145044f,  0.7698455f , -0.04643121f},
            {1.305906f  ,-1.959684f , -1.899214f , -0.5372382f , -0.7482896f,  1.896493f},
            {0.2740504f , -1.380205f , 1.536549f , -0.7863572f  ,-2.47486f , -1.547924f},
            {-1.366019f  ,-0.0632474f  ,1.35166f  ,0.7991089f  ,-0.2629067f  ,-0.5210055f},
            {1.832979f,0.3665396f,1.292024f,-0.6415402f,-0.8612988f,1.0746f },
            { 0.04817724f,-0.2777255f,-0.1544364f,-0.3687655f,1.049587f,0.4745168f},
            {-0.1098307f,1.027995f,-0.7473472f,-0.6086587f,-0.2126996f,1.161373f},
            { -1.97154f,0.6979373f,-0.2164864f,0.09800851f,0.2626977f,-0.8374355f },
            {0.6489992f,-0.1693007f,1.664958f,-0.2866672f,-0.8016707f,0.709641f},
            {0.5940348f,0.6862857f,-0.486322f,-0.5800229f,0.1246383f,-0.9583831f},
            {-0.9581243f,1.170798f,0.6460137f,0.366217f,-1.171016f,1.329355f },
            {1.277516f,1.433298f,-0.5041577f,-1.072145f,1.10956f,0.4944702f },
            {-0.898831f,-0.5393173f,-0.1154103f,-0.9486543f,0.5228851f,0.1146836f},
            {0.03454646f,-0.9715312f,0.8627224f,1.256821f,-0.7619987f,0.5566175f}
            };
            float[] dataWij = new float[] { 2.282419f, 2.586385f, 1.670612f, -0.09844889f, 1.181688f, -1.981908f, 1.194082f, 0.125284f, 1.428096f, -1.436763f, 0.05035987f, 0.9311036f, -0.6933131f, -1.548525f, -1.383015f };
            float[] dataa = new float[]{-1.255837f , -1.116254f , 0.0733989f,0.354004f ,-0.3725047f , -0.1567855f , 0.3352263f , 0.4787318f , 0.2413591f , 0.373641f , 0.1144013f,  1.010988f  ,0.07992264f  ,-2.235177f  ,-1.379348f };
            float[] datab = new float[] { -1.265001f, -0.2734743f, 0.6498196f, 0.1608497f,-0.8530558f ,0.1870729f,0.2749617f ,-1.43715f , 0.2649245f,  -0.686395f , 1.267891f , -0.09106331f,  0.54422f , 0.02860428f,  0.2482116f};*/


            Wij = new Matrix<float>(outlayer, hidelayer);  //hide to out
            Wjk = new Matrix<float>(hidelayer, segTime);//input to hide
            a = new Matrix<float>(outlayer, hidelayer);
            b = new Matrix<float>(outlayer, hidelayer);
          /*  Wij = new Matrix<float>(dataWij);  //hide to out
            Wij = Wij.Transpose();
            Wjk = new Matrix<float>(dateWjk);//input to hide
            a = new Matrix<float>(dataa); a = a.Transpose();
            b = new Matrix<float>(datab); b = b.Transpose();*/

            //tmp data
            //rand init
            Wjk.SetRandNormal(mean, std);
            Wij.SetRandNormal(mean, std);
            a.SetRandNormal(mean, std);
            b.SetRandNormal(mean, std);

           /* Matrix<float> old_Wjk = new Matrix<float>(Wjk.Size);
            Matrix<float> old_Wij = new Matrix<float>(Wij.Size);
            Matrix<float> old_a = new Matrix<float>(a.Size);
            Matrix<float> old_b = new Matrix<float>(b.Size);

            Wjk.CopyTo(old_Wjk);
            Wij.CopyTo(old_Wij);
            a.CopyTo(old_a);
            b.CopyTo(old_b);*/



            if (logger.IsDebugEnabled)
            {
                loggerUntil.printMatToLogger("init Wij mat : ", ref Wij, ref logger);
                loggerUntil.printMatToLogger("init Wjk mat : ", ref Wjk, ref logger);
                loggerUntil.printMatToLogger("init a   mat : ", ref a, ref logger);
                loggerUntil.printMatToLogger("init b   mat : ", ref b, ref logger);

            }

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
                        //logger.Debug("updata weight");
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
                    Wjk -= lr1 * d_Wjk;
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

                

                if (logger.IsDebugEnabled)
                {
                    loggerUntil.printMatToLogger("updata Wij mat : ", ref Wij, ref logger);
                    loggerUntil.printMatToLogger("updata Wjk mat : ", ref Wjk, ref logger);
                    loggerUntil.printMatToLogger("updata a   mat : ", ref a, ref logger);
                    loggerUntil.printMatToLogger("updata b   mat : ", ref b, ref logger);

                }

                /*// is accurate termination iter
                if (MatrixUntil.isAccurate(ref Wij, ref old_Wij, accurate) && MatrixUntil.isAccurate(ref Wjk, ref old_Wjk, accurate)
                    && MatrixUntil.isAccurate(ref b, ref old_b, accurate) && MatrixUntil.isAccurate(ref a, ref old_a, accurate))
                {
                    logger.Info(" accurate reach , iter end , NO. iter :" + (i+1));
                    old_Wij.Dispose();
                    old_Wjk.Dispose();
                    old_b.Dispose();
                    old_a.Dispose();
                    break;
                }

                Wjk.CopyTo(old_Wjk);
                Wij.CopyTo(old_Wij);
                a.CopyTo(old_a);
                b.CopyTo(old_b);*/
              
            
            }

        }
        private float _predict(ref Matrix<float> x, ref Matrix<float> net, ref Matrix<float> net_ab)
        {
            Matrix<float> temp = new Matrix<float>(Wij.Width,Wij.Height);
            float y=0.0f;

            for (int j = 0; j < hidelayer; ++j)
            { 
                for(int k=0;k< segTime;++k)
                {
                    net[OUTLAYER, j] = net[OUTLAYER, j] + Wjk[j, k] * x[OUTLAYER, k];
                    net_ab[OUTLAYER, j] = (net[OUTLAYER, j] - b[OUTLAYER, j]) / a[OUTLAYER, j];

                }

                temp[j,OUTLAYER] = morlet(net_ab[OUTLAYER, j]);
                //y = y + Wij[OUTLAYER, j] * temp;
            }
            temp = Wij * temp;
            y = (float)temp.Sum;
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

            if (logger.IsDebugEnabled)
            {
                loggerUntil.printMatToLogger("printf nomal train data mat : ", ref traindata, ref logger);
                loggerUntil.printMatToLogger("printf nomal label data mat : ", ref label, ref logger);
            }

        }

        protected override void beforePredict(ref Matrix<float> predictdata)
        {
            MatrixUntil.maxminnomal(ref predictdata, intputmaxv, intputminv);

            if (logger.IsDebugEnabled)
            {
                loggerUntil.printMatToLogger("printf predict  data mat after nomal : ", ref predictdata, ref logger);
            }
        }
        protected override void afterPredict(ref float[] data)
        {

            if (logger.IsDebugEnabled)
            {
                loggerUntil.printMatToLogger("printf predict  data mat before reversem nomal : ", ref data, ref logger);
            }

            MatrixUntil.reversemaxminnomal(ref data, outputmaxv[0], outputrminv[0]);
        }

      
    }
}

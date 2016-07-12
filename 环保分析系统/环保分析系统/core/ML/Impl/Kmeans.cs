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
using 环保分析系统.core.ML.Impl;
using 环保分析系统.core.Until;
using System.Drawing;

namespace 环保分析系统.core.ML
{
    class Kmeans : AbstractMLAlg
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Kmeans));

        private int numClass;
        protected Matrix<float> center;//族中心，索引为分类的种类
        //private Matrix<float> centerDiag;//族中心的对称矩阵
        private int maxIter;//最大迭代次数

        public Kmeans(int numClass = 2, int maxIter = 100, int segTime = 2, float accurate = 0.001f)
            : base(segTime, true)
        {
            if (numClass < 2)
            {
                throw new Exception("class num  at least 2 "); 
            }
            this.segTime = segTime;
            this.numClass = numClass;
            this.maxIter = maxIter;
            this.accurate = accurate;

            this.haslabel = false;
        
        }
        //private void calCenterDiag()
        //{
        //    centerDiag = (center * center.Transpose());
        //    centerDiag = centerDiag.GetDiag();

        //    if (centerDiag.Height != numClass && centerDiag.Width != 1)
        //    {
        //        throw new Exception("cent diag dim wrong");
        //    }
        //}

        private int _predict(ref Matrix<float> y,out float distance)
        {
            //logger.Debug("predict class");
            if (y.Height != 1&&y.Width!=segTime)
            {
                throw new Exception("input mat dim wrong");
            }
            Matrix<float> tmp=new Matrix<float>(center.Height,1);
            Point maxlocal;
            Point minlocal;
            double minv = 0;
            double maxv = 0;
            //float prod = 0;

            //tmp = y.Transpose();
            //prod = (y * tmp)[0, 0];
            //tmp = centerDiag - 2 * center * tmp + prod;
            for (int i = 0; i < center.Height; ++i)
            {

                for (int j = 0; j < center.Width; ++j)
                {
                    tmp[i, 0] += (center[i, j] - y[0, j]) * (center[i, j] - y[0, j]);
                }

            }


                tmp.MinMax(out minv, out maxv, out minlocal, out maxlocal);

            //logger.Debug("predict class:" + minlocal.Y);

            distance = (float)minv;

            //return class

            return minlocal.Y;
        
        }

        private void updateCenter( ref Dictionary<int, List<int>> indexs)
        {
            Matrix<float> tmp = new Matrix<float>(1,traindata.Width);
            

            foreach(int yclass in indexs.Keys)
            {

                List<int> indexlist = indexs[yclass];
                foreach (int i in indexlist)
                {
                    tmp = tmp + traindata.GetRow(i);
                }
                 
                tmp /= indexlist.Count;

                // clear and free memory
                indexlist.Clear();//防止内存上升

                //copy result to center 
                for (int col = 0; col < segTime; ++col)
                {
                    center[yclass, col] = tmp[0, col];
                }
                tmp.SetZero();
            }

            // clear and free memory
            tmp.Dispose();
            indexs.Clear();//防止内存上升
        }
        
        private void initCenter(ref Matrix<float> data)
        {
                logger.Debug("init center matrix");
                Random random = new Random();
                HashSet<int> randomset = new HashSet<int>();
                int count=0;

                if (numClass>data.Height)
                {
                    throw new Exception("class num set too much or data too less");
                }

                while (randomset.Count != numClass)
                {
                    randomset.Add(random.Next(data.Height));
                }

                center = new Matrix<float>(numClass,segTime);
                
                foreach (int row in randomset)
                {
                    //logger.Debug("extract row number :"+row);

                    for (int col = 0; col < segTime; ++col)
                    {
                        center[count, col] = data[row, col];
                    }
                    ++count;
                }
                randomset.Clear();
        }
        protected override void train()
        {
            logger.Info("main processing");

            Dictionary<int, List<int>> indexs = new Dictionary<int, List<int>>();
            int wClass;
            Matrix<float> oldcenter;
            Matrix<float> tmp;
            float dist;

            //init center 
            initCenter(ref traindata);
            if (logger.IsDebugEnabled)
            {
                string tmpstr;
                tmpstr = loggerUntil.printMatToLogger("init center mat : ", ref center);
                logger.Debug(tmpstr);

            }

            oldcenter=center.Clone();

            //iter train
            for (int iter = 0; iter < maxIter; ++iter)
            {
                logger.Debug("iter time : " + (iter + 1));

                //calCenterDiag();

                //updata train data label
                //logger.Info("updata train data label");
                for (int row = 0; row < traindata.Height; ++row)
                {

                    tmp = traindata.GetRow(row);
                    wClass = _predict(ref tmp,out dist);
                    if (!indexs.ContainsKey(wClass))
                    { 
                        indexs.Add(wClass,new List<int>());
                    }
                    indexs[wClass].Add(row);
                    //logger.Debug("[class,row ]:"+wClass+","+row);
                }

               
                //updata center
                //logger.Info("updata center");
                updateCenter( ref indexs);
                
                  if (logger.IsDebugEnabled)
                {
                    string tmpstr;
                    tmpstr = loggerUntil.printMatToLogger("updata center mat:", ref center);
                    logger.Debug(tmpstr);
                
                }

                //is accurate termination iter
                if (MatrixUntil.isAccurate(ref center, ref oldcenter,accurate))
                {
                    logger.Info(" accurate reach , iter end");
                    oldcenter.Dispose();
                    break;
                }

                oldcenter.Dispose();
                oldcenter = center.Clone();
            }
        }

        public override void Clear()
        {

            this.center.Dispose();
            //this.centerDiag.Dispose();
            this.traindata.Dispose();
        }
        protected override void predict(ref Matrix<float> data, out float[] result)
        {
            float dist; 
            Matrix<float> tmp;
            result = new float[data.Height];
            for (int i = 0; i < data.Height; ++i)
            {
                tmp = data.GetRow(i);
                result[i] = _predict(ref tmp, out dist);
            }
        }

        protected override bool doMergeData(ref float[] data, out Matrix<float> mergedata)
        {
            logger.Info("merge data processing");

            int rows = data.Length / segTime;
            mergedata = new Matrix<float>(rows,segTime);

          
                for (int col = 0; col < segTime; col++)
                {
                    for (int row = 0; row < rows; ++row)
                    {
                        mergedata[row, col] = data[rows * col + row];
                    }
                }
            return true;
        }

      /*  public override float[] Predict(ref float[] data)
        {
            logger.Info("Predict data");


            //merge predict data
            float[] result;
            Matrix<float> predictdata = null;
           
            bool isSuccess = false;
            

            isSuccess = doMergeData(ref data, out predictdata);
            if (!isSuccess || predictdata == null)
            {
                throw new Exception("megre predict data flase");
            }

            //predict processing
            try
            {
                predict(ref predictdata,out result);
                    
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                throw e;
            }

            //deal result to list
            return result;
        }*/
      /*  public override bool Train(ref float[] data, int flags = 0)
        {
            logger.Info("Kmeans train");

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
            isSuccess = doMergeData(ref data, out traindata);
            if (!isSuccess && traindata == null && label == null)
            {
                throw new Exception("megre train data flase");
            }

            //training
            try
            {
                train(ref traindata);
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                throw e;
            }

            logger.Info("train success");
            return true;
        }*/
        
    }
}

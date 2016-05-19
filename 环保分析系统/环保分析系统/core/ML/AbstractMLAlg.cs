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

namespace 环保分析系统.core.ML
{
    abstract class AbstractMLAlg : IMLAlgorithm
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AbstractMLAlg));
        protected IStatModel  trainmodel = null;
        protected int segTime = 150;

        

        public int SegTime
        {  get{
                    return segTime;
                }
            set {
                segTime = value;
            }
        }
            
            
        public abstract bool Train( float[] data,  int flags = 0);
        public abstract float[] Predict( float[] data);
        abstract public void Clear();

        //==================================================================
        //函数名：  doMergeTrainData
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    整合训练数据
        //输入参数：data 需要整合的数据,traindata整合后的数据,label整合的标签，segTime 需要分割的时间段
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        protected bool doMergeTrainData(ref float[] data, out Matrix<float> traindata ,out Matrix<float> label)
        {

            logger.Info("merge train data");
            //init
            int datalen = data.Length;
            if(datalen<segTime)
            {
                throw new Exception("data is too few  or segTime is too much");
            }

            int rows = datalen - segTime;
            traindata = new Matrix<float>(rows, segTime);
            label =new Matrix<float>(rows, 1);

            //merge data
            try
            {
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < segTime; ++j)
                    {
                        traindata.Data[i, j] = data[i + j];
                    }
                    int temp = i + segTime;
                    label.Data[i, 0] = data[temp];
                }
            }
            catch (Exception e)
            {
                logger.Error("error information:"+e);
                return false;
            }
            return true;
        }

        //==================================================================
        //函数名：  doMergePredictData
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    整合预测数据
        //输入参数：data 需要整合的数据,predictData 整合后的数据,num 需要预测数据的数量
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        protected bool doMergePredictData(ref float[] data,out  Matrix<float> predictData)
        {
            logger.Info("merge predict data");
            //init 
            int datalen = data.Length;
            if (datalen != segTime)
            {
                throw new Exception("data is not equls to seg time");
            }

            
            try
            {
                predictData = new Matrix<float>(1, datalen);
                //merge predict data
                for (int i = 0; i < datalen; ++i)
                {
                    predictData[0, i] = data[i];
                }
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                throw e;
            }
            return true;
        }
    }
}

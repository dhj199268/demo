using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using 环保分析系统.core.ML.Impl;

namespace 环保分析系统.core.ML
{
    abstract class AbstractMLAlg : IMLAlgorithm
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AbstractMLAlg));
        public abstract bool Train(float[] data, int flags = 0);
        public abstract float[] Predict(float[] data);


        //==================================================================
        //函数名：  doMergeTrainData
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    整合训练数据
        //输入参数：data 需要整合的数据,traindata整合后的数据,label整合的标签，segTime 需要分割的时间段
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        protected bool doMergeTrainData(float[] data,Matrix<float> traindata ,Matrix<float> label,int segTime=150)
        {
            //init
            int datalen = data.Length;
            if(datalen<segTime)
            {
                throw new Exception("data is too few  or segTime is too much");
            }

            int rows=datalen - segTime ;
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

                    label.Data[i, 0] = data[i + segTime + 1];
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
        protected bool doMergePredictData(float[] data,Matrix<float> predictData)
        {

            //init 
            int datalen = data.Length;

            try
            {
                predictData = new Matrix<float>(1, datalen);
                //merge predict data
                for (int i = 0; i < datalen; ++i)
                {
                    predictData.Data[0, i] = data[i];
                }
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                return false;
            }
            return true;
        }
    }
}

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
        
        protected int segTime;
        protected Matrix<float> traindata;
        protected Matrix<float> label;
        protected bool haslabel=true;
        protected float accurate;//精确度

        public int SegTime
        {  get{
                    return segTime;
                }
            set {
                segTime = value;
            }
        }
        //==================================================================
        //函数名：  beforeTrain
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    训练模型前对数据处理，用于继承改写，对traindata，和label 进行处理
        //输入参数：
        //返回值：  类型void
        //修改记录：
        //==================================================================
        protected virtual void beforeTrain()
        {
            logger.Info("before train deal");
        }
        //==================================================================
        //函数名：  beforePredict
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    预测前对数据处理，用于继承改写
        //输入参数：data 需要处理的数据
        //返回值：  类型void
        //修改记录：
        //==================================================================
        protected virtual void beforePredict(ref Matrix<float> data) 
        {
            logger.Info("before predict deal");
        
        }
        //==================================================================
        //函数名：  afterPredict
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    预测后对数据处理，用于继承改写
        //输入参数：data 需要处理的数据
        //返回值：  类型void
        //修改记录：
        //==================================================================
        protected virtual void afterPredict(ref float[] data)
        {
            logger.Info("after predict deal");
        
        }
        protected  abstract void train();
        protected abstract void predict(ref Matrix<float> data, out float[] result);
        abstract public void Clear();




        public virtual bool Train(ref  float[] data, int flags = 0) 
        {
            logger.Info("model train");

            //mergr trian data and label
            if (data == null)
            {
                logger.Debug("train data is null,program can not run");
                return false;
            }

            //merge data
            bool isSuccess = false;

            if (this.haslabel == true)
            {
                isSuccess = doMergeData(ref data, out traindata, out label);
            }
            else 
            {
                isSuccess = doMergeData(ref data, out traindata);
            }
            
            if (!isSuccess)
            {
                throw new Exception("megre train data flase");
            }

            
            //training
            try
            {
                beforeTrain();
                train();
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                throw e;
            }

            logger.Info("train success");
            return true;
        
        
        
        }
        public virtual float[] Predict(ref float[] data) 
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
            //nomaldata
            
            //predict processing
            try
            {
                beforePredict(ref predictdata);

                predict(ref predictdata, out result);

                afterPredict(ref result);
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                throw e;
            }

            //deal result to list
            return result;
        
        
        
        
        
        
        }
       

        //==================================================================
        //函数名：  doMergeTrainData
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    整合训练数据
        //输入参数：data 需要整合的数据,traindata整合后的数据,label整合的标签
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        protected virtual bool doMergeData(ref float[] data, out Matrix<float> traindata ,out Matrix<float> label)
        {


            logger.Info("merge  data");
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
                        traindata[i, j] = data[i + j];
                    }
                    int temp = i + segTime;
                    label[i, 0] = data[temp];
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
        //函数名：  doMergeData
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    整合训练数据
        //输入参数：data  整理的数据没有 label ，用于 预测和聚类的数据整理   mergedata  整理好的数据
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        protected virtual bool doMergeData(ref float[] data,out  Matrix<float> mergedata)
        {
            logger.Info("merge  data");
            //init 
            int datalen = data.Length;
            if (datalen < segTime)
            {
                throw new Exception("len of data is too short ");
            }

            int rows = datalen - segTime + 1;
            try
            {
                mergedata = new Matrix<float>(rows, segTime);
                //merge predict data
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < segTime; ++j)
                    {
                        mergedata[i, j] = data[i + j];
                    }
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

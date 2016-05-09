using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    class RandomForest : AbstractMLAlg
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(RandomForest));
        private RTrees randomforset = new RTrees();

        //==================================================================
        //函数名：  Train
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    RandomForest 训练
        //输入参数：data 需要的数据，flags 扩展项
        //返回值：  类型（bool)
        //修改记录：
        //==================================================================
        public override bool Train(float[] data, int flags = 0) 
        {
            logger.Info("RandomForest train");

            //mergr trian data and label
            if (data == null) 
            {
                logger.Debug("train data is null,program can not run");
                return false;
            }
            //merge data
            Matrix<float> traindata = null;
            Matrix<float> label = null ;
            bool isSuccess=false;
            isSuccess=doMergeTrainData(data,traindata,label);
            if (isSuccess || traindata == null || label == null)
            {
                throw new Exception("megre train data flase");
            }

            //training
            try
            {
                TrainData tempdata = new TrainData(traindata, DataLayoutType.RowSample, label);
                randomforset.Train(tempdata);
            }
            catch (Exception e){
                logger.Error("error information:"+e);
            }

            logger.Info("train success");
            return true;
            
        }
        //==================================================================
        //函数名：  Predict
        //作者：    dhj
        //日期：    2016-05-09
        //功能：    RandomForest 预测
        //输入参数：data 需要预测的数据
        //返回值：  类型（float) 预测的结果
        //修改记录：
        //==================================================================
        public override float[] Predict(float[] data) 
        {
            logger.Info("Predict data");

            //merge predict data
            Matrix<float> result=null;
            Matrix<float> predictdata = null;
            bool isSuccess = false;
            isSuccess = doMergePredictData(data, predictdata);
            if(isSuccess||predictdata==null)
            {
                throw new Exception("megre predict data flase");
            }


            //predict processing
            try
            {
               result = new Matrix<float>(predictdata.Height, 1);
               randomforset.Predict(predictdata, result);
            }
            catch (Exception e)
            {
                logger.Error("error information:" + e);
                return null;
            }
            
            //deal result to list
            float[] resultList = new float[result.Height];
            for (int i = 0; i < result.Height;++i )
            {
                resultList[i]=result.Data[i,0];

            }
            return resultList;
        }

    }
}

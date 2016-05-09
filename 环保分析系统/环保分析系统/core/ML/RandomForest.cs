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
    class RandomForest : IMLAlgorithm
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
        bool Train(Matrix<float> traindata,Matrix<float> label, int flags = 0) 
        {
            logger.Info("RandomForest train");

            //mergr trian data and label
            if (traindata==null||label==null) 
            {
                logger.Debug("train data is null,program can not run");
                return false;
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
        Matrix<float> Predict(Matrix<float> predictdata) 
        {
            logger.Info("Predict data");
            Matrix<float> result;

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
            return result;
        }

    }
}

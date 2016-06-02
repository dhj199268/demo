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
        
        private int maxCategories;
        private int maxDepth ;
        private bool seRule;
        private IStatModel trainmodel = null;

       
        public RandomForest(int numTree=500,int segTime=150, int maxCategories=10, float regAccuracy=0.1f,int maxDepth=15, bool seRule=true)
            :base(segTime,true)
        {
            this.maxCategories = maxCategories;
            this.accurate = regAccuracy;
            this.maxDepth = maxDepth;
            this.seRule = seRule;
        }
       
        public override void Clear()
        {
            this.traindata.Dispose();
            this.label.Dispose();
            this.trainmodel.Clear();
        }
        protected override void beforeTrain()
        {
            logger.Info("before train in RF");


            RTrees temp = new RTrees();
            temp.MaxCategories = this.maxCategories;
            temp.RegressionAccuracy = this.accurate;
            temp.MaxDepth = this.maxDepth;
            temp.Use1SERule = this.seRule;

            this.trainmodel = temp;

        }
        protected override void train()
        {
            logger.Info(" train model in RF");
            TrainData tempdata = new TrainData(traindata, DataLayoutType.RowSample, label);
            trainmodel.Train(tempdata);
        }



        protected override void predict(ref Matrix<float> data, out float[] result)
        {
            Matrix<float> tmp = new Matrix<float>(data.Height, 1);
            trainmodel.Predict(data, tmp);

             result = new float[tmp.Height];
            for (int i = 0; i < tmp.Height; ++i)
            {
                result[i] = tmp[i, 0];

            }

        }

       /* public override bool Train( ref float[] data, int flags = 0) 
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
            bool isSuccess = false;
            isSuccess = doMergeData(ref data, out traindata,out label);
            if (!isSuccess && traindata == null && label == null)
            {
                throw new Exception("megre train data flase");
            }

            //training
            try
            {
                TrainData tempdata = new TrainData(traindata, DataLayoutType.RowSample, label);
                trainmodel.Train(tempdata);
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
        public override float[] Predict(ref float[] data) 
        {
            logger.Info("Predict data");

            if (trainmodel == null)
            {
                throw new Exception("model is null");
            }


            //merge predict data
            Matrix<float> result=null;
            Matrix<float> predictdata=null;
            bool isSuccess = false;


            isSuccess = doMergeData(ref data, out predictdata);
            if(!isSuccess&&predictdata==null)
            {
                throw new Exception("megre predict data flase");
            }


            //predict processing
            try
            {
               result = new Matrix<float>(predictdata.Height, 1);
               trainmodel.Predict(predictdata, result);
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
                resultList[i]=result[i,0];

            }
            return resultList;
        }
*/

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 环保分析系统.core.ML.Impl;
using 环保分析系统.Draw.Impl;

namespace 环保分析系统.core
{
    class ThreadML
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ThreadML));
        private float[] tradata;
        private IMLAlgorithm model;
        private IDraw draw;
        private float[] result;
        private float[] predictdata;


        public ThreadML(ref float[] tradata, ref float[] predata, IMLAlgorithm model,IDraw draw)
        {
            this.tradata = tradata;
            this.predictdata = predata;
            this.model = model;
            this.draw = draw;
         }
        
        public  float[] TrainData
        {
            set{
                tradata = value;          
                }

            get 
            {
                return tradata;
            }
        }
        public IMLAlgorithm Model
        {
        
            set{
                        model=value;          
               }

            get
            {
                return model;
            }
        }

        public float[] Result
        {
        
                get
                {
                  return result;   
                }
        
        }
        public float[] PredictData
        {
            set
            {
                predictdata = value;            
            }
            get 
            {
                return predictdata;
            }        
        }
        public void train()
        {
            try
            {
                model.Train(ref tradata);
                result = model.Predict(ref predictdata);
                model.Clear();
                draw.DrawPicture(ref this.predictdata, ref this.result);
            }
            catch (Exception e)
            {
                logger.Error(e);
                MessageBox.Show(e.ToString());
            }
            
        }

        private void ShowResult()
        {
            for (int i = 0; i < result.Length; ++i)
                logger.Info("result:" + result[i]);
        }

       

    }
}

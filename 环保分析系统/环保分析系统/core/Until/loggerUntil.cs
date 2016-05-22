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

namespace 环保分析系统.core.Until
{
    class loggerUntil
    {

        private loggerUntil() { }
        public static void printMatToLogger(string msg, ref Matrix<float> data, ref log4net.ILog logger)
        {

            StringBuilder str = new StringBuilder("\n");
            //str.Append("\n");
            for (int i = 0; i < data.Height; ++i)
            {
                str.Append(i + ":  ");
                for (int j = 0; j < data.Width; ++j)
                {
                    str.Append(data[i, j] + "  ");

                }
                str.Append("\n");
            }
            logger.Debug(msg + str);

        }
        public static void printMatToLogger(string msg, ref float[] data, ref log4net.ILog logger)
        {

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < data.Length; ++i)
            {
                str.Append(data[i]+"\n");
            }
            logger.Debug(msg + str);
        
        
        }

    }



}

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

namespace 环保分析系统.core.Until
{
    class MatrixUntil
    {
        private MatrixUntil() { }
       
        //==================================================================
        //函数名：  Sin
        //作者：    dhj
        //日期：    2016-05-16
        //功能：    Sin计算
        //输入参数：
        //返回值：  类型（void)
        //修改记录：
        //==================================================================
        public static void Sin(Matrix<float> data, out Matrix<float> result)
        {

            result = new Matrix<float>(data.Height, data.Width);
            for (int i = 0; i < result.Height; ++i)
            {
                for (int j = 0; j < result.Width; ++j)
                {
                    result[i, j] = (float)Math.Sin((double)data[i, j]);
                }
            }

        }
        //==================================================================
        //函数名：  Cos
        //作者：    dhj
        //日期：    2016-05-16
        //功能：    Cos计算
        //输入参数：
        //返回值：  类型（void)
        //修改记录：
        //==================================================================
        public static void Cos(Matrix<float> data, out Matrix<float> result)
        {

            result = new Matrix<float>(data.Height, data.Width);
            for (int i = 0; i < result.Height; ++i)
            {
                for (int j = 0; j < result.Width; ++j)
                {
                    result[i, j] = (float)Math.Cos((double)data[i, j]);
                }
            }

        }

        //==================================================================
        //函数名：  maxminnomal
        //作者：    dhj
        //日期：    2016-05-16
        //功能：    归一化数据
        //输入参数：data 需要归一化的矩阵
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        public static void maxminnomal(ref Matrix<float> data, out float[] maxv, out float[] minv)
        {
            Point tempa;
            Point tempb;
            double tmpminv ;
            double tmpmaxv ;
            Matrix<float> tmpmat;
            maxv = new float[data.Width];
            minv = new float[data.Width];

            for (int i = 0; i < data.Width; i++)
            {
                tmpmat = data.GetCol(i);
                tmpmat.MinMax(out tmpminv, out tmpmaxv, out tempa, out tempb);
                maxv[i] = (float)tmpmaxv;
                minv[i] = (float)tmpminv;

                for (int j = 0; j < data.Height; j++)
                {
                    data[j, i] = 2 * (data[j, i] - (float)tmpminv) / ((float)tmpmaxv - (float)tmpminv) - 1;
                }
            }
            

            
           
            
        }
        public static void maxminnomal(ref Matrix<float> data, float[] maxv, float[] minv)
        {
            double tmpminv;
            double tmpmaxv;
            //Matrix<float> temprow = data.GetRow(i);
            for (int i = 0; i < data.Width; i++)
            {
                tmpmaxv=maxv[i];
                tmpminv=minv[i];

                for (int j = 0; j < data.Height; j++)
                {
                    data[j, i] = 2 * (data[j, i] - (float)tmpminv) / ((float)tmpmaxv - (float)tmpminv) - 1;
                }
            }
        }
        //==================================================================
        //函数名：  reversemaxminnomal
        //作者：    dhj
        //日期：    2016-05-16
        //功能：    反归一化数据
        //输入参数：data 需要反归一化的矩阵
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        public static void reversemaxminnomal(ref Matrix<float> data,ref float[] maxv, ref float[] minv)
        {
            float ymin = -1;
            float tmpmax;
            float tmpmin;
            for (int i = 0; i < data.Width; i++)
            {
                tmpmax = maxv[i];
                tmpmin = minv[i];

                for (int j = 0; j < data.Height; j++)
                {
                    data[j, i] = (data[j, i] - ymin) * (tmpmax - tmpmin) / 2.0f + tmpmin;
                }
                
            }
            

        }
        public static void reversemaxminnomal(ref float[] data, float maxv, float minv)
        {
            double ymin = -1;
            for (int i = 0; i < data.Length; ++i)
            {
                double tmp = (double)data[i];
                tmp = (tmp - ymin) * (maxv - minv) / 2.0 + minv;
               
                data[i] = (float)tmp;
            }
        }

        public static bool isAccurate(ref Matrix<float> last, ref Matrix<float> old, float accurate)
        {
            if (last.Size!=old.Size)
            {
                throw new Exception(" the two mat dim is no equal");
            }
            Matrix<float> tmp = new Matrix<float>(last.Size);
            CvInvoke.AbsDiff(last, old, tmp);


            Point tempa;
            Point tempb;
            double minv = 0;
            double maxv = 0;
            tmp.MinMax(out minv, out maxv, out tempa, out tempb);
            if (maxv < accurate)
            {
                
                return true;
            }

            return false;

        }


      
    }
}

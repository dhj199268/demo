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
        //函数名：  DotMul
        //作者：    dhj
        //日期：    2016-05-16
        //功能：    矩阵点乘
        //输入参数：
        //返回值：  类型（bool) 整合是否成功
        //修改记录：
        //==================================================================
        public static void DotMul(ref Matrix<float> src1, ref Matrix<float> src2, out Matrix<float> result)
        {
            if (src1.Width != src2.Width || src1.Height != src2.Height)
            {
                throw new Exception("src1 dim not equel src2 dim");
            }

            result = new Matrix<float>(src1.Height, src1.Width);
            for (int i = 0; i < result.Height; ++i)
            {
                for (int j = 0; j < result.Width; ++j)
                {
                    result[i, j] = src1[i, j] * src2[i, j];
                }
            }
        }
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
        public static void maxminnomal(ref Matrix<float> data, out double maxv, out double minv)
        {
            Point tempa;
            Point tempb;
            //Matrix<float> temprow = data.GetRow(i);
            data.MinMax(out minv, out maxv, out tempa, out tempb);
            maxminnomal(ref data, maxv, minv);
        }
        public static void maxminnomal(ref Matrix<float> data, double maxv, double minv)
        {
            double ymax = 1;
            double ymin = -1;

            //Matrix<float> temprow = data.GetRow(i);
            data = (ymax - ymin) * (data - minv) / (maxv - minv) + ymin;
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
        public static void reversemaxminnomal(ref Matrix<float> data, double maxv, double minv)
        {
            double ymax = 1;
            double ymin = -1;
            data = (data - ymin) * (maxv - minv) / (ymax - ymin) + minv;

        }
    }
}

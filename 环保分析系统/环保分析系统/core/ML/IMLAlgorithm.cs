using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace 环保分析系统.core.ML.Impl
{
    interface IMLAlgorithm
    {
        //==================================================================
        //函数名：  Train
        //作者：    dhj
        //日期：    2016-05-10
        //功能：    训练模型接口函数
        //输入参数：data 训练时序列数据  flages 预留接口
        //返回值：  类型（bool) 
        //修改记录：
        //==================================================================
        bool Train(ref float[] data, int flags = 0);

        //==================================================================
        //函数名：  Predict
        //作者：    dhj
        //日期：    2016-05-10
        //功能：    预测模型接口函数
        //输入参数：data 预测数据 
        //返回值：  类型（bool) 
        //修改记录：
        //==================================================================
        float[] Predict( ref float[] data);
        //==================================================================
        //函数名：  clear
        //作者：    dhj
        //日期：    2016-05-10
        //功能：    清除模型
        //输入参数：data 预测数据 
        //返回值：  类型（bool) 
        //修改记录：
        //==================================================================
        void Clear();
        //bool SaveModel(string filename);
        //bool loadModel(string filename)
    
    }
}

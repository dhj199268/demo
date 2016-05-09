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
        bool Train(Matrix<float> traindata, Matrix<float> label, int flags = 0);
        Matrix<float> Predict(Matrix<float> predictdata); 
        //bool SaveModel(string filename);
        //bool loadModel(string filename)
    
    }
}

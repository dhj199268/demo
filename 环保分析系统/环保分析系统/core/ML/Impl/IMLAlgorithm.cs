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
        bool Train(float[] data, int flags = 0);
        float[] Predict( float[] data);
        void clear();
        //bool SaveModel(string filename);
        //bool loadModel(string filename)
    
    }
}

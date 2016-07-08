using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 环保分析系统.Draw.Impl
{
    interface IDraw
    {
        void DrawPicture(ref float[] predictdata, ref float[] result);
    }
}

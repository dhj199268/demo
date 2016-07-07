using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 环保分析系统.Draw.Impl;
using 环保分析系统.core.Until;
namespace 环保分析系统.Draw
{
    
    class LogDraw:IDraw
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LogDraw));
        public LogDraw()
        { 
        
        }
        public void DrawPicture(ref float[] predictdata, ref float[] result)
        {
            string tmp;
            tmp = loggerUntil.printMatToLogger("show predict data", ref predictdata);
            logger.Info(tmp);
            tmp = loggerUntil.printMatToLogger("show result data", ref result);
            logger.Info(tmp);
        
        }

    }
}

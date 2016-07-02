using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 环保分析系统.except
{
    class OutOfRangeException: ApplicationException
    {
        public OutOfRangeException(string message) : base(message) { }
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }
    }

    
}

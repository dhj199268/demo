using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 环保分析系统.except
{
    public static class DataAbnormal
    {
        public static void ShowError(Exception err)
        {
            MessageBox.Show(err.Message, "提示信息",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

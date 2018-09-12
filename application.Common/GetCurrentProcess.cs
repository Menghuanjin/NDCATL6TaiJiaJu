using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common
{
    public class GetCurrentProcess
    {
        public static void Kill()
        {
            Process.GetCurrentProcess().Kill();

        }
    }
}

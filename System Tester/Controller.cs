using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Tester
{
    
    class Controller
    {
        public static void initLogger()
        {

        }
        public static void initDebugMode(bool  debug_state)
        {
            if (debug_state) Model.logger_window_init();
            else Model.logger_window_destroy();
        }
    }
}



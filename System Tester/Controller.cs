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
        public static void InitLogger()
        {

        }
        public static void ChangeDebugMode()
        {
            if (!Model.Debug_mode)Model.Debug_state_init();
            else Model.Debug_state_destroy();
        }
        public static void GetSystemInfo()
        {
            Model.GetCompuerData();
        }
    }
}



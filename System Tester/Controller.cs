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
        public static void GetTestMessage()
        {
            WMICollector.test();
        }
        class CPUTester
        {
            
        }

        class RAMTester
        {

        }

        class DSTester
        {

        }

        class TCNTester
        {

        }

        class WMICollector
        {
            public static void test()
            {
                MainView.GetRWE().ShowMessage("Adele Edited");
            }
        }
    }
}



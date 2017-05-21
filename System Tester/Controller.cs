using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static void StartCpuTest()
        {
            int cpu_count = Environment.ProcessorCount;
            Logger.AddText("CPUs count: " + cpu_count);
            CPUTest[] test_core = new CPUTest[cpu_count];
            Thread[] thread_test = new Thread[cpu_count];
            for (int cpu = 0; cpu < cpu_count; cpu++)
            {
                Logger.AddText("Thread starting: " + cpu);
                test_core[cpu] = new CPUTest("Core " + cpu, 2000000);
                thread_test[cpu] = new Thread(new ThreadStart(test_core[cpu].CPU_Beanch));
                thread_test[cpu].Start();
            }
            bool alive = true;
            while (alive)
            {
                alive = false;
                for (int cpu = 0; cpu < cpu_count; cpu++)
                {
                    if (thread_test[cpu].IsAlive) alive = true;
                }
            }
    
            Logger.AddText("Тест завершен!" );
        }
    }
}



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
        const Int64 LOAD = 2000000;
        public static Stopwatch test_speed;
        static List<DeviceForView> btest;
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
            btest = new List<DeviceForView>();
            test_speed = new Stopwatch();
            
            int cpu_count = Environment.ProcessorCount;
            Logger.AddText("CPUs count: " + cpu_count);
            CPUTest[] test_core = new CPUTest[cpu_count];
            Thread[] thread_test = new Thread[cpu_count];
            for (int cpu = 0; cpu < cpu_count; cpu++)
            {
               // Logger.AddText("Thread starting: " + cpu);
                test_core[cpu] = new CPUTest("Core " + cpu, LOAD);
                thread_test[cpu] = new Thread(new ThreadStart(test_core[cpu].CPU_Beanch));
                Model.thread_count++;
            }

            test_speed.Start();

            for (int cpu = 0; cpu < cpu_count; cpu++)
            {
                thread_test[cpu].Start();
            }

            
            Logger.AddText("Тест завершен!" );
        }
        public static void Thread_Finish()
        {
            btest.Add(new DeviceForView("Результат CPU", Model.ValueСonvert( LOAD * Environment.ProcessorCount / test_speed.ElapsedMilliseconds * 1000, "", 1000),""));
            //Logger.AddText("Test time:" + Model.ValueСonvert(LOAD * Environment.ProcessorCount / test_speed.ElapsedMilliseconds * 1000, "", 1000));
            Model.MainWindow.SetInfo(btest, TabOfProgramm.general, "Результат тестирования");
        }
    }
}



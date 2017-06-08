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
            Thread networkSeacher = new Thread(Network.Receiver);
            networkSeacher.Start();
            Model.GetCompuerData();
            int i = 0;
            while (true) {
                Thread.Sleep(1000);
                Model.MainWindow.RenewValue(TabOfProgramm.cpu, "CPU_Name", i.ToString());
                i++;
               // Logger.AddText("Обновление данных!");
            }
        }
        public static void StartCpuTest()
        {
            Network.StartSpeedTest();
            btest = new List<DeviceForView>();
            test_speed = new Stopwatch();
            Int64 ram_load = 40000;
            btest.Add(new DeviceForView("Результат RAM", Model.ValueСonvert(ram_load / CPUTest.RAMTest(ram_load) * 1000, "", 1000), ""));
            Int64 storage_load = 400;
            btest.Add(new DeviceForView("Результат системного диска", Model.ValueСonvert(storage_load * 1024 / CPUTest.StorageTest(storage_load) * 1000, "", 1000), ""));
            int cpu_count = Environment.ProcessorCount;
            Logger.AddText("CPUs count: " + cpu_count);
            CPUTest[] test_core = new CPUTest[cpu_count];
            Thread[] thread_test = new Thread[cpu_count];
            for (int cpu = 0; cpu < cpu_count; cpu++)
            {
               // Logger.AddText("Thread starting: " + cpu);
                test_core[cpu] = new CPUTest("Core " + cpu, LOAD);
                thread_test[cpu] = new Thread(test_core[cpu].CPU_Beanch);
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
            Model.MainWindow.SetInfo(btest, TabOfProgramm.general, "Результат тестирования");
        }
    }
}



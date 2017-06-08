using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class CPUTest
    {
        private string name;
        private long load;
        private double[,] mas;
        private static Random r= new Random();
        Stopwatch sWatch;
        double tmp;

        public CPUTest(string thread_name, long thread_load)
        {
            name = thread_name;
            load = thread_load;
            mas = new double[2, load];
            sWatch = new Stopwatch();
            
            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    
                    mas[i, j] = r.NextDouble();
                    
                }

        }



        public static Int64 RAMTest(Int64 load)
        {
            string filename = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "test.xml");
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            Int32 tmp = 0;
            for (Int64 i = 0; i < load; i++) tmp = r.Next(Int32.MinValue, Int32.MaxValue);
            sWatch.Stop();
            return sWatch.ElapsedMilliseconds;
        }


        public static Int64 StorageTest(Int64 load) {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "test.dat");
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            byte[] tmp = new byte[1024];
            r.NextBytes(tmp);
            string result = System.Text.Encoding.UTF8.GetString(tmp);
            for (Int64 i = 0; i < load; i++) {
                File.AppendAllText(filename, result);
            }
            sWatch.Stop();
            File.Delete(filename);
            return sWatch.ElapsedMilliseconds;
        }

        public void CPU_Beanch()
        {
            sWatch.Start();
            for (int j = 0; j < mas.GetLength(1); j++) tmp = mas[0, j] + mas[1, j];
            sWatch.Stop();
            Model.thread_count--;
            if (Model.thread_count < 1) Controller.Thread_Finish();
        }

        public void GetThreadResult()
        {
            double flop = (double)load / sWatch.ElapsedMilliseconds * 1000;
            Logger.AddText("Поток: " + name + " Кол-во операций: " + load + " Производительность ядра:" + Model.ValueСonvert( (long) flop,  "флоп", 1000) , Message_level.debug, Message_type.debug);
        }
    }
}

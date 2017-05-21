using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class CPUTest
    {
        private string name;
        private long load;
        public CPUTest(string thread_name, long thread_load)
        {
            name = thread_name;
            load = thread_load;
        }

        public void CPU_Beanch()
        {

            double[,] mas = new double[2, load];
            Random r = new Random();

            Stopwatch sWatch = new Stopwatch();

            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = r.NextDouble();
                }

            double tmp;
            sWatch.Start();

            for (int j = 0; j < mas.GetLength(1); j++) tmp = mas[0, j] + mas[1, j];
            sWatch.Stop();
            double flop = (double) load / sWatch.ElapsedMilliseconds  * 1000;
            Logger.AddText("Поток: " + name + " Кол-во операций: " + load + " Производительность ядра:" + flop + " флоп", Message_level.debug, Message_type.debug);

        }
    }
}

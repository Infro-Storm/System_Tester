using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class RAMData : Device
    {
        static new string prefix = "RAM_";
        public new static string classWMI = "Win32_PhysicalMemory";
        public RAMData() : base(prefix)
        {

        }
      
    }
}

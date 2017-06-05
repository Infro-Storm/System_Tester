using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class StorageData : Device
    {
        static new string prefix = "SMEMORY_";
        public new static string classWMI = "Win32_DiskDrive";
        public StorageData() : base(prefix)
        {

        }
    }
}

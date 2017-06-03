using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class CatchMemoryData : Device
    {
        static new string prefix = "CMEMORY_";
        public static new string classWMI = "Win32_CacheMemory";
        public CatchMemoryData() : base(prefix)
        {

        }

        public override List<DeviceForView> GetInfo()
        {
            name = props[prefix + "DeviceID"];
            return base.GetInfo();
        }

        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = base.GetInfo();
            return result; 
        }
    }
}

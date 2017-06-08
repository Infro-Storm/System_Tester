using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class TemperatureSensorDate : Device
    {
        static new string prefix = "TSENSORS_";
        public new static string classWMI = "Win32_PerfFormattedData_Counters_ThermalZoneInformation";
        public TemperatureSensorDate() : base(prefix)
        {

        }
                public override List<DeviceForView> GetInfo()
        {
            name = "Сенсоры температуры:";// props[prefix + ""] + " (" + props[prefix + "Name"] + ")";
            ShiftAddPropUnits("Temperature", "C°", -273.15);
          
            return base.GetInfo();
        }
    }
}

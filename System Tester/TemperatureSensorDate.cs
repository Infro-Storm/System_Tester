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
    }
}

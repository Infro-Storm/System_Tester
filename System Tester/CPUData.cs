using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class CPUData : Device
    {
        static new string prefix = "CPU_";
        public new static string classWMI = "Win32_Processor";
        public new string name;
        Dictionary<string, ListViewItem.ListViewSubItem> filds = new Dictionary<string, ListViewItem.ListViewSubItem>();
        
        public CPUData() 
        {
            base.prefix = prefix;
        }

        public void SetFilds(string name, ListViewItem.ListViewSubItem sItem )
        {
            filds.Add(name, sItem);
        }

        public override List<DeviceForView> GetInfo()
        {
            name = props[prefix + "DeviceID"] + " (" + props[prefix + "Name"] + ")";
            props[prefix + "CurrentClockSpeed"] += " МГц";
            props[prefix + "CurrentVoltage"] = (Convert.ToDouble(props[prefix + "CurrentVoltage"]) / 10).ToString() + " В";
            props[prefix + "ExtClock"] += " МГц";
            props[prefix + "LoadPercentage"] += " %";
            props[prefix + "MaxClockSpeed"] += " МГц";
            if (props[prefix + "VirtualizationFirmwareEnabled"].Equals("True")) props[prefix + "VirtualizationFirmwareEnabled"] = "Поддерживается";
            else props[prefix + "VirtualizationFirmwareEnabled"] = "Не поддерживается";
            return base.GetInfo();
        }
    }
}

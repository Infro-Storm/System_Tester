using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class Device
    {
        public Device(ManagementObject instance)
        {
        }
        public virtual List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();
            return result;
        }
    }

    class DeviceWithID : Device
    {
        protected string deviceName;
        public DeviceWithID(ManagementObject instance) : base(instance)
        {
            if (instance["DeviceID"] != null) deviceName = instance["DeviceID"].ToString();
        }
        public override List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();
            result.Add(new DeviceForView("Идентификатор устройства", deviceName, ""));
            return result;
        }
    }

    public class DeviceForView
    {
        string name;
        string value;
        string units;
        public DeviceForView(string name, string value, string units)
        {
            this.name = name;
            this.value = value;
            this.units = units;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Value
        {
            get
            {
                return value;
            }
        }
        public string Unit
        {
            get
            {
                return units;
            }
        }
    }
}

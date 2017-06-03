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
        protected Dictionary<string, string> props = new Dictionary<string, string>();
        protected ManagementObject instance;
        protected static string classWMI;
        protected string prefix;
        public string name = "Unnamed_device";
        public Device()
        {

        }
        public Device(string prefix)
        {
            this.prefix = prefix;

        }

        public Device(ManagementObject instance, string prefix)
        {
            this.prefix = prefix;
            this.instance = instance;

        }

        public virtual void InitDevice(ManagementObject instance)
        {
            this.instance = instance;
            foreach (PropertyData nameprp in instance.Properties)
            {
                if (nameprp.Value != null) props.Add(prefix + nameprp.Name, nameprp.Value.ToString());
            }

        }

        public virtual List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();

            foreach (KeyValuePair<string, string> entry in props) {
                string name = Properties.Resources.ResourceManager.GetString(entry.Key);
                //Logger.AddText("Translated item: \"" + name + '\"');
                if (name==null && Model.showUnknownValue) result.Add(new DeviceForView(entry.Key, entry.Value, ""));
                if (name!=null )result.Add(new DeviceForView(name, entry.Value, ""));
            }
            return result;
        }

        public static List<T> GetDeviceData<T>(string classWMI)
        where T : Device, new()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select * From " + classWMI);//Win32_Processor
            List<T> devices = new List<T>();
            foreach (ManagementObject instance in searcher.Get())
            {
                T newdevice = new T();
                newdevice.InitDevice(instance);
                devices.Add(newdevice);
            }
            return devices;
        }
    }

    /*
    class DeviceWithID : Device
    {
        protected string deviceName;
        public DeviceWithID(ManagementObject instance) : base(instance)
        {
            if (instance["DeviceID"] != null) deviceName = instance["DeviceID"].ToString();
        }
        public override List<DeviceForView> GetInfo(string prefix)
        {
            List<DeviceForView> result = new List<DeviceForView>();
            return result;
        }
    }
    */
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

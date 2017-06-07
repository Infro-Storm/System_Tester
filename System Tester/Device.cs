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
        protected static string classWMI ="";
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
        public virtual void AddPropUnits(string key, string units)
        {
            if (props.TryGetValue(prefix + key, out string tmp_value)) props[prefix + key] += " "+units;
        }

        public virtual void FactorAddPropUnits(string key, string units, double factor)
        {
            if (props.TryGetValue(prefix + key, out string tmp_value)) props[prefix + key] = (Convert.ToInt64(tmp_value) * factor).ToString() + " " + units;
        }

        public virtual void LogicalAddPropUnits(string key)
        {
            if (props.TryGetValue(prefix + key, out string tmp_value))
            {
                if (props[prefix + key].Equals("True")) props[prefix + key] = "Поддерживается";
                else props[prefix + key] = "Не поддерживается";
            }
        }



        public virtual List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();

            foreach (KeyValuePair<string, string> entry in props) {
                string name = Properties.Resources.ResourceManager.GetString(entry.Key);
                Logger.AddText("Translated item: \"" + entry.Key + '\"' + ": " + entry.Value);
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

using System;
using System.Collections.Generic;
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
        
        public CPUData() 
        {
            base.prefix = prefix;
        }
/*
        public CPUData(ManagementObject instance) : base(instance)
        {
            foreach (PropertyData nameprp in instance.Properties)
            {
                string propertyName = nameprp.Name;
                if (instance[propertyName] != null)
                {
                    switch (propertyName)
                    {
                        case "Name":
                            modelNameCPU = instance[propertyName].ToString();
                            break;
                        case "MaxClockSpeed":
                            maxClockCPU = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "DeviceID":
                            break;
                        case "NumberOfCores":
                            coreCount = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "NumberOfLogicalProcessors":
                            logicalCoreCount = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "ProcessorId":
                            processorID = instance[propertyName].ToString();
                            break;
                        default:
                            Logger.AddText(nameprp.Name + " " + instance[nameprp.Name].ToString(), Message_level.debug, Message_type.info);
                            break;
                    }

                }
            } 
        }
        */
        public override List<DeviceForView> GetInfo()
        {
           name = props[prefix + "DeviceID"];
             return base.GetInfo();
        }
        
        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();
           // result.Add()
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class CPUData : DeviceWithID
    {
        string modelNameCPU;
        string processorID;
        Int32 maxClockCPU;
        Int32 cacheSizeL2;
        Int32 cacheSizeL3;
        Int32 coreCount;
        Int32 logicalCoreCount;

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
                        case "L2CacheSize":
                            cacheSizeL2 = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "L3CacheSize":
                            cacheSizeL3 = Convert.ToInt32(instance[propertyName].ToString());
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

        public override List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = base.GetInfo();
            result.Add(new DeviceForView("Название процессора", modelNameCPU, ""));
            result.Add(new DeviceForView("ID процессора", processorID, ""));
            result.Add(new DeviceForView("Максимальная частота", maxClockCPU.ToString(), "МГц"));
            result.Add(new DeviceForView("Размер L2 кэша", cacheSizeL2.ToString(), "Кб"));
            result.Add(new DeviceForView("Размер L3 кэша", cacheSizeL3.ToString(), "Кб"));
            result.Add(new DeviceForView("Количество физ. ядер", coreCount.ToString(), ""));
            result.Add(new DeviceForView("Количество лог. ядер", logicalCoreCount.ToString(), ""));
            return result;
        }
        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = base.GetInfo();
            result.Add(new DeviceForView("Название процессора", modelNameCPU, ""));
            result.Add(new DeviceForView("Максимальная частота", maxClockCPU.ToString(), "МГц"));
            return result;
        }
    }
}

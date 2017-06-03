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
        string storageCaption;
        string serialNumber;
        string storageFirmware;
        string storageInterface;
        string storageModel;
        Int32 diskPartitions;
        Int64 storageSize;
        static string prefix = "SMEMORY_";
        public StorageData(ManagementObject instance) : base(instance, prefix)
        {/*
            foreach (PropertyData nameprp in instance.Properties)
            {
                string propertyName = nameprp.Name;
                if (instance[propertyName] != null)
                {
                    switch (propertyName)
                    {
                        case "Caption":
                            storageCaption = instance[propertyName].ToString();
                            break;
                        case "FirmwareRevision":
                            storageFirmware = instance[propertyName].ToString();
                            break;
                        case "DeviceID":
                            break;
                        case "InterfaceType":
                            storageInterface = instance[propertyName].ToString();
                            break;
                        case "Model":
                            storageModel = instance[propertyName].ToString();
                            break;
                        case "Partitions":
                            diskPartitions = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "Size":
                            storageSize = Convert.ToInt64(instance[propertyName].ToString());
                            break;
                        case "SerialNumber":
                            serialNumber = instance[propertyName].ToString();
                            break;
                        default:
                            Logger.AddText(nameprp.Name + " " + instance[nameprp.Name].ToString(), Message_level.debug, Message_type.info);
                            break;
                    }

                }
            }*/
        }
        /*
        public List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = base.GetInfo("SMEMORY");
            result.Add(new DeviceForView("Название устройства", storageCaption, ""));
            result.Add(new DeviceForView("Серийный номер", serialNumber, ""));
            result.Add(new DeviceForView("Версия прошивки", storageFirmware, ""));
            result.Add(new DeviceForView("Интерфейс", storageInterface.ToString(), ""));
            result.Add(new DeviceForView("Модель", storageModel.ToString(), ""));
            result.Add(new DeviceForView("Разделов на диске", diskPartitions.ToString(), ""));
            result.Add(new DeviceForView("Ёмкость", Model.ValueСonvert( storageSize, "б", 1024), ""));
            return result;
        }*/
        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = base.GetInfo();/*
            result.Add(new DeviceForView("Название устройства", storageCaption, ""));
            result.Add(new DeviceForView("Ёмкость", Model.ValueСonvert(storageSize, "б", 1024), ""));*/
            return result;
        }
    }
}

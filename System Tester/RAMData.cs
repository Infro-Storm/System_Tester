using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class RAMData : Device
    {
        MemoryFormFactor fFactor;
        MemoryType type;
        string bankLabel;
        string deviceLocator;
        string manufacturer;
        string partNumber;
        string serialNumber;
        Int64 capacityRAM;
        Int32 speed;
        Int32 configuredClockSpeed;
        static string prefix = "RAM_";
        public RAMData(ManagementObject instance) : base(instance, prefix)
        {/*
            foreach (PropertyData nameprp in instance.Properties)
            {
                string propertyName = nameprp.Name;
                if (instance[propertyName] != null)
                {
                    switch (propertyName)
                    {
                        case "BankLabel":
                            bankLabel = instance[propertyName].ToString();
                            break;
                        case "Capacity":
                            capacityRAM = Convert.ToInt64(instance[propertyName].ToString());
                            break;
                        case "DeviceID":
                            break;
                        case "ConfiguredClockSpeed":
                            configuredClockSpeed = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "Speed":
                            speed = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "FormFactor":
                            fFactor = (MemoryFormFactor)Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "MemoryType":
                            type = (MemoryType)Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "PartNumber":
                            partNumber = instance[propertyName].ToString();
                            break;
                        case "Manufacturer":
                            manufacturer = instance[propertyName].ToString();
                            break;
                        case "SerialNumber":
                            serialNumber = instance[propertyName].ToString();
                            break;
                        case "DeviceLocator":
                            deviceLocator = instance[propertyName].ToString();
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
            List<DeviceForView> result = base.GetInfo("RAM");
            result.Add(new DeviceForView("Производитель", manufacturer, ""));
            result.Add(new DeviceForView("Модель", partNumber, ""));
            result.Add(new DeviceForView("Установленная частота", configuredClockSpeed.ToString(), "МГц"));
            result.Add(new DeviceForView("Частота", speed.ToString(), "МГц"));
            result.Add(new DeviceForView("Объем памяти модуля", Model.ValueСonvert(capacityRAM, "б", 1024), ""));//Величина генерируется конвертером
            result.Add(new DeviceForView("Банк памяти", bankLabel, ""));
            result.Add(new DeviceForView("Слот", deviceLocator, ""));
            result.Add(new DeviceForView("Форм-фактор", fFactor.ToString(), ""));
            result.Add(new DeviceForView("Тип памяти", type.ToString(), ""));
            result.Add(new DeviceForView("Серийный номер", serialNumber, ""));
            return result;
        }*/
     
        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = base.GetInfo();/*
            result.Add(new DeviceForView("Производитель", manufacturer, ""));
            result.Add(new DeviceForView("Частота", speed.ToString(), "МГц"));
            result.Add(new DeviceForView("Объем памяти модуля", Model.ValueСonvert(capacityRAM, "б", 1024), ""));//Величина генерируется конвертером*/
            return result;
        }

    }
}

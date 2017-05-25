using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{
    class CatchMemoryData : Device
    {
        string purposeMemory;
        Int32 size;
        CacheLevel levelMemory;
        ErrorCorrection errorCorrection;
        CacheType CacheType;

        public CatchMemoryData(ManagementObject instance) : base(instance)
        {
            foreach (PropertyData nameprp in instance.Properties)
            {
                string propertyName = nameprp.Name;
                if (instance[propertyName] != null)
                {
                    switch (propertyName)
                    {
                        case "Purpose":
                            purposeMemory = instance[propertyName].ToString();
                            break;
                        case "InstalledSize":
                            size = Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "Level":
                            levelMemory = (CacheLevel) Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "ErrorCorrectType":
                            errorCorrection =(ErrorCorrection) Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "CacheType":
                            CacheType = (CacheType) Convert.ToInt32(instance[propertyName].ToString());
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
            result.Add(new DeviceForView("Название кэш-памяти", purposeMemory, ""));
            result.Add(new DeviceForView("Размер кэш-памяти", size.ToString(), "Кб"));
            result.Add(new DeviceForView("Уровень кэш-памяти", levelMemory.ToString(), ""));
            result.Add(new DeviceForView("Коррекция ошибок", errorCorrection.ToString(), ""));
            result.Add(new DeviceForView("Назначение кэш-памяти", CacheType.ToString(), ""));
            return result;
        }
        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = base.GetInfo();
            return result; 
        }
    }
}

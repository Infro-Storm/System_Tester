using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;



namespace System_Tester
{
    //enum перечисления:
    public enum Message_type : byte
    {
        error,
        info,
        test,
        debug,
        warning
    }
    public enum Message_level : byte
    {
        normal,
        debug,
        full_log,
    }
    public enum TabOfProgramm : byte
    {
        general,
        cpu,
        ram,
        storage,
        network
    }

    public enum MemoryFormFactor : byte
    {
        Unknown = 0,
        Other = 1,
        SIP = 2,
        DIP = 3,
        ZIP = 4,
        SOJ = 5,
        Proprietary = 6,
        SIMM = 7,
        DIMM = 8,
        TSOP = 9,
        PGA = 10,
        RIMM = 11,
        SODIMM = 12,
        SRIMM = 13,
        SMD = 4,
        SSMP = 15,
        QFP = 16,
        TQFP = 17,
        SOIC = 18,
        LCC = 19,
        PLCC = 20,
        BGA = 21,
        FPBGA = 22,
        LGA = 23
    }
    public enum MemoryType : byte
    {
        Unknown = 0,
        Other = 1,
        DRAM = 2,
        SynchronousDRAM = 3,
        CacheDRAM = 4,
        EDO = 5,
        EDRAM = 6,
        VRAM = 7,
        SRAM = 8,
        RAM = 9,
        ROM = 10,
        Flash = 11,
        EEPROM = 12,
        FEPROM = 13,
        EPROM = 14,
        CDRAM = 15,
        RAM3D = 16,
        SDRAM = 17,
        SGRAM = 18,
        RDRAM = 19,
        DDR = 20,
        DDR2 = 21,
        DDR2FB = 22,
        DIMM = 23,
        DDR3 = 24,
        FBD2 = 25,
    }

    static class Model
    {
        //Глобальные переменные
        static bool debug_mode = false;
        static LogView loggerWindow;
        static MainView mainView;
        //Геттеры и сеттеры
        public static bool Debug_mode
        {
            get
            {
                return debug_mode;
            }
        }
        public static LogView LoggerWindow
        {
            get
            {
                return loggerWindow;
            }
        }
        public static string ValueСonvert(Int64 value, string units)
        {
            if (value > 1099511627776)  return (value / 1099511627776).ToString() + " Т" + units;   //Тера
            if (value > 1073741824)     return (value / 1073741824).ToString() + " Г" + units;      //Гига
            if (value > 1048576)        return (value / 1048576).ToString() + " М" + units;         //Мега
            if (value > 1024)           return (value / 1024).ToString() + " К" + units;            //Кило
            return value.ToString() + " " + units;
        }

        //
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainView = new MainView();
            Application.Run(mainView);
        }

        public static void Debug_state_init()
        {
            loggerWindow = new LogView();
            loggerWindow.Show();
            debug_mode = true;
            Logger.AddText("Вход в режим отладки", Message_level.normal, Message_type.info);
        }

        public static void Debug_state_destroy()
        {
            loggerWindow.Close();
            loggerWindow = null;
            debug_mode = false;
            Logger.AddText("Выход из режима отладки", Message_level.normal, Message_type.info);
        }

        public static void GetCompuerData()
        {
            foreach (CPUData cpu in GetCPUData())
            {
                mainView.SetInfo(cpu.GetShortInfo(), TabOfProgramm.general);
                mainView.SetInfo(cpu.GetInfo(), TabOfProgramm.cpu);
            }

            foreach (RAMData ram in GetRAMData())
            {
                mainView.SetInfo(ram.GetShortInfo(), TabOfProgramm.general);
                mainView.SetInfo(ram.GetInfo(), TabOfProgramm.ram);
            }
        }
        private static List<CPUData> GetCPUData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select * From Win32_Processor");
            List<CPUData> CPUs = new List<CPUData>();
            foreach (ManagementObject instance in searcher.Get()) CPUs.Add(new CPUData(instance));
            return CPUs;
        }
        private static List<RAMData> GetRAMData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select * From Win32_PhysicalMemory");
            List<RAMData> RAMs = new List<RAMData>();
            foreach (ManagementObject instance in searcher.Get()) RAMs.Add(new RAMData(instance));
            return RAMs;
        }
    }

    class Device {
        public Device(ManagementObject instance)
        {
        }
        public virtual List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();
            return result;
        }
    }

    class DeviceWithID:Device
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

    public class DeviceForView {
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

    class CPUData : DeviceWithID
    {
        string modelNameCPU;
        string processorID;
        Int32 maxClockCPU;
        Int32 cacheSizeL2;
        Int32 cacheSizeL3;
        Int32 coreCount;
        Int32 logicalCoreCount;
        
        public CPUData(ManagementObject instance) : base (instance)
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

        public RAMData(ManagementObject instance) :base(instance)
        {
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
                            fFactor =(MemoryFormFactor) Convert.ToInt32(instance[propertyName].ToString());
                            break;
                        case "MemoryType":
                            type = (MemoryType) Convert.ToInt32(instance[propertyName].ToString());
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
            }
        }

        public override List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = base.GetInfo();
            result.Add(new DeviceForView("Производитель", manufacturer, ""));
            result.Add(new DeviceForView("Модель", partNumber, ""));
            result.Add(new DeviceForView("Установленная частота", configuredClockSpeed.ToString(), "МГц"));
            result.Add(new DeviceForView("Частота", speed.ToString(), "МГц"));
            result.Add(new DeviceForView("Объем памяти модуля", Model.ValueСonvert( capacityRAM, "б") , ""));//Величина генерируется конвертером
            result.Add(new DeviceForView("Банк памяти", bankLabel, ""));
            result.Add(new DeviceForView("Слот", deviceLocator, ""));
            result.Add(new DeviceForView("Форм-фактор", fFactor.ToString(), ""));
            result.Add(new DeviceForView("Тип памяти", type.ToString(), ""));
            result.Add(new DeviceForView("Серийный номер", serialNumber, ""));
            return result;
        }
        public List<DeviceForView> GetShortInfo()
        {
            List<DeviceForView> result = base.GetInfo();
            result.Add(new DeviceForView("Производитель", manufacturer, ""));
            result.Add(new DeviceForView("Частота", speed.ToString(), "МГц"));
            result.Add(new DeviceForView("Объем памяти модуля", Model.ValueСonvert(capacityRAM, "б"), ""));//Величина генерируется конвертером
            return result;
        }
        
    }
}

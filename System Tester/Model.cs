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
        }
        private static List<CPUData> GetCPUData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select * From Win32_Processor");
            List<CPUData> CPUs = new List<CPUData>();
            foreach (ManagementObject instance in searcher.Get()) CPUs.Add(new CPUData(instance));
            return CPUs;
        }
    }

    class Device {
        protected string deviceName;
        public Device(ManagementObject instance) {
            if (instance["DeviceID"] != null)  deviceName = instance["DeviceID"].ToString();
        }
        public virtual List<DeviceForView> GetInfo()
        {
            List<DeviceForView> result = new List<DeviceForView>();
            result.Add(new DeviceForView("Идентификатор устройства", deviceName, "") );
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

    class CPUData : Device
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
}

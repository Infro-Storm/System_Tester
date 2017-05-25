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

    public enum CacheType : byte
    {
        Другое = 1,
        Неизвестный = 2,
        Инструкция = 3,
        Данные = 4,
        Унифицированный = 5
    }

    public enum ErrorCorrection : byte
    {
        Резервирование = 0,
        Другой = 1,
        Неизвестный = 2,
        Отсутствует = 3,
        Четность = 4,
        Однобитовая = 5,
        Многобитовая = 6
    }
    public enum CacheLevel : byte
    {
        Другой = 1,
        Неизвестный = 2,
        Первый = 3,
        Второй = 4,
        Третий = 5,
        Неприменимо = 6,
    }

    static class Model
    {
        //Глобальные переменные
        static bool debug_mode = false;
        static LogView loggerWindow;
        static MainView mainView;
        public static Int32 thread_count = 0;
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

        public static MainView MainWindow
        {
            get
            {
                return mainView;
            }
        }
        public static string ValueСonvert(Int64 value, string units, Int32 factor)
        {
            if (value > Math.Pow(factor, 4))   return (value / Math.Pow(factor, 4)).ToString() + " Т" + units;  //Тера
            if (value > Math.Pow(factor, 3))   return (value / Math.Pow(factor, 3)).ToString() + " Г" + units;  //Гига
            if (value > Math.Pow(factor, 2))   return (value / Math.Pow(factor, 2)).ToString() + " М" + units;  //Мега
            if (value > factor)         return (value / factor).ToString() + " К" + units;      //Кило
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

            foreach (StorageData storage in GetStorageData())
            {
                mainView.SetInfo(storage.GetShortInfo(), TabOfProgramm.general);
                mainView.SetInfo(storage.GetInfo(), TabOfProgramm.storage);
            }
            foreach (CatchMemoryData catchMemory in GetCatchData())
            { 
               mainView.SetInfo(catchMemory.GetShortInfo(), TabOfProgramm.general);
               mainView.SetInfo(catchMemory.GetInfo(), TabOfProgramm.cpu); 
            }
            foreach (TemperatureSensorDate catchMemory in GetTemperatureSensorDate())
            {
                mainView.SetInfo(catchMemory.GetShortInfo(), TabOfProgramm.general);
                mainView.SetInfo(catchMemory.GetInfo(), TabOfProgramm.general);
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

        private static List<StorageData> GetStorageData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select * From Win32_DiskDrive");
            List<StorageData> Storages = new List<StorageData>();
            foreach (ManagementObject instance in searcher.Get()) Storages.Add(new StorageData(instance));
            return Storages;
        }
        private static List<CatchMemoryData> GetCatchData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select * From Win32_CacheMemory");
            List<CatchMemoryData> Storages = new List<CatchMemoryData>();
            foreach (ManagementObject instance in searcher.Get()) Storages.Add(new CatchMemoryData(instance));
            return Storages; 
        }

        private static List<TemperatureSensorDate> GetTemperatureSensorDate()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "Select * From MSAcpi_ThermalZoneTemperature");
            List<TemperatureSensorDate> Storages = new List<TemperatureSensorDate>();
            //foreach (ManagementObject instance in searcher.Get()) Storages.Add(new TemperatureSensorDate(instance));
            return Storages;
        }
    }






}

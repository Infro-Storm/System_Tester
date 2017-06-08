using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Resources;
using System.Threading;

namespace System_Tester
{
    //enum перечисления:
    //Здесь всякие удобные типы которые понятны (Исползуются вместо чисел, для обозночение того или иного свойства)

    //Объявляем типы сообщений в логе
    //Влияет на отображение в журнале событий
    public enum Message_type : byte
    {
        error,  //Ошибка
        info,   //Информация
        test,   //Тестовое сообщение
        debug,  //Отладка
        warning //Предупреждение
    }

    //Объявляем уровни журналирования
    public enum Message_level : byte
    {
        normal,     //Нормальный лог
        debug,      //Отладочный лог
        full_log,   //Показывать все
    }

    //Объявляем вкладки программы
    public enum TabOfProgramm : byte
    {
        general,    //Общая информация
        cpu,        //О ЦП
        ram,        //Об ОЗУ
        storage,    //О устройствах хранения информации
        network     //Сеть
    }


    //Объявляем форм факторы оперативной памяти, можно использовать для отображения
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

    //Объявляем типы памяти, можно использовать для отображения
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

    //Типы данных для которых используется данная кэш память
    public enum CacheType : byte
    {
        Другое = 1,
        Неизвестный = 2,
        Инструкция = 3,
        Данные = 4,
        Унифицированный = 5
    }

    //Типы коррекции ошибок кэш-памяти
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

    //Уровни кэша
    public enum CacheLevel : byte
    {
        Другой = 1,
        Неизвестный = 2,
        Первый = 3,
        Второй = 4,
        Третий = 5,
        Неприменимо = 6,
    }

    //Класс модели
    static class Model
    {
        //Глобальные переменные
        static bool debug_mode = false;             //Переменная отвечающая за состояние окна журналирования
        static LogView loggerWindow;                //Экземпляр окна журнала
        static MainView mainView;                   //Экземпляр главного окна
        public static Int32 thread_count = 0;       //Количество потоков процессора (Используется для расчета и запуска тестирования CPU)
        public static bool showUnknownValue = false;//Если False то программа скрывает неизвестные значения которые вернул WMI. Используется для отладки.
        public static Int32 networkPort = 9000;     //UDP порт использующийся для сетевого обмена
        //Геттеры и сеттеры
        public static bool Debug_mode               //Возвращает состояние окна журналирования (Переменная debug_mode)
        {
            get
            {
                return debug_mode;
            }
        }

        public static LogView LoggerWindow          //Возвращает экземпляр окна журналирования
        {
            get
            {
                return loggerWindow;
            }
        }

        public static MainView MainWindow           //Возвращает экземпляр главного окна
        {
            get
            {
                return mainView;
            }
        }
        //Функция преобразования по системе СИ (Кило, Мега, Гига, Тера)
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

        //Функция инициализации окна журнала
        public static void Debug_state_init()
        {
            loggerWindow = new LogView();
            loggerWindow.Show();
            debug_mode = true;
            Logger.AddText("Вход в режим отладки", Message_level.normal, Message_type.info);
        }

        //Функция отключения окна журнала
        public static void Debug_state_destroy()
        {
            loggerWindow.Close();
            loggerWindow = null;
            debug_mode = false;
            Logger.AddText("Выход из режима отладки", Message_level.normal, Message_type.info);
        }

        //Функция получения WMI информации об узлах компьютера
        public static void GetCompuerData()
        {
            //Вызываем универсальный метод у родительского класса DEVICE с типом CPUDate и дополнительно берем и докидываем статическое поле 
            //С названием класса WMI из которого можно почерпнуть информации об устройствах данного типа установленных в данной машине.
            foreach (CPUData cpu in Device.GetDeviceData<CPUData>(CPUData.classWMI))//В ответ данная функция возвращает массив устройств заданного типа
                mainView.SetInfo(cpu.GetInfo(), TabOfProgramm.cpu, cpu.name);//У каждого устройства вызывается метод GetInfo, реализация которого в основном
                                                                             //Лежит в методе родительского класса. GetInfo возвращает лист специальных классов
                                                                             //DeviceForView. Этот лист метод SetInfo обрабатывает и выводит в заданные ListView на главном окне 
           //Реализация выгрузки инфы по другим типам устройств иденитчна.
            foreach (RAMData ram in Device.GetDeviceData<RAMData>(RAMData.classWMI))
                mainView.SetInfo(ram.GetInfo(), TabOfProgramm.ram, ram.name);
            

            foreach (StorageData storage in Device.GetDeviceData<StorageData>(StorageData.classWMI))
                mainView.SetInfo(storage.GetInfo(), TabOfProgramm.storage, storage.name);
            
            foreach (CatchMemoryData catchMemory in Device.GetDeviceData<CatchMemoryData>(CatchMemoryData.classWMI))
               mainView.SetInfo(catchMemory.GetInfo(), TabOfProgramm.cpu, catchMemory.name); 
            
            foreach (TemperatureSensorDate TempSensor in Device.GetDeviceData<TemperatureSensorDate>(TemperatureSensorDate.classWMI))
                mainView.SetInfo(TempSensor.GetInfo(), TabOfProgramm.general, TempSensor.name);
            
        }
    }
}

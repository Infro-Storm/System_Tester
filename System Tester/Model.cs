using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;



namespace System_Tester
{
    static class Model
    {
        //Глобальные переменные
        static bool debug_mode = false;
        static LogView loggerWindow;
        //Геттеры и сеттеры
        public static bool Debug_mode {
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
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
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

        static string[] GetCompuerData() {
            // Get the WMI class
            ManagementClass processClass =
                new ManagementClass();
            processClass.Path = new
                ManagementPath("Win32_Process");

            // Get the methods in the class
            MethodDataCollection methods =
                processClass.Methods;

            // display the methods
            Console.WriteLine("Method Names: ");
            foreach (MethodData method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine();

            // Get the properties in the class
            PropertyDataCollection properties =
                processClass.Properties;

            // display the properties
            Console.WriteLine("Property Names: ");
            foreach (PropertyData property in properties)
            {
                Console.WriteLine(property.Name);
            }
            Console.WriteLine();

            // Get the Qualifiers in the class
            QualifierDataCollection qualifiers =
                processClass.Qualifiers;

            // display the qualifiers
            Console.WriteLine("Qualifier Names: ");
            foreach (QualifierData qualifier in qualifiers)
            {
                Console.WriteLine(qualifier.Name);
            }
            return null;
        }
    }
}

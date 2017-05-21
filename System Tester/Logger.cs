using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Tester
{



    static class Logger

    {
        public delegate void RefreshLog(List<Log_message> log_msg_list);
        public static event RefreshLog OnRefresh;
        static List<Log_message> log_text = new List<Log_message>();


        public static void AddText(string new_messag, Message_level level, Message_type type)
        {
            log_text.Add(new Log_message(new_messag, level, type));
            OnRefresh?.Invoke(log_text);
        }
        public static void AddText(string new_messag)
        {
            AddText(new_messag, Message_level.normal, Message_type.test);
        }
    }
    public class Log_message
    {
        string message;
        Message_type type;
        Message_level level;
        DateTime datetime;

        public string Message {
            get {
                return message;
            }
        }

        public Message_type Type
        {
            get
            {
                return type;
            }
        }

        public Message_level Level 
        {
            get
            {
                return level;
            }
        }

        public DateTime Datetime
        {
            get
            {
                return datetime;
            }
        }

        public Log_message(string str, Message_level level, Message_type type)
        {
            message = str;
            this.level = level;
            this.type = type;
            datetime = DateTime.Now;
        }

    }
}

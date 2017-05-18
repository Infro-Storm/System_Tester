using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Tester
{
    public partial class LogView : Form
    {
        public LogView()
        {
            InitializeComponent();
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            
            Logger.OnRefresh += Model.LoggerWindow.LogRefresh;
        }

        public void LogRefresh(List<Log_message>lst)
        {
            LogView_rtb.Text = null;
            foreach (Log_message msg in lst)
            {
                Color color = Color.Black;
                switch (msg.Type) {
                    case Message_type.debug:
                        color = Color.Blue;
                        break;
                    case Message_type.error:
                        color = Color.Red;
                        break;
                    case Message_type.info:
                        color = Color.Black;
                        break;
                    case Message_type.test:
                        color = Color.BlueViolet;
                        break;
                    case Message_type.warning:
                        color = Color.Orange;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }
                LogView_rtb.SelectionColor = color;
                LogView_rtb.AppendText(msg.Datetime.ToString() +  ": " + msg.Message + Environment.NewLine);
            }
        }

        private void LogView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Alt) Controller.ChangeDebugMode();
        }

        private void LogView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.OnRefresh -= Model.LoggerWindow.LogRefresh;
        }
    }
}

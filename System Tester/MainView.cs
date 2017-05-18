using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Tester
{

    public partial class MainView : Form
    {
        public static MainView RunWindowEx;
        public static MainView GetRWE() {
            return RunWindowEx;
        }
        public MainView()
        {
            InitializeComponent();
            RunWindowEx = this;
        }

        private void MainTabs_Click(object sender, EventArgs e)
        {

        }
        public void ShowMessage(string str)
        {
            MessageBox.Show(str);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {









        }

        private void MainView_Load(object sender, EventArgs e)
        {
            //   if (Model.debug_mode) Controller.initDebugMode();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label newlbl = new Label();
            newlbl.Text = "test";
            GeneralAnalysisTbl.Controls.Add(newlbl, 0, 1 );
            Logger.AddText("debug", Message_level.debug, Message_type.debug);
            Logger.AddText("error", Message_level.debug, Message_type.error);
            Logger.AddText("info", Message_level.debug, Message_type.info);
            Logger.AddText("test", Message_level.debug, Message_type.test);
            Logger.AddText("warning", Message_level.debug, Message_type.warning);

        }

        private void GeneralAnalysisTab_Click(object sender, EventArgs e)
        {

        }


        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Alt) Controller.ChangeDebugMode();
        }
    }
}

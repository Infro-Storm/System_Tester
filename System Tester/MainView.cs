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
        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {









        }

        private void MainView_Load(object sender, EventArgs e)
        {
            //   if (Model.debug_mode) Controller.initDebugMode();
            Controller.GetSystemInfo();
        }
        public void SetInfo(List<DeviceForView> newfilds, TabOfProgramm tab)
        {
            foreach (DeviceForView filds in newfilds)
            {
                Label NameLabel = new Label();
                NameLabel.Text = filds.Name + ":";
                NameLabel.AutoSize = true;
                Label ValueLable = new Label();
                ValueLable.Text = filds.Value;
                ValueLable.AutoSize = true;
                if (filds.Unit != "") ValueLable.Text += " " + filds.Unit;
                switch (tab)
                {
                    case TabOfProgramm.general:
                        GeneralAnalysisTbl.Controls.Add(NameLabel);
                        GeneralAnalysisTbl.Controls.Add(ValueLable);
                        break;
                    case TabOfProgramm.cpu:
                        cpuPanel.Controls.Add(NameLabel);
                        cpuPanel.Controls.Add(ValueLable);
                        break;
                    case TabOfProgramm.network:
                        NetworkTab.Controls.Add(NameLabel);
                        NetworkTab.Controls.Add(ValueLable);
                        break;
                    case TabOfProgramm.ram:
                        RAMTab.Controls.Add(NameLabel);
                        RAMTab.Controls.Add(ValueLable);
                        break;
                    case TabOfProgramm.storage:
                        StorageTab.Controls.Add(NameLabel);
                        StorageTab.Controls.Add(ValueLable);
                        break;
                    default:
                        GeneralAnalysisTab.Controls.Add(NameLabel);
                        GeneralAnalysisTab.Controls.Add(ValueLable);
                        break;
                }
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Label newlbl = new Label();
            newlbl.Text = "test";
            GeneralAnalysisTbl.Controls.Add(newlbl, 0, 1 );

        }

        private void GeneralAnalysisTab_Click(object sender, EventArgs e)
        {

        }


        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Alt) Controller.ChangeDebugMode();
        }

        private void CPUAnalysisTab_Enter(object sender, EventArgs e)
        {
            Logger.AddText("Открыта вкладка CPU");
        }
    }
}

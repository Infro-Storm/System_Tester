using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Tester
{

    public partial class MainView : Form
    {
        delegate void setInfoDelegate(List<DeviceForView> newfilds, TabOfProgramm tab, string name);
        public static MainView RunWindowEx;
        ResourceManager rm = new ResourceManager("MainView", typeof(MainView).Assembly);
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
            Thread refreser = new Thread(Controller.GetSystemInfo);
            refreser.Start();
           // MessageBox.Show(Properties.Resources.ResourceManager.GetString("CPU_NAME"));
        }
        public void SetInfo(List<DeviceForView> newfilds, TabOfProgramm tab, string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new setInfoDelegate(SetInfo), new object[] { newfilds, tab, name });
                return;
            }

            ListView listView;

            switch (tab)
            {
                case TabOfProgramm.general:
                    listView = GeneralListView;
                    break;
                case TabOfProgramm.cpu:
                    listView = CPU_ListView;
                    break;
                case TabOfProgramm.ram:
                    listView = RAMListView;
                    break;
                case TabOfProgramm.network:
                    listView = networkListView;
                    break;
                case TabOfProgramm.storage:
                    listView = storageListView;
                    break;
                default:
                    listView = GeneralListView;
                    break;
            }
            ListViewGroup group = new ListViewGroup();
            group.Header = name;
            listView.Groups.Add(group);
            foreach (DeviceForView filds in newfilds)
            {
                ListViewItem item = new ListViewItem();
                item.Text = filds.Name;
                item.SubItems.Add(filds.Value);
                item.Group = group;
                listView.Items.Add(item);
                listView.Columns[0].Width = -2;
                listView.Columns[1].Width = -2;
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Controller.StartCpuTest();
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

        private void CPU_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

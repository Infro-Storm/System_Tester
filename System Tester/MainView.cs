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
        delegate void renewValueDelegate(TabOfProgramm tab, string valueName, string value);
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
        public void RenewValue(TabOfProgramm tab, string valueName, string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new renewValueDelegate(RenewValue), new object[] { tab, valueName, value });
                return;
            }
            try
            {
                // ListView list = SelectTab(tab);
                // list.Items[valueName].SubItems["first"].Text = value;
            }
            catch (Exception e)
            {
                Logger.AddText(e.ToString(), Message_level.normal, Message_type.error);
            }
        }
        public void NewNeighbor(string ip, string name)
        {
            List<DeviceForView> list = new List<DeviceForView>();
            list.Add(new DeviceForView(name, ip, ""));
            SetInfo(list, TabOfProgramm.network, "Компьютеры в сети");
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        public void ShowMessage(string title, string message, Message_type type )
        {
            MessageBoxIcon msgIco;
            switch (type)
            {
                case Message_type.error:
                    msgIco = MessageBoxIcon.Error;
                        break;
                case Message_type.info:
                    msgIco = MessageBoxIcon.Asterisk;
                    break;
                case Message_type.warning:
                    msgIco = MessageBoxIcon.Warning;
                    break;
                default:
                    msgIco = MessageBoxIcon.None;
                    break;
            }
            MessageBox.Show(message, title , MessageBoxButtons.OK,  msgIco);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            //   if (Model.debug_mode) Controller.initDebugMode();
            Thread refreser = new Thread(Controller.GetSystemInfo);
            refreser.Start();
           // MessageBox.Show(Properties.Resources.ResourceManager.GetString("CPU_NAME"));
        }

        public ListView SelectTab(TabOfProgramm tab) {
            ListView result;
            switch (tab)
            {
                case TabOfProgramm.general:
                    result = GeneralListView;
                    break;
                case TabOfProgramm.cpu:
                    result = CPU_ListView;
                    break;
                case TabOfProgramm.ram:
                    result = RAMListView;
                    break;
                case TabOfProgramm.network:
                    result = networkListView;
                    break;
                case TabOfProgramm.storage:
                    result = storageListView;
                    break;
                default:
                    result = GeneralListView;
                    break;
            }
            return result;
        }

        public void SetInfo(List<DeviceForView> newfilds, TabOfProgramm tab, string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new setInfoDelegate(SetInfo), new object[] { newfilds, tab, name });
                return;
            }            
            ListView listView = SelectTab(tab);
            ListViewGroup group;
            if (listView.Groups[name] == null)
            {
                group = new ListViewGroup();
                group.Header = name;
                group.Name = name;
                listView.Groups.Add(group);
            }
            else
            {
                group = listView.Groups[name];
            }
            foreach (DeviceForView filds in newfilds)
            {
                ListViewItem item = new ListViewItem();
                item.Text = filds.Name;
                ListViewItem.ListViewSubItem sItem = new ListViewItem.ListViewSubItem();
                sItem.Text = filds.Value;
                item.SubItems.Add(sItem);
                item.Group = group;
                if (tab == TabOfProgramm.network) item.ImageIndex = 0;
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

        private void NetworkListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NetworkListView_DoubleClick(object sender, EventArgs e)
        {
           // MessageBox.Show("Вы выбрали!");
        }

        private void NetworkListView_ItemActivate(object sender, EventArgs e)
        {
            string ipaddr = networkListView.SelectedItems[0].SubItems[1].Text;
            Network.SetNeighbor(ipaddr);
            ShowMessage("Выбран сосед для теста скорости с IP:" + ipaddr);
        }
    }
}

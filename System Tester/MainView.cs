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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller.GetTestMessage();
        }
    }
}

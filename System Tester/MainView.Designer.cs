namespace System_Tester
{
    partial class MainView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralAnalysisTab = new System.Windows.Forms.TabPage();
            this.CPUAnalysisTab = new System.Windows.Forms.TabPage();
            this.CPU_ListView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RAMAnalysisTab = new System.Windows.Forms.TabPage();
            this.DSAnalysisTab = new System.Windows.Forms.TabPage();
            this.TCNAnalysisTab = new System.Windows.Forms.TabPage();
            this.GeneralListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RAMListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.storageListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.networkListView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralAnalysisTab.SuspendLayout();
            this.CPUAnalysisTab.SuspendLayout();
            this.RAMAnalysisTab.SuspendLayout();
            this.DSAnalysisTab.SuspendLayout();
            this.TCNAnalysisTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 379);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(260, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "Запустить тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.GeneralAnalysisTab);
            this.tabControl1.Controls.Add(this.CPUAnalysisTab);
            this.tabControl1.Controls.Add(this.RAMAnalysisTab);
            this.tabControl1.Controls.Add(this.DSAnalysisTab);
            this.tabControl1.Controls.Add(this.TCNAnalysisTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 323);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 4;
            // 
            // GeneralAnalysisTab
            // 
            this.GeneralAnalysisTab.Controls.Add(this.GeneralListView);
            this.GeneralAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralAnalysisTab.Name = "GeneralAnalysisTab";
            this.GeneralAnalysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.GeneralAnalysisTab.TabIndex = 0;
            this.GeneralAnalysisTab.Text = "Общий анализ";
            this.GeneralAnalysisTab.UseVisualStyleBackColor = true;
            this.GeneralAnalysisTab.Click += new System.EventHandler(this.GeneralAnalysisTab_Click);
            // 
            // CPUAnalysisTab
            // 
            this.CPUAnalysisTab.Controls.Add(this.CPU_ListView);
            this.CPUAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.CPUAnalysisTab.Name = "CPUAnalysisTab";
            this.CPUAnalysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.CPUAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.CPUAnalysisTab.TabIndex = 1;
            this.CPUAnalysisTab.Text = "Анализ ЦП";
            this.CPUAnalysisTab.UseVisualStyleBackColor = true;
            this.CPUAnalysisTab.Enter += new System.EventHandler(this.CPUAnalysisTab_Enter);
            // 
            // CPU_ListView
            // 
            this.CPU_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});
            this.CPU_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPU_ListView.Location = new System.Drawing.Point(3, 3);
            this.CPU_ListView.Name = "CPU_ListView";
            this.CPU_ListView.Size = new System.Drawing.Size(362, 291);
            this.CPU_ListView.TabIndex = 0;
            this.CPU_ListView.UseCompatibleStateImageBehavior = false;
            this.CPU_ListView.View = System.Windows.Forms.View.Details;
            this.CPU_ListView.SelectedIndexChanged += new System.EventHandler(this.CPU_ListView_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Название";
            this.columnName.Width = 62;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Значение";
            this.columnValue.Width = 333;
            // 
            // RAMAnalysisTab
            // 
            this.RAMAnalysisTab.Controls.Add(this.RAMListView);
            this.RAMAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.RAMAnalysisTab.Name = "RAMAnalysisTab";
            this.RAMAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.RAMAnalysisTab.TabIndex = 2;
            this.RAMAnalysisTab.Text = "Анализ ОЗУ";
            this.RAMAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // DSAnalysisTab
            // 
            this.DSAnalysisTab.Controls.Add(this.storageListView);
            this.DSAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.DSAnalysisTab.Name = "DSAnalysisTab";
            this.DSAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.DSAnalysisTab.TabIndex = 4;
            this.DSAnalysisTab.Text = "Анализ ЗУ";
            this.DSAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // TCNAnalysisTab
            // 
            this.TCNAnalysisTab.Controls.Add(this.networkListView);
            this.TCNAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.TCNAnalysisTab.Name = "TCNAnalysisTab";
            this.TCNAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.TCNAnalysisTab.TabIndex = 3;
            this.TCNAnalysisTab.Text = "Анализ ТВС";
            this.TCNAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // GeneralListView
            // 
            this.GeneralListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.GeneralListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralListView.Location = new System.Drawing.Point(3, 3);
            this.GeneralListView.Name = "GeneralListView";
            this.GeneralListView.Size = new System.Drawing.Size(362, 291);
            this.GeneralListView.TabIndex = 1;
            this.GeneralListView.UseCompatibleStateImageBehavior = false;
            this.GeneralListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Название";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значение";
            this.columnHeader2.Width = 333;
            // 
            // RAMListView
            // 
            this.RAMListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.RAMListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RAMListView.Location = new System.Drawing.Point(0, 0);
            this.RAMListView.Name = "RAMListView";
            this.RAMListView.Size = new System.Drawing.Size(368, 297);
            this.RAMListView.TabIndex = 1;
            this.RAMListView.UseCompatibleStateImageBehavior = false;
            this.RAMListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Название";
            this.columnHeader3.Width = 62;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Значение";
            this.columnHeader4.Width = 333;
            // 
            // storageListView
            // 
            this.storageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.storageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storageListView.Location = new System.Drawing.Point(0, 0);
            this.storageListView.Name = "storageListView";
            this.storageListView.Size = new System.Drawing.Size(368, 297);
            this.storageListView.TabIndex = 1;
            this.storageListView.UseCompatibleStateImageBehavior = false;
            this.storageListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Название";
            this.columnHeader5.Width = 62;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Значение";
            this.columnHeader6.Width = 333;
            // 
            // networkListView
            // 
            this.networkListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.networkListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkListView.Location = new System.Drawing.Point(0, 0);
            this.networkListView.Name = "networkListView";
            this.networkListView.Size = new System.Drawing.Size(368, 297);
            this.networkListView.TabIndex = 1;
            this.networkListView.UseCompatibleStateImageBehavior = false;
            this.networkListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Название";
            this.columnHeader7.Width = 62;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Значение";
            this.columnHeader8.Width = 333;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainView";
            this.Text = "System Tester";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralAnalysisTab.ResumeLayout(false);
            this.CPUAnalysisTab.ResumeLayout(false);
            this.RAMAnalysisTab.ResumeLayout(false);
            this.DSAnalysisTab.ResumeLayout(false);
            this.TCNAnalysisTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeneralAnalysisTab;
        private System.Windows.Forms.TabPage CPUAnalysisTab;
        private System.Windows.Forms.TabPage RAMAnalysisTab;
        private System.Windows.Forms.TabPage DSAnalysisTab;
        private System.Windows.Forms.TabPage TCNAnalysisTab;
        private System.Windows.Forms.ListView CPU_ListView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnValue;
        private System.Windows.Forms.ListView GeneralListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView RAMListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView storageListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView networkListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}


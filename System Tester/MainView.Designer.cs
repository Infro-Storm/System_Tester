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
            this.GeneralAnalysisTbl = new System.Windows.Forms.TableLayoutPanel();
            this.CPUAnalysisTab = new System.Windows.Forms.TabPage();
            this.RAMAnalysisTab = new System.Windows.Forms.TabPage();
            this.DSAnalysisTab = new System.Windows.Forms.TabPage();
            this.TCNAnalysisTab = new System.Windows.Forms.TabPage();
            this.cpuPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RAMTab = new System.Windows.Forms.TableLayoutPanel();
            this.StorageTab = new System.Windows.Forms.TableLayoutPanel();
            this.NetworkTab = new System.Windows.Forms.TableLayoutPanel();
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
            this.GeneralAnalysisTab.Controls.Add(this.GeneralAnalysisTbl);
            this.GeneralAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralAnalysisTab.Name = "GeneralAnalysisTab";
            this.GeneralAnalysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.GeneralAnalysisTab.TabIndex = 0;
            this.GeneralAnalysisTab.Text = "Общий анализ";
            this.GeneralAnalysisTab.UseVisualStyleBackColor = true;
            this.GeneralAnalysisTab.Click += new System.EventHandler(this.GeneralAnalysisTab_Click);
            // 
            // GeneralAnalysisTbl
            // 
            this.GeneralAnalysisTbl.ColumnCount = 2;
            this.GeneralAnalysisTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GeneralAnalysisTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GeneralAnalysisTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralAnalysisTbl.Location = new System.Drawing.Point(3, 3);
            this.GeneralAnalysisTbl.Name = "GeneralAnalysisTbl";
            this.GeneralAnalysisTbl.RowCount = 9;
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GeneralAnalysisTbl.Size = new System.Drawing.Size(362, 291);
            this.GeneralAnalysisTbl.TabIndex = 0;
            // 
            // CPUAnalysisTab
            // 
            this.CPUAnalysisTab.Controls.Add(this.cpuPanel);
            this.CPUAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.CPUAnalysisTab.Name = "CPUAnalysisTab";
            this.CPUAnalysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.CPUAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.CPUAnalysisTab.TabIndex = 1;
            this.CPUAnalysisTab.Text = "Анализ ЦП";
            this.CPUAnalysisTab.UseVisualStyleBackColor = true;
            this.CPUAnalysisTab.Enter += new System.EventHandler(this.CPUAnalysisTab_Enter);
            // 
            // RAMAnalysisTab
            // 
            this.RAMAnalysisTab.Controls.Add(this.RAMTab);
            this.RAMAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.RAMAnalysisTab.Name = "RAMAnalysisTab";
            this.RAMAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.RAMAnalysisTab.TabIndex = 2;
            this.RAMAnalysisTab.Text = "Анализ ОЗУ";
            this.RAMAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // DSAnalysisTab
            // 
            this.DSAnalysisTab.Controls.Add(this.StorageTab);
            this.DSAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.DSAnalysisTab.Name = "DSAnalysisTab";
            this.DSAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.DSAnalysisTab.TabIndex = 4;
            this.DSAnalysisTab.Text = "Анализ ЗУ";
            this.DSAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // TCNAnalysisTab
            // 
            this.TCNAnalysisTab.Controls.Add(this.NetworkTab);
            this.TCNAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.TCNAnalysisTab.Name = "TCNAnalysisTab";
            this.TCNAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.TCNAnalysisTab.TabIndex = 3;
            this.TCNAnalysisTab.Text = "Анализ ТВС";
            this.TCNAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // cpuPanel
            // 
            this.cpuPanel.ColumnCount = 2;
            this.cpuPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.cpuPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cpuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpuPanel.Location = new System.Drawing.Point(3, 3);
            this.cpuPanel.Name = "cpuPanel";
            this.cpuPanel.RowCount = 9;
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.cpuPanel.Size = new System.Drawing.Size(362, 291);
            this.cpuPanel.TabIndex = 1;
            // 
            // RAMTab
            // 
            this.RAMTab.ColumnCount = 2;
            this.RAMTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RAMTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RAMTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RAMTab.Location = new System.Drawing.Point(0, 0);
            this.RAMTab.Name = "RAMTab";
            this.RAMTab.RowCount = 9;
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RAMTab.Size = new System.Drawing.Size(368, 297);
            this.RAMTab.TabIndex = 1;
            // 
            // StorageTab
            // 
            this.StorageTab.ColumnCount = 2;
            this.StorageTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.StorageTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.StorageTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StorageTab.Location = new System.Drawing.Point(0, 0);
            this.StorageTab.Name = "StorageTab";
            this.StorageTab.RowCount = 9;
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StorageTab.Size = new System.Drawing.Size(368, 297);
            this.StorageTab.TabIndex = 1;
            // 
            // NetworkTab
            // 
            this.NetworkTab.ColumnCount = 2;
            this.NetworkTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NetworkTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NetworkTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkTab.Location = new System.Drawing.Point(0, 0);
            this.NetworkTab.Name = "NetworkTab";
            this.NetworkTab.RowCount = 9;
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NetworkTab.Size = new System.Drawing.Size(368, 297);
            this.NetworkTab.TabIndex = 1;
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
        private System.Windows.Forms.TableLayoutPanel GeneralAnalysisTbl;
        private System.Windows.Forms.TableLayoutPanel cpuPanel;
        private System.Windows.Forms.TableLayoutPanel RAMTab;
        private System.Windows.Forms.TableLayoutPanel StorageTab;
        private System.Windows.Forms.TableLayoutPanel NetworkTab;
    }
}


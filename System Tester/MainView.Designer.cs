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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CPUAnalysisTab = new System.Windows.Forms.TabPage();
            this.RAMAnalysisTab = new System.Windows.Forms.TabPage();
            this.DSAnalysisTab = new System.Windows.Forms.TabPage();
            this.TCNAnalysisTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralAnalysisTab.SuspendLayout();
            this.GeneralAnalysisTbl.SuspendLayout();
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
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.GeneralAnalysisTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GeneralAnalysisTbl.Controls.Add(this.label1, 0, 0);
            this.GeneralAnalysisTbl.Controls.Add(this.label2, 0, 1);
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название процессора:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество ядер:";
            // 
            // CPUAnalysisTab
            // 
            this.CPUAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.CPUAnalysisTab.Name = "CPUAnalysisTab";
            this.CPUAnalysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.CPUAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.CPUAnalysisTab.TabIndex = 1;
            this.CPUAnalysisTab.Text = "Анализ ЦП";
            this.CPUAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // RAMAnalysisTab
            // 
            this.RAMAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.RAMAnalysisTab.Name = "RAMAnalysisTab";
            this.RAMAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.RAMAnalysisTab.TabIndex = 2;
            this.RAMAnalysisTab.Text = "Анализ ОЗУ";
            this.RAMAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // DSAnalysisTab
            // 
            this.DSAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.DSAnalysisTab.Name = "DSAnalysisTab";
            this.DSAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.DSAnalysisTab.TabIndex = 4;
            this.DSAnalysisTab.Text = "Анализ ЗУ";
            this.DSAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // TCNAnalysisTab
            // 
            this.TCNAnalysisTab.Location = new System.Drawing.Point(4, 22);
            this.TCNAnalysisTab.Name = "TCNAnalysisTab";
            this.TCNAnalysisTab.Size = new System.Drawing.Size(368, 297);
            this.TCNAnalysisTab.TabIndex = 3;
            this.TCNAnalysisTab.Text = "Анализ ТВС";
            this.TCNAnalysisTab.UseVisualStyleBackColor = true;
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
            this.GeneralAnalysisTbl.ResumeLayout(false);
            this.GeneralAnalysisTbl.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


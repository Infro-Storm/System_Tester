namespace System_Tester
{
    partial class LogView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogView));
            this.CleanLog_btn = new System.Windows.Forms.Button();
            this.LogView_rtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CleanLog_btn
            // 
            this.CleanLog_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CleanLog_btn.Location = new System.Drawing.Point(0, 450);
            this.CleanLog_btn.Name = "CleanLog_btn";
            this.CleanLog_btn.Size = new System.Drawing.Size(585, 23);
            this.CleanLog_btn.TabIndex = 0;
            this.CleanLog_btn.Text = "Очистить журнал";
            this.CleanLog_btn.UseVisualStyleBackColor = true;
            // 
            // LogView_rtb
            // 
            this.LogView_rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogView_rtb.Location = new System.Drawing.Point(0, 0);
            this.LogView_rtb.Name = "LogView_rtb";
            this.LogView_rtb.Size = new System.Drawing.Size(585, 450);
            this.LogView_rtb.TabIndex = 1;
            this.LogView_rtb.Text = "";
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 473);
            this.Controls.Add(this.LogView_rtb);
            this.Controls.Add(this.CleanLog_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LogView";
            this.Text = "Просмотр журнала";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogView_FormClosing);
            this.Load += new System.EventHandler(this.LogView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CleanLog_btn;
        private System.Windows.Forms.RichTextBox LogView_rtb;
    }
}
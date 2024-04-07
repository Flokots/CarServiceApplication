namespace YQED3S
{
    partial class WorksheetRegistrationForm
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
            this.outerPanel = new System.Windows.Forms.Panel();
            this.totalsPanel = new System.Windows.Forms.Panel();
            this.workPanel = new System.Windows.Forms.Panel();
            this.outerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outerPanel
            // 
            this.outerPanel.AutoSize = true;
            this.outerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.outerPanel.Controls.Add(this.totalsPanel);
            this.outerPanel.Controls.Add(this.workPanel);
            this.outerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerPanel.Location = new System.Drawing.Point(0, 0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(617, 349);
            this.outerPanel.TabIndex = 0;
            // 
            // totalsPanel
            // 
            this.totalsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.totalsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalsPanel.Location = new System.Drawing.Point(0, 281);
            this.totalsPanel.Name = "totalsPanel";
            this.totalsPanel.Size = new System.Drawing.Size(617, 68);
            this.totalsPanel.TabIndex = 1;
            // 
            // workPanel
            // 
            this.workPanel.AutoScroll = true;
            this.workPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.workPanel.Location = new System.Drawing.Point(0, 0);
            this.workPanel.MinimumSize = new System.Drawing.Size(620, 275);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(620, 275);
            this.workPanel.TabIndex = 0;
            // 
            // WorksheetRegistrationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(617, 349);
            this.Controls.Add(this.outerPanel);
            this.Name = "WorksheetRegistrationForm";
            this.Text = "Worksheet Registration";
            this.outerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel outerPanel;
        private System.Windows.Forms.Panel workPanel;
        private System.Windows.Forms.Panel totalsPanel;
    }
}
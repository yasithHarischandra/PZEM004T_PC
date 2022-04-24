namespace PZEM004T_PC
{
    partial class Settings
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
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.textBoxRefreshinterval = new System.Windows.Forms.TextBox();
            this.labelRefreshInterval = new System.Windows.Forms.Label();
            this.labelRefreshIntervalUnits = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(12, 26);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(161, 17);
            this.checkBoxAutoRefresh.TabIndex = 0;
            this.checkBoxAutoRefresh.Text = "Refresh values automatically";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.checkBoxAutoRefresh_CheckedChanged);
            // 
            // textBoxRefreshinterval
            // 
            this.textBoxRefreshinterval.Location = new System.Drawing.Point(114, 47);
            this.textBoxRefreshinterval.Name = "textBoxRefreshinterval";
            this.textBoxRefreshinterval.Size = new System.Drawing.Size(72, 20);
            this.textBoxRefreshinterval.TabIndex = 1;
            // 
            // labelRefreshInterval
            // 
            this.labelRefreshInterval.AutoSize = true;
            this.labelRefreshInterval.Location = new System.Drawing.Point(13, 50);
            this.labelRefreshInterval.Name = "labelRefreshInterval";
            this.labelRefreshInterval.Size = new System.Drawing.Size(81, 13);
            this.labelRefreshInterval.TabIndex = 2;
            this.labelRefreshInterval.Text = "Refresh interval";
            // 
            // labelRefreshIntervalUnits
            // 
            this.labelRefreshIntervalUnits.AutoSize = true;
            this.labelRefreshIntervalUnits.Location = new System.Drawing.Point(192, 50);
            this.labelRefreshIntervalUnits.Name = "labelRefreshIntervalUnits";
            this.labelRefreshIntervalUnits.Size = new System.Drawing.Size(63, 13);
            this.labelRefreshIntervalUnits.TabIndex = 3;
            this.labelRefreshIntervalUnits.Text = "milliseconds";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(358, 364);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(450, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 402);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelRefreshIntervalUnits);
            this.Controls.Add(this.labelRefreshInterval);
            this.Controls.Add(this.textBoxRefreshinterval);
            this.Controls.Add(this.checkBoxAutoRefresh);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.TextBox textBoxRefreshinterval;
        private System.Windows.Forms.Label labelRefreshInterval;
        private System.Windows.Forms.Label labelRefreshIntervalUnits;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
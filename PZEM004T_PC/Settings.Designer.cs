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
            this.textBoxRefreshinterval = new System.Windows.Forms.TextBox();
            this.labelRefreshInterval = new System.Windows.Forms.Label();
            this.labelRefreshIntervalUnits = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelOverloadAlarmVal = new System.Windows.Forms.Label();
            this.textBoxOverloadAlarmVal = new System.Windows.Forms.TextBox();
            this.buttonChangeOverloadVal = new System.Windows.Forms.Button();
            this.labelAlarmUnits = new System.Windows.Forms.Label();
            this.buttonRefreshThreshold = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRefreshinterval
            // 
            this.textBoxRefreshinterval.Location = new System.Drawing.Point(114, 21);
            this.textBoxRefreshinterval.Name = "textBoxRefreshinterval";
            this.textBoxRefreshinterval.Size = new System.Drawing.Size(72, 20);
            this.textBoxRefreshinterval.TabIndex = 1;
            // 
            // labelRefreshInterval
            // 
            this.labelRefreshInterval.AutoSize = true;
            this.labelRefreshInterval.Location = new System.Drawing.Point(13, 24);
            this.labelRefreshInterval.Name = "labelRefreshInterval";
            this.labelRefreshInterval.Size = new System.Drawing.Size(81, 13);
            this.labelRefreshInterval.TabIndex = 2;
            this.labelRefreshInterval.Text = "Refresh interval";
            // 
            // labelRefreshIntervalUnits
            // 
            this.labelRefreshIntervalUnits.AutoSize = true;
            this.labelRefreshIntervalUnits.Location = new System.Drawing.Point(192, 24);
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
            // labelOverloadAlarmVal
            // 
            this.labelOverloadAlarmVal.AutoSize = true;
            this.labelOverloadAlarmVal.Location = new System.Drawing.Point(13, 59);
            this.labelOverloadAlarmVal.Name = "labelOverloadAlarmVal";
            this.labelOverloadAlarmVal.Size = new System.Drawing.Size(116, 13);
            this.labelOverloadAlarmVal.TabIndex = 7;
            this.labelOverloadAlarmVal.Text = "Power Alarm Threshold";
            // 
            // textBoxOverloadAlarmVal
            // 
            this.textBoxOverloadAlarmVal.Location = new System.Drawing.Point(135, 56);
            this.textBoxOverloadAlarmVal.Name = "textBoxOverloadAlarmVal";
            this.textBoxOverloadAlarmVal.Size = new System.Drawing.Size(72, 20);
            this.textBoxOverloadAlarmVal.TabIndex = 6;
            // 
            // buttonChangeOverloadVal
            // 
            this.buttonChangeOverloadVal.Location = new System.Drawing.Point(252, 55);
            this.buttonChangeOverloadVal.Name = "buttonChangeOverloadVal";
            this.buttonChangeOverloadVal.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeOverloadVal.TabIndex = 8;
            this.buttonChangeOverloadVal.Text = "Change";
            this.buttonChangeOverloadVal.UseVisualStyleBackColor = true;
            this.buttonChangeOverloadVal.Click += new System.EventHandler(this.buttonChangeOverloadVal_Click);
            // 
            // labelAlarmUnits
            // 
            this.labelAlarmUnits.AutoSize = true;
            this.labelAlarmUnits.Location = new System.Drawing.Point(214, 59);
            this.labelAlarmUnits.Name = "labelAlarmUnits";
            this.labelAlarmUnits.Size = new System.Drawing.Size(18, 13);
            this.labelAlarmUnits.TabIndex = 9;
            this.labelAlarmUnits.Text = "W";
            // 
            // buttonRefreshThreshold
            // 
            this.buttonRefreshThreshold.Location = new System.Drawing.Point(339, 55);
            this.buttonRefreshThreshold.Name = "buttonRefreshThreshold";
            this.buttonRefreshThreshold.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshThreshold.TabIndex = 10;
            this.buttonRefreshThreshold.Text = "Refresh";
            this.buttonRefreshThreshold.UseVisualStyleBackColor = true;
            this.buttonRefreshThreshold.Click += new System.EventHandler(this.buttonRefreshThreshold_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 402);
            this.Controls.Add(this.buttonRefreshThreshold);
            this.Controls.Add(this.labelAlarmUnits);
            this.Controls.Add(this.buttonChangeOverloadVal);
            this.Controls.Add(this.labelOverloadAlarmVal);
            this.Controls.Add(this.textBoxOverloadAlarmVal);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelRefreshIntervalUnits);
            this.Controls.Add(this.labelRefreshInterval);
            this.Controls.Add(this.textBoxRefreshinterval);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRefreshinterval;
        private System.Windows.Forms.Label labelRefreshInterval;
        private System.Windows.Forms.Label labelRefreshIntervalUnits;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelOverloadAlarmVal;
        private System.Windows.Forms.TextBox textBoxOverloadAlarmVal;
        private System.Windows.Forms.Button buttonChangeOverloadVal;
        private System.Windows.Forms.Label labelAlarmUnits;
        private System.Windows.Forms.Button buttonRefreshThreshold;
    }
}
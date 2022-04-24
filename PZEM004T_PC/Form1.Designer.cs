﻿namespace PZEM004T_PC
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRefreshPorts = new System.Windows.Forms.Button();
            this.comboBoxComPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.testCom = new System.Windows.Forms.Button();
            this.voltageUnits = new System.Windows.Forms.Label();
            this.timerRefreshSensorReading = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.VoltageDisplay = new System.Windows.Forms.TextBox();
            this.FreqDisplay = new System.Windows.Forms.TextBox();
            this.PowerDisplay = new System.Windows.Forms.TextBox();
            this.CurrentDisplay = new System.Windows.Forms.TextBox();
            this.PowerUnits = new System.Windows.Forms.Label();
            this.CurrentUnits = new System.Windows.Forms.Label();
            this.PowerfactorDisplay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(135, 48);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudRate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select baud rate";
            // 
            // buttonRefreshPorts
            // 
            this.buttonRefreshPorts.Location = new System.Drawing.Point(281, 12);
            this.buttonRefreshPorts.Name = "buttonRefreshPorts";
            this.buttonRefreshPorts.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshPorts.TabIndex = 8;
            this.buttonRefreshPorts.Text = "Refresh";
            this.buttonRefreshPorts.UseVisualStyleBackColor = true;
            // 
            // comboBoxComPorts
            // 
            this.comboBoxComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPorts.FormattingEnabled = true;
            this.comboBoxComPorts.Location = new System.Drawing.Point(135, 12);
            this.comboBoxComPorts.Name = "comboBoxComPorts";
            this.comboBoxComPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxComPorts.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select COM port";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(373, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // testCom
            // 
            this.testCom.Location = new System.Drawing.Point(473, 13);
            this.testCom.Name = "testCom";
            this.testCom.Size = new System.Drawing.Size(75, 23);
            this.testCom.TabIndex = 12;
            this.testCom.Text = "Test";
            this.testCom.UseVisualStyleBackColor = true;
            this.testCom.Click += new System.EventHandler(this.testCom_Click);
            // 
            // voltageUnits
            // 
            this.voltageUnits.AutoSize = true;
            this.voltageUnits.BackColor = System.Drawing.SystemColors.Control;
            this.voltageUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voltageUnits.Location = new System.Drawing.Point(89, 92);
            this.voltageUnits.Name = "voltageUnits";
            this.voltageUnits.Size = new System.Drawing.Size(26, 25);
            this.voltageUnits.TabIndex = 14;
            this.voltageUnits.Text = "V";
            // 
            // timerRefreshSensorReading
            // 
            this.timerRefreshSensorReading.Interval = 300;
            this.timerRefreshSensorReading.Tick += new System.EventHandler(this.timerRefreshSensorReading_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(186, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hz";
            // 
            // VoltageDisplay
            // 
            this.VoltageDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.VoltageDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageDisplay.Location = new System.Drawing.Point(18, 89);
            this.VoltageDisplay.Name = "VoltageDisplay";
            this.VoltageDisplay.ReadOnly = true;
            this.VoltageDisplay.Size = new System.Drawing.Size(71, 31);
            this.VoltageDisplay.TabIndex = 17;
            this.VoltageDisplay.Text = "000.0";
            this.VoltageDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FreqDisplay
            // 
            this.FreqDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FreqDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreqDisplay.Location = new System.Drawing.Point(129, 89);
            this.FreqDisplay.Name = "FreqDisplay";
            this.FreqDisplay.ReadOnly = true;
            this.FreqDisplay.Size = new System.Drawing.Size(58, 31);
            this.FreqDisplay.TabIndex = 18;
            this.FreqDisplay.Text = "00.0";
            this.FreqDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PowerDisplay
            // 
            this.PowerDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PowerDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerDisplay.Location = new System.Drawing.Point(129, 152);
            this.PowerDisplay.Name = "PowerDisplay";
            this.PowerDisplay.ReadOnly = true;
            this.PowerDisplay.Size = new System.Drawing.Size(73, 31);
            this.PowerDisplay.TabIndex = 22;
            this.PowerDisplay.Text = "0000.0";
            this.PowerDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CurrentDisplay
            // 
            this.CurrentDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CurrentDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDisplay.Location = new System.Drawing.Point(18, 152);
            this.CurrentDisplay.Name = "CurrentDisplay";
            this.CurrentDisplay.ReadOnly = true;
            this.CurrentDisplay.Size = new System.Drawing.Size(71, 31);
            this.CurrentDisplay.TabIndex = 21;
            this.CurrentDisplay.Text = "00.000";
            this.CurrentDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PowerUnits
            // 
            this.PowerUnits.AutoSize = true;
            this.PowerUnits.BackColor = System.Drawing.SystemColors.Control;
            this.PowerUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerUnits.Location = new System.Drawing.Point(201, 155);
            this.PowerUnits.Name = "PowerUnits";
            this.PowerUnits.Size = new System.Drawing.Size(32, 25);
            this.PowerUnits.TabIndex = 20;
            this.PowerUnits.Text = "W";
            // 
            // CurrentUnits
            // 
            this.CurrentUnits.AutoSize = true;
            this.CurrentUnits.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUnits.Location = new System.Drawing.Point(89, 155);
            this.CurrentUnits.Name = "CurrentUnits";
            this.CurrentUnits.Size = new System.Drawing.Size(26, 25);
            this.CurrentUnits.TabIndex = 19;
            this.CurrentUnits.Text = "A";
            // 
            // PowerfactorDisplay
            // 
            this.PowerfactorDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PowerfactorDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerfactorDisplay.Location = new System.Drawing.Point(246, 152);
            this.PowerfactorDisplay.Name = "PowerfactorDisplay";
            this.PowerfactorDisplay.ReadOnly = true;
            this.PowerfactorDisplay.Size = new System.Drawing.Size(58, 31);
            this.PowerfactorDisplay.TabIndex = 24;
            this.PowerfactorDisplay.Text = "0.00";
            this.PowerfactorDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(303, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "PF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PowerfactorDisplay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PowerDisplay);
            this.Controls.Add(this.CurrentDisplay);
            this.Controls.Add(this.PowerUnits);
            this.Controls.Add(this.CurrentUnits);
            this.Controls.Add(this.FreqDisplay);
            this.Controls.Add(this.VoltageDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.voltageUnits);
            this.Controls.Add(this.testCom);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefreshPorts);
            this.Controls.Add(this.comboBoxComPorts);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "PZEM 004T V3.0 UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRefreshPorts;
        private System.Windows.Forms.ComboBox comboBoxComPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button testCom;
        protected System.Windows.Forms.Label voltageUnits;
        private System.Windows.Forms.Timer timerRefreshSensorReading;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VoltageDisplay;
        private System.Windows.Forms.TextBox FreqDisplay;
        private System.Windows.Forms.TextBox PowerDisplay;
        private System.Windows.Forms.TextBox CurrentDisplay;
        protected System.Windows.Forms.Label PowerUnits;
        protected System.Windows.Forms.Label CurrentUnits;
        private System.Windows.Forms.TextBox PowerfactorDisplay;
        protected System.Windows.Forms.Label label4;
    }
}

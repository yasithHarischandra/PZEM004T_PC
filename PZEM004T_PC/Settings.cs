using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PZEM004T_PC
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void checkBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            setTimerSettings();
        }

        private void setTimerSettings()
        {
            Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            frm.timerRefreshSensorReading.Interval = int.Parse(textBoxRefreshinterval.Text);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            frm.timerRefreshSensorReading.Interval = int.Parse(textBoxRefreshinterval.Text);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            textBoxRefreshinterval.Text = frm.timerRefreshSensorReading.Interval.ToString();

            if(Program.isSerialPortOpen)
            {
                buttonChangeOverloadVal.Enabled = true;
                textBoxOverloadAlarmVal.Enabled = true;

                //read overload alarm trigger value
                //Cursor.Current = Cursors.WaitCursor;
                //Thread.Sleep(frm.timerRefreshSensorReading.Interval + 800); //wait until timer tick event done, 
                textBoxOverloadAlarmVal.Text = frm.energyMeter.powerAlarmThreshold.ToString();
                //Cursor.Current = Cursors.Default;
            }
            else
            {
                buttonChangeOverloadVal.Enabled = false;
                textBoxOverloadAlarmVal.Enabled = false;
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {

            Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (Program.isSerialPortOpen)
                frm.timerRefreshSensorReading.Start();
        }

        private void buttonChangeOverloadVal_Click(object sender, EventArgs e)
        {
            UInt16 ThresholdVal = (UInt16)int.Parse(textBoxOverloadAlarmVal.Text);

            if (Program.isSerialPortOpen)
            {
                Cursor.Current = Cursors.WaitCursor;
                string error = "";
                Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (!frm.energyMeter.SetPowerAlarmThreshold(ThresholdVal, ref error))
                    MessageBox.Show("Error setting the overload threshold!\n" + error);
            }
        }

        private void buttonRefreshThreshold_Click(object sender, EventArgs e)
        {
            if (Program.isSerialPortOpen)
            {
                string error = "";
                Cursor.Current = Cursors.WaitCursor;
                Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (!frm.energyMeter.ReadPowerAlarmThreshold(ref error))
                    MessageBox.Show("Error reading power overload alarm threshold from sensor!\n" + error);

                textBoxOverloadAlarmVal.Text = frm.energyMeter.powerAlarmThreshold.ToString();
            }
        }
    }
}

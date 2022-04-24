using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            frm.timerRefreshSensorReading.Start();
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
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {

            Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            frm.timerRefreshSensorReading.Start();
        }
    }
}

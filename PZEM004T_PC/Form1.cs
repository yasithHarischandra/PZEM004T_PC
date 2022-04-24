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
    public partial class Form1 : Form
    {
        PZEM_004T_v3 energyMeter;
        public System.Windows.Forms.Timer timerRefreshSensorReading;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ///Ports
            string[] ports = Program.GetAvailablePorts();
            comboBoxComPorts.Items.Clear();
            comboBoxComPorts.Items.AddRange(ports);
            comboBoxComPorts.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";
            if (!Program.isSerialPortOpen)
            {
                if (Program.OpenSerialPort(comboBoxComPorts.Text, "9600", ref error))
                {
                    //MessageBox.Show("Port opened successfully");
                    buttonConnect.Text = "Disconnect";
                    Program.isSerialPortOpen = true;
                    energyMeter = new PZEM_004T_v3(ref Program._serialPort);
                    timerRefreshSensorReading.Start();
                }
                else
                    MessageBox.Show(error);
            }
            else
            {
                if (Program.CloseSerialPort(ref error))
                {
                    buttonConnect.Text = "Connect";
                    Program.isSerialPortOpen = false;
                }
                else
                    MessageBox.Show(error);

                timerRefreshSensorReading.Stop();
            }

            
        }

        private void readSensor()
        {
            //string error = "";
            //if (!energyMeter.RefreshAllReadings())
            //    MessageBox.Show(error);
            energyMeter.RefreshAllReadings();


        }

        private void timerRefreshSensorReading_Tick(object sender, EventArgs e)
        {
            // Create a thread and call a background method   
            Thread backgroundThread = new Thread(new ThreadStart(readSensor));
            // Start thread  
            backgroundThread.Start();
            if (energyMeter == null)
                return;

            VoltageDisplay.Text = energyMeter.readings.GetVoltage().ToString();
            FreqDisplay.Text = energyMeter.readings.GetFrequency().ToString();
            CurrentDisplay.Text = energyMeter.readings.GetCurrent().ToString();
            PowerDisplay.Text = energyMeter.readings.GetPower().ToString();
            PowerfactorDisplay.Text = energyMeter.readings.GetPowerFactor().ToString();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings newSettingsWindow = new Settings();
            timerRefreshSensorReading.Stop();
            newSettingsWindow.Show();
        }
    }
}

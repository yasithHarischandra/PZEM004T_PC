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
    public partial class Form1 : Form
    {
        PZEM_004T_v3 energyMeter;
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

            //Baud rate
            string[] baudRates = { "9600", "115200" };
            comboBoxBaudRate.Items.Clear();
            comboBoxBaudRate.Items.AddRange(baudRates);
            comboBoxBaudRate.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";
            if (!Program.isSerialPortOpen)
            {
                if (Program.OpenSerialPort(comboBoxComPorts.Text, comboBoxBaudRate.Text, ref error))
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

        private void testCom_Click(object sender, EventArgs e)
        {
            string error = "";
            //com with sensor
            Modbus modbusObject = new Modbus();
            List<UInt16> registers = Modbus.ReadInputRegisters(ref Program._serialPort, 1, 0, 2, ref error);
            if(!energyMeter.RefreshAllReadings())
                MessageBox.Show(error);
            VoltageDisplay.Text = energyMeter.readings.GetVoltage().ToString();
        }

        private void timerRefreshSensorReading_Tick(object sender, EventArgs e)
        {
            string error = "";
            if (!energyMeter.RefreshAllReadings())
                MessageBox.Show(error);
            VoltageDisplay.Text = energyMeter.readings.GetVoltage().ToString();
            FreqDisplay.Text = energyMeter.readings.GetFrequency().ToString();
            CurrentDisplay.Text = energyMeter.readings.GetCurrent().ToString();
            PowerDisplay.Text = energyMeter.readings.GetPower().ToString();
            PowerfactorDisplay.Text = energyMeter.readings.GetPowerFactor().ToString();
        }
    }
}

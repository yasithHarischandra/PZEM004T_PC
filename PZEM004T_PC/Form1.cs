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
using System.Diagnostics;


namespace PZEM004T_PC
{
    public partial class Form1 : Form
    {
        public PZEM_004T_v3 energyMeter;
        public System.Windows.Forms.Timer timerRefreshSensorReading;
        private readonly Stopwatch watch = new Stopwatch();
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

            var line = new OxyPlot.Series.LineSeries()
            {
                Color = OxyPlot.OxyColors.Blue,
                StrokeThickness = 1,
                MarkerSize = 2,
                MarkerType = OxyPlot.MarkerType.Circle
            };
            
            var model = new OxyPlot.PlotModel
            {
                Title = $"{comboBoxSelectPlotVariable.SelectedItem:N0}"
            };
            model.Series.Add(line);
        
            // load the model into the user control
            plotView1.Model = model;
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

                    Cursor.Current = Cursors.WaitCursor;
                    if (!energyMeter.ReadPowerAlarmThreshold(ref error))
                        MessageBox.Show("Error reading power overload alarm threshold from sensor!\n" + error);

                    timerRefreshSensorReading.Start();
                    watch.Start();
                }
                else
                    MessageBox.Show(error);
            }
            else
            {
                timerRefreshSensorReading.Stop();
                watch.Stop();
                Cursor.Current = Cursors.WaitCursor;
                Thread.Sleep(timerRefreshSensorReading.Interval + 1000);    //wait until auto sensor refresh is done
                if (Program.CloseSerialPort(ref error))
                {
                    buttonConnect.Text = "Connect";
                    Program.isSerialPortOpen = false;
                }
                else
                    MessageBox.Show(error);

                Cursor.Current = Cursors.Default;
                if (Program.isSerialPortOpen)
                    timerRefreshSensorReading.Start();
            }

            
        }

        private void readSensor()
        {
            //string error = "";
            //if (!energyMeter.RefreshAllReadings())
            //    MessageBox.Show(error);
            if(Program.isSerialPortOpen)
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
            backgroundThread.Join();

            VoltageDisplay.Text = energyMeter.readings.GetVoltage().ToString();
            FreqDisplay.Text = energyMeter.readings.GetFrequency().ToString();
            CurrentDisplay.Text = energyMeter.readings.GetCurrent().ToString();
            PowerDisplay.Text = energyMeter.readings.GetPower().ToString();
            PowerfactorDisplay.Text = energyMeter.readings.GetPowerFactor().ToString();
            if(energyMeter.readings.GetStatusOverloadAlarm())
                OverloadAlarmDisplay.BackColor = Color.Red;
            else 
                OverloadAlarmDisplay.BackColor = Color.Green;

           
           var s = (OxyPlot.Series.LineSeries)plotView1.Model.Series[0];
           if (s.Points.Count >= 200)
                s.Points.RemoveAt(0);
            
            s.Points.Add(GetCorrectDataPoint());
            this.plotView1.Model.InvalidatePlot(true);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings newSettingsWindow = new Settings();
            timerRefreshSensorReading.Stop();
            newSettingsWindow.Show();
        }

        private void comboBoxSelectPlotVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            plotView1.Model.Title = comboBoxSelectPlotVariable.Text;

            var s = (OxyPlot.Series.LineSeries)plotView1.Model.Series[0];
            s.Points.Clear();

            if(energyMeter != null)
                s.Points.Add(GetCorrectDataPoint());

            this.plotView1.Model.InvalidatePlot(true);
        }

        private OxyPlot.DataPoint GetCorrectDataPoint()
        {
            double t = this.watch.ElapsedMilliseconds * 0.001;
            OxyPlot.DataPoint point;

            if (comboBoxSelectPlotVariable.Text == "Voltage")
                point = new OxyPlot.DataPoint(t, (double)energyMeter.readings.GetVoltage());
            else if (comboBoxSelectPlotVariable.Text == "Current")
                point = new OxyPlot.DataPoint(t, (double)energyMeter.readings.GetCurrent());
            else if (comboBoxSelectPlotVariable.Text == "Power")
                point = new OxyPlot.DataPoint(t, (double)energyMeter.readings.GetPower());
            else if (comboBoxSelectPlotVariable.Text == "Frequency")
                point = new OxyPlot.DataPoint(t, (double)energyMeter.readings.GetFrequency());
            else if (comboBoxSelectPlotVariable.Text == "Power Factor")
                point = new OxyPlot.DataPoint(t, (double)energyMeter.readings.GetPowerFactor());
            else
                point = new OxyPlot.DataPoint(t, 0.0);

            return point;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PZEM004T_PC
{
    internal static class Program
    {
        public static SerialPort _serialPort;
        public static bool isSerialPortOpen = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string[] GetAvailablePorts()
        {
            int numPorts = SerialPort.GetPortNames().Length;
            string[] ports = new string[numPorts];
            int i = 0;
            foreach (string s in SerialPort.GetPortNames())
            {
                ports[i] = s;
                i++;
            }
            return ports;
        }

        public static bool OpenSerialPort(string port, string baudRate, ref string error)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = port;
            _serialPort.BaudRate = int.Parse(baudRate);
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            _serialPort.ReadTimeout = 100;
            if (_serialPort.IsOpen)
            {
                error = "Port is already open.";
                return false;
            }
            else
            {
                try
                {
                    _serialPort.Open();
                }
                catch (Exception ex)
                {
                    error = "Failed to open serial port!.";
                    return false;
                }
            }


            if (!_serialPort.IsOpen)
            {
                error = "Failed to open serial port!.";
                return false;
            }

            return true;
        }

        public static bool CloseSerialPort(ref string error)
        {
            try
            {
                _serialPort?.Close();
            }
            catch (Exception ex)
            {
                error = "Failed to close serial port!.";
                return false;
            }

            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PZEM004T_PC
{
    internal class Modbus
    {
        SerialPort _serialPort;
        public static bool isSerialPortOpen = false;

        public static byte[] GetCommandReadInputRegisters(int slaveAddress, int startRegister, int numRegisters)
        {
            byte[] ModbusCommand = new byte[6];

            ModbusCommand[0] = (byte)slaveAddress;
            ModbusCommand[1] = 04;  //function

            //start register
            ModbusCommand[2] = (byte)((startRegister >> 8) & 0xFF); //High byte
            ModbusCommand[3] = (byte)(startRegister & 0xFF);        //low byte

            //number of registers to read
            ModbusCommand[4] = (byte)((numRegisters >> 8) & 0xFF); //High byte
            ModbusCommand[5] = (byte)(numRegisters & 0xFF);        //low byte

            //Add CRC bytes
            byte[] crcBytes = new byte[2];
            UInt16 crc = ComputeCRC(ModbusCommand, ref crcBytes);
            Array.Resize(ref ModbusCommand, ModbusCommand.Length + 2);
            ModbusCommand[6] = crcBytes[0];         //low byte
            ModbusCommand[7] = crcBytes[1];        //high byte


            return ModbusCommand;
        }

        public static bool ProcessResponse(ref byte[] response,ref List<UInt16> result, ref string error)
        {
            //List<UInt16> result = new List<UInt16>();

            switch(response[1])
            {
                case 4:
                    int numBytesToRead = response[2];
                    for(int i = 0; i < numBytesToRead; i+=2)
                    {
                        UInt16 highByte = (UInt16)response[i + 3];
                        UInt16 lowByte = (UInt16)response[i + 4];
                        highByte = (UInt16)(highByte << 8);
                        UInt16 registerval = (UInt16)(highByte | lowByte);
                        result.Add(registerval);
                    }
                    break;
            }
                

            return true;
        }

        public static List<UInt16> ReadInputRegisters(ref SerialPort _serialPort, int slaveAddress, int startRegister, int numRegisters, ref string error)
        {
            List<UInt16> registers = new List<UInt16>();
            int responseLength = 5 + 2 * numRegisters;
            byte[] response = new byte[responseLength];

            byte[] modbusCommand = GetCommandReadInputRegisters(slaveAddress, startRegister, numRegisters);
            
            bool sendSuccess = sendModbusCommand(ref _serialPort, ref modbusCommand, responseLength, ref response, ref error);
            
            bool responseSuccess = ProcessResponse(ref response, ref registers, ref error);

            return registers;
        }

        

        private static void GetResponse(ref SerialPort _serialPort, ref byte[] response)
        {
            //There is a bug in .Net 2.0 DataReceived Event that prevents people from using this
            //event as an interrupt to handle data (it doesn't fire all of the time).  Therefore
            //we have to use the ReadByte command for a fixed length as it's been shown to be reliable.
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = (byte)(_serialPort.ReadByte());
            }
        }

        private static bool sendModbusCommand(ref SerialPort _serialPort, ref byte[] command, int responseLength, ref byte[] response, ref string error)
        {
            _serialPort.DiscardOutBuffer();
            _serialPort.DiscardInBuffer();

            try
            {
                _serialPort.Write(command, 0, command.Length);
                System.Threading.Thread.Sleep(2000);
                _serialPort.Read(response, 0, response.Length);
                //GetResponse(ref _serialPort, ref response);
            }
            catch (Exception ex)
            {
                error = "Failed to close serial port!.";
                return false;
            }

            return true;
        }

        private static ushort[] CrcTable =
        {
            0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
            0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
            0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
            0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
            0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
            0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
            0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
            0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
            0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
            0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
            0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
            0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
            0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
            0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
            0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
            0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
            0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
            0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
            0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
            0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
            0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
            0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
            0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
            0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
            0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
            0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
            0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
            0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
            0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
            0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
            0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
            0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040
        };
        public static UInt16 ComputeCRC(byte[] data, ref byte[] CRC)
        {
            UInt16 crc = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;

            foreach (byte datum in data)
            {
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ datum) & 0xFF]);
            }

            CRC[1] = CRCHigh = (byte)((crc >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(crc & 0xFF);
            return crc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PZEM004T_PC
{
    public class PZEM004T_PARAMS
    {
        double voltage = 0.0;
        double current = 0.0;
        double power = 0.0;
        double energy = 0.0;
        double frequency = 0.0;
        double powerFactor = 0.0;
        bool overloadAlarm = false;

        public double GetVoltage() { return voltage; }
        public double GetCurrent() { return current; }
        public double GetPower() { return power; }
        public double GetEnergy() { return energy; }
        public double GetFrequency() { return frequency; }
        public double GetPowerFactor() { return powerFactor; }
        public bool GetStatusOverloadAlarm() { return overloadAlarm; }

        public void SetVoltage(double voltage) { this.voltage = voltage; }
        public void SetCurrent(double current) { this.current = current; }
        public void SetPower(double power) { this.power = power; }
        public void SetEnergy(double energy) { this.energy = energy;}
        public void SetFrequency(double frequency) { this.frequency = frequency;}
        public void SetPowerFactor(double powerFactor) { this.powerFactor = powerFactor; }
        public void SetStatusOverloadAlarm(bool alarm ) { this.overloadAlarm = alarm;}

    }
    internal class PZEM_004T_v3
    {
        public PZEM004T_PARAMS readings;
        public static SerialPort _serialPort;

        public PZEM_004T_v3(ref SerialPort sp)
        {
            _serialPort = sp;
            readings = new PZEM004T_PARAMS();
        }

        public bool RefreshAllReadings()
        {
            string error = "";
            const int numRegistersToRead = 10;
            List<UInt16> registers = Modbus.ReadInputRegisters(ref Program._serialPort, 1, 0, numRegistersToRead, ref error);

            if (registers != null && registers.Count == numRegistersToRead)
            {
                readings.SetVoltage(registers[0] / 10.0);

                UInt32 currentreading = (UInt32)((registers[2] << 16) | (registers[1]));
                readings.SetCurrent((double)currentreading / 1000.0);

                UInt32 powerreading = (UInt32)((registers[4] << 16) | (registers[3]));
                readings.SetPower((double)powerreading / 10.0);

                UInt32 energyreading = (UInt32)((registers[6] << 16) | (registers[5]));
                readings.SetEnergy((double)energyreading);

                readings.SetFrequency(registers[7] / 10.0);

                readings.SetPowerFactor(registers[8] / 100.0);

                //check internal alarm for overload
                if(registers[9] == 0xFF)
                    readings.SetStatusOverloadAlarm(true);
                else 
                    readings.SetStatusOverloadAlarm(false);
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}

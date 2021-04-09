﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Device.Communication;


namespace Device.MPDA
{   
    /// <summary>
    /// Base class for MPDA.Provide methods/parameter for setting/getting MPDA set value
    /// </summary>
    public class MPDAControl
    {

        #region >>>private field<<<

        private CommunicationBase _communication;
        private IOSetting _iOSet;
        private List<byte> _byteCmd = new List<byte>();


        //    Default value    //    
        private bool _offset = false;
        private bool _bias = false;
        private byte _filterRange = 1; 
        private byte _secondRange = 1; 

        #endregion

        #region >>>Constructor<<<
        public MPDAControl(TcpSetting tcpSet) 
        {
            this._communication = new CommunicationBase(tcpSet);
            if (!this._communication.Connect())
            {
                throw this._communication.Exception;
            }
            this._iOSet = new IOSetting(this._communication);
        }
        #endregion

        #region >>>public property<<<

        public CommunicationBase Communication
        {
            get { return _communication; }
        }

        public IOSetting IOSet
        {
            get { return _iOSet; }
        }

        public int MsrTime
        {
            get 
            {
                this._communication.SendCmd(0x38);
                int integrationTimes = ( (this._communication.ReturnBytes[1] << 8) | this._communication.ReturnBytes[2]);
                int intervalTime = this._communication.ReturnBytes[3];
                return integrationTimes * intervalTime;
            }
        }

        public int DelayTime
        {
            get
            {
                this._communication.SendCmd(0x40);
                int delayTime = ( (this._communication.ReturnBytes[1] << 8) | this._communication.ReturnBytes[2]);
                int timeBase = ((this._communication.ReturnBytes[3] << 8) | this._communication.ReturnBytes[4]);
                return delayTime * timeBase;
            }
        }

        public decimal BiasVoltage
        {
            get
            {
                this._communication.SendCmd(0x34);
                Int16 biasVoltageDAC = (Int16) ((this._communication.ReturnBytes[1] << 8) | this._communication.ReturnBytes[2]);
                Int16 signedMask = 0x7ff; // 07ff -> Mask the signed bit
                decimal biasVoltage = (biasVoltageDAC & signedMask) * 0.005m;
                if ((biasVoltageDAC & 0x0800) == 0)
                {
                    biasVoltage = -biasVoltage;
                }
                return biasVoltage;
            }
        }

        public string FirstRange 
        {
            get 
            {
                this._communication.SendCmd(0x32);
                switch (this._communication.ReturnBytes[1])
                {
                    case 1:
                        return "1nA";
                    case 2:
                        return "10nA";
                    case 3:
                        return "100nA";
                    case 4:
                        return "1uA";
                    case 5:
                        return "10uA";
                    case 6:
                        return "100uA";
                    case 7:
                        return "1mA";
                    case 8:
                        return "10mA";
                    case 9:
                        return "100mA";
                    default:
                        return string.Empty;
                }
            }
        }

        public int FilterRange 
        {
            get 
            {
                this._communication.SendCmd(0x32);
                return this._communication.ReturnBytes[2] >> 4;
            }
        }

        public int SecondRange
        {
            get
            {
                this._communication.SendCmd(0x32);
                return (this._communication.ReturnBytes[2] & 0x0c) >> 2;
            }
        }

        public bool Offset
        {
            get
            {
                this._communication.SendCmd(0x32);
                return (this._communication.ReturnBytes[2] & 0x02) != 0;
            }
        }

        public bool Bias
        {
            get
            {
                this._communication.SendCmd(0x32);
                return (this._communication.ReturnBytes[2] & 0x01) != 0;
            }
        }

        public string TriggerMode
        {
            get
            {
                this._communication.SendCmd(0x36);
                switch (this._communication.ReturnBytes[1])
	            {
                    case (byte) 0x01:
                        return "HD Trigger";                     
                    case (byte)0x02:
                        return "Rise Trigger";
                    case (byte)0x04:
                        return "Window Capture";
                    case (byte)0x08:
                        return "Real-time Translation";
                    case (byte)0x10:
                        return "Bias Trigger";
                    default:
                        return string.Empty;
	            }
            }
        }

        #endregion

        #region >>>private method<<<
        #endregion

        #region >>>public method<<<

        /// <summary>
        /// Clear Buffer
        /// </summary>
        public void ClearBuffer() 
        {
            this._communication.SendCmd(0x45);
        }

        /// <summary>
        /// Use internal trigger to start measure.
        /// </summary>
        public void InternalTrigger() 
        {
            this._communication.SendCmd(0x98);
            if (this._communication.ReturnBytes[1] != (byte)0x01)
            {
                throw new Exception("Internal Trigger is failed");
            }
        }

        /// <summary>
        /// Set MPDA measure times = integrationTimes * intervalTime (us)
        /// </summary>
        /// <param name="integrationTimes">Limit = 32767</param>
        /// <param name="intervalTime">Limit = 100</param>
        public void SetMsrTime(int integrationTimes, int intervalTime) 
        {
            this._byteCmd.Clear();
            byte[] temp = BitConverter.GetBytes((ushort) integrationTimes);
            this._byteCmd.Add(0x37);
            this._byteCmd.Add(temp[1]);
            this._byteCmd.Add(temp[0]);
            this._byteCmd.Add((byte) intervalTime);
            this._communication.SendCmd(this._byteCmd.ToArray());
            if (this._communication.ReturnBytes[1] != (byte) 0x01)
            {
                throw new Exception("Measure times set is failed");
            }
        }

        /// <summary>
        /// Set Delay time = DelayTimeSet * Timebase * 100 (ns)
        /// </summary>
        /// <param name="delayTimeSet">Limit = 65535</param>
        /// <param name="timeBase">Limit = 2000</param>
        public void SetDelayTime(int delayTimeSet, int timeBase)
        {
            byte[] temp = BitConverter.GetBytes((ushort)delayTimeSet);
            this._byteCmd.Clear();
            this._byteCmd.Add(0x39);
            this._byteCmd.Add(temp[1]);
            this._byteCmd.Add(temp[0]);
            temp = BitConverter.GetBytes((ushort)timeBase);
            this._byteCmd.Add(temp[1]);
            this._byteCmd.Add(temp[0]);
            this._communication.SendCmd(this._byteCmd.ToArray());
            if (this._communication.ReturnBytes[1] != (byte)0x01)
            {
                throw new Exception("Delay times set is failed");
            }           
        }

        /// <summary>
        /// Set Bias Voltage
        /// </summary>
        /// <param name="biasVoltage">Range = -10 to +10, resolution is 0.005 (V)</param>
        public void SetBiasVoltage(decimal biasVoltage)
        {
            Int16 positiveMask = 2048; // 0X0800
            decimal resolution = 0.005m;
            Int16 biasVoltageDAC = Convert.ToInt16(biasVoltage / resolution);
            if (biasVoltage > 0)
            {
                biasVoltageDAC = (Int16)(biasVoltageDAC | positiveMask); //最左位元補1
            }
            else
            {
                biasVoltageDAC = Math.Abs(biasVoltageDAC);
            }            
            byte[] temp = BitConverter.GetBytes((ushort)biasVoltageDAC);
            this._byteCmd.Clear();
            this._byteCmd.Add(0x33);
            this._byteCmd.Add(temp[1]);
            this._byteCmd.Add(temp[0]);
            this._communication.SendCmd(this._byteCmd.ToArray());
            if ((this._communication.ReturnBytes[1] != 0x01) || (Math.Abs(biasVoltage) > 10))
            {
                throw new Exception("Delay times set is failed");
            }
        }

        /// <summary>
        /// Set Measure Range, Filter Range, Offset, Bias
        /// </summary>
        /// <param name="firstRange">(Set value:Range)
        /// 1:1nA; 2:10nA; 3:100nA; 4:1uA; 5:10uA;
        /// 6:100uA; 7:1mA; 8:10mA; 9:100mA
        /// </param>
        public void SetMsrRange(byte firstRange) 
        {
            this._byteCmd.Clear();
            this._byteCmd.Add(0x31);
            this._byteCmd.Add(firstRange);
            int temp = (this._filterRange << 4) | (this._secondRange << 2) | (Convert.ToByte(this._offset) << 1) | (Convert.ToByte(this._bias));
            this._byteCmd.Add(BitConverter.GetBytes(temp)[0]);
            this._communication.SendCmd(this._byteCmd.ToArray());
            if (this._communication.ReturnBytes[1] != (byte) 0x01)
            {
                throw new Exception("Measure times set is failed");
            } 
        }

        public void SetMsrRange(byte firstRange, byte filterRange, byte secondRange, bool offset, bool bias) 
        {
            this._filterRange = filterRange;
            this._secondRange = secondRange;
            this._offset = offset;
            this._bias = bias;
            this.SetMsrRange(firstRange);
        }

        /// <summary>
        /// Set Trigger Mode
        /// </summary>
        /// <param name="modeSelect">
        /// 1:硬體觸發; 2:上升觸發; 3:窗型擷取; 4:實時傳輸; 5:Bias觸發;
        /// </param>
        public void SetTriggerMode(int modeSelect) 
        {
            this._byteCmd.Clear();
            this._byteCmd.Add(0x35);
            this._byteCmd.Add( (byte) (0x01 << (modeSelect-1)) );
            this._communication.SendCmd(this._byteCmd.ToArray());            
            if (this._communication.ReturnBytes[1] != 0x01)
            {
                throw new Exception("Trigger mode set is failed");
            } 
        }

        /// <summary>
        /// Read buffer data
        /// </summary>
        /// <param name="numOfRead">
        /// The number of data want to get
        /// </param>
        public double[] ReadData(int numOfRead) 
        {
            this._byteCmd.Clear();
            this._byteCmd.Add(0x44);
            byte[] temp = BitConverter.GetBytes((Int16)numOfRead);
            this._byteCmd.Add(temp[1]);
            this._byteCmd.Add(temp[0]);
            this._communication.SendCmd(this._byteCmd.ToArray());
            double[] readData = new double[numOfRead];
            for (int i = 0; i < numOfRead; i++)
            {
                int startIndex = i * 5;
                int rawValue = (this.Communication.ReturnBytes[startIndex + 0] << 24) + (this.Communication.ReturnBytes[startIndex+1] << 16)
                             + (this.Communication.ReturnBytes[startIndex + 2] << 8) + (this.Communication.ReturnBytes[startIndex+3]);
                double scale = 10e-9 * Math.Pow(10, -(10-this.Communication.ReturnBytes[startIndex + 4]));
                readData[i] = rawValue * scale;
            }
            return readData;
            
        }

        public void SetAllParameter(MPDAMeasureParameter msrItem)
        {
            try
            {
                this.SetMsrRange(msrItem.MeasureRange);
                this.SetMsrTime(msrItem.IntegrationTimes, msrItem.IntervalTimes);
                this.SetDelayTime(msrItem.DelayTimeSet, msrItem.TimeBase);
                this.SetBiasVoltage(msrItem.BiasVoltage);
                this.SetTriggerMode(msrItem.TriggerMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}

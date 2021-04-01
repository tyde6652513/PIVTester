using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSeting
{
    public class PulseParameter
    {
        #region>>>Field<<<

        private double _pulseWidth;
        private double _dutyCycle;
        private double _startValue;
        private double _endValue;
        private double _stepValue;
        private double _count;
        
        #endregion
       
        #region>>>Property<<<

        public double DutyCycle
        {
            get { return _dutyCycle; }
            set { _dutyCycle = value; }
        }

        public double PulseWidth
        {
            get { return _pulseWidth; }
            set { _pulseWidth = value; }
        }

        public double StartValue
        {
            get { return _startValue; }
            set { _startValue = value; }
        }

        public double EndValue
        {
            get { return _endValue; }
            set { _endValue = value; }
        }

        public double StepValue
        {
            get { return _stepValue; }
            set { _stepValue = value; }
        }

        public double Count
        {
            get { return _count; }
            set { _count = value; }
        }

        #endregion     
    
    }

    public class SwParameter 
    {
        #region>>>Property<<<

        public double Nplc;
        public int MsrRange;
        public int LimitV;
        public double SrcRange;
        public int SwCount;
        public double StartValue;
        public double EndValue;
        public double ForceTime;

        #endregion
        public SwParameter() 
        {
            Nplc = 0.01;
            MsrRange = 10;
            LimitV = 10;
            SrcRange = 0.012;
            StartValue = 10e-3;
            EndValue = 30e-3;
            SwCount = 5;
            ForceTime = 0.3e-3;
        }
    }

    public static class DMMParameter 
    {
        public static double MsrtDelay;
        public static int MsrtCount;
    }
}

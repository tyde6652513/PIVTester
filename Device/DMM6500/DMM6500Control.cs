using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Device.Communication;
using TestSeting;
using TestSeting;

namespace Device.DMM6500
{
    public class DMM6500Control
    {

        #region >>>Field<<<

        private CommunicationBase _communicationBase;

        private string _script;

        #endregion        
        
        #region >>>Property<<<

        public CommunicationBase CommunicationBase
        {
            get { return _communicationBase; }
        }

        #endregion        

        #region >>>Constructor<<<

        public DMM6500Control(TcpSetting tcpSet) 
        {
            this._communicationBase = new CommunicationBase(tcpSet);
            if (!this._communicationBase.Connect())
            {
                throw this._communicationBase.Exception;
            }
        }

        #endregion

        #region >>>Public method<<<

        public void SetTrigger() 
        {
            string script = string.Empty;

            script += "eventlog.clear()\n";
            script += "status.clear()\n";
            script += "display.changescreen(display.SCREEN_HOME_LARGE_READING)\n";
            script += "digio.writeport(0)\n";
            script += "status.operation.setmap(10, 2731, 2732)\n";
            script += "trigger.extin.edge = trigger.EDGE_RISING\n";
            
            script += "dmm.measure.autorange = dmm.OFF\n";
            script += "dmm.measure.autozero.enable = dmm.OFF\n";
            script += "dmm.measure.autodelay = dmm.DELAY_OFF\n";

            script += "dmm.measure.func = dmm.FUNC_DC_CURRENT\n";
            script += string.Format("dmm.measure.range = {0}\n", 0.01);
            script += string.Format("dmm.measure.nplc = {0}\n", 1e-3);
            
            //Block 與 Trigger時序

            //script += "status.clear()\n";
            script += string.Format("trigger.model.load(\"{0}\")\n", "Empty");
            script += string.Format("trigger.model.setblock({0}, trigger.BLOCK_BUFFER_CLEAR)\n", 1);   // could be removed


            script += string.Format("trigger.model.setblock({0}, trigger.BLOCK_WAIT, trigger.EVENT_EXTERNAL)\n", 2);   // Ext.Trigger IN for starting measure with EVENT_EXTERNAL
            script += string.Format("trigger.model.setblock({0}, trigger.BLOCK_DELAY_CONSTANT, {1})\n", 3, 0);
            script += string.Format("trigger.model.setblock({0}, trigger.BLOCK_MEASURE, defbuffer1, 1)\n", 4);
            script += string.Format("trigger.model.setblock({0}, trigger.BLOCK_BRANCH_COUNTER, {1}, 2)\n", 5, DMMParameter.MsrtCount);
            script += "waitcomplete()\n";
            script += "trigger.model.initiate()\n";
            //script += "printbuffer(1, defbuffer1.n, defbuffer1)\n";

            this._communicationBase.SendCmd(script);
        }

        

        #endregion

    }
}

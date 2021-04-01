using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Device.K2601;
using Device.DMM6500;
using Device.MPDA;
using Device.Communication;
using TestSeting;

namespace GUI
{
    public partial class frmMain : Form
    {

        #region >>>field<<<

        //子視窗
        private K2601.frmConnect _frmK2601Connect = new K2601.frmConnect();
        private DMM650.frmConnectDMM _frmConnectDMM = new DMM650.frmConnectDMM();

        //Device driver
        private K2601Control _k2601Control;
        private DMM6500Control _dmmControl;
        private MPDAControl _mpdaControl;

        //Other
        private CommunicationBase _comBase;
        private int numOfRead = 600;

        #endregion

        #region >>>Constructor<<<

        public frmMain()
        {
            //連結委派方法
            this._frmK2601Connect.SetK2601 = SetK2601;
            this._frmConnectDMM.SetDMM = SetDMM;
            //
            InitializeComponent();
        }

        #endregion

        #region >>>Method to delegate<<<

        public void SetK2601(K2601Control k2601) 
        {
            this._k2601Control = k2601;
        }

        public void SetDMM(DMM6500Control dmm)
        {
            this._dmmControl = dmm;
        }

        #endregion

        #region >>>Event<<<

        private void stpK2601TcpSet_Click(object sender, EventArgs e)
        {
            this._frmK2601Connect.ShowDialog();
        }

        private void stpDMMTcpSet_Click(object sender, EventArgs e)
        {
            this._frmConnectDMM.ShowDialog();
        }
        
        private void btnRun_Click(object sender, EventArgs e)
        {
            SwParameter item = new SwParameter();
            DMMParameter.MsrtCount = item.SwCount + 1;
            try
            {
                switch (cboMsrDevice.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        this._dmmControl.SetTrigger();
                        break;
                    default:
                        break;
                }
                //this._k2601Control.Print();
                this._k2601Control.CommunicationBase.SendCmd("reset()\n");
                this._k2601Control.SetTrig2();
                this._k2601Control.SW(item);
                this._k2601Control.PulseSweep(item);
                //this._k2601Control.LoadFunction_FiMv(); //SiMv(10e-3, 8, 0.1e-3)
                //this._k2601Control.LoadFunction_FvMi2(); //SvMi(0.9, 1.5, 1e-3)
                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cboSelectDevice.SelectedIndex)
                {
                    case 0:
                        this._comBase = this._k2601Control.CommunicationBase;
                        break;
                    case 2:
                        this._comBase = this._dmmControl.CommunicationBase;
                        break;
                    default:
                        this._comBase = null;
                        break;
                }
                txtReceive.Text = this._comBase.Receive(0);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }          
        }

        private void btnSend_Click(object sender, EventArgs e)
        {                    
            try
            {
                switch (cboSelectDevice.SelectedIndex)
                {
                    case 0:
                        this._comBase = this._k2601Control.CommunicationBase;
                        break;
                    case 2:
                        this._comBase = this._dmmControl.CommunicationBase;
                        break;
                    default:
                        this._comBase = null;
                        break;
                }
                this._comBase.SendCmd(txtDataSend.Text);
                //txtReceive.Text = comBase.Receive(0);
            }
            catch (Exception ex)
            {              
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double[] dataRead = new double[numOfRead];
                dataRead = _mpdaControl.ReadData(numOfRead);

                StringBuilder sb = new StringBuilder();
                string first;
                string second;
                string newLine;
                first = "TestNum";
                second = "Value(A)";
                newLine = string.Format("{0},{1}", first, second);
                sb.AppendLine(newLine);
                for (int i = 0; i < dataRead.Length; i++)
                {
                    first = (i + 1).ToString();
                    second = dataRead[i].ToString();
                    newLine = string.Format("{0},{1}", first, second);
                    sb.AppendLine(newLine);
                }
                saveFileDialog1.ShowDialog();
                string filePath = saveFileDialog1.FileName;
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        

        

       

        
    }
}

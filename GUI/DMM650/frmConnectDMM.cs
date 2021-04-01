using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Device.Communication;
using Device.DMM6500;

namespace GUI.DMM650
{
    public partial class frmConnectDMM : Form
    {
        //將K2601物件 委派給主視窗
        public delegate void DSetDMM(DMM6500Control dmm);
        public DSetDMM SetDMM;

        //
        private DMM6500Control _dmmControl;
        private TcpSetting _tcpSetting = new TcpSetting();

        public frmConnectDMM()
        {
            InitializeComponent();
        }

        #region>>>Event<<<

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            try
            {
                this._tcpSetting.IpAddress = txtAdress.Text;
                this._tcpSetting.Port = Convert.ToInt32(txtPort.Text);
                this._dmmControl = new DMM6500Control(this._tcpSetting);
                lblStatus.Text = "Connected";
                SetDMM.Invoke(this._dmmControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region>>>Save Property(Default value)<<<

        private void frmConnect_Load(object sender, EventArgs e)
        {
            txtAdress.Text = GUI.Properties.Settings.Default.DMMIP;
            txtPort.Text = GUI.Properties.Settings.Default.DMMPort;
        }

        private void frmConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            GUI.Properties.Settings.Default.DMMIP = txtAdress.Text;
            GUI.Properties.Settings.Default.DMMPort = txtPort.Text;
            GUI.Properties.Settings.Default.Save();
        }

        #endregion

        #endregion
              
        
    }
}

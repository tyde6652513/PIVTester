using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Device.Communication;
using Device.K2601;

namespace GUI.K2601
{
    public partial class frmConnect : Form
    {
        //將K2601物件 委派給主視窗
        public delegate void DSetK2601(K2601Control k2601);
        public DSetK2601 SetK2601;

        //
        private K2601Control _k2601Control;
        private TcpSetting _tcpSetting = new TcpSetting();

        public frmConnect()
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
                this._k2601Control = new K2601Control(this._tcpSetting);
                lblStatus.Text = "Connected";
                SetK2601.Invoke(this._k2601Control);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region>>>Save Property(Default value)<<<

        private void frmConnect_Load(object sender, EventArgs e)
        {
            txtAdress.Text = GUI.Properties.Settings.Default.K2601IP;
            txtPort.Text = GUI.Properties.Settings.Default.K2601Port;
        }

        private void frmConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            GUI.Properties.Settings.Default.K2601IP = txtAdress.Text;
            GUI.Properties.Settings.Default.K2601Port = txtPort.Text;
            GUI.Properties.Settings.Default.Save();
        }

        #endregion

        #endregion
              
        
    }
}

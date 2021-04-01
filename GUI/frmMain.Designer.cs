namespace GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stpK2601ParameterSet = new System.Windows.Forms.ToolStripMenuItem();
            this.stpK2601TcpSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mPDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stpMPDAParameterSet = new System.Windows.Forms.ToolStripMenuItem();
            this.stpMPDATcpSet = new System.Windows.Forms.ToolStripMenuItem();
            this.dMMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stpDMMParaSet = new System.Windows.Forms.ToolStripMenuItem();
            this.stpDMMTcpSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboMsrDevice = new System.Windows.Forms.ComboBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSelectDevice = new System.Windows.Forms.ComboBox();
            this.txtDataSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mPDAToolStripMenuItem,
            this.dMMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stpK2601ParameterSet,
            this.stpK2601TcpSet});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 24);
            this.toolStripMenuItem1.Text = "K2601";
            // 
            // stpK2601ParameterSet
            // 
            this.stpK2601ParameterSet.Name = "stpK2601ParameterSet";
            this.stpK2601ParameterSet.Size = new System.Drawing.Size(183, 24);
            this.stpK2601ParameterSet.Text = "Parameter set";
            // 
            // stpK2601TcpSet
            // 
            this.stpK2601TcpSet.Name = "stpK2601TcpSet";
            this.stpK2601TcpSet.Size = new System.Drawing.Size(183, 24);
            this.stpK2601TcpSet.Text = "Tcp set";
            this.stpK2601TcpSet.Click += new System.EventHandler(this.stpK2601TcpSet_Click);
            // 
            // mPDAToolStripMenuItem
            // 
            this.mPDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stpMPDAParameterSet,
            this.stpMPDATcpSet});
            this.mPDAToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.mPDAToolStripMenuItem.Name = "mPDAToolStripMenuItem";
            this.mPDAToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.mPDAToolStripMenuItem.Text = "MPDA";
            // 
            // stpMPDAParameterSet
            // 
            this.stpMPDAParameterSet.Name = "stpMPDAParameterSet";
            this.stpMPDAParameterSet.Size = new System.Drawing.Size(183, 24);
            this.stpMPDAParameterSet.Text = "Parameter set";
            // 
            // stpMPDATcpSet
            // 
            this.stpMPDATcpSet.Name = "stpMPDATcpSet";
            this.stpMPDATcpSet.Size = new System.Drawing.Size(183, 24);
            this.stpMPDATcpSet.Text = "Tcp set";
            // 
            // dMMToolStripMenuItem
            // 
            this.dMMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stpDMMParaSet,
            this.stpDMMTcpSet});
            this.dMMToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.dMMToolStripMenuItem.Name = "dMMToolStripMenuItem";
            this.dMMToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.dMMToolStripMenuItem.Text = "DMM";
            // 
            // stpDMMParaSet
            // 
            this.stpDMMParaSet.Name = "stpDMMParaSet";
            this.stpDMMParaSet.Size = new System.Drawing.Size(142, 24);
            this.stpDMMParaSet.Text = "參數設定";
            // 
            // stpDMMTcpSet
            // 
            this.stpDMMTcpSet.Name = "stpDMMTcpSet";
            this.stpDMMTcpSet.Size = new System.Drawing.Size(142, 24);
            this.stpDMMTcpSet.Text = "連線";
            this.stpDMMTcpSet.Click += new System.EventHandler(this.stpDMMTcpSet_Click);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btnRun.Location = new System.Drawing.Point(32, 247);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(79, 35);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.label1.Location = new System.Drawing.Point(14, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Receive";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(18, 200);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(247, 108);
            this.txtReceive.TabIndex = 4;
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btnRead.Location = new System.Drawing.Point(186, 118);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(79, 35);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 358);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.cboMsrDevice);
            this.tabPage1.Controls.Add(this.lbl3);
            this.tabPage1.Controls.Add(this.btnRun);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PIV test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboMsrDevice
            // 
            this.cboMsrDevice.FormattingEnabled = true;
            this.cboMsrDevice.Items.AddRange(new object[] {
            "MPDA",
            "DMM"});
            this.cboMsrDevice.Location = new System.Drawing.Point(121, 21);
            this.cboMsrDevice.Name = "cboMsrDevice";
            this.cboMsrDevice.Size = new System.Drawing.Size(121, 27);
            this.cboMsrDevice.TabIndex = 11;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(28, 24);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(70, 19);
            this.lbl3.TabIndex = 10;
            this.lbl3.Text = "Device :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cboSelectDevice);
            this.tabPage2.Controls.Add(this.txtDataSend);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.txtReceive);
            this.tabPage2.Controls.Add(this.btnRead);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(293, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Send Command";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Device :";
            // 
            // cboSelectDevice
            // 
            this.cboSelectDevice.FormattingEnabled = true;
            this.cboSelectDevice.Items.AddRange(new object[] {
            "K2601",
            "MPDA",
            "DMM"});
            this.cboSelectDevice.Location = new System.Drawing.Point(121, 21);
            this.cboSelectDevice.Name = "cboSelectDevice";
            this.cboSelectDevice.Size = new System.Drawing.Size(121, 27);
            this.cboSelectDevice.TabIndex = 8;
            // 
            // txtDataSend
            // 
            this.txtDataSend.Location = new System.Drawing.Point(18, 77);
            this.txtDataSend.Multiline = true;
            this.txtDataSend.Name = "txtDataSend";
            this.txtDataSend.Size = new System.Drawing.Size(247, 35);
            this.txtDataSend.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btnSend.Location = new System.Drawing.Point(18, 118);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 35);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.button1.Location = new System.Drawing.Point(163, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 402);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stpK2601ParameterSet;
        private System.Windows.Forms.ToolStripMenuItem stpK2601TcpSet;
        private System.Windows.Forms.ToolStripMenuItem mPDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stpMPDAParameterSet;
        private System.Windows.Forms.ToolStripMenuItem stpMPDATcpSet;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ToolStripMenuItem dMMToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSelectDevice;
        private System.Windows.Forms.TextBox txtDataSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cboMsrDevice;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.ToolStripMenuItem stpDMMParaSet;
        private System.Windows.Forms.ToolStripMenuItem stpDMMTcpSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}
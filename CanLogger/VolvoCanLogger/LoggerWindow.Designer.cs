namespace VolvoCanLogger
{
    partial class LoggerWindow
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
            this.components = new System.ComponentModel.Container();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCanBitrate = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblComSpeed = new System.Windows.Forms.Label();
            this.lblComPort = new System.Windows.Forms.Label();
            this.cmbComSpeed = new System.Windows.Forms.ComboBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.lbRawLog = new System.Windows.Forms.ListBox();
            this.lbIdList = new System.Windows.Forms.ListBox();
            this.cbRawLogEnable = new System.Windows.Forms.CheckBox();
            this.receivingTimer = new System.Windows.Forms.Timer(this.components);
            this.btnClearRawLog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbDataList = new System.Windows.Forms.ListBox();
            this.btnResetNew = new System.Windows.Forms.Button();
            this.btnResetSelected = new System.Windows.Forms.Button();
            this.btnEditMask = new System.Windows.Forms.Button();
            this.tbDataMask = new System.Windows.Forms.TextBox();
            this.tbIdDataMask = new System.Windows.Forms.TextBox();
            this.btnEditIdMask = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowIdMessages = new System.Windows.Forms.Button();
            this.btnShowIdMessageHistory = new System.Windows.Forms.Button();
            this.btnResetSelectedCount = new System.Windows.Forms.Button();
            this.btnResetIdName = new System.Windows.Forms.Button();
            this.btnEditIdName = new System.Windows.Forms.Button();
            this.tbIdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetIdMask = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tpSetup = new System.Windows.Forms.TabControl();
            this.tabComPort = new System.Windows.Forms.TabPage();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.btnResetCurrentLine = new System.Windows.Forms.Button();
            this.btnPlay1000 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFileCurrentLine = new System.Windows.Forms.TextBox();
            this.btnPlay100 = new System.Windows.Forms.Button();
            this.btnPlay10 = new System.Windows.Forms.Button();
            this.btnPlay1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFileLines = new System.Windows.Forms.TextBox();
            this.btnOpenLogFile = new System.Windows.Forms.Button();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.tbLogFileName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEnableLogging = new System.Windows.Forms.CheckBox();
            this.btnStartNewFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tpSetup.SuspendLayout();
            this.tabComPort.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Enabled = false;
            this.cbAutoStart.Location = new System.Drawing.Point(9, 72);
            this.cbAutoStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(108, 24);
            this.cbAutoStart.TabIndex = 27;
            this.cbAutoStart.Text = "Auto Start";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(130, 222);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 35);
            this.btnStop.TabIndex = 26;
            this.btnStop.Text = "Sto&p";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(9, 222);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 25;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "CAN Bitrate";
            // 
            // cmbCanBitrate
            // 
            this.cmbCanBitrate.FormattingEnabled = true;
            this.cmbCanBitrate.Items.AddRange(new object[] {
            "10Kbit",
            "20Kbit",
            "50Kbit",
            "100Kbit",
            "125Kbit",
            "250Kbit",
            "500Kbit",
            "800Kbit",
            "1Mbit"});
            this.cmbCanBitrate.Location = new System.Drawing.Point(9, 180);
            this.cmbCanBitrate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCanBitrate.Name = "cmbCanBitrate";
            this.cmbCanBitrate.Size = new System.Drawing.Size(126, 28);
            this.cmbCanBitrate.TabIndex = 23;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(146, 109);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(136, 35);
            this.btnDisconnect.TabIndex = 22;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(10, 108);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(126, 37);
            this.btnConnect.TabIndex = 21;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblComSpeed
            // 
            this.lblComSpeed.AutoSize = true;
            this.lblComSpeed.Location = new System.Drawing.Point(141, 6);
            this.lblComSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComSpeed.Name = "lblComSpeed";
            this.lblComSpeed.Size = new System.Drawing.Size(56, 20);
            this.lblComSpeed.TabIndex = 20;
            this.lblComSpeed.Text = "Speed";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(4, 6);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(38, 20);
            this.lblComPort.TabIndex = 19;
            this.lblComPort.Text = "Port";
            // 
            // cmbComSpeed
            // 
            this.cmbComSpeed.FormattingEnabled = true;
            this.cmbComSpeed.Items.AddRange(new object[] {
            "2400",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "250000",
            "500000",
            "1000000",
            "2000000"
            });
            this.cmbComSpeed.Location = new System.Drawing.Point(146, 31);
            this.cmbComSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbComSpeed.Name = "cmbComSpeed";
            this.cmbComSpeed.Size = new System.Drawing.Size(133, 28);
            this.cmbComSpeed.TabIndex = 18;
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(9, 31);
            this.cmbComPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(126, 28);
            this.cmbComPort.TabIndex = 17;
            // 
            // serialPort
            // 
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // lbRawLog
            // 
            this.lbRawLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRawLog.DataSource = this.lbIdList.CustomTabOffsets;
            this.lbRawLog.FormattingEnabled = true;
            this.lbRawLog.ItemHeight = 20;
            this.lbRawLog.Location = new System.Drawing.Point(9, 69);
            this.lbRawLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbRawLog.Name = "lbRawLog";
            this.lbRawLog.Size = new System.Drawing.Size(369, 564);
            this.lbRawLog.TabIndex = 1;
            // 
            // lbIdList
            // 
            this.lbIdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIdList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdList.FormattingEnabled = true;
            this.lbIdList.ItemHeight = 20;
            this.lbIdList.Location = new System.Drawing.Point(12, 86);
            this.lbIdList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbIdList.Name = "lbIdList";
            this.lbIdList.Size = new System.Drawing.Size(350, 804);
            this.lbIdList.TabIndex = 6;
            this.lbIdList.SelectedIndexChanged += new System.EventHandler(this.lbIdList_SelectedIndexChanged);
            // 
            // cbRawLogEnable
            // 
            this.cbRawLogEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRawLogEnable.AutoSize = true;
            this.cbRawLogEnable.Location = new System.Drawing.Point(30, 26);
            this.cbRawLogEnable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRawLogEnable.Name = "cbRawLogEnable";
            this.cbRawLogEnable.Size = new System.Drawing.Size(85, 24);
            this.cbRawLogEnable.TabIndex = 3;
            this.cbRawLogEnable.Text = "Enable";
            this.cbRawLogEnable.UseVisualStyleBackColor = true;
            this.cbRawLogEnable.Click += new System.EventHandler(this.cbRawLogEnable_Click);
            // 
            // receivingTimer
            // 
            this.receivingTimer.Tick += new System.EventHandler(this.receivingTimer_Tick);
            // 
            // btnClearRawLog
            // 
            this.btnClearRawLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearRawLog.Location = new System.Drawing.Point(267, 20);
            this.btnClearRawLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearRawLog.Name = "btnClearRawLog";
            this.btnClearRawLog.Size = new System.Drawing.Size(112, 35);
            this.btnClearRawLog.TabIndex = 4;
            this.btnClearRawLog.Text = "Clea&r";
            this.btnClearRawLog.UseVisualStyleBackColor = true;
            this.btnClearRawLog.Click += new System.EventHandler(this.btnClearRawLog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbRawLog);
            this.groupBox1.Controls.Add(this.btnClearRawLog);
            this.groupBox1.Controls.Add(this.cbRawLogEnable);
            this.groupBox1.Location = new System.Drawing.Point(868, 355);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.MinimumSize = new System.Drawing.Size(389, 659);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(389, 659);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Log";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(8, 42);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 35);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset Data";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbDataList
            // 
            this.lbDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDataList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataList.FormattingEnabled = true;
            this.lbDataList.ItemHeight = 20;
            this.lbDataList.Location = new System.Drawing.Point(15, 206);
            this.lbDataList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbDataList.Name = "lbDataList";
            this.lbDataList.Size = new System.Drawing.Size(436, 764);
            this.lbDataList.TabIndex = 9;
            // 
            // btnResetNew
            // 
            this.btnResetNew.Location = new System.Drawing.Point(123, 42);
            this.btnResetNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetNew.Name = "btnResetNew";
            this.btnResetNew.Size = new System.Drawing.Size(124, 35);
            this.btnResetNew.TabIndex = 10;
            this.btnResetNew.Text = "Reset Count";
            this.btnResetNew.UseVisualStyleBackColor = true;
            this.btnResetNew.Click += new System.EventHandler(this.btnResetNew_Click);
            // 
            // btnResetSelected
            // 
            this.btnResetSelected.Location = new System.Drawing.Point(20, 158);
            this.btnResetSelected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetSelected.Name = "btnResetSelected";
            this.btnResetSelected.Size = new System.Drawing.Size(110, 35);
            this.btnResetSelected.TabIndex = 11;
            this.btnResetSelected.Text = "Reset Data";
            this.btnResetSelected.UseVisualStyleBackColor = true;
            this.btnResetSelected.Click += new System.EventHandler(this.btnResetSelected_Click);
            // 
            // btnEditMask
            // 
            this.btnEditMask.Location = new System.Drawing.Point(314, 37);
            this.btnEditMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditMask.Name = "btnEditMask";
            this.btnEditMask.Size = new System.Drawing.Size(54, 31);
            this.btnEditMask.TabIndex = 12;
            this.btnEditMask.Text = "Edit";
            this.btnEditMask.UseVisualStyleBackColor = true;
            this.btnEditMask.Click += new System.EventHandler(this.btnEditMask_Click);
            // 
            // tbDataMask
            // 
            this.tbDataMask.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataMask.Location = new System.Drawing.Point(111, 38);
            this.tbDataMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDataMask.Name = "tbDataMask";
            this.tbDataMask.ReadOnly = true;
            this.tbDataMask.Size = new System.Drawing.Size(192, 26);
            this.tbDataMask.TabIndex = 13;
            // 
            // tbIdDataMask
            // 
            this.tbIdDataMask.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdDataMask.Location = new System.Drawing.Point(112, 29);
            this.tbIdDataMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIdDataMask.Name = "tbIdDataMask";
            this.tbIdDataMask.ReadOnly = true;
            this.tbIdDataMask.Size = new System.Drawing.Size(198, 26);
            this.tbIdDataMask.TabIndex = 14;
            // 
            // btnEditIdMask
            // 
            this.btnEditIdMask.Location = new System.Drawing.Point(321, 31);
            this.btnEditIdMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditIdMask.Name = "btnEditIdMask";
            this.btnEditIdMask.Size = new System.Drawing.Size(54, 31);
            this.btnEditIdMask.TabIndex = 15;
            this.btnEditIdMask.Text = "Edit";
            this.btnEditIdMask.UseVisualStyleBackColor = true;
            this.btnEditIdMask.Click += new System.EventHandler(this.btnEditIdMask_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data Mask";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Data Mask";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnShowIdMessages);
            this.groupBox2.Controls.Add(this.btnShowIdMessageHistory);
            this.groupBox2.Controls.Add(this.btnResetSelectedCount);
            this.groupBox2.Controls.Add(this.btnResetIdName);
            this.groupBox2.Controls.Add(this.btnEditIdName);
            this.groupBox2.Controls.Add(this.tbIdName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnResetIdMask);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnEditIdMask);
            this.groupBox2.Controls.Add(this.tbIdDataMask);
            this.groupBox2.Controls.Add(this.btnResetSelected);
            this.groupBox2.Controls.Add(this.lbDataList);
            this.groupBox2.Location = new System.Drawing.Point(398, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.MinimumSize = new System.Drawing.Size(462, 995);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(462, 995);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected ID";
            // 
            // btnShowIdMessages
            // 
            this.btnShowIdMessages.Location = new System.Drawing.Point(282, 158);
            this.btnShowIdMessages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowIdMessages.Name = "btnShowIdMessages";
            this.btnShowIdMessages.Size = new System.Drawing.Size(171, 35);
            this.btnShowIdMessages.TabIndex = 25;
            this.btnShowIdMessages.Text = "Investigate List";
            this.btnShowIdMessages.UseVisualStyleBackColor = true;
            this.btnShowIdMessages.Click += new System.EventHandler(this.btnShowIdMessages_Click);
            // 
            // btnShowIdMessageHistory
            // 
            this.btnShowIdMessageHistory.Location = new System.Drawing.Point(282, 117);
            this.btnShowIdMessageHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowIdMessageHistory.Name = "btnShowIdMessageHistory";
            this.btnShowIdMessageHistory.Size = new System.Drawing.Size(171, 35);
            this.btnShowIdMessageHistory.TabIndex = 24;
            this.btnShowIdMessageHistory.Text = "Investgate History";
            this.btnShowIdMessageHistory.UseVisualStyleBackColor = true;
            this.btnShowIdMessageHistory.Click += new System.EventHandler(this.btnShowIdMessageHistory_Click);
            // 
            // btnResetSelectedCount
            // 
            this.btnResetSelectedCount.Location = new System.Drawing.Point(138, 158);
            this.btnResetSelectedCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetSelectedCount.Name = "btnResetSelectedCount";
            this.btnResetSelectedCount.Size = new System.Drawing.Size(124, 35);
            this.btnResetSelectedCount.TabIndex = 23;
            this.btnResetSelectedCount.Text = "Reset Count";
            this.btnResetSelectedCount.UseVisualStyleBackColor = true;
            this.btnResetSelectedCount.Click += new System.EventHandler(this.btnResetIdCount_Click);
            // 
            // btnResetIdName
            // 
            this.btnResetIdName.Location = new System.Drawing.Point(384, 65);
            this.btnResetIdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetIdName.Name = "btnResetIdName";
            this.btnResetIdName.Size = new System.Drawing.Size(69, 31);
            this.btnResetIdName.TabIndex = 22;
            this.btnResetIdName.Text = "Reset";
            this.btnResetIdName.UseVisualStyleBackColor = true;
            this.btnResetIdName.Click += new System.EventHandler(this.btnResetIdName_Click);
            // 
            // btnEditIdName
            // 
            this.btnEditIdName.Location = new System.Drawing.Point(321, 65);
            this.btnEditIdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditIdName.Name = "btnEditIdName";
            this.btnEditIdName.Size = new System.Drawing.Size(54, 31);
            this.btnEditIdName.TabIndex = 21;
            this.btnEditIdName.Text = "Edit";
            this.btnEditIdName.UseVisualStyleBackColor = true;
            this.btnEditIdName.Click += new System.EventHandler(this.btnEditIdName_Click);
            // 
            // tbIdName
            // 
            this.tbIdName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdName.Location = new System.Drawing.Point(112, 65);
            this.tbIdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIdName.Name = "tbIdName";
            this.tbIdName.ReadOnly = true;
            this.tbIdName.Size = new System.Drawing.Size(198, 26);
            this.tbIdName.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Name";
            // 
            // btnResetIdMask
            // 
            this.btnResetIdMask.Location = new System.Drawing.Point(384, 31);
            this.btnResetIdMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetIdMask.Name = "btnResetIdMask";
            this.btnResetIdMask.Size = new System.Drawing.Size(69, 31);
            this.btnResetIdMask.TabIndex = 18;
            this.btnResetIdMask.Text = "Reset";
            this.btnResetIdMask.UseVisualStyleBackColor = true;
            this.btnResetIdMask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnResetIdMask_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lbIdList);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnResetNew);
            this.groupBox3.Location = new System.Drawing.Point(15, 92);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.MinimumSize = new System.Drawing.Size(374, 922);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(374, 922);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAN ID List";
            // 
            // tpSetup
            // 
            this.tpSetup.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tpSetup.Controls.Add(this.tabComPort);
            this.tpSetup.Controls.Add(this.tabFile);
            this.tpSetup.Controls.Add(this.tabLogging);
            this.tpSetup.Location = new System.Drawing.Point(884, 17);
            this.tpSetup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.SelectedIndex = 0;
            this.tpSetup.Size = new System.Drawing.Size(373, 318);
            this.tpSetup.TabIndex = 24;
            // 
            // tabComPort
            // 
            this.tabComPort.Controls.Add(this.cbAutoStart);
            this.tabComPort.Controls.Add(this.label1);
            this.tabComPort.Controls.Add(this.btnStop);
            this.tabComPort.Controls.Add(this.cmbComPort);
            this.tabComPort.Controls.Add(this.btnStart);
            this.tabComPort.Controls.Add(this.cmbComSpeed);
            this.tabComPort.Controls.Add(this.lblComPort);
            this.tabComPort.Controls.Add(this.cmbCanBitrate);
            this.tabComPort.Controls.Add(this.lblComSpeed);
            this.tabComPort.Controls.Add(this.btnDisconnect);
            this.tabComPort.Controls.Add(this.btnConnect);
            this.tabComPort.Location = new System.Drawing.Point(4, 32);
            this.tabComPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabComPort.Name = "tabComPort";
            this.tabComPort.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabComPort.Size = new System.Drawing.Size(365, 282);
            this.tabComPort.TabIndex = 0;
            this.tabComPort.Text = "Com Port";
            this.tabComPort.UseVisualStyleBackColor = true;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.btnResetCurrentLine);
            this.tabFile.Controls.Add(this.btnPlay1000);
            this.tabFile.Controls.Add(this.label6);
            this.tabFile.Controls.Add(this.tbFileCurrentLine);
            this.tabFile.Controls.Add(this.btnPlay100);
            this.tabFile.Controls.Add(this.btnPlay10);
            this.tabFile.Controls.Add(this.btnPlay1);
            this.tabFile.Controls.Add(this.label5);
            this.tabFile.Controls.Add(this.tbFileLines);
            this.tabFile.Controls.Add(this.btnOpenLogFile);
            this.tabFile.Location = new System.Drawing.Point(4, 32);
            this.tabFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFile.Size = new System.Drawing.Size(360, 282);
            this.tabFile.TabIndex = 1;
            this.tabFile.Text = "File";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // btnResetCurrentLine
            // 
            this.btnResetCurrentLine.Location = new System.Drawing.Point(258, 94);
            this.btnResetCurrentLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetCurrentLine.Name = "btnResetCurrentLine";
            this.btnResetCurrentLine.Size = new System.Drawing.Size(88, 35);
            this.btnResetCurrentLine.TabIndex = 9;
            this.btnResetCurrentLine.Text = "Reset";
            this.btnResetCurrentLine.UseVisualStyleBackColor = true;
            this.btnResetCurrentLine.Click += new System.EventHandler(this.btnResetCurrentLine_Click);
            // 
            // btnPlay1000
            // 
            this.btnPlay1000.Location = new System.Drawing.Point(168, 94);
            this.btnPlay1000.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlay1000.Name = "btnPlay1000";
            this.btnPlay1000.Size = new System.Drawing.Size(62, 35);
            this.btnPlay1000.TabIndex = 8;
            this.btnPlay1000.Text = "1000";
            this.btnPlay1000.UseVisualStyleBackColor = true;
            this.btnPlay1000.Click += new System.EventHandler(this.btnPlay1000_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Current";
            // 
            // tbFileCurrentLine
            // 
            this.tbFileCurrentLine.Location = new System.Drawing.Point(258, 54);
            this.tbFileCurrentLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFileCurrentLine.Name = "tbFileCurrentLine";
            this.tbFileCurrentLine.ReadOnly = true;
            this.tbFileCurrentLine.Size = new System.Drawing.Size(91, 26);
            this.tbFileCurrentLine.TabIndex = 6;
            // 
            // btnPlay100
            // 
            this.btnPlay100.Location = new System.Drawing.Point(110, 94);
            this.btnPlay100.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlay100.Name = "btnPlay100";
            this.btnPlay100.Size = new System.Drawing.Size(50, 35);
            this.btnPlay100.TabIndex = 5;
            this.btnPlay100.Text = "100";
            this.btnPlay100.UseVisualStyleBackColor = true;
            this.btnPlay100.Click += new System.EventHandler(this.btnPlay100_Click);
            // 
            // btnPlay10
            // 
            this.btnPlay10.Location = new System.Drawing.Point(60, 94);
            this.btnPlay10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlay10.Name = "btnPlay10";
            this.btnPlay10.Size = new System.Drawing.Size(50, 35);
            this.btnPlay10.TabIndex = 4;
            this.btnPlay10.Text = "10";
            this.btnPlay10.UseVisualStyleBackColor = true;
            this.btnPlay10.Click += new System.EventHandler(this.btnPlay10_Click);
            // 
            // btnPlay1
            // 
            this.btnPlay1.Location = new System.Drawing.Point(10, 94);
            this.btnPlay1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlay1.Name = "btnPlay1";
            this.btnPlay1.Size = new System.Drawing.Size(50, 35);
            this.btnPlay1.TabIndex = 3;
            this.btnPlay1.Text = "1";
            this.btnPlay1.UseVisualStyleBackColor = true;
            this.btnPlay1.Click += new System.EventHandler(this.btnPlay1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Lines";
            // 
            // tbFileLines
            // 
            this.tbFileLines.Location = new System.Drawing.Point(258, 14);
            this.tbFileLines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFileLines.Name = "tbFileLines";
            this.tbFileLines.ReadOnly = true;
            this.tbFileLines.Size = new System.Drawing.Size(91, 26);
            this.tbFileLines.TabIndex = 1;
            // 
            // btnOpenLogFile
            // 
            this.btnOpenLogFile.Location = new System.Drawing.Point(9, 9);
            this.btnOpenLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenLogFile.Name = "btnOpenLogFile";
            this.btnOpenLogFile.Size = new System.Drawing.Size(136, 35);
            this.btnOpenLogFile.TabIndex = 0;
            this.btnOpenLogFile.Text = "Open Log File";
            this.btnOpenLogFile.UseVisualStyleBackColor = true;
            this.btnOpenLogFile.Click += new System.EventHandler(this.btnOpenLogFile_Click);
            // 
            // tabLogging
            // 
            this.tabLogging.Controls.Add(this.tbLogFileName);
            this.tabLogging.Controls.Add(this.label7);
            this.tabLogging.Controls.Add(this.cbEnableLogging);
            this.tabLogging.Controls.Add(this.btnStartNewFile);
            this.tabLogging.Location = new System.Drawing.Point(4, 32);
            this.tabLogging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Size = new System.Drawing.Size(360, 282);
            this.tabLogging.TabIndex = 2;
            this.tabLogging.Text = "Logging";
            this.tabLogging.UseVisualStyleBackColor = true;
            // 
            // tbLogFileName
            // 
            this.tbLogFileName.Location = new System.Drawing.Point(108, 14);
            this.tbLogFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLogFileName.Name = "tbLogFileName";
            this.tbLogFileName.ReadOnly = true;
            this.tbLogFileName.Size = new System.Drawing.Size(230, 26);
            this.tbLogFileName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "File name";
            // 
            // cbEnableLogging
            // 
            this.cbEnableLogging.AutoSize = true;
            this.cbEnableLogging.Location = new System.Drawing.Point(26, 54);
            this.cbEnableLogging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEnableLogging.Name = "cbEnableLogging";
            this.cbEnableLogging.Size = new System.Drawing.Size(152, 24);
            this.cbEnableLogging.TabIndex = 1;
            this.cbEnableLogging.Text = "Enable log to file";
            this.cbEnableLogging.UseVisualStyleBackColor = true;
            this.cbEnableLogging.CheckedChanged += new System.EventHandler(this.cbEnableLogging_CheckedChanged);
            // 
            // btnStartNewFile
            // 
            this.btnStartNewFile.Location = new System.Drawing.Point(22, 89);
            this.btnStartNewFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartNewFile.Name = "btnStartNewFile";
            this.btnStartNewFile.Size = new System.Drawing.Size(159, 35);
            this.btnStartNewFile.TabIndex = 0;
            this.btnStartNewFile.Text = "Start New File";
            this.btnStartNewFile.UseVisualStyleBackColor = true;
            this.btnStartNewFile.Click += new System.EventHandler(this.btnStartNewFile_Click);
            // 
            // LoggerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 1032);
            this.Controls.Add(this.tpSetup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDataMask);
            this.Controls.Add(this.btnEditMask);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoggerWindow";
            this.Text = "Car CAN Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoggerWindow_FormClosing);
            this.Load += new System.EventHandler(this.LoggerWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tpSetup.ResumeLayout(false);
            this.tabComPort.ResumeLayout(false);
            this.tabComPort.PerformLayout();
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.tabLogging.ResumeLayout(false);
            this.tabLogging.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblComSpeed;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cmbComSpeed;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCanBitrate;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.ListBox lbRawLog;
        private System.Windows.Forms.CheckBox cbRawLogEnable;
        private System.Windows.Forms.Timer receivingTimer;
        private System.Windows.Forms.Button btnClearRawLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbIdList;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListBox lbDataList;
        private System.Windows.Forms.Button btnResetNew;
        private System.Windows.Forms.Button btnResetSelected;
        private System.Windows.Forms.Button btnEditMask;
        private System.Windows.Forms.TextBox tbDataMask;
        private System.Windows.Forms.TextBox tbIdDataMask;
        private System.Windows.Forms.Button btnEditIdMask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnResetIdMask;
        private System.Windows.Forms.Button btnResetIdName;
        private System.Windows.Forms.Button btnEditIdName;
        private System.Windows.Forms.TextBox tbIdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tpSetup;
        private System.Windows.Forms.TabPage tabComPort;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.Button btnOpenLogFile;
        private System.Windows.Forms.TextBox tbFileLines;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbFileCurrentLine;
        private System.Windows.Forms.Button btnPlay100;
        private System.Windows.Forms.Button btnPlay10;
        private System.Windows.Forms.Button btnPlay1;
        private System.Windows.Forms.Button btnPlay1000;
        private System.Windows.Forms.Button btnResetCurrentLine;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.CheckBox cbEnableLogging;
        private System.Windows.Forms.Button btnStartNewFile;
        private System.Windows.Forms.TextBox tbLogFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnResetSelectedCount;
        private System.Windows.Forms.Button btnShowIdMessageHistory;
        private System.Windows.Forms.Button btnShowIdMessages;
    }
}


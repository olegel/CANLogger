using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolvoCanLogger
{
    public partial class LoggerWindow : Form
    {
        private Can232Processor _can232 = new Can232Processor();
        private bool _init = false;

        private DataProcessor _dataProcessor = new DataProcessor();
        private LogData _logData = new LogData();
        private FileLogger _fileLogger = new FileLogger();
        private LogPlayer _logPlayer;

        private IReceivedMessageProcessor[] _receivedMessageProcessors;

        public LoggerWindow()
        {
            InitializeComponent();
            _logPlayer = new LogPlayer(_can232);

            lbRawLog.DataSource = _logData;

            lbIdList.DisplayMember = nameof(CanIdStatus.DisplayText);
            lbIdList.DataSource = _dataProcessor.GetIdBindingList();

            tbDataMask.DataBindings.Add(nameof(tbDataMask.Text), _dataProcessor, nameof(_dataProcessor.DataMaskText));

            btnResetSelected.DataBindings.Add(nameof(btnResetSelected.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));
            btnResetSelectedCount.DataBindings.Add(nameof(btnResetSelectedCount.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));

            tbIdDataMask.DataBindings.Add(nameof(tbIdDataMask.Text), _dataProcessor, nameof(_dataProcessor.SelectedIdDataMaskText));
            btnEditIdMask.DataBindings.Add(nameof(btnEditIdMask.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));
            btnResetIdMask.DataBindings.Add(nameof(btnResetIdMask.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));

            tbIdName.DataBindings.Add(nameof(tbIdName.Text), _dataProcessor, nameof(_dataProcessor.SelectedIdName));
            btnResetIdName.DataBindings.Add(nameof(btnResetIdName.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));
            btnEditIdName.DataBindings.Add(nameof(btnEditIdName.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));

            btnShowIdMessageHistory.DataBindings.Add(nameof(btnShowIdMessageHistory.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));
            btnShowIdMessages.DataBindings.Add(nameof(btnShowIdMessages.Enabled), _dataProcessor, nameof(_dataProcessor.IsIdSelected));

            tbFileLines.DataBindings.Add(nameof(tbFileLines.Text), _logPlayer, nameof(_logPlayer.MessageCount));
            tbFileCurrentLine.DataBindings.Add(nameof(tbFileCurrentLine.Text), _logPlayer, nameof(_logPlayer.CurrentLine));

            lbDataList.DisplayMember = nameof(CanDataStatus.DisplayText);
            lbDataList.DataBindings.Add(nameof(lbDataList.DataSource), _dataProcessor, nameof(_dataProcessor.CurrentDataBindingList));

            tbLogFileName.DataBindings.Add(nameof(tbLogFileName.Text), _fileLogger, nameof(_fileLogger.FileName));

            var configData = ConfigData.Load();
            if (configData != null)
                _dataProcessor.SetConfig(configData);

            _receivedMessageProcessors = new IReceivedMessageProcessor[] { _dataProcessor, _logData, _fileLogger };

        }

        private void LoggerWindow_Load(object sender, EventArgs e)
        {
            //Config config = new Config();
            //config.DataMask = 0x3FFFFFFFFFFFFFFF;
            //config.AddIdName("00404066", "SWM");
            //config.AddIdDataMask("00404066", 0x3FFFFFF0FFFFFFFF);
            //config.AddIdName("01e052ee", "REM");
            //_dataProcessor.SetConfig(config);

            cmbComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if( cmbComPort.Items.Count > 0 )
                cmbComPort.SelectedIndex = 0;

            cmbComSpeed.SelectedIndex = 5;
            cmbCanBitrate.SelectedIndex = 4;

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            cbAutoStart.Enabled = true;
            cbAutoStart.Checked = true;

            cbRawLogEnable.Checked = true;

            receivingTimer.Interval = 330;
            receivingTimer.Start();
        }
        private void LoggerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var configData = _dataProcessor.GetConfig();
            if (configData != null)
                configData.Save();
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    // Open Port
                    serialPort.PortName = cmbComPort.SelectedItem.ToString();
                    serialPort.BaudRate = int.Parse(cmbComSpeed.SelectedItem.ToString());
                    serialPort.Open();

                    cmbComPort.Enabled = false;
                    cmbComSpeed.Enabled = false;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    cbAutoStart.Enabled = false;

                    if (cbAutoStart.Checked)
                    {
                        StartCan();
                        cbAutoStart.Checked = false;
                    }
                    else
                        btnStart.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Failed to open COM port");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                cmbComPort.Enabled = true;
                cmbComSpeed.Enabled = true;

                btnStart.Enabled = false;
                btnStop.Enabled = false;
                cbAutoStart.Enabled = true;

                StopCan();
                btnStart.Enabled = false;
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                _can232.ProcessStream(serialPort.ReadExisting());
            }
            catch (System.TimeoutException)
            {
            }
        }
        private void serialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartCan();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCan();
        }


        private void StartCan()
        {
            _logData.InsertLine("Start");

            btnStart.Enabled = false;
            cmbCanBitrate.Enabled = false;
            btnStop.Enabled = true;

            System.Threading.Thread.Sleep(500);
            if (!_init)
            {
                SendCan("C\r");
                _init = true;
            }
            SendCan("Z1\r");
            SendCan("V\r");
            SendCan("L\r");
        }

        private void StopCan()
        {
            _logData.InsertLine("Stop");
            SendCan("C\r");
            btnStart.Enabled = true;
            cmbCanBitrate.Enabled = true;
            btnStop.Enabled = false;
        }

        private void SendCan(string s)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(s);
                _logData.InsertLine(s);
                System.Threading.Thread.Sleep(50);
            }
            else
            {
                _logData.InsertLine("Port closed");
            }
        }

        // raw log
        private void cbRawLogEnable_Click(object sender, EventArgs e)
        {
            _logData.Pause(!cbRawLogEnable.Checked);
        }

        private void btnClearRawLog_Click(object sender, EventArgs e)
        {
            _logData.DeleteAll();
        }

        private void logTimer_Tick(object sender, EventArgs e)
        {
            //int lastSelectedCanId = GetSelectedCanId();
            //var list = _dataProcessor.GetCanIdList();

            //foreach (var v in list)
            //{
            //    CanIdData data = null;
            //    if( _canIdDataDict.TryGetValue( v.Id, out data ) )
            //    {
            //        _canIdDataDict[v.Id] = v;
            //    }
            //    else
            //    {
            //        _canIdDataDict.Add(v.Id, v);
            //    }
            //}

            //{
            //    lbIdList.BeginUpdate();

            //    if (_canIdDataDict.Count != _idListDict.Count)
            //    {
            //        lbIdList.Items.Clear();
            //        _idListDict.Clear();
            //    }

            //    int posToSelect = -1;
            //    foreach (var pair in _canIdDataDict)
            //    {
            //        var v = pair.Value;
            //        string s;
            //        if( v.Name == null )
            //            s = string.Format("{0,8:X8} {1,4} {2,4}", v.Id, v.Count, v.NewCount);
            //        else
            //        {
            //            string name = v.Name.Substring(0, v.Name.Length > 8 ? 8 : v.Name.Length);
            //            s = string.Format("{0,8} {1,4} {2,4}", name, v.Count, v.NewCount);
            //        }

            //        int listBoxPos = -1;
            //        if (!_idListDict.TryGetValue(v.Id, out listBoxPos))
            //        {
            //            listBoxPos = lbIdList.Items.Add(s);
            //            _idListDict.Add(v.Id, listBoxPos);
            //        }
            //        else
            //        {
            //            lbIdList.Items[listBoxPos] = s;
            //        }

            //        if (lastSelectedCanId >= 0 && v.Id == lastSelectedCanId)
            //            posToSelect = listBoxPos;
            //    }
            //    if (posToSelect >= 0)
            //        lbIdList.SelectedIndex = posToSelect;

            //    lbIdList.EndUpdate();
            //}

            //// fill data list

            //if( lastSelectedCanId >= 0 )
            //{
            //    CanIdData idData = null;
            //    if (_canIdDataDict.TryGetValue(lastSelectedCanId, out idData))
            //    {
            //        lbDataList.BeginUpdate();
            //        lbDataList.Items.Clear();
            //        foreach (var pair in idData.MessageDict)
            //        {
            //            string s = string.Format("{0} {1,4} {2}", Helpers.DataAsString(pair.Value.Message.Data), pair.Value.Version, pair.Value.Message.Time);
            //            lbDataList.Items.Add(s);
            //        }
            //        lbDataList.EndUpdate();

            //        string dataMaskTxt = Helpers.DataMaskAsString(idData.DataMask);
            //        if (0 != dataMaskTxt.CompareTo(tbIdDataMask.Text))
            //            tbIdDataMask.Text = dataMaskTxt;
            //    }
            //    else
            //    {
            //        tbIdDataMask.Text = "";
            //        lbDataList.Items.Clear();
            //    }
            //}
            //else if (lbDataList.Items.Count > 0)
            //{
            //    tbIdDataMask.Text = "";
            //    lbDataList.Items.Clear();
            //}
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _dataProcessor.ResetData();
        }

        private void btnResetNew_Click(object sender, EventArgs e)
        {
            _dataProcessor.ResetCounters();
        }

        private void btnResetSelected_Click(object sender, EventArgs e)
        {
            _dataProcessor.ResetSelectedIdMessages();
        }

        private void btnEditMask_Click(object sender, EventArgs e)
        {
            MaskEditor win = new MaskEditor(_dataProcessor.DataMask );
            var result = win.ShowDialog(this);
            if(DialogResult.OK == result)
                _dataProcessor.DataMask = win.GetMask();
        }

        private void receivingTimer_Tick(object sender, EventArgs e)
        {
            var receivedMessageList = _can232.GetReceivedMessageList();
            if (receivedMessageList.Count <= 0)
                return;

            foreach (var processor in _receivedMessageProcessors)
                processor.ProcessMessages(receivedMessageList);
        }

        private void lbIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lbIdList.SelectedIndex;
            _dataProcessor.SetSelectedIdIndex(idx);
        }

        private void btnEditIdMask_Click(object sender, EventArgs e)
        {
            if (!_dataProcessor.IsIdSelected)
                return;

            MaskEditor win = new MaskEditor(_dataProcessor.SelectedIdDataMask);
            var result = win.ShowDialog(this);
            if (DialogResult.OK == result)
                _dataProcessor.SelectedIdDataMask = win.GetMask();
        }

        private void btnResetIdMask_MouseClick(object sender, MouseEventArgs e)
        {
            _dataProcessor.ResetSelectedIdMask();
        }

        private void btnEditIdName_Click(object sender, EventArgs e)
        {
            if (!_dataProcessor.IsIdSelected)
                return;

            var win = new NameEditor(_dataProcessor.SelectedIdName);
            var result = win.ShowDialog(this);
            if (DialogResult.OK == result)
                _dataProcessor.SelectedIdName = win.GetName();
        }

        private void btnResetIdName_Click(object sender, EventArgs e)
        {
            _dataProcessor.ResetSelectedIdName();
        }

        private void btnOpenLogFile_Click(object sender, EventArgs e)
        {
            var win = new OpenFileDialog();
            win.Title = "Open Log File";
            win.Filter = "Log data|*.logdata";
            //win.InitialDirectory = @"C:\";
            if (win.ShowDialog() != DialogResult.OK)
                return;

            _logPlayer.LoadFile(win.FileName);
        }

        private void btnPlay1_Click(object sender, EventArgs e)
        {
            _logPlayer.PlayLines(1);
        }

        private void btnPlay10_Click(object sender, EventArgs e)
        {
            _logPlayer.PlayLines(10);
        }

        private void btnPlay100_Click(object sender, EventArgs e)
        {
            _logPlayer.PlayLines(100);
        }

        private void btnPlay1000_Click(object sender, EventArgs e)
        {
            _logPlayer.PlayLines(1000);
        }

        private void btnResetCurrentLine_Click(object sender, EventArgs e)
        {
            _logPlayer.CurrentLine = 0;
        }

        private void cbEnableLogging_CheckedChanged(object sender, EventArgs e)
        {
            _fileLogger.Enable = cbEnableLogging.Checked;
        }

        private void btnStartNewFile_Click(object sender, EventArgs e)
        {
            _fileLogger.CreateNewFileName();
        }

        private void btnResetIdCount_Click(object sender, EventArgs e)
        {
            _dataProcessor.ResetSelecteIdCounters();
        }

        private void btnShowIdMessageHistory_Click(object sender, EventArgs e)
        {
            var list = _dataProcessor.GetSelectedIdLastMessages();
            if (list == null)
                return;

            var win = new MessageList(list);
            var result = win.ShowDialog(this);
        }

        private void btnShowIdMessages_Click(object sender, EventArgs e)
        {
            var list = _dataProcessor.GetSelectedIdMessages();
            if (list == null)
                return;

            var win = new MessageList(list);
            var result = win.ShowDialog(this);
        }
    }
}

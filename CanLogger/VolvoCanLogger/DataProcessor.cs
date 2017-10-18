using BindingHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoCanLogger
{
    public class CanDataStatus
    {
        internal CanMessage _message;
        private int _count;
        private string _name;
        private int _version;

        internal CanDataStatus(CanMessage message)
        {
            _message = message;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string DisplayText
        {
            get
            {
                string s;
                if (_name == null)
                    s = string.Format("{0} {1,4} {2,5}", Helpers.DataAsString(_message.Data), _count, _version);
                else
                {
                    string name = _name.Substring(0, _name.Length > 8 ? 8 : _name.Length);
                    s = string.Format("{0} {1,4} {2,5} {3}", Helpers.DataAsString(_message.Data), _count, _version, name);
                }
                return s;
            }
        }

        internal void ResetCounters()
        {
            _count = 0;
            _version = 0;
        }

        internal void ProcessMessage(CanMessage canMessage, int count)
        {
            _message = canMessage;
            _version = count;
            _count++;
        }
    }

    public class CanDataStatuses : BindingList<CanDataStatus>
    {
        private SortedDictionary<ulong, CanDataStatus> _dict = new SortedDictionary<ulong, CanDataStatus>();

        private CanDataStatus Find(ulong data)
        {
            CanDataStatus status;
            if (_dict.TryGetValue(data, out status))
                return status;
            return null;
        }

        internal void ResetData()
        {
            Clear();
            _dict.Clear();
        }

        internal bool ProcessMessage(CanMessage canMessage, int version)
        {
            var status = Find(canMessage.Data);
            if (status == null)
            {
                status = new CanDataStatus(canMessage);
                _dict.Add(canMessage.Data, status);
                Add(status);
                status.ProcessMessage(canMessage, version);
                return true;
            }
            else
            {
                status.ProcessMessage(canMessage, version);
                return false;
            }
        }

        internal void ResetCounters()
        {
            foreach(var status in this)
                status.ResetCounters();
        }
    }


    public class CanIdStatus
    {
        internal int Id;
        internal int Count = 0;
        internal int NewCount = 0;
        private bool _isMaskSet = false;

        private ulong _dataMask = 0xFFFFFFFFFFFFFFFF;
        private string _name;

        private CanDataStatuses _dataStatuses = new CanDataStatuses();
        private List<CanMessage> _lastCanMessages = new List<CanMessage>();
        const int MAX_MESSAGES_TO_HOLD = 500;

        internal CanIdStatus(int id)
        {
            Id = id;
        }
        
        public ulong DataMask
        {
            get { return _dataMask; }
            set { _isMaskSet = true; _dataMask = value; }
        }

        public bool IsMaskSet {
            get { return _isMaskSet; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string DisplayText {
            get
            {
                string s;
                if (_name == null)
                    s = string.Format("{0,8:X8} {1,5} {2,4}", Id, Count, NewCount);
                else
                {
                    string name = _name.Substring(0, _name.Length > 8 ? 8 : _name.Length);
                    s = string.Format("{0,8:X8} {1,5} {2,4} {3}", Id, Count, NewCount, name);
                }
                return s;
            }
        }

        internal void ResetCounters()
        {
            Count = 0;
            NewCount = 0;
            _dataStatuses.ResetCounters();
        }

        internal void ProcessMessage(CanMessage canMessage)
        {
            _lastCanMessages.Add(canMessage);
            while (_lastCanMessages.Count > MAX_MESSAGES_TO_HOLD)
                _lastCanMessages.RemoveAt(0);

            Count++;
            if (_isMaskSet)
                canMessage.ApplyMask(_dataMask);
            if ( _dataStatuses.ProcessMessage(canMessage, Count) )
                NewCount++;
        }

        internal void ResetDataMask()
        {
            _isMaskSet = false;
        }

        internal CanDataStatuses GetDataStatuses()
        {
            return _dataStatuses;
        }

        internal void ResetData()
        {
            _dataStatuses.ResetData();
            ResetCounters();
            _lastCanMessages.Clear();
        }

        internal List<CanMessage> GetLastCanMessages()
        {
            return _lastCanMessages.ToList();
        }

        internal List<CanMessage> GetCanMessages()
        {
            List<CanMessage> list = new List<CanMessage>();
            foreach (var m in _dataStatuses)
                list.Add(m._message);
            return list;
        }
    }


    public class CanIdStatuses : BindingList<CanIdStatus>
    {
        private SortedDictionary<int, CanIdStatus> _dict = new SortedDictionary<int, CanIdStatus>();

        internal CanIdStatus Find( int id )
        {
            CanIdStatus status;
            if (_dict.TryGetValue(id, out status))
                return status;
            return null;
        }

        internal CanIdStatus GetStatus(int id)
        {
            var status = Find(id);
            if(status == null)
            {
                status = new CanIdStatus(id);
                _dict.Add(id, status);
                Add(status);
            }
            return status;
        }

        internal void ResetData()
        {
            Clear();
            _dict.Clear();
        }

        internal int IndexOf(int id)
        {
            for(int i=0; i < Count; i++)
            {
                if (this[i].Id == id)
                    return i;
            }
            return -1;
        }
    }

    public class DataProcessor : INotifyPropertyChanged, IReceivedMessageProcessor
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        private Config _config = new Config();
        private CanIdStatuses _statuses = new CanIdStatuses();
        private CanIdStatus _selectedIdStatus;
        private CanDataStatuses _emptyCanDataStatuses = new CanDataStatuses();

        public IBindingList GetIdBindingList()
        {
            return _statuses;
        }

        public string DataMaskText
        {
            get { return Helpers.DataMaskAsString(_config.DataMask); }
        }

        public ulong DataMask
        {
            get
            {
                return _config.DataMask;
            }
            set
            {
                _config.DataMask = value;
                NotifyPropertyChanged(nameof(DataMaskText));
            }
        }

        public bool IsIdSelected
        {
            get { return _selectedIdStatus != null; }
        }

        public IBindingList CurrentDataBindingList
        {
            get { return _selectedIdStatus != null ? _selectedIdStatus.GetDataStatuses() : _emptyCanDataStatuses; }
        }

        public string SelectedIdDataMaskText
        {
            get
            {
                if (_selectedIdStatus == null)
                    return "<not selected>";
                else
                    return _selectedIdStatus.IsMaskSet ? Helpers.DataMaskAsString(_selectedIdStatus.DataMask) : "Default";
            }
        }

        public ulong SelectedIdDataMask
        {
            get
            {
                if (_selectedIdStatus != null)
                    return _selectedIdStatus.IsMaskSet ? _selectedIdStatus.DataMask : _config.DataMask;
                return 0;
            }
            set
            {
                if (_selectedIdStatus != null)
                {
                    _selectedIdStatus.DataMask = value;
                    _config.SetIdDataMask(_selectedIdStatus.Id, value);
                    NotifyPropertyChanged(nameof(SelectedIdDataMaskText));
                }
            }
        }

        public string SelectedIdName
        {
            get
            {
                if (_selectedIdStatus != null && _selectedIdStatus.Name != null)
                    return _selectedIdStatus.Name;
                return "";
            }
            set
            {
                if (_selectedIdStatus != null)
                {
                    _selectedIdStatus.Name = value;
                    _config.SetIdName(_selectedIdStatus.Id, value);
                    NotifyPropertyChanged(nameof(SelectedIdName));
                    _statuses.ResetBindings();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        // methods

        public ConfigData GetConfig()
        {
            return _config.GetData();
        }

        public void SetConfig(ConfigData data)
        {
            _config.SetData(data);

            using (_statuses.CreateUpdateSuppressor())
            {
                ApplyConfigToStatuses();
            }
        }

        public void ResetData()
        {
            int selectedIdx = -1;
            using (_statuses.CreateUpdateSuppressor())
            {
                int id = _selectedIdStatus != null ? _selectedIdStatus.Id : -1;
                _statuses.ResetData();
                _selectedIdStatus = null;
                ApplyConfigToStatuses();
                selectedIdx = _statuses.IndexOf(id);
            }
            //SetSelectedIdIndex(-1);
            SetSelectedIdIndex(selectedIdx);
        }

        public void ResetCounters()
        {
            using (_statuses.CreateUpdateSuppressor())
            using (_selectedIdStatus != null ? _selectedIdStatus.GetDataStatuses().CreateUpdateSuppressor() : null)
            {
                foreach (var status in _statuses)
                    status.ResetCounters();
            }
        }

        internal void SetSelectedIdIndex(int idx)
        {
            _selectedIdStatus = GetSelectedIdStatus(idx);
            NotifyPropertyChanged(nameof(CurrentDataBindingList));
            //NotifyPropertyChanged(nameof(SelectedIdDataMaskText));
            //NotifyPropertyChanged(nameof(SelectedIdName));
        }

        internal void ResetSelectedIdMask()
        {
            if (_selectedIdStatus == null)
                return;

            _config.RemoveIdDataMask(_selectedIdStatus.Id);
            if (_selectedIdStatus.IsMaskSet)
            {
                _selectedIdStatus.ResetDataMask();
                NotifyPropertyChanged(nameof(SelectedIdDataMaskText));
                _statuses.ResetBindings();
            }
        }
        internal void ResetSelectedIdName()
        {
            if (_selectedIdStatus == null)
                return;

            _config.RemoveIdName(_selectedIdStatus.Id);
            if (_selectedIdStatus.Name != null)
            {
                _selectedIdStatus.Name = null;
                NotifyPropertyChanged(nameof(SelectedIdName));
                _statuses.ResetBindings();
            }
        }

        public void ResetSelectedIdMessages()
        {
            if (_selectedIdStatus == null)
                return;

            using (_selectedIdStatus.GetDataStatuses().CreateUpdateSuppressor())
            {
                _selectedIdStatus.ResetData();
            }
            _statuses.ResetBindings();
        }

        internal void ResetSelecteIdCounters()
        {
            if (_selectedIdStatus == null)
                return;

            _selectedIdStatus.ResetCounters();

            _statuses.ResetBindings();
            _selectedIdStatus.GetDataStatuses().ResetBindings();
        }

        // IReceivedMessageProcessor
        public void ProcessMessages(ReceivedMessageList messageList)
        {
            using (_statuses.CreateUpdateSuppressor())
            using (_selectedIdStatus != null ? _selectedIdStatus.GetDataStatuses().CreateUpdateSuppressor() : null)
            {
                foreach (var message in messageList)
                {
                    var canMessage = message.CanMessage;
                    if (canMessage == null)
                        continue;

                    canMessage.ApplyMask(_config.DataMask);

                    CanIdStatus status = _statuses.GetStatus(canMessage.Id);
                    status.ProcessMessage(canMessage);
                }
            }
        }

        internal List<CanMessage> GetSelectedIdLastMessages()
        {
            if (_selectedIdStatus == null)
                return null;

            return _selectedIdStatus.GetLastCanMessages();
        }

        internal List<CanMessage> GetSelectedIdMessages()
        {
            if (_selectedIdStatus == null)
                return null;

            return _selectedIdStatus.GetCanMessages();
        }

        /// private

        private CanIdStatus GetSelectedIdStatus( int idx )
        {
            if (idx >= 0 && idx < _statuses.Count())
                return _statuses[idx];
            return null;
        }

        private void ApplyConfigToStatuses()
        {
            foreach (var p in _config.IdDataMaskDict)
            {
                var status = _statuses.GetStatus(p.Key);
                status.DataMask = p.Value;
            }
            foreach (var p in _config.IdNameDict)
            {
                var status = _statuses.GetStatus(p.Key);
                status.Name = p.Value;
            }
        }
    }
}

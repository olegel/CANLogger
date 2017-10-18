using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoCanLogger
{
    public class FileLogger : IReceivedMessageProcessor, INotifyPropertyChanged
    {
        private string _fileName;

        public bool Enable { get; set; }
        public string FileName {
            get { return _fileName; }
            set
            {
                _fileName = value;
                NotifyPropertyChanged(nameof(FileName));
            }
        }

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

        public FileLogger(string filename)
        {
            FileName = filename;
        }

        public FileLogger()
        {
            CreateNewFileName();
        }

        public void CreateNewFileName()
        {
            DateTime current = DateTime.Now;
            FileName = string.Format("{0}{1:00}{2:00}_{3:00}{4:00}{5:00}.logdata", current.Year, current.Month, current.Day, current.Hour, current.Minute, current.Second);
        }

        public void ProcessMessages( ReceivedMessageList messages )
        {
            if (!Enable)
                return;

            List<string> list = new List<string>();
            foreach(var message in messages)
            {
                if (message.CanMessage == null)
                    continue;
                list.Add(message.RawText);
            }

            if(list.Count > 0)
            System.IO.File.AppendAllLines(FileName, list );
        }
    }
}

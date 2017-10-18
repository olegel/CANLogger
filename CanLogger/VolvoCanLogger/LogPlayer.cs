using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoCanLogger
{
    class LogPlayer : INotifyPropertyChanged
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

        private ICanMessageParser _parser;
        private string[] _lines;
        private int _currentLine;

        public LogPlayer( ICanMessageParser parser )
        {
            _parser = parser;
        }

        public void LoadFile( string fileName)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            _lines = lines;
            _currentLine = 0;
            NotifyPropertyChanged(nameof(MessageCount));
            NotifyPropertyChanged(nameof(CurrentLine));
        }

        public int MessageCount
        {
            get { return _lines != null ? _lines.Length : 0;  }
        }
        public int CurrentLine
        {
            get { return _currentLine; }
            set
            {
                _currentLine = value;
                NotifyPropertyChanged(nameof(CurrentLine));
            }
        }

        internal void PlayLines(int count)
        {
            if (count <= 0 || _lines == null)
                return;

            int played = 0;
            while( _currentLine < _lines.Length )
            {
                _parser.ProcessTextMessage(_lines[_currentLine]);
                _currentLine++;
                played++;

                if (played >= count)
                    break;
            }
            NotifyPropertyChanged(nameof(CurrentLine));
        }
    }
}

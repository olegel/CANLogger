using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VolvoCanLogger
{
    public class LogData : BindingList<string>, IReceivedMessageProcessor
    {
        private bool _isPaused = false;

        // IReceivedMessageProcessor
        public void ProcessMessages( ReceivedMessageList list )
        {
            RaiseListChangedEvents = false;

            foreach( var message in list)
                AddNewLine(message.LogText);

            RaiseListChangedEvents = true;
            ResetBindings();
        }

        public void InsertLine( string s )
        {
            RaiseListChangedEvents = false;

            AddNewLine(s);

            RaiseListChangedEvents = true;
            ResetBindings();
        }

        public void DeleteAll()
        {
            RaiseListChangedEvents = false;

            Clear();
            AddNewLine("Erased");

            RaiseListChangedEvents = true;
            ResetBindings();
        }

        public void Pause( bool paused )
        {
            if (paused)
                InsertLine("Paused");
            _isPaused = paused;
            if (!paused)
                InsertLine("Resumed");
        }
        private void AddNewLine(string s)
        {
            if (_isPaused)
                return;
            while (Count > 100)
            {
                RemoveAt(Count - 1);
            }
            InsertItem(0, s);
        }
    }
}

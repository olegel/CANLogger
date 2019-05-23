using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoCanLogger
{
    public class CanMessage
    {
        public int Id;
        public int DataCount;
        public ulong Data;
        public int Time;

        public CanMessage()
        {
            Data = 0;
        }

        public string Dump()
        {
            return string.Format("{0}. {1:X} {2}", Time, Id, Helpers.DataMaskAsString(Data));
        }

        public string DisplayText
        {
            get
            {
                return string.Format("{0} {1}", Helpers.DataAsString(Data), Time);
            }
        }

    internal void ApplyMask(ulong dataMask)
        {
            Data &= dataMask;
        }
    }

    public class ReceivedMessage
    {
        public int RawId;
        public CanMessage CanMessage;
        public string LogText;
        public string RawText;

        public void GenerateLogText()
        {
            if (CanMessage != null)
                LogText = $"{RawId}. {CanMessage.Dump()}";
            else
                LogText = $"{RawId}. {RawText}";
        }
    }

    public class ReceivedMessageList : List<ReceivedMessage>
    {
        public ReceivedMessage Add(int rawId, string text)
        {
            var message = new ReceivedMessage();
            message.RawId = rawId;
            message.RawText = text;
            Add(message);
            return message;
        }

    }

    public class CanMessageStats
    {
        public CanMessage Message;
        public uint Count;
        public uint Version;

        public CanMessageStats( CanMessage mes )
        {
            Message = mes;
        }

        public void Update(CanMessage m)
        {
            Message = m;
            Version++;
            Count++;
        }
    }
    
    public interface IReceivedMessageProcessor
    {
        void ProcessMessages(ReceivedMessageList messageList);
    }

    public interface ICanMessageParser
    {
        void ProcessTextMessage(string line);
    }
}

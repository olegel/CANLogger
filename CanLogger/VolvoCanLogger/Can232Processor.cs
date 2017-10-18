using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoCanLogger
{
    public class Can232Processor : ICanMessageParser
    {
        private object _lock = new object();
        ReceivedMessageList _messageList = new ReceivedMessageList();

        private int _rawId = 0;
        private string _buffer;

        public Can232Processor()
        {
        }

        public ReceivedMessageList GetReceivedMessageList()
        {
            ReceivedMessageList list;
            lock (_lock)
            {
                list = _messageList;
                _messageList = new ReceivedMessageList();
            }
            return list;
        }

        public void ProcessTextMessage(string line)
        {
            lock (_lock)
            {
                var messageList = new ReceivedMessageList();
                var receivedMessage = messageList.Add(++_rawId, line);

                CanMessage canMessage = ProcessMessageData(line);
                if (canMessage != null)
                {
                    receivedMessage.CanMessage = canMessage;
                }

                PushReceivedMessages(messageList);
            }
        }

        public bool ProcessStream(string data)
        {
            lock (_lock)
            {
                _buffer += data;

                var messageList = new ReceivedMessageList();

                int pos = ParseMessages(_buffer, messageList);
                if (pos < 0)
                    _buffer = "";
                else
                    _buffer = _buffer.Substring(pos);

                PushReceivedMessages(messageList);
            }
            return true;
        }

        void PushReceivedMessages(ReceivedMessageList list)
        {
            foreach (var message in list)
                message.GenerateLogText();
            _messageList.AddRange(list);
        }

        int ParseMessages(string data, ReceivedMessageList messageList)
        {
            int length = data.Length;
            int pos = 0;
            while (true)
            {
                int remain = length - pos;
                if (remain <= 0)
                    break;

                int c = data[pos];
                switch (c)
                {
                    case 13:
                        messageList.Add(++_rawId, "ok");
                        pos++;
                        continue;
                    case 7:
                        messageList.Add(++_rawId, "error");
                        pos++;
                        continue;
                }

                int end = data.IndexOf('\r', pos);
                if (end < 0)
                    return pos;

                string message = data.Substring(pos, end - pos);
                pos = end + 1;

                var receivedMessage = messageList.Add(++_rawId, message);

                CanMessage canMessage = ProcessMessageData(message);
                if (canMessage != null)
                {
                    receivedMessage.CanMessage = canMessage;
                }
            }
            return -1;
        }

        CanMessage ProcessMessageData(string data)
        {
            CanMessage canMessage = null;

            int length = data.Length;
            int pos = 0;
            int c = data[pos];
            int idLen = 0;
            switch (c)
            {
                case 'T':
                    idLen = 8;
                    break;
                case 't':
                    idLen = 3;
                    break;
            }

            while (true)
            {
                if (idLen <= 0)
                    break;

                pos++;

                if (length < idLen + pos)
                    break;

                string idTxt = data.Substring(pos, idLen);
                pos += idLen;

                if (length < pos + 1)
                    break;

                int dataByteCount = int.Parse(data.Substring(pos, 1));
                if (dataByteCount < 0 || dataByteCount > 8)
                    break;
                pos++;
                if (length < pos + dataByteCount * 2)
                    break;

                string dataTxt = data.Substring(pos, dataByteCount * 2);
                pos += dataByteCount * 2;

                string timeTxt = "00";
                if (pos < length)
                    timeTxt = data.Substring(pos);

                canMessage = new CanMessage();
                canMessage.Id = Convert.ToInt32(idTxt, 16);
                canMessage.Time = Convert.ToInt32(timeTxt, 16);
                canMessage.DataCount = dataByteCount;
                for (int i = 0; i < dataByteCount; i++)
                {
                    string s = dataTxt.Substring(i * 2, 2);
                    byte b = (byte)Convert.ToInt32(s, 16);
                    canMessage.Data = Helpers.SetDataByte(canMessage.Data, i, b);
                }
                break;
            }
            return canMessage;
        }
    }
}

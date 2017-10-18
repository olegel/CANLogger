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
    public partial class MessageList : Form
    {
        private BindingList<CanMessage> _messages = new BindingList<CanMessage>();

        public MessageList( List<CanMessage> list )
        {
            InitializeComponent();

            foreach (var m in list)
                _messages.Add(m);

            lbMessages.DisplayMember = nameof(CanMessage.DisplayText);
            lbMessages.DataSource = _messages;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
        }

        private void lbMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMessages.SelectedIndices.Count == 1)
                UpdateData(_messages[lbMessages.SelectedIndices[0]], null);
            else if (lbMessages.SelectedIndices.Count == 2)
                UpdateData(_messages[lbMessages.SelectedIndices[0]], _messages[lbMessages.SelectedIndices[1]]);
            else
                UpdateData(null, null);
        }

        private void UpdateData( CanMessage m1, CanMessage m2 )
        {
            string text1 = "", text2="", diff = "", item1 = "", item2 = "";
            if (m1 != null)
            {
                item1 = m1.DisplayText;
                text1 = Helpers.DataAsBinaryString(m1.Data);
            }
            if (m2 != null)
            {
                item2 = m2.DisplayText;
                text2 = Helpers.DataAsBinaryString(m2.Data);
                diff = Helpers.DataAsBinaryDiffString(m1.Data ^ m2.Data);
            }

            tbData1.Text = text1;
            tbData2.Text = text2;
            tbDataDiff.Text = diff;

            tbItem1.Text = item1;
            tbItem2.Text = item2;
        }
    }
}

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
    public partial class MaskEditor : Form
    {
        private ulong _mask;
        TextBox[] EditBoxes;

        public MaskEditor( ulong mask )
        {
            InitializeComponent();
            _mask = mask;
        }

        public ulong GetMask()
        {
            return _mask;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ulong mask = _mask;
                for (int i = 0; i < 8; i++)
                {
                    byte b = (byte)Convert.ToInt32(EditBoxes[i].Text , 16);
                    mask = Helpers.SetDataByte(mask, i, b);
                }

                _mask = mask;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;

        }

        private void MaskEditor_Load(object sender, EventArgs e)
        {
            EditBoxes = new TextBox[] { tbD0, tbD1, tbD2, tbD3, tbD4, tbD5, tbD6, tbD7 };

            for(int i = 0; i < 8; i++)
            {
                EditBoxes[i].Text = string.Format( "{0,2:X2}", Helpers.GetDataByte(_mask, i) );
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            SetValues("FF");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetValues("00");
        }

        private void SetValues( string v )
        {
            for (int i = 0; i < 8; i++)
            {
                EditBoxes[i].Text = v;
            }
        }

    }
}

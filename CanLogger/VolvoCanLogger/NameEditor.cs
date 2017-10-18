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
    public partial class NameEditor : Form
    {
        private string _name;


        public NameEditor(string name)
        {
            InitializeComponent();
            _name = name;
            tbName.Text = name;
        }

        public string GetName()
        {
            return _name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _name = tbName.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }
    }
}

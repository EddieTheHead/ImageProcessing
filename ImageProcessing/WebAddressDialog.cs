using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class WebAddressDialog : Form
    {
        public WebAddressDialog()
        {
            InitializeComponent();
            if(textBoxUrl.Text == "") textBoxUrl.Text = url;
        }
        
        public String url = @"http://";

        public DialogResult result = DialogResult.Ignore;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
           result = DialogResult.Cancel;
           this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnScreenVirtualJoystickController
{
    public partial class KeyVerificationForm : Form
    {

        private string product_id = FingerPrint.Value();

        public KeyVerificationForm()
        {
            InitializeComponent();
        }

        public string get_license_key()
        {
            return this.license_textbox.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            if(this.keyCheck(this.product_id, this.license_textbox.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.setFailedMessage();
            }
        }

        private void license_textbox_TextChanged(object sender, EventArgs e)
        {
            this.failed_label.Text = "";
        }

        private bool keyCheck(string product_id, string license_key)
        {
            bool result = false;
            if (KeyCheck.CheckKey(product_id, license_key) == "GOOD")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}

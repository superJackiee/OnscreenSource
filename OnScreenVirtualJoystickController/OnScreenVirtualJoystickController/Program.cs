using System;
using System.Windows.Forms;

namespace OnScreenVirtualJoystickController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // fireFunction();

            string[] reg_values = RegistryManagement.getRegistryValue();
            if(reg_values[0] == null)
            {
                keyVerify();
            }
            else
            {
                string product_id = reg_values[0];
                string license_key = reg_values[1];
                if (keyCheck(product_id, license_key))
                {
                    fireFunction();
                }
                else
                {
                    keyVerify();
                }
            }
        }


        private static void keyVerify()
        {
            string product_id = FingerPrint.Value();

            KeyVerificationForm keyform = new KeyVerificationForm();
            keyform.setProductID(product_id);
            keyform.ShowDialog();

            if(keyform.DialogResult == DialogResult.OK)
            {
                RegistryManagement.setRegistryValue(product_id, keyform.get_license_key());
                fireFunction();
            }
        }

        private static bool keyCheck(string product_id, string license_key)
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

        private static void fireFunction()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainController());
        }
    }
}

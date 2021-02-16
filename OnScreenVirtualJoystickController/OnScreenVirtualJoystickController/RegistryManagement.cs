using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace OnScreenVirtualJoystickController
{
    class RegistryManagement
    {
        public static string[] getRegistryValue()
        {
            string[] result = new string[2];
            string userRoot = "HKEY_CURRENT_USER\\Software";
            string sub_key = "osvjc";
            string key_Name = userRoot + "\\" + sub_key;
            result[0] = (string)Registry.GetValue(key_Name, "pro_id", null);
            result[1] = (string)Registry.GetValue(key_Name, "osvjc_lic", null);
            return result;
        }

        public static void setRegistryValue(string pro_ID, string lic_key)
        {
            string userRoot = "HKEY_CURRENT_USER\\Software";
            string sub_key = "osvjc";
            string key_Name = userRoot + "\\" + sub_key;
            Registry.SetValue(key_Name, "pro_id", pro_ID);
            Registry.SetValue(key_Name, "osvjc_lic", lic_key);
        }
    }
}

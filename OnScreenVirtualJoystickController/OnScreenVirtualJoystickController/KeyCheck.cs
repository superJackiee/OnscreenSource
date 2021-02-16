using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OnScreenVirtualJoystickController
{
    class KeyCheck
    {
        public static string CheckKey(string id, string key)
        {
            string result = "";

            int i_value = int.Parse(id);
            long val1 = ((long)i_value + 1989) * 11 % 9999;
            long val2 = ((long)i_value + 910) * 101 % 9999;
            long val3 = ((long)i_value + 11304) * 1001 % 9999;
            string val_str = val1.ToString() + val2.ToString() + val3.ToString();

            string ver_key = CalculateMD5Hash(val_str);
            if(key == ver_key)
            {
                result = "GOOD";
            }
            else
            {
                result = "NO";
            }
            return result;
        }

        private static string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            string hashedString = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return hashedString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Buisness.Fuctions.Utilities
{
    public enum ProductSize
    {
        [System.ComponentModel.Description("Small")]
        S,
        [System.ComponentModel.Description("Medium")]
        M,
        [System.ComponentModel.Description("Large")]
        L

    }
    public static class Utility
    {



        public enum EnvironmentURL
        {
            [System.ComponentModel.Description("AP")]
            AutomationPractice
        }
        public static string GenerateTimeStamp()
        {
            DateTime time = DateTime.Now;
            string timeStamp = time.ToString("MMddyyyy HHmmss");
            return timeStamp;
        }

        public static decimal RemoveSpecialCharsAndConverIntoDecimal(string str)
        {
            string[] chars = new string[] { ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", "|", "[", "]" };
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }

            }
            decimal number = decimal.Parse(str);
            return number;
        }
    }
}

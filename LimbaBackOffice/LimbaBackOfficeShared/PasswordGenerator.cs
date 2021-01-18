using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeShared.NotificationEmail
{
    public class PasswordGenerator
    {
        public PasswordGenerator()
        {
                
        }

        public string RandomPassword(int? size)
        {
            int stringSize = size != null ? (int)size : 8;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i <= stringSize; i++)
            {
                if (new System.Random().Next(2) == 0)
                {
                    builder.Append(RandomString());
                }
                else
                {
                    builder.Append(RandomNumber());
                }
            }
            
            var result = builder.ToString();
            return result.ToString();
        }

        public int RandomNumber()
        {
            // Generate a random number  
            Random random = new Random();
            // Any random integer   
            return random.Next(10);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        public string RandomString()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);

            if (new System.Random().Next(2) == 0)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}

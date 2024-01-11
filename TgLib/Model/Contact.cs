using System;
using System.Collections.Generic;
using System.Text;

namespace TgLib.Model
{
    public class Contact
    {
        public string PhoneNumber { get; set; }

        /// <summary>
        /// First name of the user; 1-255 characters in length
        /// </summary>
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

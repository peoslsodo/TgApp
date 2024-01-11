using System;

namespace TgApp.Model
{
    public class Contact
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Username { get; set; }


        public string PhoneNumber { get; set; }


        public bool IsContact { get; set; }


        public string RestrictionReason { get; set; }


        public bool IsScam { get; set; }

        public DateTime Date { get; set; }


    }
}

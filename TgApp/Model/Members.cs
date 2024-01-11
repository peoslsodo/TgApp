using System;

namespace TgApp.Model
{
    public class Members
    {
        [SugarColumn(IsPrimaryKey = true)]
        public int Id { get; set; }

        public long GroupId { get; set; }
        public long UserId { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Username { get; set; }


        public string PhoneNumber { get; set; }


        public bool IsContact { get; set; }
        public string Status { get; set; }


        public string RestrictionReason { get; set; }


        public bool IsScam { get; set; }

        public DateTime Date { get; set; }


    }


    public class MemberView
    {
        public string GroupName { get; set; }
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Username { get; set; }


        public string PhoneNumber { get; set; }


        public bool IsContact { get; set; }


        public string RestrictionReason { get; set; }
        public string Status { get; set; }

        public bool IsScam { get; set; }

        public DateTime Date { get; set; }


    }
}

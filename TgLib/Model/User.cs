namespace TgLib.Model
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

 
        public string Username { get; set; }

  
        public string PhoneNumber { get; set; }

        
        public bool IsContact { get; set; }

        public string Status { get; set; }


        public string RestrictionReason { get; set; }

        
        public bool IsScam { get; set; }

    }


    public class SearchUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Username { get; set; }

        public string Status { get; set; }
        public string PhoneNumber { get; set; }

    }
}

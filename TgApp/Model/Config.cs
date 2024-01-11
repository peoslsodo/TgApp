using System;

namespace TgApp.Model
{
    public class Config
    {
  
        public int Id { get; set; }
        public string Phone { get; set; }
        public string ApiId { get; set; }
        public string ApiHash { get; set; }
        public bool IsUsed { get; set; }
        public string Pwd { get; set; }
        public DateTime UsedTime { get; set; }

    }
}
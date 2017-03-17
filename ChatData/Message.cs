using System;
using System.Collections.Generic;
using System.Text;

namespace ChatData
{
    //public class to store information about each message
    public class Message : User
    {
        public long messageId { get; set; }
        public string message { get; set; }
        public User user = new User();
    }
}

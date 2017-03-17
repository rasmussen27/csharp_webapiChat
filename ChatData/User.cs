using System;
using System.Collections.Generic;
using System.Text;

namespace ChatData
{
    //public class to store information about a user
    public class User
    {
        public string login { get; set; }

        //password not implemented, for future use if I use a database
        public string password { get; set; }

        public long lastReadMessage { get; set; }

        public User()
        {
            this.login = "";
            this.password = "";
            lastReadMessage = 0;
        }

    }
}

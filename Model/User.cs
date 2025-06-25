using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string inUsername, string inPassword)
        {
            Username = inUsername;
            Password = inPassword;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAnime_Client.UserLibs
{
    [Serializable]
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }

        public User(string user, string passwrd, string mail, DateTime dateTime)
        {
            username = user;
            password = passwrd;
            email = mail;
            date = dateTime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class User {
        public long UserId { get; set; }
        public String Pseudo { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }

        public User()
        {

        }

        public User(long id, String pseudo, String email, String password, String phoneNumber) {
            UserId = id;
            Pseudo = pseudo;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public User(String pseudo, String email, String password, String phoneNumber)
        {
            Pseudo = pseudo;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}
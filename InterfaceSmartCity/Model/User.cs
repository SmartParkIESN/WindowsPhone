using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class User {
        public long Id { get; set; }
        public String Pseudo { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
        public List<Parking> Parkings { get; set; }
        public List<Announcement> Announcements { get; set; }
        public List<Reporting> Reportings { get; set; }

        public User(long id, String pseudo, String email, String password, String phoneNumber) {
            Id = id;
            Pseudo = pseudo;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Parkings = new List<Parking>();
            Announcements = new List<Announcement> ();
            Reportings = new List<Reporting> ();
        }

        public User (long id, String pseudo, String email, String password) {
            Id = id;
            Pseudo = pseudo;
            Email = email;
            Password = password;
            Parkings = new List<Parking> ();
            Announcements = new List<Announcement> ();
            Reportings = new List<Reporting> ();
        }
    }
}
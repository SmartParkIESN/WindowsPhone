using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Parking {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Street { get; set; }
        public String Number { get; set; }
        public String Picture { get; set; }
        public String Description { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
        public Place Place { get; set; }
        public User User { get; set; }
        public List<Announcement> Announcements { get; set; }

        public Parking(long id, String name, String street, String number, String picture, String description, long longitude, long latitude, Place place, User user) {
            Id = id;
            Name = name;
            Street = street;
            Picture = picture;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
            Place = place;
            User = user;
            Announcements = new List<Announcement> ();


        }

    }
}

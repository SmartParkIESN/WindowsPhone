using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Parking {
        public long ParkingId { get; set; }
        public String Name { get; set; }
        public String Street { get; set; }
        public String Number { get; set; }
        public String Picture { get; set; }
        public String Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public Place Place { get; set; }
        public User User { get; set; }
        public long PlaceId { get; set; }
        public long UserId { get; set; }

        public Parking()
        {

        }

        public Parking(long id, String name, String street, String number, String picture, String description, float longitude, float latitude, Place place, User user, long placeId, long userId) {
            ParkingId = id;
            Name = name;
            Street = street;
            Number = number;
            Picture = picture;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
            Place = place;
            User = user;
            PlaceId = placeId;
            UserId = userId;
        }

        public Parking(String name, String street, String number, String picture, String description, float longitude, float latitude, long placeId, long userId)
        {
            Name = name;
            Street = street;
            Number = number;
            Picture = picture;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
            PlaceId = placeId;
            UserId = userId;
        }

    }
}

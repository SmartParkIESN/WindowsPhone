using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Announcement {
        public long Id { get; set; }
        public String Title { get; set; }
        public Double Price { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Boolean Rented { get; set; }
        public Parking Parking { get; set; }
        public User User { get; set; }
        public List<Reporting> Reportings { get; set; }

        public Announcement(long id, String title, Double price, DateTime dateFrom, DateTime dateTo, Boolean rented, Parking parking, User user) {
            Id = id;
            Title = title;
            Price = price;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Rented = rented;
            Parking = parking;
            User = user;
            Reportings = new List<Reporting> ();
        }
    }
}

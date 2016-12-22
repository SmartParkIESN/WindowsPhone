using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Announcement {
        public long AnnouncementId { get; set; }
        public String Title { get; set; }
        public int Price { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Boolean Rented { get; set; }
        public Parking Parking { get; set; }
        public long ParkingId { get; set; }

        public Announcement(long id, String title, int price, DateTime dateFrom, DateTime dateTo, Boolean rented, Parking parking, long parkingId)
        {
            AnnouncementId = id;
            Title = title;
            Price = price;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Rented = rented;
            Parking = parking;
            ParkingId = parkingId;
        }

        public Announcement(String title, int price, DateTime dateFrom, DateTime dateTo, Boolean rented, long parkingId)
        {
            Title = title;
            Price = price;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Rented = rented;
            ParkingId = parkingId;
        }
    }
}

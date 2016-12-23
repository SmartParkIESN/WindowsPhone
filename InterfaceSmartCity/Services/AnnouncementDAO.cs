using InterfaceSmartCity.Exceptions;
using InterfaceSmartCity.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Services
{
    class AnnouncementDAO
    {

        public async Task<IEnumerable<Announcement>> getAllAnnouncements()
        {
            List<Announcement> ListAnnouncements = new List<Announcement>();
            HttpClient client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Announcements/";
            var announcementsJson = await client.GetStringAsync(new Uri(url));
            dynamic Announcements = JArray.Parse(announcementsJson);

            for(int i = 0; i < Announcements.Count; i++)
            {
                dynamic announceJson = Announcements[i];
                dynamic parkingJson = announceJson.parking;
                dynamic userJson = announceJson.parking.user;
                dynamic placeJson = announceJson.parking.place;

                Place place = new Place((long) placeJson.PlaceId, (String) placeJson.Name);
                User user = new User((long)userJson.UserId, (String)userJson.Pseudo, (String)userJson.Email, (String)userJson.Password, (String)userJson.PhoneNumber);
                Parking parking = new Parking((long)parkingJson.ParkingId, (String)parkingJson.Name, (String)parkingJson.Street, (String)parkingJson.Number, (String)parkingJson.Picture, (String)parkingJson.Description, (float)parkingJson.Longitude, (float)parkingJson.Latitude, place, user, (long)place.PlaceId, (long)user.UserId);
                Announcement announcement = new Announcement((long)announceJson.AnnouncementId, (String)announceJson.Title, (int)announceJson.Price, (DateTime)announceJson.DateFrom, (DateTime)announceJson.DateTo, (Boolean)announceJson.Rented, parking, (long)parking.ParkingId);

                ListAnnouncements.Add(announcement);
            }

            return ListAnnouncements;
        }

        public async Task<IEnumerable<Announcement>> getAllAnnouncementsPrice(int min, int max)
        {
            List<Announcement> ListAnnouncements = new List<Announcement>();
            HttpClient client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Announcements/price/" + min + "/" + max;
            var announcementsJson = await client.GetStringAsync(new Uri(url));
            dynamic Announcements = JArray.Parse(announcementsJson);

            for (int i = 0; i < Announcements.Count; i++)
            {
                dynamic announceJson = Announcements[i];
                dynamic parkingJson = announceJson.parking;
                dynamic userJson = announceJson.parking.user;
                dynamic placeJson = announceJson.parking.place;

                Place place = new Place((long)placeJson.PlaceId, (String)placeJson.Name);
                User user = new User((long)userJson.UserId, (String)userJson.Pseudo, (String)userJson.Email, (String)userJson.Password, (String)userJson.PhoneNumber);
                Parking parking = new Parking((long)parkingJson.ParkingId, (String)parkingJson.Name, (String)parkingJson.Street, (String)parkingJson.Number, (String)parkingJson.Picture, (String)parkingJson.Description, (float)parkingJson.Longitude, (float)parkingJson.Latitude, place, user, (long)place.PlaceId, (long)user.UserId);
                Announcement announcement = new Announcement((long)announceJson.AnnouncementId, (String)announceJson.Title, (int)announceJson.Price, (DateTime)announceJson.DateFrom, (DateTime)announceJson.DateTo, (Boolean)announceJson.Rented, parking, (long)parking.ParkingId);

                ListAnnouncements.Add(announcement);
            }

            return ListAnnouncements;
        }
        

        public async Task<IEnumerable<Announcement>> getMyAnnouncements()
        {
            UserConnected userConnected = new UserConnected();
            userConnected = userConnected.getINSTANCE();
            List<Announcement> ListAnnouncements = new List<Announcement>();
            HttpClient client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Announcements/user/" + userConnected.getUserConnected().UserId;
            var announcementsJson = await client.GetStringAsync(new Uri(url));
            dynamic Announcements = JArray.Parse(announcementsJson);

            for (int i = 0; i < Announcements.Count; i++)
            {
                dynamic announceJson = Announcements[i];
                dynamic parkingJson = announceJson.parking;
                dynamic userJson = announceJson.parking.user;
                dynamic placeJson = announceJson.parking.place;

                Place place = new Place((long)placeJson.PlaceId, (String)placeJson.Name);
                User user = new User((long)userJson.UserId, (String)userJson.Pseudo, (String)userJson.Email, (String)userJson.Password, (String)userJson.PhoneNumber);
                Parking parking = new Parking((long)parkingJson.ParkingId, (String)parkingJson.Name, (String)parkingJson.Street, (String)parkingJson.Number, (String)parkingJson.Picture, (String)parkingJson.Description, (float)parkingJson.Longitude, (float)parkingJson.Latitude, place, user, (long)place.PlaceId, (long)user.UserId);
                Announcement announcement = new Announcement((long)announceJson.AnnouncementId, (String)announceJson.Title, (int)announceJson.Price, (DateTime)announceJson.DateFrom, (DateTime)announceJson.DateTo, (Boolean)announceJson.Rented, parking, (long)parking.ParkingId);

                ListAnnouncements.Add(announcement);
            }

            return ListAnnouncements;
        }

        public async Task<string> PostAnnouncement(Announcement announcement)
        {
            if (announcement.Title == null || announcement.Title.Length < 4 || announcement.Title.Length > 30)
            {
                throw new TitleException();
            }

            if (announcement.Price < 2 || announcement.Price > 100)
            {
                throw new PriceException();
            }

            if (announcement.ParkingId == 0)
            {
                throw new ParkingException();
            }

            var client = new HttpClient();
            string jsonAnnouncement = JsonConvert.SerializeObject(announcement);
            var content = new StringContent(jsonAnnouncement, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://smartpark1.azurewebsites.net/api/Announcements", content);

            return "Succesfull";

        }

        public async void removeAnnouncement(Announcement announcement)
        {
            var client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Announcements/delete/" + announcement.AnnouncementId;
            var result = await client.DeleteAsync(url);
        }
    }
}

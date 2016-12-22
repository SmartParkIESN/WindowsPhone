using InterfaceSmartCity.Exceptions;
using InterfaceSmartCity.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Services
{
    class ParkingDAO
    {

        public async Task<List<Parking>> getMyParkings()
        {
            UserConnected userConnected = new UserConnected();
            userConnected = userConnected.getINSTANCE();
            List<Parking> ListParkings = new List<Parking>();

            HttpClient client = new HttpClient();

            String url = "http://smartpark1.azurewebsites.net/api/Parkings/user/" + userConnected.getUserConnected().UserId;
            var parkingsJson = await client.GetStringAsync(new Uri(url));
            dynamic Parkings = JArray.Parse(parkingsJson);

            for (int i = 0; i < Parkings.Count; i++)
            {
                dynamic parkingJson = Parkings[i];
                dynamic userJson = parkingJson.user;
                dynamic placeJson = parkingJson.place;

                Place place = new Place((long)placeJson.PlaceId, (String)placeJson.Name);
                User user = new User((long)userJson.UserId, (String)userJson.Pseudo, (String)userJson.Email, (String)userJson.Password, (String)userJson.PhoneNumber);
                Parking parking = new Parking((long)parkingJson.ParkingId, (String)parkingJson.Name, (String)parkingJson.Street, (String)parkingJson.Number, (String)parkingJson.Picture, (String)parkingJson.Description, (float)parkingJson.Longitude, (float)parkingJson.Latitude, place, user, (long)place.PlaceId, (long)user.UserId);               

                ListParkings.Add(parking);
            }

            return ListParkings;
        }

        public async Task<string> PostParking(Parking parking)
        {
            if(parking.Name == null || parking.Name.Length < 4 || parking.Name.Length > 30)
            {
                throw new TitleException();
            }

            if (parking.Street == null || parking.Street.Length < 4 || parking.Street.Length > 40)
            {
                throw new StreetException();
            }

            if (parking.Number == null || parking.Number.Length < 1 || parking.Number.Length > 8)
            {
                throw new NumberException();
            }

            if (parking.Description == null || parking.Description.Length < 20 || parking.Description.Length > 120)
            {
                throw new DescriptionException();
            }

            if (parking.PlaceId == 0)
            {
                throw new PlaceException();
            }


            var client = new HttpClient();
            string jsonParking = JsonConvert.SerializeObject(parking);
            var content = new StringContent(jsonParking, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://smartpark1.azurewebsites.net/api/Parkings", content);

            return "Succesfull";

        }

        public async void removeParking(Parking parkings)
        {
            var client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Parkings/" + parkings.ParkingId;
            var result = await client.DeleteAsync(url);
        }






    }
}

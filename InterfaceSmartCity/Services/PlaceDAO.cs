using InterfaceSmartCity.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Services
{
    class PlaceDAO
    {
        public async Task<List<Place>> getAllPlaces()
        {
            List<Place> ListPlaces = new List<Place>();
            HttpClient client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Places/";
            var placesJson = await client.GetStringAsync(new Uri(url));
            dynamic Places = JArray.Parse(placesJson);

            for (int i = 0; i < Places.Count; i++)
            {
                dynamic placeJson = Places[i];

                Place place = new Place((long)placeJson.PlaceId, (String)placeJson.Name);

                ListPlaces.Add(place);
            }

            return ListPlaces;
        }

    }
}

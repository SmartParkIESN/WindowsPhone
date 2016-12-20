using InterfaceSmartCity.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Services
{
    class UserDAO
    {
        public async Task<bool> logIn(string pseudo, string password)
        {

            User user = await getUserPseudo(pseudo);

            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<User> getUserPseudo(string pseudo)
        {
            User user = new User();
            HttpClient client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Users/" + pseudo;
            var usersJson = await client.GetStringAsync(new Uri(url));
            dynamic userElement = JObject.Parse(usersJson);
            user.UserId = userElement.UserId;
            user.Email = userElement.Email;
            user.Pseudo = userElement.Pseudo;
            user.Password = userElement.Password;
            user.PhoneNumber = userElement.PhoneNumber;
            return user;
        }

        public async Task<string> SignUp(User user)
        {
            var client = new HttpClient();
            string jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://smartpark1.azurewebsites.net/api/Users", content);

            return "Succesfull";

        }
    }
}

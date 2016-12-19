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
    class UsersDAO
    {
        public async Task<User>getUserPseudo(string pseudo)
        {
            HttpClient client = new HttpClient();
            var users = await client.GetStringAsync(new
            Uri("http://smartpark1.azurewebsites.net/api/Users/" + pseudo));
            var userJson = JObject.Parse(users);
            User user = new User();
            
            return user;
        }

    }
}

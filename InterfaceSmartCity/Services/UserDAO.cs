using InterfaceSmartCity.Exceptions;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace InterfaceSmartCity.Services
{
    class UserDAO
    {
        public async Task<string> logIn(string pseudo, string password)
        {

            if(pseudo == null || pseudo.Length < 4 || pseudo.Length > 20)
            {
                throw new PseudoException();
            }

            if (password == null || password.Length < 4 || password.Length > 20)
            {
                throw new PasswordException();
            }


            User user = await getUserPseudo(pseudo);
            password = ComputeMD5(password);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    UserConnected userConnected = new UserConnected();
                    userConnected = userConnected.getINSTANCE();
                    userConnected.setUser(user);
                    userConnected.setConnected(true);             
                }
                else
                {
                    throw new LoginException();
                }
            }
            else
            {
                throw new LoginException();
            }

            return "Connection successful";
        }

        public async Task<User> getUserPseudo(string pseudo)
        {
            User user = new User();
            HttpClient client = new HttpClient();
            String url = "http://smartpark1.azurewebsites.net/api/Users/pseudo/" + pseudo;
            var usersJson = await client.GetStringAsync(new Uri(url));
            dynamic userElement = JObject.Parse(usersJson);
            user.UserId = userElement.UserId;
            user.Email = userElement.Email;
            user.Pseudo = userElement.Pseudo;
            user.Password = userElement.Password;
            user.PhoneNumber = userElement.PhoneNumber;
            return user;
        }



        public async Task<string> SignUp(User user, string passwordConf)
        {

            if (user.Pseudo == null || user.Pseudo.Length < 4 || user.Pseudo.Length > 20)
            {
                throw new PseudoException();
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                throw new EmailException();
            }

            if (user.Password == null || passwordConf == null || user.Password.Length < 4 || user.Password.Length > 20)
            {
                throw new PasswordException();
            }

            if(user.Password != passwordConf)
            {
                throw new PasswordVerifException();
            }


            var client = new HttpClient();
            user.Password = ComputeMD5(user.Password);
            string jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            await client.PostAsync("http://smartpark1.azurewebsites.net/api/Users", content);

            return "Sign Up successful";

        }

        public async Task<String> ModifyUser(User user, string passwordConf)
        {

            if (user.Email == null || !Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                throw new EmailException();
            }

            if (user.Password == null || passwordConf == null || user.Password.Length < 4 || user.Password.Length > 20)
            {
                throw new PasswordException();
            }

            if (user.Password != passwordConf)
            {
                throw new PasswordVerifException();
            }

            var client = new HttpClient();
            user.Password = ComputeMD5(user.Password);
            string jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            String url = "http://smartpark1.azurewebsites.net/api/Users/" + user.UserId.ToString();
            var result = await client.PutAsync(url, content);

            return "Edit successful";

        }

        private static string ComputeMD5(string str)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;
        }


    }
}

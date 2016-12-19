using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public static class AllUsers {
        public static IEnumerable<User> Users { get; set; }
        public static IEnumerable<User> GetAllUsers () {
            return new List<User> {
                new User(1,"Chronix","alexandre.jottard@gmail.com","mdpchronix"),
                new User(2,"SkyLi7h","lucas.ferrer@gmail.com","mdpskyli7h"),
                new User(2,"Vubelle","charlotte.colin@gmail.com","mdpvubelle")
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public static class AllAnnouncements {
        public static IEnumerable<Announcement> Announcements { get; set; }
        public static IEnumerable<Announcement> GetAllAnnouncements () {
            return new List<Announcement> {
                new Announcement(1, "Grand parking intérieur", 12.50, DateTime.Now, DateTime.Now, false, new Parking(1,"Parking intérieur 1","Rue de l'Eglise","23","photo1","Parking couvert de grande taille, sol en gravier",323,625, new Place(1,"Namur centre"),new User(1,"Chronix","alexandre.jottard@gmail.com","mdpchronix")),new User(1,"Chronix","alexandre.jottard@gmail.com","mdpchronix")),
                new Announcement(2, "Petit parking extérieur", 7.60, DateTime.Now, DateTime.Now, false, new Parking(1,"Parking extérieur 3","Rue de l'Escargot","12","photo2","Parking de petite taille",352,120, new Place(1,"Jambes"),new User(2,"SkyLi7h","lucas.ferrer@gmail.com","mdpskyli7h")),new User(2,"SkyLi7h","lucas.ferrer@gmail.com","mdpskyli7h"))
            };
        }
    }
}

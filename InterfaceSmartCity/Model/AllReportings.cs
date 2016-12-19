using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public static class AllReportings {
        public static IEnumerable<Reporting> Reportings { get; set; }
        public static IEnumerable<Reporting> GetAllReportings () {
            return new List<Reporting> {
                new Reporting(1,DateTime.Now,  new Announcement(1, "Grand parking intérieur", 12.50, DateTime.Now, DateTime.Now, false, new Parking(1,"Parking intérieur 1","Rue de l'Eglise","23","photo1","Parking couvert de grande taille, sol en gravier",323,625, new Place(1,"Namur centre"),new User(1,"Chronix","alexandre.jottard@gmail.com","mdpchronix")),new User(1,"Chronix","alexandre.jottard@gmail.com","mdpchronix")), new User(2,"Vubelle","charlotte.colin@gmail.com","mdpvubelle"))
            };
        }
    }
}

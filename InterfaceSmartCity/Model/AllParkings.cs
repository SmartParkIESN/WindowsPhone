using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public static class AllParkings {
        public static IEnumerable<Parking> Parkings { get; set; }
        public static IEnumerable<Parking> GetAllParkings () {
            return new List<Parking> {
                new Parking(1,"Parking intérieur 1","Rue de l'Eglise","23","photo1","Parking couvert de grande taille, sol en gravier",323,625, new Place(1,"Namur centre"),new User(1,"Chronix","alexandre.jottard@gmail.com","mdpchronix")),
                new Parking(2,"Parking extérieur 1","Avenue des Escargot","48","photo2","Parking devant la maison",672,978, new Place(1,"Bouges"),new User(2,"SkyLi7h","lucas.ferrer@gmail.com","mdpskyli7h"))
            };
        }
    }
}

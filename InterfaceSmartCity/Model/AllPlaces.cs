using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public static class AllPlaces {
        public static IEnumerable<Place> Places { get; set; }
        public static IEnumerable<Place> GetAllPlaces () {
            return new List<Place> {
                new Place(1,"Namur centre"),
                new Place(1,"Bouges")
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Place {
        public long PlaceId { get; set; }
        public String Name { get; set; }

        public Place(long id, String name) {
            PlaceId = id;
            Name = name;
        }
    }
}

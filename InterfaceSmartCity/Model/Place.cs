using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Place {
        public long Id { get; set; }
        public String Name { get; set; }
        public List<Parking> Parkings { get; set; }

        public Place(long id, String name) {
            Id = id;
            Name = name;
            Parkings = new List<Parking> ();
        }
    }
}

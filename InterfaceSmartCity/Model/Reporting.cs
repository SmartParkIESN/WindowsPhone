using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Model {
    public class Reporting {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public Announcement Signaled { get; set; }
        public User SignalMan { get; set; }

        public Reporting(long id, DateTime date, Announcement signaled, User signalMan) {
            Id = id;
            Date = date;
            Signaled = signaled;
            SignalMan = signalMan;
        }
    }
}

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
        public Announcement Announcement { get; set; }
        public long IdAnnouncement { get; set; }

        public Reporting(long id, DateTime date, Announcement announcement, long idAnnouncement) {
            Id = id;
            Date = date;
            Announcement = announcement;
            IdAnnouncement = IdAnnouncement;
        }
    }
}

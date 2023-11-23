using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Models
{
    public class Hostels
    {
        [Key]
        public int HostelID { get; set; }
        [MaxLength(50)]
        public string HostelName { get; set; }
        [MaxLength(100)]
        public string HostelNameDetail { get; set; }
        [MaxLength(100)]
        public string HostelZone { get; set; }
        [MaxLength(100)]
        public string HostelFacilities { get; set; }
        [MaxLength(50)]
        public string HostelNumberOfGuests { get; set; }
        [MaxLength(50)]
        public string HostelNumberOfBedrooms { get; set; }
        [MaxLength(50)]
        public string HostelNumberOfBathrooms { get; set; }
        public string HostelLinkToBook { get; set; }
        public string HostelPicture { get; set; }
        public string HostelRoomPicture { get; set; }

    }
}

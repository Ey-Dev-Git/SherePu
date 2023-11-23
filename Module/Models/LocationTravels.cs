using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Hosting;

namespace Module.Models
{
    public class LocationTravels
    {
        [Key]
        public int LocationTravelID { get; set; }
        [MaxLength(50)]
        public string LocationTravelName { get; set; }
        [MaxLength(250)]
        public string LocationTravelDetail { get; set; }
        public string LocationTravelPicture { get; set; }
        public string LocationTravelPathGoogleMap { get; set; }

        [InverseProperty("LocationTravel")]
        public ICollection<Activities>? Activities { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Models
{
    public class Activities
    {
        [Key]
        public int ActivityID { get; set; }
        [MaxLength(50)]
        public string ActivityName { get; set; }
        [MaxLength(250)]
        public string ActivityDetail { get; set; }
        public string ActivityPicture { get; set; }

        [ForeignKey("LocationTravelID")]
        public int? LocationTravelID { get; set; }
        public LocationTravels? LocationTravel { get; set; }

    }
}

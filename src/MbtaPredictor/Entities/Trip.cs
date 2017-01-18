using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.Entities
{
    public class Trip
    {
        [Required, Key]
        public int trip_id { get; set; }
        [Required]
        public string tripName { get; set; }
        [Required]
        public string tripHeadSign { get; set; }

        //This will be primary keys of items in the vehicle table
        public List<int> vehicle { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        [Required]
        public int trip_id { get; set; }
        [Required]
        public string tripName { get; set; }
        [Required]
        public string tripHeadSign { get; set; }

        /// <summary>
        /// this should probably be an int value linked
        /// to the ID of the vehicles. look into this. 
        /// </summary>
        [Required]
        public List<Vehicle> vehicle { get; set; }
    }
}

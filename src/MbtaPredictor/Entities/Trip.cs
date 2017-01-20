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
        public string Trip_Id { get; set; }
        public string TripName { get; set; }
        public string TripHeadSign { get; set; }

        //This will be primary keys of items in the vehicle table
        public int Vehicles { get; set; }
    }
}

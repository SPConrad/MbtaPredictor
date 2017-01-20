using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.Entities
{
    
    public class Vehicle
    {
        [Key]
        public int Vehicle_Id { get; set; }

        public String Lat { get; set; }

        public String Lon { get; set; }

        public int Bearing { get; set; }

        public string Timestamp { get; set; }
        
        public String Label { get; set; }
    }
}

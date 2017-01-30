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
        public int Trip_Id { get; set; }
        public string Trip_Name { get; set; }
        public string Trip_HeadSign { get; set; }
        //This will be primary keys of items in the vehicle table
        public string Vehicle_Id { get; set; }

        public string Vehicle_Lat { get; set; }

        public string Vehicle_Lon { get; set; }

        public string Vehicle_Bearing { get; set; }

        public string Vehicle_Timestamp { get; set; }

        public string Vehicle_Label { get; set; }

    }
}

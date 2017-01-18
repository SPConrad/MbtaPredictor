using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.ViewModels
{
    public class TripEditViewModel
    {
        public int tripId { get; set; }

        public string tripName { get; set; }

        public string tripHeadSign { get; set; }

        public Vehicle vehicle { get; set; }
    }
}

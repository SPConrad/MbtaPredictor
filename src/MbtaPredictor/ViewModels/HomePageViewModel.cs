using MbtaPredictor.Entities;
using System.Collections.Generic;

namespace MbtaPredictor.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Trip> Trips { get; set; }
    }
}

using MbtaPredictor.Entities;
using System.Collections.Generic;

namespace MbtaPredictor.ViewModels
{
    public class HomePageViewModel
    {
        public enum RouteTypes
        {
            Red,
            Orange,
            Blue,
            Silver,
            Green,
            Commuter
        }
        public IEnumerable<Trip> Trips { get; set; }
    }
}

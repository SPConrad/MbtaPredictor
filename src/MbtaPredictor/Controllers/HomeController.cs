using MbtaPredictor.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbtaPredictor.Controllers
{
    public class HomeController : Controller
    {
        private ITripData _tripData;

        public HomeController(ITripData tripData)
        {
            _tripData = tripData;
        }
    }
}

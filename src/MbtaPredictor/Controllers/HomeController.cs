using MbtaPredictor.Services;
using MbtaPredictor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MbtaPredictor.Controllers
{
    public class HomeController : Controller
    {
        private ITripData _tripData;
        private IVehicleData _vehicleData;

        private string apiKey = "wX9NwuHnZU2ToO7GmGR9uw";

        private string getVehiclesByRouteURL = "http://realtime.mbta.com/developer/api/v2/vehiclesbyroute?api_key=";

        private string routeFragment = "&route=";

        private string jsonFragment = "&format=json";

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            //don't really get all of them that's crazy
            //model.Trips = _tripData.GetAll();
            return View(model);
        }

        [HttpGet]
        [Route("/Home/GetRoutes")]
        public async Task<IActionResult> GetRoutes(HomePageViewModel model)
        {
            string urlToSend = getVehiclesByRouteURL + apiKey + routeFragment + model.routeType.ToString() + jsonFragment;
            Console.WriteLine("HomeController Get Routes");
            var result = await WebCalls.GetUrl(urlToSend);
            Console.WriteLine(result);
            ViewData["result"] = result;
            return View();
        }

    }
}

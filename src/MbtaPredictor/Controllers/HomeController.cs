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

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            //don't really get all of them that's crazy
            //model.Trips = _tripData.GetAll();
            return View(model);
        }

        [HttpGet]
        [Route("/Home/GetRoutes")]
        public async Task<IActionResult> GetRoutes(string routeType)
        { 
            Console.WriteLine("HomeController Get Routes");
            var result =  await WebCalls.GetUrl(routeType);
            Console.WriteLine(result);
            ViewData["result"] = result;
            return View();
        }

    }
}

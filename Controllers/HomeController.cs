using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartQuiz()
        {
            ViewData["SubjectList"] = new RimworldSubjectData[]
            {
                new RimworldSubjectData("Shooting"),
                new RimworldSubjectData("Melee"),
                new RimworldSubjectData("Construction"),
                new RimworldSubjectData("Mining"),
                new RimworldSubjectData("Cooking"),
                new RimworldSubjectData("Plants"),
                new RimworldSubjectData("Animals"),
                new RimworldSubjectData("Crafting"),
                new RimworldSubjectData("Artisting"),
                new RimworldSubjectData("Medical"),
                new RimworldSubjectData("Social"),
                new RimworldSubjectData("Intellectual"),

            };

            return View("Quiz");
        }
        public IActionResult FinishQuiz()
        {
            return View("Results");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class RimworldSubjectData
    {
        public string Name { get; set; } = "NA";
        public int Level { get; set; } = 0;
        public string Passion => PassionStringFromVal(PassionVal);
        public int PassionVal { get; set; } = 1;

        public RimworldSubjectData(string name)
        {
            Name = name;
        }


        private string PassionStringFromVal(int val)
        {
            string returnVal = "NA";
            switch (val)
            {
                case 0: returnVal = "Apathy"; break;
                case 1: returnVal = "Normal"; break;
                case 2: returnVal = "Passon"; break;
                case 3: returnVal = "Burning Passion"; break;
                case 4: returnVal = "Critical Passion"; break;
            }
            return returnVal;
        }
    }
}
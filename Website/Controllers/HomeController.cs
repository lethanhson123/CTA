using Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedbackBusiness _FeedbackBusiness;
        private readonly IAboutBusiness _AboutBusiness;
        private readonly ITeamBusiness _TeamBusiness;
        public HomeController(ILogger<HomeController> logger, IFeedbackBusiness feedbackBusiness, IAboutBusiness aboutBusiness, ITeamBusiness teamBusiness)
        {
            _logger = logger;
            _FeedbackBusiness = feedbackBusiness;
            _AboutBusiness = aboutBusiness;
            _TeamBusiness = teamBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            Feedback model = new Feedback();
            return View(model);
        }
        public IActionResult Thank()
        {            
            return View();
        }
        public IActionResult Subscribe()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AboutDetail(string Code, long ID)
        {
            About model = _AboutBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult TeamDetail(string Code, long ID)
        {
            Team model = _TeamBusiness.GetByID(ID);
            return View(model);
        }
        [HttpPost]
        public string SaveFeedback(Feedback feedback)
        {
            string result = GlobalHelper.InitializationString;
            try
            {
                feedback.ParentID = 1;
                _FeedbackBusiness.Save(feedback);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
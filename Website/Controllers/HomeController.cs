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
        private readonly IProjectBusiness _ProjectBusiness;
        private readonly INewsBusiness _NewsBusiness;
        private readonly IServiceBusiness _ServiceBusiness;
        private readonly ICareerBusiness _CareerBusiness;
        private readonly IIdeasBusiness _IdeasBusiness;
        private readonly ICandidateBusiness _CandidateBusiness;
        private readonly INewsletterBusiness _NewsletterBusiness;
        private readonly ICategoryIdeasBusiness _CategoryIdeasBusiness;
        public HomeController(ILogger<HomeController> logger
            , IFeedbackBusiness feedbackBusiness
            , IAboutBusiness aboutBusiness
            , ITeamBusiness teamBusiness
            , IProjectBusiness projectBusiness
            , INewsBusiness newsBusiness
            , IServiceBusiness serviceBusiness
            , ICareerBusiness careerBusiness
            , IIdeasBusiness ideasBusiness
            , ICandidateBusiness candidateBusiness
            , INewsletterBusiness newsletterBusiness
            , ICategoryIdeasBusiness categoryIdeasBusiness
            )
        {
            _logger = logger;
            _FeedbackBusiness = feedbackBusiness;
            _AboutBusiness = aboutBusiness;
            _TeamBusiness = teamBusiness;
            _ProjectBusiness = projectBusiness;
            _NewsBusiness = newsBusiness;
            _ServiceBusiness = serviceBusiness;
            _CareerBusiness = careerBusiness;
            _IdeasBusiness = ideasBusiness;
            _CandidateBusiness = candidateBusiness;
            _NewsletterBusiness = newsletterBusiness;
            _CategoryIdeasBusiness = categoryIdeasBusiness;
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
        public IActionResult Project()
        {
            return View();
        }
        public IActionResult ProjectDetail(string Code, long ID)
        {
            Project model = _ProjectBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult NewsDetail(string Code, long ID)
        {
            News model = _NewsBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult ServiceDetail(string Code, long ID)
        {
            Service model = _ServiceBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Career()
        {
            return View();
        }
        public IActionResult CareerDetail(string Code, long ID)
        {
            Career model = _CareerBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Ideas()
        {
            return View();
        }
        public IActionResult IdeasDetail(string Code, long ID)
        {
            Ideas model = _IdeasBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult CategoryIdeas(string Code, long ID)
        {
            CategoryIdeas model = _CategoryIdeasBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Tag(string searchString)
        {
            BaseViewModel model = new BaseViewModel();
            model.QueryString = searchString;
            return View(model);
        }
        public IActionResult Search(string searchString)
        {            
            BaseViewModel model=new BaseViewModel ();
            model.QueryString = searchString;
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
        [HttpPost]
        public string SaveCandidate(Candidate candidate)
        {
            string result = GlobalHelper.InitializationString;
            try
            {
                Candidate candidateSave = new Candidate();
                candidateSave.ParentID = candidate.ID;
                candidateSave.Name = candidate.Name;
                candidateSave.Code = candidate.Code;
                candidateSave.Display = candidate.Display;
                _CandidateBusiness.Save(candidateSave);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        [HttpPost]
        public string SaveNewsletter(Newsletter newsletter)
        {
            string result = GlobalHelper.InitializationString;
            try
            {
                newsletter.ParentID = 1;
                _NewsletterBusiness.Save(newsletter);
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
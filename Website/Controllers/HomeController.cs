

using Data.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Matching;
using System;

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
        private readonly IWebHostEnvironment _webHostEnvironment;
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
            , IWebHostEnvironment webHostEnvironment

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
            _webHostEnvironment = webHostEnvironment;
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
            BaseViewModel model = new BaseViewModel();
            model.QueryString = searchString;
            return View(model);
        }
        [HttpPost]
        public string SaveFeedback(Feedback feedback)
        {
            string result = GlobalHelper.InitializationString;
            try
            {
                feedback.ParentID = GlobalHelper.CategoryLanguageID;
                _FeedbackBusiness.Save(feedback);
                if (feedback.ID > 0)
                {
                    Helper.Model.Mail mail = new Helper.Model.Mail();
                    mail.MailFrom = GlobalHelper.MasterEmailUser;
                    mail.UserName = GlobalHelper.MasterEmailUser;
                    mail.Password = GlobalHelper.MasterEmailPassword;
                    mail.SMTPPort = GlobalHelper.SMTPPort;
                    mail.SMTPServer = GlobalHelper.SMTPServer;
                    mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                    mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                    mail.Display = GlobalHelper.MasterEmailDisplay;
                    mail.MailTo = GlobalHelper.MailTo;
                    mail.Subject = "Feedback: " + feedback.Code + " sent at " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    if (!string.IsNullOrEmpty(mail.MailTo))
                    {
                        string path = Path.Combine(_webHostEnvironment.WebRootPath, "Mail", "Feedback.html");
                        string contentHTML = GlobalHelper.InitializationString;
                        using (FileStream fs = new FileStream(path, FileMode.Open))
                        {
                            using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                            {
                                contentHTML = r.ReadToEnd();
                            }
                        }                        
                        contentHTML = contentHTML.Replace("[Name]", feedback.Name);
                        contentHTML = contentHTML.Replace("[Code]", feedback.Code);
                        contentHTML = contentHTML.Replace("[Display]", feedback.Display);
                        contentHTML = contentHTML.Replace("[Description]", feedback.Description);
                        mail.Content = contentHTML;
                        if (!string.IsNullOrEmpty(mail.MailTo))
                        {
                            MailHelper.SendMail(mail);
                        }
                        if (!string.IsNullOrEmpty(feedback.Code))
                        {
                            mail.MailTo = feedback.Code;
                            MailHelper.SendMail(mail);
                        }
                    }
                }
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
                if (candidateSave.ID > 0)
                {
                    Helper.Model.Mail mail = new Helper.Model.Mail();
                    mail.MailFrom = GlobalHelper.MasterEmailUser;
                    mail.UserName = GlobalHelper.MasterEmailUser;
                    mail.Password = GlobalHelper.MasterEmailPassword;
                    mail.SMTPPort = GlobalHelper.SMTPPort;
                    mail.SMTPServer = GlobalHelper.SMTPServer;
                    mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                    mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                    mail.Display = GlobalHelper.MasterEmailDisplay;
                    mail.MailTo = GlobalHelper.MailTo;
                    mail.Subject = "Candidate: " + candidateSave.Code + " sent at " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    if (!string.IsNullOrEmpty(mail.MailTo))
                    {
                        string path = Path.Combine(_webHostEnvironment.WebRootPath, "Mail", "Candidate.html");
                        string contentHTML = GlobalHelper.InitializationString;
                        using (FileStream fs = new FileStream(path, FileMode.Open))
                        {
                            using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                            {
                                contentHTML = r.ReadToEnd();
                            }
                        }
                        contentHTML = contentHTML.Replace("[Name]", candidateSave.Name);
                        contentHTML = contentHTML.Replace("[Code]", candidateSave.Code);
                        contentHTML = contentHTML.Replace("[Display]", candidateSave.Display);
                        contentHTML = contentHTML.Replace("[Description]", candidateSave.Description);
                        mail.Content = contentHTML;
                        if (!string.IsNullOrEmpty(mail.MailTo))
                        {
                            MailHelper.SendMail(mail);
                        }
                        if (!string.IsNullOrEmpty(candidateSave.Code))
                        {
                            mail.MailTo = candidateSave.Code;
                            MailHelper.SendMail(mail);
                        }
                    }
                }
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
                newsletter.ParentID = GlobalHelper.CategoryLanguageID;
                _NewsletterBusiness.Save(newsletter);
                if (newsletter.ID > 0)
                {
                    Helper.Model.Mail mail = new Helper.Model.Mail();
                    mail.MailFrom = GlobalHelper.MasterEmailUser;
                    mail.UserName = GlobalHelper.MasterEmailUser;
                    mail.Password = GlobalHelper.MasterEmailPassword;
                    mail.SMTPPort = GlobalHelper.SMTPPort;
                    mail.SMTPServer = GlobalHelper.SMTPServer;
                    mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                    mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                    mail.Display = GlobalHelper.MasterEmailDisplay;
                    mail.MailTo = GlobalHelper.MailTo;
                    mail.Subject = "Newsletter: " + newsletter.Code + " sent at " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    if (!string.IsNullOrEmpty(mail.MailTo))
                    {
                        string path = Path.Combine(_webHostEnvironment.WebRootPath, "Mail", "Newsletter.html");
                        string contentHTML = GlobalHelper.InitializationString;
                        using (FileStream fs = new FileStream(path, FileMode.Open))
                        {
                            using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                            {
                                contentHTML = r.ReadToEnd();
                            }
                        }
                        contentHTML = contentHTML.Replace("[Name]", newsletter.Name);
                        contentHTML = contentHTML.Replace("[Code]", newsletter.Code);
                        contentHTML = contentHTML.Replace("[Display]", newsletter.Display);
                        contentHTML = contentHTML.Replace("[Description]", newsletter.Description);
                        mail.Content = contentHTML;
                        if (!string.IsNullOrEmpty(mail.MailTo))
                        {
                            MailHelper.SendMail(mail);
                        }
                        if (!string.IsNullOrEmpty(newsletter.Code))
                        {
                            mail.MailTo = newsletter.Code;
                            MailHelper.SendMail(mail);
                        }
                    }
                }
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
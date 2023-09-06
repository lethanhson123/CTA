namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedbackBusiness _FeedbackBusiness;
        private readonly IAboutBusiness _AboutBusiness;
        private readonly IAwardBusiness _AwardBusiness;
        private readonly ITeamBusiness _TeamBusiness;
        private readonly IProjectBusiness _ProjectBusiness;
        private readonly INewsBusiness _NewsBusiness;
        private readonly IServiceBusiness _ServiceBusiness;
        private readonly ICareerBusiness _CareerBusiness;
        private readonly IIdeasBusiness _IdeasBusiness;
        private readonly ICandidateBusiness _CandidateBusiness;
        private readonly INewsletterBusiness _NewsletterBusiness;
        private readonly ICategoryIdeasBusiness _CategoryIdeasBusiness;
        private readonly IEmailBusiness _EmailBusiness;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger
            , IFeedbackBusiness feedbackBusiness
            , IAboutBusiness aboutBusiness
            , IAwardBusiness awardBusiness
            , ITeamBusiness teamBusiness
            , IProjectBusiness projectBusiness
            , INewsBusiness newsBusiness
            , IServiceBusiness serviceBusiness
            , ICareerBusiness careerBusiness
            , IIdeasBusiness ideasBusiness
            , ICandidateBusiness candidateBusiness
            , INewsletterBusiness newsletterBusiness
            , ICategoryIdeasBusiness categoryIdeasBusiness
            , IEmailBusiness emailBusiness
            , IWebHostEnvironment webHostEnvironment
            )
        {
            _logger = logger;
            _FeedbackBusiness = feedbackBusiness;
            _AboutBusiness = aboutBusiness;
            _AwardBusiness = awardBusiness;
            _TeamBusiness = teamBusiness;
            _ProjectBusiness = projectBusiness;
            _NewsBusiness = newsBusiness;
            _ServiceBusiness = serviceBusiness;
            _CareerBusiness = careerBusiness;
            _IdeasBusiness = ideasBusiness;
            _CandidateBusiness = candidateBusiness;
            _NewsletterBusiness = newsletterBusiness;
            _CategoryIdeasBusiness = categoryIdeasBusiness;
            _EmailBusiness = emailBusiness;
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
            int PageIndex = 1;
            int pageCount = PageIndex * GlobalHelper.RowCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Abouts = _AboutBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            model.Awards = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Award> list = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult AboutPage(int PageIndex)
        {
            int pageCount = PageIndex * GlobalHelper.RowCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Abouts = _AboutBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            model.Awards = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<About> list = _AboutBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult AboutDetail(string Code, long ID)
        {
            About model = _AboutBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Award()
        {
            int PageIndex = 1;
            int pageCount = PageIndex * GlobalHelper.RowCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Awards = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Award> list = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult AwardPage(int PageIndex)
        {
            int pageCount = PageIndex * GlobalHelper.RowCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Awards = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Award> list = _AwardBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult AwardDetail(string Code, long ID)
        {
            Award model = _AwardBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Team()
        {
            int PageIndex = 1;
            int pageCount = PageIndex * GlobalHelper.TeamCount + 2;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Teams = _TeamBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Team> list = _TeamBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult TeamPage(int PageIndex)
        {
            int pageCount = PageIndex * GlobalHelper.TeamCount + 2;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Teams = _TeamBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Team> list = _TeamBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {     
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult TeamDetail(string Code, long ID)
        {
            Team model = _TeamBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult Project()
        {
            int PageIndex = 1;
            int pageCount = PageIndex * GlobalHelper.RowCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Projects = _ProjectBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Project> list = _ProjectBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult ProjectPage(int PageIndex)
        {
            int pageCount = PageIndex * GlobalHelper.RowCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Projects = _ProjectBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<Project> list = _ProjectBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult ProjectDetail(string Code, long ID)
        {
            Project model = _ProjectBusiness.GetByID(ID);
            return View(model);
        }
        public IActionResult News()
        {
            int PageIndex = 1;
            int pageCount = PageIndex * GlobalHelper.NewsCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;
            model.Newss = _NewsBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<News> list = _NewsBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
        }
        public IActionResult NewsPage(int PageIndex)
        {
            int pageCount = PageIndex * GlobalHelper.NewsCount + 1;
            BaseViewModel model = new BaseViewModel();
            model.PageIndex = PageIndex;            
            model.Newss = _NewsBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true).Take(pageCount).OrderBy(item => item.SortOrder).ToList();
            List<News> list = _NewsBusiness.GetByParentIDAndActiveToList(GlobalHelper.CategoryLanguageID, true);
            if (pageCount < list.Count)
            {
                model.IsShowPage = true;
            }
            return View(model);
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
            Career career = _CareerBusiness.GetByID(ID);
            BaseViewModel model = new BaseViewModel();
            model.Career = career;
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
        public IActionResult CategoryIdeas(long ID)
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
                        Data.Model.Email email = _EmailBusiness.GetByID(1);
                        if (email != null)
                        {
                            mail.MailTo = GlobalHelper.MailTo;
                        }
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
        public ActionResult SaveCandidate(BaseViewModel model)
        {
            string result = GlobalHelper.InitializationString;
            try
            {
                Candidate candidateSave = new Candidate();
                candidateSave.ParentID = model.Career.ID;
                candidateSave.Name = model.Name;
                candidateSave.Code = model.Note;
                candidateSave.Display = model.Display;

                if (model.File == null || model.File.Length == 0)
                {
                }
                if (model.File != null)
                {
                    string fileExtension = Path.GetExtension(model.File.FileName);
                    model.FileName = GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, candidateSave.GetType().Name);
                    bool isFolderExists = System.IO.Directory.Exists(folderPath);
                    if (!isFolderExists)
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    var physicalPath = Path.Combine(folderPath, model.FileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        model.File.CopyTo(stream);
                    }
                }
                candidateSave.FileName = GlobalHelper.DomainURL + GlobalHelper.Image + "/" + candidateSave.GetType().Name + "/" + model.FileName;
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
                        contentHTML = contentHTML.Replace("[FileName]", candidateSave.FileName);
                        mail.Content = contentHTML;
                        Data.Model.Email email = _EmailBusiness.GetByID(2);
                        if (email != null)
                        {
                            mail.MailTo = GlobalHelper.MailTo;
                        }
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
            string url = GlobalHelper.DomainURL + "loi-cam-on.html";
            return Redirect(url);
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
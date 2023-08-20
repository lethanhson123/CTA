namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NewsletterController : BaseController<Newsletter, INewsletterBusiness>
    {
        private readonly INewsletterBusiness _NewsletterBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public NewsletterController(INewsletterBusiness NewsletterBusiness, IWebHostEnvironment WebHostEnvironment) : base(NewsletterBusiness, WebHostEnvironment)
        {
            _NewsletterBusiness = NewsletterBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailController : BaseController<Email, IEmailBusiness>
    {
        private readonly IEmailBusiness _EmailBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public EmailController(IEmailBusiness EmailBusiness, IWebHostEnvironment WebHostEnvironment) : base(EmailBusiness, WebHostEnvironment)
        {
            _EmailBusiness = EmailBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

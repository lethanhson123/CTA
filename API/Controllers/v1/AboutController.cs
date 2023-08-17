namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AboutController : BaseController<About, IAboutBusiness>
    {
        private readonly IAboutBusiness _AboutBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public AboutController(IAboutBusiness AboutBusiness, IWebHostEnvironment WebHostEnvironment) : base(AboutBusiness, WebHostEnvironment)
        {
            _AboutBusiness = AboutBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AboutFileController : BaseController<AboutFile, IAboutFileBusiness>
    {
        private readonly IAboutFileBusiness _AboutFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public AboutFileController(IAboutFileBusiness AboutFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(AboutFileBusiness, WebHostEnvironment)
        {
            _AboutFileBusiness = AboutFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

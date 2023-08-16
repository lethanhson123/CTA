namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AboutController : BaseController<About, IAboutBusiness>
    {
        private readonly IAboutBusiness _AboutBusiness;
        public AboutController(IAboutBusiness AboutBusiness) : base(AboutBusiness)
        {
            _AboutBusiness = AboutBusiness;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class SocialNetworkController : BaseController<SocialNetwork, ISocialNetworkBusiness>
    {
        private readonly ISocialNetworkBusiness _SocialNetworkBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public SocialNetworkController(ISocialNetworkBusiness SocialNetworkBusiness, IWebHostEnvironment WebHostEnvironment) : base(SocialNetworkBusiness, WebHostEnvironment)
        {
            _SocialNetworkBusiness = SocialNetworkBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

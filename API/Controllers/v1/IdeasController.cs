namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class IdeasController : BaseController<Ideas, IIdeasBusiness>
    {
        private readonly IIdeasBusiness _IdeasBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public IdeasController(IIdeasBusiness IdeasBusiness, IWebHostEnvironment WebHostEnvironment) : base(IdeasBusiness, WebHostEnvironment)
        {
            _IdeasBusiness = IdeasBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

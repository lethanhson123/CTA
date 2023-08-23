namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AwardFileController : BaseController<AwardFile, IAwardFileBusiness>
    {
        private readonly IAwardFileBusiness _AwardFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public AwardFileController(IAwardFileBusiness AwardFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(AwardFileBusiness, WebHostEnvironment)
        {
            _AwardFileBusiness = AwardFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AwardController : BaseController<Award, IAwardBusiness>
    {
        private readonly IAwardBusiness _AwardBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public AwardController(IAwardBusiness AwardBusiness, IWebHostEnvironment WebHostEnvironment) : base(AwardBusiness, WebHostEnvironment)
        {
            _AwardBusiness = AwardBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

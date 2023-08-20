namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CandidateController : BaseController<Candidate, ICandidateBusiness>
    {
        private readonly ICandidateBusiness _CandidateBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public CandidateController(ICandidateBusiness CandidateBusiness, IWebHostEnvironment WebHostEnvironment) : base(CandidateBusiness, WebHostEnvironment)
        {
            _CandidateBusiness = CandidateBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

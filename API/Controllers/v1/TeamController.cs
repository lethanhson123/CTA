namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TeamController : BaseController<Team, ITeamBusiness>
    {
        private readonly ITeamBusiness _TeamBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public TeamController(ITeamBusiness TeamBusiness, IWebHostEnvironment WebHostEnvironment) : base(TeamBusiness, WebHostEnvironment)
        {
            _TeamBusiness = TeamBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TeamController : BaseController<Team, ITeamBusiness>
    {
        private readonly ITeamBusiness _TeamBusiness;
        public TeamController(ITeamBusiness TeamBusiness) : base(TeamBusiness)
        {
            _TeamBusiness = TeamBusiness;
        }
    }
}

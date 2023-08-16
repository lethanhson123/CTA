namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TeamFileController : BaseController<TeamFile, ITeamFileBusiness>
    {
        private readonly ITeamFileBusiness _TeamFileBusiness;
        public TeamFileController(ITeamFileBusiness TeamFileBusiness) : base(TeamFileBusiness)
        {
            _TeamFileBusiness = TeamFileBusiness;
        }
    }
}

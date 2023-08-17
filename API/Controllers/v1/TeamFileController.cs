namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TeamFileController : BaseController<TeamFile, ITeamFileBusiness>
    {
        private readonly ITeamFileBusiness _TeamFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public TeamFileController(ITeamFileBusiness TeamFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(TeamFileBusiness, WebHostEnvironment)
        {
            _TeamFileBusiness = TeamFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

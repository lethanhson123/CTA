namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProjectController : BaseController<Project, IProjectBusiness>
    {
        private readonly IProjectBusiness _ProjectBusiness;
        public ProjectController(IProjectBusiness ProjectBusiness) : base(ProjectBusiness)
        {
            _ProjectBusiness = ProjectBusiness;
        }
    }
}

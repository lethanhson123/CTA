namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProjectController : BaseController<Project, IProjectBusiness>
    {
        private readonly IProjectBusiness _ProjectBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProjectController(IProjectBusiness ProjectBusiness, IWebHostEnvironment WebHostEnvironment) : base(ProjectBusiness, WebHostEnvironment)
        {
            _ProjectBusiness = ProjectBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

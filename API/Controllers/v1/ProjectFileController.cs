namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProjectFileController : BaseController<ProjectFile, IProjectFileBusiness>
    {
        private readonly IProjectFileBusiness _ProjectFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProjectFileController(IProjectFileBusiness ProjectFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(ProjectFileBusiness, WebHostEnvironment)
        {
            _ProjectFileBusiness = ProjectFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

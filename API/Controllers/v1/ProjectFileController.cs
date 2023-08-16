namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProjectFileController : BaseController<ProjectFile, IProjectFileBusiness>
    {
        private readonly IProjectFileBusiness _ProjectFileBusiness;
        public ProjectFileController(IProjectFileBusiness ProjectFileBusiness) : base(ProjectFileBusiness)
        {
            _ProjectFileBusiness = ProjectFileBusiness;
        }
    }
}

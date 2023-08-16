
namespace Business.Implement
{
    public class ProjectBusiness : BaseBusiness<Project, IProjectRepository>, IProjectBusiness
    {
        private readonly IProjectRepository _ProjectRepository;
        public ProjectBusiness(IProjectRepository ProjectRepository) : base(ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }
    }
}

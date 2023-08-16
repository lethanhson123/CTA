
namespace Business.Implement
{
    public class ProjectFileBusiness : BaseBusiness<ProjectFile, IProjectFileRepository>, IProjectFileBusiness
    {
        private readonly IProjectFileRepository _ProjectFileRepository;
        public ProjectFileBusiness(IProjectFileRepository ProjectFileRepository) : base(ProjectFileRepository)
        {
            _ProjectFileRepository = ProjectFileRepository;
        }
    }
}

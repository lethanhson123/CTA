namespace Data.Repository.Implement
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly CTAContext _context;
        public ProjectRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

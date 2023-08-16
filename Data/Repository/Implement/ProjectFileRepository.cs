namespace Data.Repository.Implement
{
    public class ProjectFileRepository : BaseRepository<ProjectFile>, IProjectFileRepository
    {
        private readonly CTAContext _context;
        public ProjectFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

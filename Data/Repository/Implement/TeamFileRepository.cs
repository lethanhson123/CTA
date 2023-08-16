namespace Data.Repository.Implement
{
    public class TeamFileRepository : BaseRepository<TeamFile>, ITeamFileRepository
    {
        private readonly CTAContext _context;
        public TeamFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

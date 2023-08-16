namespace Data.Repository.Implement
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        private readonly CTAContext _context;
        public TeamRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

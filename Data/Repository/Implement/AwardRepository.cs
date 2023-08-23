namespace Data.Repository.Implement
{
    public class AwardRepository : BaseRepository<Award>, IAwardRepository
    {
        private readonly CTAContext _context;
        public AwardRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

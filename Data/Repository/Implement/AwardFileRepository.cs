namespace Data.Repository.Implement
{
    public class AwardFileRepository : BaseRepository<AwardFile>, IAwardFileRepository
    {
        private readonly CTAContext _context;
        public AwardFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

namespace Data.Repository.Implement
{
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        private readonly CTAContext _context;
        public AboutRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

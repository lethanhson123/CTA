namespace Data.Repository.Implement
{
    public class NewsletterRepository : BaseRepository<Newsletter>, INewsletterRepository
    {
        private readonly CTAContext _context;
        public NewsletterRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

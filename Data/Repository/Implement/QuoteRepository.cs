namespace Data.Repository.Implement
{
    public class QuoteRepository : BaseRepository<Quote>, IQuoteRepository
    {
        private readonly CTAContext _context;
        public QuoteRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

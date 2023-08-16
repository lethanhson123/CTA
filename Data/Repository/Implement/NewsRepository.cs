namespace Data.Repository.Implement
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        private readonly CTAContext _context;
        public NewsRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

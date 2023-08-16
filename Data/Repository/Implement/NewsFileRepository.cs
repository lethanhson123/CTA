namespace Data.Repository.Implement
{
    public class NewsFileRepository : BaseRepository<NewsFile>, INewsFileRepository
    {
        private readonly CTAContext _context;
        public NewsFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

namespace Data.Repository.Implement
{
    public class BannerFileRepository : BaseRepository<BannerFile>, IBannerFileRepository
    {
        private readonly CTAContext _context;
        public BannerFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

namespace Data.Repository.Implement
{
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        private readonly CTAContext _context;
        public BannerRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

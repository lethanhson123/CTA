namespace Data.Repository.Implement
{
    public class SocialNetworkRepository : BaseRepository<SocialNetwork>, ISocialNetworkRepository
    {
        private readonly CTAContext _context;
        public SocialNetworkRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

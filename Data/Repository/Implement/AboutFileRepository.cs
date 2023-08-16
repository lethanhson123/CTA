namespace Data.Repository.Implement
{
    public class AboutFileRepository : BaseRepository<AboutFile>, IAboutFileRepository
    {
        private readonly CTAContext _context;
        public AboutFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

namespace Data.Repository.Implement
{
    public class IdeasRepository : BaseRepository<Ideas>, IIdeasRepository
    {
        private readonly CTAContext _context;
        public IdeasRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

namespace Data.Repository.Implement
{
    public class IdeasFileRepository : BaseRepository<IdeasFile>, IIdeasFileRepository
    {
        private readonly CTAContext _context;
        public IdeasFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

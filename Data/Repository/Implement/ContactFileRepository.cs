namespace Data.Repository.Implement
{
    public class ContactFileRepository : BaseRepository<ContactFile>, IContactFileRepository
    {
        private readonly CTAContext _context;
        public ContactFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

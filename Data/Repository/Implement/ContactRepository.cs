namespace Data.Repository.Implement
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly CTAContext _context;
        public ContactRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

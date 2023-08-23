namespace Data.Repository.Implement
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        private readonly CTAContext _context;
        public EmailRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

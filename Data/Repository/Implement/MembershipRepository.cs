namespace Data.Repository.Implement
{
    public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
    {
        private readonly CTAContext _context;
        public MembershipRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

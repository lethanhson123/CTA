namespace Data.Repository.Implement
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        private readonly CTAContext _context;
        public ServiceRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

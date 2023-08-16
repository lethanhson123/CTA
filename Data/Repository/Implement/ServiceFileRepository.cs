namespace Data.Repository.Implement
{
    public class ServiceFileRepository : BaseRepository<ServiceFile>, IServiceFileRepository
    {
        private readonly CTAContext _context;
        public ServiceFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

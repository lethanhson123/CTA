namespace Data.Repository.Implement
{
    public class CareerRepository : BaseRepository<Career>, ICareerRepository
    {
        private readonly CTAContext _context;
        public CareerRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

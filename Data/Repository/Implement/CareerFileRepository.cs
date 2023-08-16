namespace Data.Repository.Implement
{
    public class CareerFileRepository : BaseRepository<CareerFile>, ICareerFileRepository
    {
        private readonly CTAContext _context;
        public CareerFileRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

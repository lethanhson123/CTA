namespace Data.Repository.Implement
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        private readonly CTAContext _context;
        public CandidateRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

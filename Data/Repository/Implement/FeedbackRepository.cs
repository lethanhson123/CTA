namespace Data.Repository.Implement
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        private readonly CTAContext _context;
        public FeedbackRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}


namespace Business.Implement
{
    public class FeedbackBusiness : BaseBusiness<Feedback, IFeedbackRepository>, IFeedbackBusiness
    {
        private readonly IFeedbackRepository _FeedbackRepository;
        public FeedbackBusiness(IFeedbackRepository FeedbackRepository) : base(FeedbackRepository)
        {
            _FeedbackRepository = FeedbackRepository;
        }
    }
}

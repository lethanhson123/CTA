
namespace Business.Implement
{
    public class QuoteBusiness : BaseBusiness<Quote, IQuoteRepository>, IQuoteBusiness
    {
        private readonly IQuoteRepository _QuoteRepository;
        public QuoteBusiness(IQuoteRepository QuoteRepository) : base(QuoteRepository)
        {
            _QuoteRepository = QuoteRepository;
        }
    }
}

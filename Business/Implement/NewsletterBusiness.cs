
namespace Business.Implement
{
    public class NewsletterBusiness : BaseBusiness<Newsletter, INewsletterRepository>, INewsletterBusiness
    {
        private readonly INewsletterRepository _NewsletterRepository;
        public NewsletterBusiness(INewsletterRepository NewsletterRepository) : base(NewsletterRepository)
        {
            _NewsletterRepository = NewsletterRepository;
        }
    }
}


namespace Business.Implement
{
    public class EmailBusiness : BaseBusiness<Email, IEmailRepository>, IEmailBusiness
    {
        private readonly IEmailRepository _EmailRepository;
        public EmailBusiness(IEmailRepository EmailRepository) : base(EmailRepository)
        {
            _EmailRepository = EmailRepository;
        }
    }
}


namespace Business.Implement
{
    public class AboutBusiness : BaseBusiness<About, IAboutRepository>, IAboutBusiness
    {
        private readonly IAboutRepository _AboutRepository;
        public AboutBusiness(IAboutRepository AboutRepository) : base(AboutRepository)
        {
            _AboutRepository = AboutRepository;
        }
    }
}

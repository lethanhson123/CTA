
namespace Business.Implement
{
    public class AboutFileBusiness : BaseBusiness<AboutFile, IAboutFileRepository>, IAboutFileBusiness
    {
        private readonly IAboutFileRepository _AboutFileRepository;
        public AboutFileBusiness(IAboutFileRepository AboutFileRepository) : base(AboutFileRepository)
        {
            _AboutFileRepository = AboutFileRepository;
        }
    }
}

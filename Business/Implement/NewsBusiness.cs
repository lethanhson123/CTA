
namespace Business.Implement
{
    public class NewsBusiness : BaseBusiness<News, INewsRepository>, INewsBusiness
    {
        private readonly INewsRepository _NewsRepository;
        public NewsBusiness(INewsRepository NewsRepository) : base(NewsRepository)
        {
            _NewsRepository = NewsRepository;
        }
    }
}

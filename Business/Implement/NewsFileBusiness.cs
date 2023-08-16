
namespace Business.Implement
{
    public class NewsFileBusiness : BaseBusiness<NewsFile, INewsFileRepository>, INewsFileBusiness
    {
        private readonly INewsFileRepository _NewsFileRepository;
        public NewsFileBusiness(INewsFileRepository NewsFileRepository) : base(NewsFileRepository)
        {
            _NewsFileRepository = NewsFileRepository;
        }
    }
}

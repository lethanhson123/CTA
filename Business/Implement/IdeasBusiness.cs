
namespace Business.Implement
{
    public class IdeasBusiness : BaseBusiness<Ideas, IIdeasRepository>, IIdeasBusiness
    {
        private readonly IIdeasRepository _IdeasRepository;
        public IdeasBusiness(IIdeasRepository IdeasRepository) : base(IdeasRepository)
        {
            _IdeasRepository = IdeasRepository;
        }
    }
}

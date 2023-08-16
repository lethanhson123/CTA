
namespace Business.Implement
{
    public class IdeasFileBusiness : BaseBusiness<IdeasFile, IIdeasFileRepository>, IIdeasFileBusiness
    {
        private readonly IIdeasFileRepository _IdeasFileRepository;
        public IdeasFileBusiness(IIdeasFileRepository IdeasFileRepository) : base(IdeasFileRepository)
        {
            _IdeasFileRepository = IdeasFileRepository;
        }
    }
}

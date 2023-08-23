
namespace Business.Implement
{
    public class AwardFileBusiness : BaseBusiness<AwardFile, IAwardFileRepository>, IAwardFileBusiness
    {
        private readonly IAwardFileRepository _AwardFileRepository;
        public AwardFileBusiness(IAwardFileRepository AwardFileRepository) : base(AwardFileRepository)
        {
            _AwardFileRepository = AwardFileRepository;
        }
    }
}

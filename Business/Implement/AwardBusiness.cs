
namespace Business.Implement
{
    public class AwardBusiness : BaseBusiness<Award, IAwardRepository>, IAwardBusiness
    {
        private readonly IAwardRepository _AwardRepository;
        public AwardBusiness(IAwardRepository AwardRepository) : base(AwardRepository)
        {
            _AwardRepository = AwardRepository;
        }
    }
}

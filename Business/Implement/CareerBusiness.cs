
namespace Business.Implement
{
    public class CareerBusiness : BaseBusiness<Career, ICareerRepository>, ICareerBusiness
    {
        private readonly ICareerRepository _CareerRepository;
        public CareerBusiness(ICareerRepository CareerRepository) : base(CareerRepository)
        {
            _CareerRepository = CareerRepository;
        }
    }
}

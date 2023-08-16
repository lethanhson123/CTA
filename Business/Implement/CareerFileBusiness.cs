
namespace Business.Implement
{
    public class CareerFileBusiness : BaseBusiness<CareerFile, ICareerFileRepository>, ICareerFileBusiness
    {
        private readonly ICareerFileRepository _CareerFileRepository;
        public CareerFileBusiness(ICareerFileRepository CareerFileRepository) : base(CareerFileRepository)
        {
            _CareerFileRepository = CareerFileRepository;
        }
    }
}

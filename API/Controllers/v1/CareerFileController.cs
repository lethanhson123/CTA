namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CareerFileController : BaseController<CareerFile, ICareerFileBusiness>
    {
        private readonly ICareerFileBusiness _CareerFileBusiness;
        public CareerFileController(ICareerFileBusiness CareerFileBusiness) : base(CareerFileBusiness)
        {
            _CareerFileBusiness = CareerFileBusiness;
        }
    }
}

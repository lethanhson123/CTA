namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CareerController : BaseController<Career, ICareerBusiness>
    {
        private readonly ICareerBusiness _CareerBusiness;
        public CareerController(ICareerBusiness CareerBusiness) : base(CareerBusiness)
        {
            _CareerBusiness = CareerBusiness;
        }
    }
}

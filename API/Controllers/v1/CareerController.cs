namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CareerController : BaseController<Career, ICareerBusiness>
    {
        private readonly ICareerBusiness _CareerBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public CareerController(ICareerBusiness CareerBusiness, IWebHostEnvironment WebHostEnvironment) : base(CareerBusiness, WebHostEnvironment)
        {
            _CareerBusiness = CareerBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

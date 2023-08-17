namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CareerFileController : BaseController<CareerFile, ICareerFileBusiness>
    {
        private readonly ICareerFileBusiness _CareerFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public CareerFileController(ICareerFileBusiness CareerFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(CareerFileBusiness, WebHostEnvironment)
        {
            _CareerFileBusiness = CareerFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

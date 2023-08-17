namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceController : BaseController<Service, IServiceBusiness>
    {
        private readonly IServiceBusiness _ServiceBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ServiceController(IServiceBusiness ServiceBusiness, IWebHostEnvironment WebHostEnvironment) : base(ServiceBusiness, WebHostEnvironment)
        {
            _ServiceBusiness = ServiceBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

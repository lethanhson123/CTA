namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceController : BaseController<Service, IServiceBusiness>
    {
        private readonly IServiceBusiness _ServiceBusiness;
        public ServiceController(IServiceBusiness ServiceBusiness) : base(ServiceBusiness)
        {
            _ServiceBusiness = ServiceBusiness;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceFileController : BaseController<ServiceFile, IServiceFileBusiness>
    {
        private readonly IServiceFileBusiness _ServiceFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ServiceFileController(IServiceFileBusiness ServiceFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(ServiceFileBusiness, WebHostEnvironment)
        {
            _ServiceFileBusiness = ServiceFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

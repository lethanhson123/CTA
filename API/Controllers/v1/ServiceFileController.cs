namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceFileController : BaseController<ServiceFile, IServiceFileBusiness>
    {
        private readonly IServiceFileBusiness _ServiceFileBusiness;
        public ServiceFileController(IServiceFileBusiness ServiceFileBusiness) : base(ServiceFileBusiness)
        {
            _ServiceFileBusiness = ServiceFileBusiness;
        }
    }
}

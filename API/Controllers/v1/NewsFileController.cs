namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NewsFileController : BaseController<NewsFile, INewsFileBusiness>
    {
        private readonly INewsFileBusiness _NewsFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public NewsFileController(INewsFileBusiness NewsFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(NewsFileBusiness, WebHostEnvironment)
        {
            _NewsFileBusiness = NewsFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

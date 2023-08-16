namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NewsFileController : BaseController<NewsFile, INewsFileBusiness>
    {
        private readonly INewsFileBusiness _NewsFileBusiness;
        public NewsFileController(INewsFileBusiness NewsFileBusiness) : base(NewsFileBusiness)
        {
            _NewsFileBusiness = NewsFileBusiness;
        }
    }
}

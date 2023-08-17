namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NewsController : BaseController<News, INewsBusiness>
    {
        private readonly INewsBusiness _NewsBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public NewsController(INewsBusiness NewsBusiness, IWebHostEnvironment WebHostEnvironment) : base(NewsBusiness, WebHostEnvironment)
        {
            _NewsBusiness = NewsBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

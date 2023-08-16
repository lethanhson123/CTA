namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NewsController : BaseController<News, INewsBusiness>
    {
        private readonly INewsBusiness _NewsBusiness;
        public NewsController(INewsBusiness NewsBusiness) : base(NewsBusiness)
        {
            _NewsBusiness = NewsBusiness;
        }
    }
}

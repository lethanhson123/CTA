namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class IdeasFileController : BaseController<IdeasFile, IIdeasFileBusiness>
    {
        private readonly IIdeasFileBusiness _IdeasFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public IdeasFileController(IIdeasFileBusiness IdeasFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(IdeasFileBusiness, WebHostEnvironment)
        {
            _IdeasFileBusiness = IdeasFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

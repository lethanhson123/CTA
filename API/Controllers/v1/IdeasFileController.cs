namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class IdeasFileController : BaseController<IdeasFile, IIdeasFileBusiness>
    {
        private readonly IIdeasFileBusiness _IdeasFileBusiness;
        public IdeasFileController(IIdeasFileBusiness IdeasFileBusiness) : base(IdeasFileBusiness)
        {
            _IdeasFileBusiness = IdeasFileBusiness;
        }
    }
}

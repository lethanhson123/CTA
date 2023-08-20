namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryIdeasController : BaseController<CategoryIdeas, ICategoryIdeasBusiness>
    {
        private readonly ICategoryIdeasBusiness _CategoryIdeasBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public CategoryIdeasController(ICategoryIdeasBusiness CategoryIdeasBusiness, IWebHostEnvironment WebHostEnvironment) : base(CategoryIdeasBusiness, WebHostEnvironment)
        {
            _CategoryIdeasBusiness = CategoryIdeasBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

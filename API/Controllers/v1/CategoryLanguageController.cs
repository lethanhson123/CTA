namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryLanguageController : BaseController<CategoryLanguage, ICategoryLanguageBusiness>
    {
        private readonly ICategoryLanguageBusiness _CategoryLanguageBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public CategoryLanguageController(ICategoryLanguageBusiness CategoryLanguageBusiness, IWebHostEnvironment WebHostEnvironment) : base(CategoryLanguageBusiness, WebHostEnvironment)
        {
            _CategoryLanguageBusiness = CategoryLanguageBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryLanguageController : BaseController<CategoryLanguage, ICategoryLanguageBusiness>
    {
        private readonly ICategoryLanguageBusiness _CategoryLanguageBusiness;
        public CategoryLanguageController(ICategoryLanguageBusiness CategoryLanguageBusiness) : base(CategoryLanguageBusiness)
        {
            _CategoryLanguageBusiness = CategoryLanguageBusiness;
        }
    }
}

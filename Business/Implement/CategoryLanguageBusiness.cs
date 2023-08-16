
namespace Business.Implement
{
    public class CategoryLanguageBusiness : BaseBusiness<CategoryLanguage, ICategoryLanguageRepository>, ICategoryLanguageBusiness
    {
        private readonly ICategoryLanguageRepository _CategoryLanguageRepository;
        public CategoryLanguageBusiness(ICategoryLanguageRepository CategoryLanguageRepository) : base(CategoryLanguageRepository)
        {
            _CategoryLanguageRepository = CategoryLanguageRepository;
        }
    }
}

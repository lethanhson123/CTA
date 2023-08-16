namespace Data.Repository.Implement
{
    public class CategoryLanguageRepository : BaseRepository<CategoryLanguage>, ICategoryLanguageRepository
    {
        private readonly CTAContext _context;
        public CategoryLanguageRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

namespace Data.Repository.Implement
{
    public class CategoryIdeasRepository : BaseRepository<CategoryIdeas>, ICategoryIdeasRepository
    {
        private readonly CTAContext _context;
        public CategoryIdeasRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}


namespace Business.Implement
{
    public class CategoryIdeasBusiness : BaseBusiness<CategoryIdeas, ICategoryIdeasRepository>, ICategoryIdeasBusiness
    {
        private readonly ICategoryIdeasRepository _CategoryIdeasRepository;
        public CategoryIdeasBusiness(ICategoryIdeasRepository CategoryIdeasRepository) : base(CategoryIdeasRepository)
        {
            _CategoryIdeasRepository = CategoryIdeasRepository;
        }      
        public override async Task<List<CategoryIdeas>> GetAllAndEmptyToListAsync()
        {
            List<CategoryIdeas> result = new List<CategoryIdeas>();
            try
            {
                CategoryIdeas empty = new CategoryIdeas();
                empty.ParentID = 1;
                empty.CategoryID = 0;
                empty.SortOrder = GlobalHelper.InitializationSortOrder;
                result.Add(empty);
                List<CategoryIdeas> list = await _CategoryIdeasRepository.GetAllToListAsync();
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
    }
}

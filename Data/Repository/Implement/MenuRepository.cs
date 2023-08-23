namespace Data.Repository.Implement
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        private readonly CTAContext _context;
        public MenuRepository(CTAContext context) : base(context)
        {
            _context = context;
        }
    }
}

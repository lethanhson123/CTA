
namespace Business.Implement
{
    public class MenuBusiness : BaseBusiness<Menu, IMenuRepository>, IMenuBusiness
    {
        private readonly IMenuRepository _MenuRepository;
        public MenuBusiness(IMenuRepository MenuRepository) : base(MenuRepository)
        {
            _MenuRepository = MenuRepository;
        }
    }
}

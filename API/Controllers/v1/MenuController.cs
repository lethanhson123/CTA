namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MenuController : BaseController<Menu, IMenuBusiness>
    {
        private readonly IMenuBusiness _MenuBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public MenuController(IMenuBusiness MenuBusiness, IWebHostEnvironment WebHostEnvironment) : base(MenuBusiness, WebHostEnvironment)
        {
            _MenuBusiness = MenuBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

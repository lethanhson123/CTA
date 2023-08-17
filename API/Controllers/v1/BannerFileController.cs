namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BannerFileController : BaseController<BannerFile, IBannerFileBusiness>
    {
        private readonly IBannerFileBusiness _BannerFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public BannerFileController(IBannerFileBusiness BannerFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(BannerFileBusiness, WebHostEnvironment)
        {
            _BannerFileBusiness = BannerFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

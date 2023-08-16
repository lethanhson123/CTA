namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AboutFileController : BaseController<AboutFile, IAboutFileBusiness>
    {
        private readonly IAboutFileBusiness _AboutFileBusiness;
        public AboutFileController(IAboutFileBusiness AboutFileBusiness) : base(AboutFileBusiness)
        {
            _AboutFileBusiness = AboutFileBusiness;
        }
    }
}

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ContactFileController : BaseController<ContactFile, IContactFileBusiness>
    {
        private readonly IContactFileBusiness _ContactFileBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ContactFileController(IContactFileBusiness ContactFileBusiness, IWebHostEnvironment WebHostEnvironment) : base(ContactFileBusiness, WebHostEnvironment)
        {
            _ContactFileBusiness = ContactFileBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

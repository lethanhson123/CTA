namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ContactController : BaseController<Contact, IContactBusiness>
    {
        private readonly IContactBusiness _ContactBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ContactController(IContactBusiness ContactBusiness, IWebHostEnvironment WebHostEnvironment) : base(ContactBusiness, WebHostEnvironment)
        {
            _ContactBusiness = ContactBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}

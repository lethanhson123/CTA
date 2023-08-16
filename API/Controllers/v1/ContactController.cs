namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ContactController : BaseController<Contact, IContactBusiness>
    {
        private readonly IContactBusiness _ContactBusiness;
        public ContactController(IContactBusiness ContactBusiness) : base(ContactBusiness)
        {
            _ContactBusiness = ContactBusiness;
        }
    }
}

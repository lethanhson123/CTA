namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ContactFileController : BaseController<ContactFile, IContactFileBusiness>
    {
        private readonly IContactFileBusiness _ContactFileBusiness;
        public ContactFileController(IContactFileBusiness ContactFileBusiness) : base(ContactFileBusiness)
        {
            _ContactFileBusiness = ContactFileBusiness;
        }
    }
}

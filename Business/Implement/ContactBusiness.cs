
namespace Business.Implement
{
    public class ContactBusiness : BaseBusiness<Contact, IContactRepository>, IContactBusiness
    {
        private readonly IContactRepository _ContactRepository;
        public ContactBusiness(IContactRepository ContactRepository) : base(ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }
    }
}

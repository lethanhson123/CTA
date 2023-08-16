
namespace Business.Implement
{
    public class ContactFileBusiness : BaseBusiness<ContactFile, IContactFileRepository>, IContactFileBusiness
    {
        private readonly IContactFileRepository _ContactFileRepository;
        public ContactFileBusiness(IContactFileRepository ContactFileRepository) : base(ContactFileRepository)
        {
            _ContactFileRepository = ContactFileRepository;
        }
    }
}

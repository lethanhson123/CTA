
namespace Business.Implement
{
    public class ServiceBusiness : BaseBusiness<Service, IServiceRepository>, IServiceBusiness
    {
        private readonly IServiceRepository _ServiceRepository;
        public ServiceBusiness(IServiceRepository ServiceRepository) : base(ServiceRepository)
        {
            _ServiceRepository = ServiceRepository;
        }
    }
}

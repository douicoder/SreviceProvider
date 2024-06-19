using Class.User.CategoryModel;
using Class.User.UserModel;
using ServiceProvider.Shared.User;

namespace ServiceProvider.Server.Modules.Interface
{
    public interface IServiceProviderDetailsManager
    {

        public bool AddDetails(ServiceProviderProfile serviceProviderProfile);
        public ServiceProviderProfile GetDetail(Guid userid);

    }
}

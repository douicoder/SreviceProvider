using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared.User;

namespace ServiceProvider.Server.Modules.Manager
{
    public class ServiceProviderDetailsManager : IServiceProviderDetailsManager
    {

        DatabaseContext database = new();
        public ServiceProviderDetailsManager(DatabaseContext _db)
        {
            database = _db;
        }
        public bool AddDetails(ServiceProviderProfile serviceProviderProfile)
        {
           
                try
                {

                    // Add the user to the database and save changes
                    database.ServiceProviderProfilesDB.Add(serviceProviderProfile);
                    database.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    return false;
                }
           
        }

        public ServiceProviderProfile GetDetail(Guid userid)
        {
            try
            {
                // Retrieve the service provider profile based on the userId
                ServiceProviderProfile serviceProviderProfile = database.ServiceProviderProfilesDB.FirstOrDefault(sp=>sp.UserID==userid);

                return serviceProviderProfile;
            }
            catch (Exception ex)
            {
                // Handle exception (you might want to log this exception)
                return null; // Return null in case of an exception
            }
        }

        public bool UpdateDetails(ServiceProviderProfile serviceProviderProfile)
        {
            try
            {
                var record = database.ServiceProviderProfilesDB.Where(c => c.ServiceproviderProfileID == serviceProviderProfile.ServiceproviderProfileID).FirstOrDefault();

                if (record != null)
                {
                    record.PinCode = serviceProviderProfile.PinCode;
                    database.SaveChanges();
                }
                // Update other properties as needed
               
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error updating service provider details: {ex.Message}");
                return false;
            }
        }











    }
}

using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared;

namespace ServiceProvider.Server.Modules.Manager
{
    public class PinCodeManager : IPinCodeManager
    {
        public async Task<bool> CheckPinCode(string code)
        {
            var apiUrl = $"https://api.postalpincode.in/pincode/{code}";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<PincodeResponse>>(jsonString);

                        if (result != null && result.Any())
                        {
                            var firstPostOffice = result.First();//;
                            if (firstPostOffice.Status == "Success") 
                            {
                                return true;
                            }
                          else 
                            {
                                return false;
                            }
                            // API call and deserialization succeeded
                        }
                        else
                        {
                            Console.WriteLine("No data found");
                            return false; // No data found
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                  return false;
                }
            }
        }
    }
}

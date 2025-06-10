using Newtonsoft.Json;
using SLHDotNetTrainingBatch1.MvcApiExample.MvcWebApp.Models;

namespace SLHDotNetTrainingBatch1.MvcApiExample.MvcWebApp.Services
{
    public class WalletService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public WalletService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration=configuration;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("ApiUrl")!);
        }

        public async Task<List<WalletModel>> GetWalletsAsync()
        {
            var response = await _httpClient.GetAsync("api/wallet");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                List<WalletModel> lst = JsonConvert.DeserializeObject<List<WalletModel>>(jsonStr)!;
                return lst;
            }
            else
            {
                throw new Exception("Failed to retrieve wallets.");
            }
        }
    }
}

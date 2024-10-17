using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    /// <summary>
    /// Эксземпляр сервиса по управлению производителями препаратов
    /// </summary>
    internal class DrugManufactureService : IDrugManufactureService
    {
        private HttpClient _httpClient = new HttpClient();

        public DrugManufactureService()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44354/");
        }

        public Task CreateDrugManufactureAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DrugManufacturerModel>> GetDrugsManufacturersAsync()
        {
            var response = await _httpClient.GetAsync("manufacturers");
            var text = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var json = JsonSerializer.Deserialize<List<DrugManufacturerModel>>(text);
                return json;
            }
            else
            {
                throw new HttpRequestException(text);
            }
        }

        public Task RemoveDrugManufactureAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDrugManufactureAsync()
        {
            throw new NotImplementedException();
        }
    }
}

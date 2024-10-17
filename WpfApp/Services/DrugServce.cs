using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    /// <summary>
    /// Эксземпляр сервиса по управлению препаратами
    /// </summary>
    internal class DrugServce : IDrugService
    {
        private HttpClient _httpClient = new HttpClient();

        public DrugServce()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44354/");
        }

        public async Task<DrugModel> CreateDrugAsync(DrugModel drugModel)
        {
            var content = JsonContent.Create(new
            {
                drugModel.Name,
                drugModel.Dosage,
                drugModel.Packaging,
                DrugManufacturerId = drugModel.Manufacturer.Id,
            });

            var response = await _httpClient.PostAsync("drugs", content);
            var text = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var json = JsonSerializer.Deserialize<DrugModel>(text);
                return json;
            }
            else
            {
                throw new HttpRequestException(text);
            }
        }

        public async Task<IEnumerable<DrugModel>> GetDrugsAsync()
        {
            var response = await _httpClient.GetAsync("drugs");
            var text = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var json = JsonSerializer.Deserialize<List<DrugModel>>(text);
                return json;
            }
            else
            {
                throw new HttpRequestException(text);
            }
        }

        public async Task RemoveDrugAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"drugs/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(text);
            }
        }

        public async Task<DrugModel> UpdateDrugAsync(DrugModel drugModel)
        {
            var content = JsonContent.Create(new
            {
                drugModel.Name,
                drugModel.Dosage,
                drugModel.Packaging,
                DrugManufacturerId = drugModel.Manufacturer.Id,
            });

            var response = await _httpClient.PutAsync($"drugs/{drugModel.Id}", content);
            var text = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var json = JsonSerializer.Deserialize<DrugModel>(text);
                return json;
            }
            else
            {
                throw new HttpRequestException(text);
            }
        }
    }
}

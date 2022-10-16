using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        public async Task<Vårdgivare> GetVårdgivareAsync(int vårdgivareId)
        {
            return await _httpClient.GetFromJsonAsync<Vårdgivare>($"api/vårdgivare/{vårdgivareId}");
        }
        public async Task<Vårdgivare[]> GetVårdgivaresAsync()
        {
            return await _httpClient.GetFromJsonAsync<Vårdgivare[]>("api/vårdgivare");
        }
        public async Task PostVårdgivaresAsync(Vårdgivare vårdgivare)
        {
            await _httpClient.PostAsJsonAsync<Vårdgivare>("api/vårdgivare",vårdgivare);
        }

        public async Task DeleteVårdgivareAsync(int vårdgivareId)
        {
            await _httpClient.DeleteAsync($"api/vårdgivare/{vårdgivareId}");
        }

        public async Task PutVårdgivareAsync(int vårdgivareId,Vårdgivare vårdgivare)
        {
            await _httpClient.PutAsJsonAsync<Vårdgivare>($"api/vårdgivare/{vårdgivareId}", vårdgivare);
        }
    }
}

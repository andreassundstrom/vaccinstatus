using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        //Leverantör
        public async Task<Leverantör[]> GetLeverantörer()
        {
            return await _httpClient.GetFromJsonAsync<Leverantör[]>("api/leverantör");
        }

        public async Task<Leverantör[]> GetLeverantör(int leverantörId)
        {
            return await _httpClient.GetFromJsonAsync<Leverantör[]>($"api/leverantör/{leverantörId}");
        }

        public async Task PostLeverantör(Leverantör leverantör)
        {
            await _httpClient.PostAsJsonAsync<Leverantör>("api/leverantör", leverantör);
        }

        public async Task DeleteLeverantör(int leverantörId)
        {
            await _httpClient.DeleteAsync($"api/leverantör/{leverantörId}");
        }
    }
}

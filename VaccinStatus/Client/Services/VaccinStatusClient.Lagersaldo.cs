using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        //Lagersaldo
        public async Task<Lagersaldo[]> GetLagersaldo()
        {
            var lagersaldo = await _httpClient.GetFromJsonAsync<Lagersaldo[]>("api/Lagersaldo");
            return lagersaldo;
        }

        public async Task PostLagerslado(Lagersaldo lagersaldo)
        {
            await _httpClient.PostAsJsonAsync<Lagersaldo>("api/lagersaldo", lagersaldo);
        }
    }
}

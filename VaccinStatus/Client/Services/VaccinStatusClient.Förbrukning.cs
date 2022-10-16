using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        public async Task<Förbrukning[]> GetFörbrukningsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Förbrukning[]>("api/förbrukning");
        }

        public async Task PostFörbrukningAsync(Förbrukning förbrukning)
        {
            await _httpClient.PostAsJsonAsync<Förbrukning>("api/förbrukning", förbrukning);
        }
    }
}

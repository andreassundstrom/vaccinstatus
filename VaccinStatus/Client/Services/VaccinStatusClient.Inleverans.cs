using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        //Inleverans
        public async Task PostInleverans(Inleverans inleverans)
        {
            await _httpClient.PostAsJsonAsync<Inleverans>("api/inleverans", inleverans);
        }

        public async Task<Inleverans[]> GetInleveranser()
        {
            return await _httpClient.GetFromJsonAsync<Inleverans[]>("api/inleverans");
        }
    }
}

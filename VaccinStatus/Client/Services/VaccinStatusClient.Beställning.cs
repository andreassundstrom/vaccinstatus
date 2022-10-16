using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        //Beställning
        public async Task<Beställning[]> GetBeställning()
        {
            var beställningar = await _httpClient.GetFromJsonAsync<Beställning[]>("api/beställning");
            return beställningar;
        }

        public async Task PostBeställning(Beställning beställning)
        {
            await _httpClient.PostAsJsonAsync<Beställning>("api/beställning", beställning);
        }
    }
}

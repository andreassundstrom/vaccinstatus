using System.Net.Http.Json;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        //Kapacitet
        public async Task<Kapacitet[]> GetKapaciteter()
        {
            var kapacitet = await _httpClient.GetFromJsonAsync<Kapacitet[]>("api/kapacitet");
            return kapacitet;
        }

        public async Task PostKapacitet(Kapacitet kapacitet)
        {
            await _httpClient.PostAsJsonAsync<Kapacitet>("api/kapacitet", kapacitet);
        }
    }
}

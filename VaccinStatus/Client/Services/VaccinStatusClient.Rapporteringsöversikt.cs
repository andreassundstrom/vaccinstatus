using System.Net.Http.Json;
using VaccinStatus.Shared.Statistik;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        public async Task<Rapporteringsöversikt[]> GetRapporteringsöversiktAsync()
        {
            return await _httpClient.GetFromJsonAsync<Rapporteringsöversikt[]>("api/Rapporteringsöversikt");
        }

        public async Task<Kapacitetsstatus[]> GetKapacitetsstatusAsync()
        {
            return await _httpClient.GetFromJsonAsync<Kapacitetsstatus[]>("api/Rapporteringsöversikt/kapacitetsstatus");
        }
    }
}

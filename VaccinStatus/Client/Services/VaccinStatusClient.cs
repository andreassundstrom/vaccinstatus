using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VaccinStatus.Shared;

namespace VaccinStatus.Client.Services
{
    public partial class VaccinStatusClient
    {
        private readonly HttpClient _httpClient;
        public VaccinStatusClient(HttpClient client)
        {
            this._httpClient = client;
        }
        

        

        


    }
}

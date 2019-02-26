using Newtonsoft.Json;
using ProyectoVueling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoVueling.Repositories
{
    public class ModulosRepository : IRepository<Modulo>
    {
        private readonly HttpClient Client;

        public ModulosRepository(HttpClient client)
        {
            Client = client;
        }

        public async Task<Modulo> GetAsync(int id)
        {
            var response = await Client.GetStringAsync(Urls_Azure.GetUriById(Urls_Azure.MODULOS, id));

            return JsonConvert.DeserializeObject<Modulo>(response);
        }

        public async Task<IEnumerable<Modulo>> GetAsync()
        {
            var response = await Client.GetStringAsync(Urls_Azure.GetUri(Urls_Azure.MODULOS));

            return JsonConvert.DeserializeObject<List<Modulo>>(response);
        }
    }
}

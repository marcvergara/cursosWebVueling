using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoVueling.Models;

namespace ProyectoVueling.Repositories
{
    public class CursoRepository:IRepository<Curso>
    {
        private readonly HttpClient Client;

        public CursoRepository(HttpClient client)
        {
            Client = client;
        }

        public async Task<Curso> GetAsync(int id)
        {
            var response = await Client.GetStringAsync(Urls_Azure.GetUriById(Urls_Azure.CURSOS, id));

            return JsonConvert.DeserializeObject<Curso>(response);
        }

        public async Task<IEnumerable<Curso>> GetAsync()
        {
            var response = await Client.GetStringAsync(Urls_Azure.GetUri(Urls_Azure.CURSOS));

            return JsonConvert.DeserializeObject<List<Curso>>(response);
        }
    }
}

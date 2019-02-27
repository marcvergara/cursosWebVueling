using Newtonsoft.Json;
using ProyectoVueling.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoVueling.Repositories
{
    public class CursoImpartidoRepository:IRepository<CursoImpartido>
    {
        private readonly HttpClient Client;

        public CursoImpartidoRepository(HttpClient client)
        {
            Client = client;
        }

        public async Task<CursoImpartido> GetAsync(int id)
        {
            var response = await Client.GetStringAsync(Urls_Azure.GetUriById(Urls_Azure.CURSOS_IMPARTIDOS, id));

            return JsonConvert.DeserializeObject<CursoImpartido>(response);
        }

        public async Task<IEnumerable<CursoImpartido>> GetAsync()
        {
            var response = await Client.GetStringAsync(Urls_Azure.GetUri(Urls_Azure.MODULOS));

            return JsonConvert.DeserializeObject<List<CursoImpartido>>(response);
        }
    }
}

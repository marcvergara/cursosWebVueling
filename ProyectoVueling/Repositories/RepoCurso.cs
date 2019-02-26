using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoVueling.Models;

namespace ProyectoVueling.Repositories
{
    public class RepoCurso:IRepoCurso
    {
        private readonly HttpClient _httpClient;

        public RepoCurso(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public DateTime CalcularFecha()
        {
            throw new NotImplementedException();
        }

        public async Task<Curso> GetAsync(int id)
        {
            var responseString = await _httpClient.GetStringAsync("");

            var catalog = JsonConvert.DeserializeObject<Curso>(responseString);

            return catalog;
        }

        public async Task<IEnumerable<Curso>> GetAsync()
        {
            var responseString = await _httpClient.GetStringAsync("");

            var catalog = JsonConvert.DeserializeObject<List<Curso>>(responseString);

            return catalog;
        }
    }
}

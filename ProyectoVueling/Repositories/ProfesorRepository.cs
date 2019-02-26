﻿using Newtonsoft.Json;
using ProyectoVueling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoVueling.Repositories
{
    public class ProfesorRepository : IRepository<Profesor>
    {
        private readonly HttpClient _httpClient;

        public ProfesorRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Profesor> GetAsync(int id)
        {
            var responseString = await _httpClient.GetStringAsync("");

            var catalog = JsonConvert.DeserializeObject<Profesor>(responseString);

            return catalog;
        }

        public async Task<IEnumerable<Profesor>> GetAsync()
        {
            var responseString = await _httpClient.GetStringAsync("");

            var catalog = JsonConvert.DeserializeObject<List< Profesor>>(responseString);

            return catalog;
        }


    }
}

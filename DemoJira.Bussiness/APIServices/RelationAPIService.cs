using DemoJira.Bussiness.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.APIServices
{
    public class RelationAPIService
    {
        private readonly HttpClient _httpClient;
        private IEnumerable<TaskRelationshipDTO> _relations;
        private TaskRelationshipDTO _relation;
        public RelationAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           // _httpClient.BaseAddress = new Uri("http://localhost:5120");

        }

        public async Task<TaskRelationshipDTO> CreateRelationAsync(TaskRelationshipDTO dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("api/Relation/create", dto);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<TaskRelationshipDTO>();
        }

        public async Task<IEnumerable<TaskRelationshipDTO>> GetAllRelations()
        {
            var response = await _httpClient.GetStringAsync("/api/Relation/relations");
            Console.WriteLine(response);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<TaskRelationshipDTO>>(response, settings);

        }
        public async Task<IEnumerable<TaskRelationshipDTO>> GetAllRelationsByTid(int tid)
        {
            var response = await _httpClient.GetStringAsync($"/api/Relation/relByTid/{tid}");
            Console.WriteLine(response);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<TaskRelationshipDTO>>(response, settings);

        }
        public async Task<bool> DeleteRelation(int id)
        {
            HttpResponseMessage resp = await _httpClient.DeleteAsync($"/api/Relation/{id}");
            return resp.IsSuccessStatusCode;
        }

        public async Task<TaskRelationshipDTO> GetRelationByID(int id)
        {
            HttpResponseMessage resp = await _httpClient.GetAsync($"api/Relation/{id}");
            if (resp.IsSuccessStatusCode)
            {
                string result = await resp.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                _relation = JsonConvert.DeserializeObject<TaskRelationshipDTO>(result, settings);
            }
            return _relation;
        }
    }
}

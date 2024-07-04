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
        private IEnumerable<RelationDTO> _relations;
        private RelationDTO _relation;
        public RelationAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           // _httpClient.BaseAddress = new Uri("http://localhost:5120");

        }

        public async Task<RelationDTO> CreateRelationAsync(RelationDTO dto)
        {
            var resp = await _httpClient.PostAsJsonAsync("api/Relation", dto);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<RelationDTO>();
        }

        public async Task<IEnumerable<RelationDTO>> GetAllRelations()
        {
            var response = await _httpClient.GetStringAsync("/api/Relation/relations");
            Console.WriteLine(response);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<RelationDTO>>(response, settings);

        }
        public async Task<bool> DeleteRelation(int id)
        {
            HttpResponseMessage resp = await _httpClient.DeleteAsync($"/api/Relation/{id}");
            return resp.IsSuccessStatusCode;
        }

        public async Task<RelationDTO> GetRelationByID(int id)
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

                _relation = JsonConvert.DeserializeObject<RelationDTO>(result, settings);
            }
            return _relation;
        }
    }
}

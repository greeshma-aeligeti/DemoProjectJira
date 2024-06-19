using DemoJira.Bussiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{
    public class TaskAPIService
    {
        private readonly HttpClient _httpClient; 
        public TaskAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TaskDTO>> GetTasksAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync<TaskDTO[]>("api/tasks");
            return (IEnumerable<TaskDTO>)response;
        }
    }
}

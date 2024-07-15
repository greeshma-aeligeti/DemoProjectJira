using Azure;
using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.APIServices
{
    public class TaskAPIService
    {
        private readonly HttpClient _httpClient;
        private IEnumerable<TaskDTO>? taskDTOs;
        private ProjectDTO projectDTO;
        private TaskDTO taskDTO;
        private IEnumerable< ProjectDTO> projectDTOs;
        private IEnumerable< IterationDTO> iterationDTOs;


        public TaskAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5120/");
       
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksAsync()
        {
            var response = await _httpClient.GetStringAsync("/api/Task/tasks");
            Console.WriteLine(response);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<TaskDTO>>(response, settings);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Task/proj");
            if (response.IsSuccessStatusCode)
            {
                // Reading Response
                string result = await response.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                projectDTOs = JsonConvert.DeserializeObject<List<ProjectDTO>>(result, settings);
            }
            return projectDTOs;
        }

        public async Task<IEnumerable<IterationDTO>> GetAllIterations()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("/api/Task/itr/all");
            if (responseMessage.IsSuccessStatusCode)
            {
                string res = await responseMessage.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                iterationDTOs = JsonConvert.DeserializeObject<List<IterationDTO>>(res, settings);
            }
            return iterationDTOs;
        }

        public async Task<bool> DeleteTaskApi(int id)
        {
            HttpResponseMessage resp = await _httpClient.DeleteAsync($"/api/Task/{id}");
            return resp.IsSuccessStatusCode;
        }

        public async Task<ProjectDTO> GetProjByID(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Task/proj/{id}/");
            if (response.IsSuccessStatusCode)
            {
                // Reading Response
                string result = await response.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                projectDTO = JsonConvert.DeserializeObject<ProjectDTO>(result, settings);
            }
            return projectDTO;
        }
        public async Task<TaskDTO> GetTaskByID(int id)
        {
            HttpResponseMessage resp = await _httpClient.GetAsync($"api/Task/{id}");
            if(resp.IsSuccessStatusCode)
            {
                string result = await resp.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                taskDTO = JsonConvert.DeserializeObject<TaskDTO>(result, settings);
            }
            return taskDTO;
        }

        public async Task UpdateTask(int id, TaskDTO taskDTO)
        {
            HttpResponseMessage rep = await _httpClient.PutAsJsonAsync($"api/Task/{id}", taskDTO);
            if (rep.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
        }

        public async Task<TaskDTO> CreateTaskAsync(TaskDTO Task)
        {

            var response = await _httpClient.PostAsJsonAsync("api/Task/CreateTask", Task);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TaskDTO>();
        }

        public async Task<bool> AddTaskRelation(TaskRelationshipDTO taskRelationshipDTO)
        {
            var resp = await _httpClient.PostAsJsonAsync("api/Task/add-relationship", taskRelationshipDTO);
            resp.EnsureSuccessStatusCode();
            return resp.IsSuccessStatusCode;
        }

       /* public async Task<(bool Success, string AttachmentUrl)> UploadFile(int taskId, MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync($"api/task/{taskId}/upload", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AttachmentResponse>();
                return (true, result.AttachmentUrl);
            }

            return (false, null);
        }

        private class AttachmentResponse
        {
            public string AttachmentUrl { get; set; }
        }*/

    }
}

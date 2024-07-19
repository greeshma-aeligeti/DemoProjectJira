using DemoJira.Bussiness.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.APIServices
{
    public class CommentAPIService
    {
        private readonly HttpClient _httpClient;
        private CommentDTO commentDTO1;
        public CommentAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           // _httpClient.BaseAddress = new Uri("http://localhost:5120");

        }


        public async Task<CommentDTO> CreateComment(CommentDTO commentDTO)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Comment", commentDTO);
            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CommentDTO>();



/*
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(commentDTO), Encoding.UTF8, "application/json");


            try
            {
                var resp = await _httpClient.PostAsync("http://localhost:5120/api/Comment", content);
                resp.EnsureSuccessStatusCode();
                return await resp.Content.ReadFromJsonAsync<CommentDTO>();

            }
            catch (HttpRequestException ex) { 
            Console.WriteLine("htttp exception "+ex.Message);
                return null;
            
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }*/
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsAsync()
        {
            var response = await _httpClient.GetStringAsync("api/Comment/comments");

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<CommentDTO>>(response, settings);
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsAsyncByTID(string id)
        {
            var response = await _httpClient.GetStringAsync($"api/Comment/task/{id}");

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<CommentDTO>>(response, settings);
        }
        public async Task<CommentDTO> GetCommentByID(int id)
        {
            HttpResponseMessage resp = await _httpClient.GetAsync($"api/Comment/{id}");
            if (resp.IsSuccessStatusCode)
            {
                string result = await resp.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                commentDTO1 = JsonConvert.DeserializeObject<CommentDTO>(result, settings);
            }
            return commentDTO1;
        }

        public async Task<bool> DeleteCommentApi(int id)
        {
            HttpResponseMessage resp = await _httpClient.DeleteAsync($"/api/Comment/{id}");
            return resp.IsSuccessStatusCode;
        }


    }


}

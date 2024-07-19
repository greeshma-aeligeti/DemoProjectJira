using DemoJira.Bussiness.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.APIServices
{
    public class FileApiService
    {
        private readonly HttpClient _httpClient;

        public FileApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
          // Adjust base URL as needed

        }
        public async Task<HttpResponseMessage> UploadFile(MultipartFormDataContent file)
        {
            try
            {
                var result = await _httpClient.PostAsync("/api/File/fileupload", file); ;
                return result;
            }
            catch (Exception ex)
            {
                var errorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"An error occurred while uploading the file: {ex.Message}")
                };
                return errorResponse;
            }
        
        
        }

        public async Task<byte[]> DownloadFile(int fileId)
        {
            var response = await _httpClient.GetAsync($"/api/File/download/{fileId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            else
            {
                throw new Exception($"Failed to download file. Status code: {response.StatusCode}");
            }
        }


        public async Task<IEnumerable<FileDTO>> GetFilesByTID(string id)
        {
            var response = await _httpClient.GetStringAsync($"api/File/getByID/{id}");
            Console.WriteLine(response);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            return JsonConvert.DeserializeObject<List<FileDTO>>(response, settings);

        }



    }
}

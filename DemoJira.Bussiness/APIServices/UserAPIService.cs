using DemoJira.Bussiness.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.APIServices
{
    public class UserAPIService
    {
        private readonly HttpClient _httpClient;
        private IEnumerable<UserDTO> UserDTOs;
        private UserDTO User;
        public UserAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           // UserDTO = userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/User/users");
            if(response.IsSuccessStatusCode)
            {
                string res=await response.Content.ReadAsStringAsync();
                UserDTOs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDTO>>(res);

            }
            return UserDTOs;
        }

        public async Task<UserDTO> GetUserbyID(int id)
        {
            HttpResponseMessage resp = await _httpClient.GetAsync($"api/User/{id}");
            if (resp.IsSuccessStatusCode)
            {
                string result = await resp.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                };

                User = JsonConvert.DeserializeObject<UserDTO>(result, settings);
            }
            return User;
        }

    }
}

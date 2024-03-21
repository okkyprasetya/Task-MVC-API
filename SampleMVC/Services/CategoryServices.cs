using Azure;
using MyRESTServices.BLL.DTOs;
using System.Text;
using System.Text.Json;

namespace SampleMVC.Services
{
    public class CategoryServices : ICategoryServices
    {
        private const string BaseUrl = "http://localhost:5272/api/v1/Categories";
        private readonly HttpClient _client;

        public CategoryServices(HttpClient client)
        {
            _client = client;
        }

        public async Task Delete(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete category");
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return categories;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            
            var httpResponse = await _client.GetAsync($"{BaseUrl}/{id}");


            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var category = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return category;
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO)
        {
            var json = JsonSerializer.Serialize(categoryCreateDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(BaseUrl, data);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot insert category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var category = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return category;
        }

        public async Task<CategoryDTO> Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var json = JsonSerializer.Serialize(categoryUpdateDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PutAsync($"{BaseUrl}/{id}", data);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync ();
            var updatedCategory = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return updatedCategory;
        }
    }
}

using MyWebFormApp.BLL.DTOs;
using MyRESTServices.BLL.DTOs;
using CategoryDTO = MyRESTServices.BLL.DTOs.CategoryDTO;
using CategoryCreateDTO = MyRESTServices.BLL.DTOs.CategoryCreateDTO;
using CategoryUpdateDTO = MyRESTServices.BLL.DTOs.CategoryUpdateDTO;

namespace SampleMVC.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO);
        Task<CategoryDTO> Update(int id, CategoryUpdateDTO categoryUpdateDTO);
        Task Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name);
        Task<int> GetCountCategories(string name);
        Task<IEnumerable<CategoryDTO>> GetAllWithPaging(int pageNumber, int pageSize, string name);
    }
}

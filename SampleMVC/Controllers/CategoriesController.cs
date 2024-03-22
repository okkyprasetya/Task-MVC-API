using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRESTServices.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.Models;
using SampleMVC.Services;
using SampleMVC.ViewModels;
namespace SampleMVC.Controllers;


//[Authorize(Roles = "admin,contributor")]
public class CategoriesController : Controller
{
    private readonly ICategoryBLL _categoryBLL;
    private readonly ICategoryServices _categoryServices;
    //private readonly IValidator<CategoryCreateDTO> _validatorCategoryCreateDTO;

    private UserDTO user = null;
    public CategoriesController(ICategoryBLL categoryBLL, ICategoryServices categoryServices/*,IValidator<CategoryCreateDTO> validatorCategoryCreateDTO*/)
    {
        _categoryBLL = categoryBLL;
        _categoryServices = categoryServices;
        //_validatorCategoryCreateDTO = validatorCategoryCreateDTO;
    }


    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5, string search = "", string act = "")
    {
        if (TempData["message"] != null)
        {
            ViewData["message"] = TempData["message"];
        }

        ViewData["search"] = search;

        CategoriesViewModel categoriesViewModel = new CategoriesViewModel()
        {
            Categories = await _categoryServices.GetAllWithPaging(pageNumber, pageSize, search)
        };

        var maxsize = (await _categoryServices.GetAll()).Count();

        if (act == "next")
        {
            if (pageNumber * pageSize < maxsize)
            {
                pageNumber += 1;
            }
            ViewData["pageNumber"] = pageNumber;
        }
        else if (act == "prev")
        {
            if (pageNumber > 1)
            {
                pageNumber -= 1;
            }
            ViewData["pageNumber"] = pageNumber;
        }
        else
        {
            ViewData["pageNumber"] = 2;
        }

        ViewData["pageSize"] = pageSize;

        return View(categoriesViewModel);
    }


    public async Task<IActionResult> GetFromServices()
    {
        var categories = await _categoryServices.GetAll();
        List<Category> categoriesList = new List<Category>();
        foreach (var category in categories)
        {
            categoriesList.Add(new Category
            {
                categoryID = category.CategoryID,
                categoryName = category.CategoryName
            });
        }
        return View(categoriesList);
    }


    public async Task<IActionResult> Detail(int id)
    {
        var model = await _categoryServices.GetById(id);
        return View(model);
    }

    //[Authorize]
    public IActionResult Create()
    {
        return PartialView("_CreateCategoryPartial");
    }

    //[Authorize]
    [HttpPost]
    public IActionResult Create(SampleMVC.ViewModels.CategoriesViewModel categoriesViewModel)
    {
        try
        {
            _categoryServices.Insert(categoriesViewModel.CategoryCreateDTO);
            //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            //ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
        }
        return RedirectToAction("GetFromServices");
    }

    //[Authorize]

    public async Task<IActionResult> Edit(int id)
    {
        var model = await _categoryServices.GetById(id);
        if (model == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    //[Authorize]
    [HttpPost]
    public IActionResult Edit(int id, CategoryUpdateDTO categoryEdit)
    {
        try
        {
            _categoryServices.Update(id,categoryEdit);
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Edit Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            return View(categoryEdit);
        }
        return RedirectToAction("GetFromServices");
    }


    //[Authorize]
    public async Task<IActionResult> Del(int id)
    {
        var model = await _categoryServices.GetById(id);
        if (model == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
            return RedirectToAction("GetFromServices");
        }
        return View(model);
    }

    //[Authorize]
    [HttpPost]
    public async Task<IActionResult> Del(int id, CategoryDTO category)
    {
        try
        {
            await _categoryServices.Delete(id);
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Delete Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            return View(category);
        }
        return RedirectToAction("GetFromServices");
    }

    public IActionResult DisplayDropdownList()
    {
        var categories = _categoryBLL.GetAll();
        ViewBag.Categories = categories;
        return View();
    }

    [HttpPost]
    public IActionResult DisplayDropdownList(string CategoryID)
    {
        ViewBag.CategoryID = CategoryID;
        ViewBag.Message = $"You selected {CategoryID}";

        ViewBag.Categories = _categoryBLL.GetAll();

        return View();
    }

}

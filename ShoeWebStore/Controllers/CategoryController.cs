using Microsoft.AspNetCore.Mvc;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Category> categoryList = _unitOfWork.Category.GetAll().ToList();
        return View(categoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name.Length < 4)
        {
            ModelState.AddModelError("key", "Name must be longer than 4 characters.");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }

        return View();
    }
}
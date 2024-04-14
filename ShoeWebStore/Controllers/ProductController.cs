using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeWebStore.DataAccess.Data;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models.Models;
using ShoeWebStore.Models.ViewModels;

namespace ShoeWebStore.Controllers;

public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        return View(productList);
    }

    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> categoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });

        ProductViewModel productViewModel = new ProductViewModel()
        {
            CategoryList = categoryList,
            Product = new Product()
        };

        if (id == null || id == 0)
        {
            //Create
            return View(productViewModel);
        }
        else
        {
            //Update
            productViewModel.Product = _unitOfWork.Product.Get(p => p.Id == id);
            return View(productViewModel);
        }
    }

    [HttpPost]
    public IActionResult Upsert(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            if (productViewModel.Product.Id == 0)
            {
                _unitOfWork.Product.Add(productViewModel.Product);
            }
            else
            {
                _unitOfWork.Product.Update(productViewModel.Product);
            }

            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");
        }
        //else nakon refresha da se ne isprazni dropdown
        else
        {
            productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        return View(productViewModel);
    }
    
    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        return Json(new { data = productList });
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var product = _unitOfWork.Product.Get(p => p.Id == id);

        if (product == null)
        {
            return Json(new { success = false, message = "Error while deleting." });
        }
        
        _unitOfWork.Product.Delete(product);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Product deleted successfully!" });
    }

    #endregion
}
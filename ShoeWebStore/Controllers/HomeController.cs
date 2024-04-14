using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        return View(productList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Details(int productId)
    {
        Product product = _unitOfWork.Product.Get(p => p.Id == productId, includeProperties: "Category");
        return View(product);
    }
}

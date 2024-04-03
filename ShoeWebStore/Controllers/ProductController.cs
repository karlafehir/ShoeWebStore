using Microsoft.AspNetCore.Mvc;

namespace ShoeWebStore.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
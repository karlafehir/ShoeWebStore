using Microsoft.AspNetCore.Mvc;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.Areas.Admin.Controllers;
[Area("Admin")]
public class CompanyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Company> companyList = _unitOfWork.Company.GetAll().ToList();
        return View(companyList);
    }

    public IActionResult Upsert(int? id)
    {
        Company company = new Company(); 
        if(id == null || id == 0) 
        { 
            return View(company);
        }
        else
        {
            company = _unitOfWork.Company.Get(p=> p.Id == id);
            return View(company);
        }
    }

    [HttpPost]
    public IActionResult Upsert(Company company)
    {
        if(ModelState.IsValid)
        {
            if(company.Id == 0)
            {
                _unitOfWork.Company.Add(company);
            }
            else
            {
                _unitOfWork.Company.Update(company);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index", "Company");
        }

        return View();
    }

    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Company> companyList = _unitOfWork.Company.GetAll().ToList();
        return Json(new { data = companyList });
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        Company company = _unitOfWork.Company.Get(p => p.Id == id);
        
        if (company.Id == 0)
        {
            return Json(new { success = true, message = "Error while deleting" });
        }

        _unitOfWork.Company.Delete(company);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Company deleted successfully" });
    }

    #endregion

}

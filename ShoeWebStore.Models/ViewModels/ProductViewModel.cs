using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ShoeWebStore.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoeWebStore.Models.ViewModels;

public class ProductViewModel
{
    public Product Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoryList { get; set; }
}
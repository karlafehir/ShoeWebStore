using ShoeWebStore.DataAccess.Data;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository.IRepository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _context;
    
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Category category)
    {
        _context.Update(category);
    }
}

using ShoeWebStore.DataAccess.Data;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Product product)
    {
        _context.Update(product);
    }
}
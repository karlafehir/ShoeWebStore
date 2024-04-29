using ShoeWebStore.DataAccess.Data;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private ApplicationDbContext _context;

    public ShoppingCartRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _context.Update(shoppingCart);
    }
}
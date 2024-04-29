using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository.IRepository;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{ 
    public void Update(ShoppingCart shoppingCart); 
}
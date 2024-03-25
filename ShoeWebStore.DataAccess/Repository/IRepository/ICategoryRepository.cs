using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    public void Update(Category category);
}

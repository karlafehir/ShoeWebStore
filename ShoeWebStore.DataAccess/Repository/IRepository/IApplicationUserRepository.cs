using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository.IRepository;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    public void Update(ApplicationUser applicationUser);
}
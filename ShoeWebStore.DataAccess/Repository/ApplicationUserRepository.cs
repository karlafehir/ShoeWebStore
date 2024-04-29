using ShoeWebStore.DataAccess.Data;
using ShoeWebStore.DataAccess.Repository.IRepository;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Repository;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    private ApplicationDbContext _context;

    public ApplicationUserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(ApplicationUser applicationUser)
    {
        _context.Update(applicationUser);
    }
}
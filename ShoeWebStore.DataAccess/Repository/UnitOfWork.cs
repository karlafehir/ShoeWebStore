using ShoeWebStore.DataAccess.Data;
using ShoeWebStore.DataAccess.Repository.IRepository;

namespace ShoeWebStore.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    public readonly ApplicationDbContext _context;
    public ICategoryRepository Category { get; private set; }
    public ICompanyRepository Company { get; private set; }
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Category = new CategoryRepository(context);
        Company = new CompanyRepository(context);
    }
    public void Save()
    {
        _context.SaveChanges();
    }
}

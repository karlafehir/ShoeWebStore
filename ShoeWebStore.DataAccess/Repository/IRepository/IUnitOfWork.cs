namespace ShoeWebStore.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    ICompanyRepository Company { get; }
    void Save();
}

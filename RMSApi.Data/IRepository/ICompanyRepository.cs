using RMSApi.Data.Models;

namespace RMSApi.Data.IRepository
{
    public interface ICompanyRepository
    {
        Company Get(int id);
        IEnumerable<Company> GetAll();
    }
}

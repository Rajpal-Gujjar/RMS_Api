using RMSApi.Data.Context;
using RMSApi.Data.IRepository;
using RMSApi.Data.Models;

namespace RMSApi.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RMSDbContext _context;

        public CompanyRepository(RMSDbContext context)
        {
            _context = context;
        }

        public Company Get(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies.ToList();
        }
    }
}

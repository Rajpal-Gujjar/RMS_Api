using RMSApi.Data.Context;
using RMSApi.Data.IRepository;
using RMSApi.Data.Repository;

namespace RMSApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RMSDbContext _context;

        public UnitOfWork(RMSDbContext context)
        {
            _context = context;
        }

        private ICompanyRepository _CompanyRepository;
        private IJobAppliedRepository _JobAppliedRepository;
        private IJobPostRepository _JobPostRepository;
        private IJobSeekerRepository _JobSeekerRepository;

        public ICompanyRepository CompanyRepository => _CompanyRepository ??= new CompanyRepository(_context);
        public IJobAppliedRepository JobAppliedRepository => _JobAppliedRepository ??= new JobAppliedRepository(_context);
        public IJobPostRepository JobPostRepository => _JobPostRepository ??= new JobPostRepository(_context);
        public IJobSeekerRepository JobSeekerRepository => _JobSeekerRepository ??= new JobSeekerRepository(_context);


        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

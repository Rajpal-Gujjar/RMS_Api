using RMSApi.Data.IRepository;

namespace RMSApi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IJobAppliedRepository JobAppliedRepository { get; }
        IJobPostRepository JobPostRepository { get; }
        IJobSeekerRepository JobSeekerRepository { get; }

        int Save();
    }
}

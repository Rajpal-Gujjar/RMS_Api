using RMSApi.Data.Models;

namespace RMSApi.Data.IRepository
{
    public interface IJobSeekerRepository
    {
        JobSeeker Get(int id);
        JobSeeker Get(string email, string password);
        IEnumerable<JobSeeker> GetAll();
        void Insert(JobSeeker entity);
        void Update(JobSeeker entity);
    }
}

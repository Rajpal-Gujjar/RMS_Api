using RMSApi.Data.Models;

namespace RMSApi.Data.IRepository
{
    public interface IJobAppliedRepository
    {
        JobApplied Get(int id);
        IEnumerable<JobApplied> GetAll();
        void Insert(JobApplied entity);
    }
}

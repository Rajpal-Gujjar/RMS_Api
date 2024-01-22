using RMSApi.Data.Models;

namespace RMSApi.Data.IRepository
{
    public interface IJobPostRepository
    {
        void Delete(JobPost entity);
        JobPost Get(int id);
        IEnumerable<JobPost> GetAll(int skip, int take,bool isPagination);
        IEnumerable<JobPost> GetAll(int skip, int take, bool isPagination, bool sort, string search);
        void Insert(JobPost entity);
        public void Update(JobPost entity);
    }
}

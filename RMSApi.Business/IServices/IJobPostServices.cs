using RMSApi.Common.DTO;

namespace RMSApi.Business.IServices
{
    public interface IJobPostServices
    {
        void Delete(int id);
        JobPostDTO Get(int id);
        IEnumerable<JobPostDTO> GetAll(int skip, int take, bool isPagination);
        IEnumerable<JobPostDTO> GetAllSearch(int skip, int take, bool isPagination,bool sort,string search);
        void Insert(JobPostDTO entity);
        void Update(int id, JobPostDTO entity);
    }
}

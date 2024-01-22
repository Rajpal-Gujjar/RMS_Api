using RMSApi.Common.DTO;

namespace RMSApi.Business.IServices
{
    public interface IJobSeekerServices
    {
        JobSeekerDTO Get(int id);
        JobSeekerDTO Get(string email, string password);
        IEnumerable<JobSeekerDTO> GetAll();
        void Insert(JobSeekerDTO entity);
        void Update(int id, JobSeekerDTO entity);
    }
}

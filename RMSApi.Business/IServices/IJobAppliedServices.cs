using RMSApi.Common.DTO;

namespace RMSApi.Business.IServices
{
    public interface IJobAppliedServices
    {
        JobAppliedDTO Get(int id);
        IEnumerable<JobAppliedDTO> GetAll();
        void Insert(JobAppliedDTO entity);
    }
}

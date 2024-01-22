using AutoMapper;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;
using RMSApi.Data;
using RMSApi.Data.Models;

namespace RMSApi.Business.Services
{
    public class JobAppliedServices : IJobAppliedServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobAppliedServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public JobAppliedDTO Get(int id)
        {
            return _mapper.Map<JobAppliedDTO>(_unitOfWork.JobAppliedRepository.Get(id));
        }

        public IEnumerable<JobAppliedDTO> GetAll()
        {
            return _mapper.Map<List<JobAppliedDTO>>(_unitOfWork.JobAppliedRepository.GetAll());
        }

        public void Insert(JobAppliedDTO entity)
        {
            _unitOfWork.JobAppliedRepository.Insert(_mapper.Map<JobApplied>(entity));
            _unitOfWork.Save();
        }
    }
}

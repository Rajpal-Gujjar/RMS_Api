using AutoMapper;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;
using RMSApi.Data;
using RMSApi.Data.Models;

namespace RMSApi.Business.Services
{
    public class JobSeekerServices : IJobSeekerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobSeekerServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public JobSeekerDTO Get(int id)
        {
            return _mapper.Map<JobSeekerDTO>(_unitOfWork.JobSeekerRepository.Get(id));
        }

        public JobSeekerDTO Get(string email, string password)
        {
            return _mapper.Map<JobSeekerDTO>(_unitOfWork.JobSeekerRepository.Get(email, password));
        }

        public IEnumerable<JobSeekerDTO> GetAll()
        {
            return _mapper.Map<List<JobSeekerDTO>>(_unitOfWork.JobSeekerRepository.GetAll());
        }

        public void Insert(JobSeekerDTO entity)
        {
            JobSeeker jobSeeker = _mapper.Map<JobSeeker>(entity);
            jobSeeker.CreatedDate= DateTime.Now;
            _unitOfWork.JobSeekerRepository.Insert(jobSeeker);
            _unitOfWork.Save();
        }

        public void Update(int id, JobSeekerDTO entity)
        {
            JobSeeker jobSeeker = _mapper.Map<JobSeeker>(entity);
            jobSeeker.Id = id;
            jobSeeker.ModifyDate = DateTime.Now;
            _unitOfWork.JobSeekerRepository.Update(jobSeeker);
            _unitOfWork.Save();
        }
    }
}

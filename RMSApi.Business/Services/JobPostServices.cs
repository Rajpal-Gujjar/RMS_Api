using AutoMapper;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;
using RMSApi.Data;
using RMSApi.Data.Models;

namespace RMSApi.Business.Services
{
    public class JobPostServices : IJobPostServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobPostServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            JobPost jobPost = _unitOfWork.JobPostRepository.Get(id);
            jobPost.Id = id;
            jobPost.IsDeleted = true;
            jobPost.DeletedDate = DateTime.Now;
            _unitOfWork.JobPostRepository.Delete(jobPost);
            _unitOfWork.Save();
        }

        public JobPostDTO Get(int id)
        {
            return _mapper.Map<JobPostDTO>(_unitOfWork.JobPostRepository.Get(id));
        }

        public IEnumerable<JobPostDTO> GetAll(int skip, int take, bool isPagination)
        {
            return _mapper.Map<List<JobPostDTO>>(_unitOfWork.JobPostRepository.GetAll(skip, take, isPagination));
        }

        public IEnumerable<JobPostDTO> GetAllSearch(int skip, int take, bool isPagination, bool sort, string search)
        {
            return _mapper.Map<List<JobPostDTO>>(_unitOfWork.JobPostRepository.GetAll(skip, take, isPagination, sort, search));
        }

        public void Insert(JobPostDTO entity)
        {
            _unitOfWork.JobPostRepository.Insert(_mapper.Map<JobPost>(entity));
            _unitOfWork.Save();
        }

        public void Update(int id, JobPostDTO entity)
        {
            JobPost jobPost = _mapper.Map<JobPost>(entity);
            jobPost.Id = id;
            jobPost.ModifyDate = DateTime.Now;
            _unitOfWork.JobPostRepository.Update(jobPost);
            _unitOfWork.Save();
        }
    }
}

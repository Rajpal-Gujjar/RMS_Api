using AutoMapper;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;
using RMSApi.Data;

namespace RMSApi.Business.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CompanyDTO Get(int id)
        {
            return _mapper.Map<CompanyDTO>(_unitOfWork.CompanyRepository.Get(id));
        }

        public IEnumerable<CompanyDTO> GetAll()
        {
            return _mapper.Map<List<CompanyDTO>>(_unitOfWork.CompanyRepository.GetAll());
        }
    }
}

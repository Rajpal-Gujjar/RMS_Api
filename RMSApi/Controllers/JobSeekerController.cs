using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;

namespace RMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobSeekerController : ControllerBase
    {
        private readonly IJobSeekerServices _jobSeekerServices;

        public JobSeekerController(IJobSeekerServices jobSeekerServices)
        {
            try
            {
                _jobSeekerServices = jobSeekerServices;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<JobSeekerDTO> Get()
        {
            try
            {
                return _jobSeekerServices.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public JobSeekerDTO Get(int id)
        {
            try
            {
                return _jobSeekerServices.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void Post(JobSeekerDTO value)
        {
            try
            {
                _jobSeekerServices.Insert(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, JobSeekerDTO value)
        {
            try
            {
                _jobSeekerServices.Update(id, value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

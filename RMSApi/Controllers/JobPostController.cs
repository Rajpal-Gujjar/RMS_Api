using Microsoft.AspNetCore.Mvc;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;

namespace RMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IJobPostServices _jobPostServices;

        public JobPostController(IJobPostServices jobPostServices)
        {
            try
            {
                _jobPostServices = jobPostServices;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<JobPostDTO> Get(int skip, int take, bool isPagination)
        {
            try
            {
                return _jobPostServices.GetAll(skip, take, isPagination);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("sort")]
        public IEnumerable<JobPostDTO> GetSearch(int skip, int take, bool isPagination,bool sort,string search)
        {
            try
            {
                return _jobPostServices.GetAllSearch(skip, take, isPagination, sort, search);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("PaginationWithId")]
        public Pagination GetPagination(int skip, int take, bool isPagination, int id)
        {
            return new Pagination
            {
                TotalCount = Get(0, 0, false).Where(x => x.CompanyId == id).Count(),
                JobPosts = Get(skip, take, isPagination).Where(x => x.CompanyId == id).ToList(),
            };
        }

        [HttpGet("PaginationWithCategory")]
        public Pagination GetAllPagination(int skip, int take, bool isPagination,string category)
        {
            return new Pagination
            {
                TotalCount = Get(0, 0, false).Where(x => x.Category == category).Count(),
                JobPosts = Get(skip, take, isPagination).Where(x => x.Category == category).ToList(),
            };
        }

        [HttpGet("search")]
        public Pagination GetSearching(int skip, int take, bool isPagination, bool sort, string search)
        {
            return new Pagination
            {
                TotalCount = Get(0, 0, false).Count(),
                JobPosts = GetSearch(skip, take, isPagination, sort, search).ToList(),
            };
        }

        [HttpGet("{id}")]
        public JobPostDTO Get(int id)
        {
            try
            {
                return _jobPostServices.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void Post(JobPostDTO value)
        {
            try
            {
                _jobPostServices.Insert(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, JobPostDTO value)
        {
            try
            {
                _jobPostServices.Update(id, value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _jobPostServices.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

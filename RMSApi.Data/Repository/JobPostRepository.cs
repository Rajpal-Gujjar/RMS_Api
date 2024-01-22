using Microsoft.EntityFrameworkCore;
using RMSApi.Data.Context;
using RMSApi.Data.IRepository;
using RMSApi.Data.Models;

namespace RMSApi.Data.Repository
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly RMSDbContext _context;

        public JobPostRepository(RMSDbContext context)
        {
            _context = context;
        }

        public void Delete(JobPost entity)
        {
            _context.JobPost.Update(entity);
        }

        public JobPost Get(int id)
        {
            return _context.JobPost.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<JobPost> GetAll(int skip, int take, bool isPagination)
        {
            if (isPagination)
            {
                return _context.JobPost.Include(x => x.Company).Where(x => x.IsDeleted == false).AsQueryable().Skip(skip).Take(take).ToList();
            }
            else
            {
                return _context.JobPost.Include(x => x.Company).Where(x => x.IsDeleted == false).ToList();
            }
        }

        public IEnumerable<JobPost> GetAll(int skip, int take, bool isPagination, bool sort, string search)
        {
            if (isPagination)
            {
                return _context.JobPost.Include(x => x.Company).Where(x => x.IsDeleted == false).AsQueryable().Skip(skip).Take(take).Where(x => /*x.CompanyId == int.Parse(search) || x.Experience == int.Parse(search) || */x.Category == search || x.Location == search|| x.Qualification.Contains(search)).ToList();
            }
            else
            {
                return _context.JobPost.Include(x => x.Company).Where(x => x.IsDeleted == false).OrderBy(x => x.Salary).AsQueryable().Skip(skip).Take(take).ToList();
            }
        }

        public void Insert(JobPost entity)
        {
            _context.JobPost.Add(entity);
        }

        public void Update(JobPost entity)
        {
            _context.JobPost.Update(entity);
        }
    }
}

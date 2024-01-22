using Microsoft.EntityFrameworkCore;
using RMSApi.Data.Context;
using RMSApi.Data.IRepository;
using RMSApi.Data.Models;

namespace RMSApi.Data.Repository
{
    public class JobAppliedRepository : IJobAppliedRepository
    {
        private readonly RMSDbContext _context;

        public JobAppliedRepository(RMSDbContext context)
        {
            _context = context;
        }

        public JobApplied Get(int id)
        {
            return _context.JobApplied.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<JobApplied> GetAll()
        {
            return _context.JobApplied.Include(x=>x.JobPost).ThenInclude(x=>x.Company).Include(x=>x.JobSeeker).ToList();
        }

        public void Insert(JobApplied entity)
        {
            _context.JobApplied.Add(entity);
        }
    }
}

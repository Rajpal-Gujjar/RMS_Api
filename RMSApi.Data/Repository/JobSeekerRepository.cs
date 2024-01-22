using RMSApi.Data.Context;
using RMSApi.Data.IRepository;
using RMSApi.Data.Models;

namespace RMSApi.Data.Repository
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        private readonly RMSDbContext _context;

        public JobSeekerRepository(RMSDbContext context)
        {
            _context = context;
        }

        public JobSeeker Get(int id)
        {
            return _context.JobSeeker.FirstOrDefault(x => x.Id == id);
        }

        public JobSeeker Get(string email, string password)
        {
            return _context.JobSeeker.FirstOrDefault(x =>x.Email==email && x.Password==password);
        }

        public IEnumerable<JobSeeker> GetAll()
        {
            return _context.JobSeeker.ToList();
        }

        public void Insert(JobSeeker entity)
        {
            _context.JobSeeker.Add(entity);
        }

        public void Update(JobSeeker entity)
        {
            _context.JobSeeker.Update(entity);
        }
    }
}
